using HeroRegistry.Application.Commands.Herois.BuscaPaginada;
using HeroRegistry.Domain.Models.Herois;
using HeroRegistry.Domain.Models.SuperPoderes;
using HeroRegistry.Domain.Models.SuperPoderesHeroi;
using Microsoft.EntityFrameworkCore;

namespace HeroRegistry.Infrastructure.Repositories;

public class SuperPoderRepositorio(ApplicationDbContext context) : ISuperPoderRepositorio
{
    private readonly ApplicationDbContext _context = context;

    public Task<Poder?> BuscarSuperPoderPorIdAsync(int id) =>
        _context.SuperPoderes.FirstOrDefaultAsync(h => h.Id == id);

    public async Task<List<Poder>> BuscarTodosSuperPoderesAsync() =>
        await _context.SuperPoderes.ToListAsync();

    public async Task AdicionarHeroiAsync(Poder poder) =>
        await _context.SuperPoderes.AddAsync(poder);

    public int AtualizarHeroiAsync(Poder poder)
    {
        _context.SuperPoderes.Update(poder);
        return poder.Id;
    }

    public void Delete(Poder poder) =>
        _context.SuperPoderes.Remove(poder);

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
