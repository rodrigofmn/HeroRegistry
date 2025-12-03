using System.Linq;
using HeroRegistry.Application.Commands.Herois.BuscaPaginada;
using HeroRegistry.Domain.Models.Herois;
using HeroRegistry.Domain.Models.HeroisSuperPoderes;
using Microsoft.EntityFrameworkCore;

namespace HeroRegistry.Infrastructure.Repositories;

public class HeroRepositorio(ApplicationDbContext context) : IHeroiRepositorio
{
    private readonly ApplicationDbContext _context = context;

    public Task<Heroi?> BuscarHeroiPorIdAsync(int id) =>
        _context.Herois.AsNoTracking()
            .Include(h => h.SuperPoderes)
                .ThenInclude(s => s.SuperPoder)
                .FirstOrDefaultAsync(h => h.Id == id);

    public async Task<List<Heroi>> BuscarTodosHeroisAsync() =>
        await _context.Herois.AsNoTracking().Include(h => h.SuperPoderes).ToListAsync();

    public async Task AdicionarHeroiAsync(Heroi hero) =>
        await _context.Herois.AddAsync(hero);

    public async Task<int> AtualizarHeroiAsync(Heroi heroi, int heroiId)
    {
        var heroiExistente = await _context.Herois
            .Include(h => h.SuperPoderes)
            .FirstOrDefaultAsync(h => h.Id == heroiId) ?? throw new Exception("Herói não encontrado");

        heroiExistente.Nome = heroi.Nome;
        heroiExistente.NomeHeroi = heroi.NomeHeroi;
        heroiExistente.DataNascimento = heroi.DataNascimento;
        heroiExistente.Altura = heroi.Altura;
        heroiExistente.Peso = heroi.Peso;

        var idsAntigos = heroiExistente.SuperPoderes.Select(sp => sp.SuperPoderId).ToList();
        var idsNovos = heroi.SuperPoderes.Select(sp => sp.SuperPoderId).ToList();

        var idsParaRemover = idsAntigos.Except(idsNovos).ToList();
        var idsParaAdicionar = idsNovos.Except(idsAntigos).ToList();

        heroiExistente.SuperPoderes.RemoveAll(sp => idsParaRemover.Contains(sp.SuperPoderId));
        heroiExistente.SuperPoderes.AddRange(idsParaAdicionar.Select(spId => new HeroiSuperPoder(heroiExistente.Id, spId)));

        await _context.SaveChangesAsync();

        return heroiExistente.Id;
    }

    public void Delete(Heroi hero) =>
        _context.Herois.Remove(hero);

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();

    public async Task<bool> ExisteNomeHeroiIgualAsync(string nomeHeroi, int heroiId) =>
        await _context.Herois.AsNoTracking().Where(h => h.NomeHeroi == nomeHeroi && h.Id != heroiId).AnyAsync();
}
