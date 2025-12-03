using System.ComponentModel.DataAnnotations;
using HeroRegistry.Domain.Models.HeroisSuperPoderes;

namespace HeroRegistry.Domain.Models.SuperPoderes;

public class Poder
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string SuperPoder { get; set; } = "";
    [MaxLength(250)]
    public string? Descricao { get; set; }
}
