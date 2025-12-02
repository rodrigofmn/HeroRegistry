using HeroRegistry.Application.Commands.Herois.Atualizar;
using HeroRegistry.Application.Commands.Herois.Criar;
using HeroRegistry.Application.Dtos.Herois;
using HeroRegistry.Domain.Models.Herois;
using MediatR;

namespace HeroRegistry.Application.Heroes.Commands.Atualizar;

public class AtualizarHeroiCommandHandler : IRequestHandler<AtualizarHeroiCommand, int>
{
    private readonly IHeroiRepositorio _repository;

    public AtualizarHeroiCommandHandler(IHeroiRepositorio repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(AtualizarHeroiCommand request, CancellationToken cancellationToken)
    {
        var dto = request.AtualizarHeroiInputDto;

        var heroi = new Heroi(
            dto.Nome,
            dto.NomeHeroi,
            dto.DataNascimento,
            dto.Altura,
            dto.Peso
        );

        _repository.AtualizarHeroiAsync(heroi);
        await _repository.SaveChangesAsync();

        return heroi.Id;
    }
}
