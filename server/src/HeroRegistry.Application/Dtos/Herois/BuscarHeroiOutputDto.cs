namespace HeroRegistry.Application.Dtos.Herois;

public class BuscarHeroiOutputDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string NomeHeroi { get; set; } = "";
    public DateTime? DataNascimento { get; set; }
    public List<int> SuperPoderesIds { get; set;} = [];
    public float Altura { get; set; } = 0;
    public float Peso { get; set; } = 0;
}