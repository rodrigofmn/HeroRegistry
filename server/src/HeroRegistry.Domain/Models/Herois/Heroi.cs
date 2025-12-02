using System.ComponentModel.DataAnnotations;
using HeroRegistry.Domain.Models.HeroisSuperPoderes;
using HeroRegistry.Domain.Models.SuperPoderes;

namespace HeroRegistry.Domain.Models.Herois;

public class Heroi
{
    public int Id { get; set; }
    [MaxLength(120)]
    public string Nome { get; set; } = "";
    [MaxLength(120)]
    public string NomeHeroi { get; set; } = "";
    public DateTime? DataNascimento { get; set; }
    public List<HeroiSuperPoder> SuperPoderes { get; set;} = [];
    public float Altura { get; set; } = 0;
    public float Peso { get; set; } = 0;

    private Heroi() {}

    public Heroi(string name, string nomeHeroi, DateTime? dataNascimento, float altura, float peso)
    {
        Id = 0;
        Update(name, nomeHeroi, dataNascimento, altura, peso);
    }

    public void Update(string name, string nomeHeroi, DateTime? dataNascimento, float altura, float peso)
    {
        Nome = name;
        NomeHeroi = nomeHeroi;
        Altura = altura;
        Peso = peso;
        DataNascimento = dataNascimento;
    }
}