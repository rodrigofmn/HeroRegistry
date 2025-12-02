using HeroRegistry.Domain.Models.SuperPoderes;

namespace HeroRegistry.Domain.Models.SuperPoderesHeroi;

public interface ISuperPoderRepositorio
{
    Task<List<Poder>> BuscarTodosSuperPoderesAsync();
    Task<Poder?> BuscarSuperPoderPorIdAsync(int id);
    Task AdicionarHeroiAsync(Poder poder);
    int AtualizarHeroiAsync(Poder poder);
    void Delete(Poder poder);
    Task SaveChangesAsync();
}