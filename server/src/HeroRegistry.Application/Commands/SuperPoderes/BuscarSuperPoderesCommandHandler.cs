using HeroRegistry.Domain.Models.Herois;
using HeroRegistry.Domain.Models.SuperPoderes;
using HeroRegistry.Domain.Models.SuperPoderesHeroi;
using MediatR;

namespace HeroRegistry.Application.Commands.SuperPoderes;

public class BuscarSuperPoderesCommandHandler : IRequestHandler<BuscarSuperPoderesCommand, List<Poder>>
{
    private readonly ISuperPoderRepositorio _repository;

    public BuscarSuperPoderesCommandHandler(ISuperPoderRepositorio repository)
    {
        _repository = repository;
    }

    public async Task<List<Poder>> Handle(BuscarSuperPoderesCommand request, CancellationToken cancellationToken)
    {

        return await _repository.BuscarTodosSuperPoderesAsync();
    }
}
