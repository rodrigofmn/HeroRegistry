namespace HeroRegistry.Domain.Models.Herois;

public interface IHeroiRepositorio
{
    Task<Heroi?> BuscarHeroiPorIdAsync(int id);
    Task<List<Heroi>> BuscarTodosHeroisAsync();
    Task AdicionarHeroiAsync(Heroi heroi);
    Task<int> AtualizarHeroiAsync(Heroi heroin, int heroiId);
    Task SaveChangesAsync();
    void Delete(Heroi heroi);
    Task<bool> ExisteNomeHeroiIgualAsync(string nomeHeroi, int heroiId);
}