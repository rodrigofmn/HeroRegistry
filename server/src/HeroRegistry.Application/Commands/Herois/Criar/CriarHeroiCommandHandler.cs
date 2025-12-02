using HeroRegistry.Application.Commands.Herois.Criar;
using HeroRegistry.Domain.Models.Herois;
using MediatR;

namespace HeroRegistry.Application.Heroes.Commands.Criar;

public class CriarHeroiCommandHandler : IRequestHandler<CriarHeroiCommand, int>
{
    private readonly IHeroiRepositorio _repository;

    public CriarHeroiCommandHandler(IHeroiRepositorio repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CriarHeroiCommand request, CancellationToken cancellationToken)
    {
        var dto = request.CriarHeroiInputDto;

        var heroi = new Heroi(
            dto.Nome,
            dto.NomeHeroi,
            dto.DataNascimento,
            dto.Altura,
            dto.Peso
        );

        await _repository.AdicionarHeroiAsync(heroi);
        await _repository.SaveChangesAsync();

        return heroi.Id;
    }
}
