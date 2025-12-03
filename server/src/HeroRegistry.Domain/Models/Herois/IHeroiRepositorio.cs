namespace HeroRegistry.Domain.Models.Herois;

public interface IHeroiRepositorio
{
    Task<Heroi?> BuscarHeroiPorIdAsync(int id);
    Task<List<Heroi>> BuscarTodosHeroisAsync(int pagina, int tamanhoPagina, CancellationToken cancellationToken);
    Task AdicionarHeroiAsync(Heroi heroi);
    Task<int> AtualizarHeroiAsync(Heroi heroi);
    Task SaveChangesAsync();
    void Delete(Heroi heroi);
    Task<bool> ExisteNomeHeroiIgualAsync(string nomeHeroi, int heroiId);
}