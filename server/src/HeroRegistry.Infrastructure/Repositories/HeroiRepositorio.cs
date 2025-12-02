using HeroRegistry.Application.Commands.Herois.BuscaPaginada;
using HeroRegistry.Domain.Models.Herois;
using Microsoft.EntityFrameworkCore;

namespace HeroRegistry.Infrastructure.Repositories;

public class HeroRepositorio(ApplicationDbContext context) : IHeroiRepositorio
{
    private readonly ApplicationDbContext _context = context;

    public Task<Heroi?> BuscarHeroiPorIdAsync(int id) =>
        _context.Herois.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);

    public async Task<List<Heroi>> BuscarTodosHeroisAsync(int pagina, int tamanhoPagina, CancellationToken cancellationToken) =>
        await _context.Herois.AsNoTracking().Include(h => h.SuperPoderes).Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToListAsync(cancellationToken);

    public async Task AdicionarHeroiAsync(Heroi hero) =>
        await _context.Herois.AddAsync(hero);

    public int AtualizarHeroiAsync(Heroi heroi)
    {
        _context.Herois.Update(heroi);
        return heroi.Id;
    }

    public void Delete(Heroi hero) =>
        _context.Herois.Remove(hero);

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();

    public async Task<bool> ExisteNomeHeroiIgualAsync(string nomeHeroi) =>
        await _context.Herois.AsNoTracking().Where(h => h.NomeHeroi == nomeHeroi).AnyAsync();
}
