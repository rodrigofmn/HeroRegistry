namespace HeroRegistry.Application.Dtos.Herois;

public class CriarHeroiInputDto
{
    public string Nome { get; set; } = "";
    public string NomeHeroi { get; set; } = "";
    public DateTime? DataNascimento { get; set; }
    public float Altura { get; set; }
    public float Peso { get; set; }
}