using HeroRegistry.Application.Commands.Herois.BuscaPaginada;
using HeroRegistry.Domain.Models.Herois;
using MediatR;

namespace HeroRegistry.Application.Heroes.Commands.BuscaPaginada;

public class BuscarHeroisPaginadosCommandHandler : IRequestHandler<BuscarHeroisPaginadosCommand, List<Heroi>>
{
    private readonly IHeroiRepositorio _repository;

    public BuscarHeroisPaginadosCommandHandler(IHeroiRepositorio repository)
    {
        _repository = repository;
    }

    public async Task<List<Heroi>> Handle(BuscarHeroisPaginadosCommand request, CancellationToken cancellationToken)
    {

        return await _repository.BuscarTodosHeroisAsync();
    }
}
