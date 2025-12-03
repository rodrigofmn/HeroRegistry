using HeroRegistry.Domain.Models.Herois;
using MediatR;

namespace HeroRegistry.Application.Commands.Herois.BuscarPorId;

public class BuscarPorIdHeroiCommandHandler : IRequestHandler<BuscarPorIdHeroiCommand, Heroi?>
{
    private readonly IHeroiRepositorio _repository;

    public BuscarPorIdHeroiCommandHandler(IHeroiRepositorio repository)
    {
    _repository = repository;
    }

    public async Task<Heroi?> Handle(BuscarPorIdHeroiCommand request, CancellationToken cancellationToken)
    {
        return await _repository.BuscarHeroiPorIdAsync(request.Id);
    }
}
