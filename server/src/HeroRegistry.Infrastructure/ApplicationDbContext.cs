using HeroRegistry.Domain.Models.Herois;
using HeroRegistry.Domain.Models.HeroisSuperPoderes;
using HeroRegistry.Domain.Models.SuperPoderes;
using Microsoft.EntityFrameworkCore;

namespace HeroRegistry.Infrastructure;

public class ApplicationDbContext : DbContext 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HeroiSuperPoder>()
            .HasKey(x => new { x.HeroiId, x.SuperPoderId });

        modelBuilder.Entity<Poder>().HasData(
            new Poder { Id = 1, SuperPoder = "Super Força", Descricao = "Capacidade de exercer força além dos limites humanos." },
            new Poder { Id = 2, SuperPoder = "Voo", Descricao = "Permite ao herói voar a grandes altitudes e velocidades." },
            new Poder { Id = 3, SuperPoder = "Velocidade Sobrenatural", Descricao = "Movimenta-se em velocidades extremamente altas." },
            new Poder { Id = 4, SuperPoder = "Invulnerabilidade", Descricao = "Resistência extrema a danos físicos." },
            new Poder { Id = 5, SuperPoder = "Telecinese", Descricao = "Capacidade de mover objetos com a mente." },
            new Poder { Id = 6, SuperPoder = "Invisibilidade", Descricao = "Fica completamente invisível ao olho humano." },
            new Poder { Id = 7, SuperPoder = "Regeneração", Descricao = "Consegue se curar rapidamente de ferimentos." },
            new Poder { Id = 8, SuperPoder = "Controle de Elementos", Descricao = "Manipula elementos naturais como fogo, água, ar e terra." },
            new Poder { Id = 9, SuperPoder = "Visão de Raios-X", Descricao = "Permite enxergar através de objetos." },
            new Poder { Id = 10, SuperPoder = "Manipulação de Energia", Descricao = "Cria, controla e absorve diversos tipos de energia." }
        );
    
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Heroi> Herois => Set<Heroi>();
    public DbSet<Poder> SuperPoderes => Set<Poder>();
    public DbSet<HeroiSuperPoder> HeroisSuperpoderes => Set<HeroiSuperPoder>();
}