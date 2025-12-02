using HeroRegistry.Domain.Models.HeroisSuperPoderes;

namespace HeroRegistry.Application.Dtos.Herois;

public class AtualizarHeroiInputDto
{
    public string Nome { get; set; } = "";
    public string NomeHeroi { get; set; } = "";
    public DateTime? DataNascimento { get; set; }
    public List<HeroiSuperPoder> SuperPoderes { get; set;} = [];
    public float Altura { get; set; } = 0;
    public float Peso { get; set; } = 0;
}