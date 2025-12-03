using HeroRegistry.Application.Commands.Herois.Remover;
using HeroRegistry.Application.Commands.Herois.Criar;
using HeroRegistry.Domain.Models.Herois;
using MediatR;

namespace HeroRegistry.Application.Heroes.Commands.Herois.Remover;

public class RemoverHeroiCommandHandler : IRequestHandler<RemoverHeroiCommand, Unit>
{
    private readonly IHeroiRepositorio _repository;

    public RemoverHeroiCommandHandler(IHeroiRepositorio repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RemoverHeroiCommand request, CancellationToken cancellationToken)
    {
        var hero = await _repository.BuscarHeroiPorIdAsync(request.Id)
                   ?? throw new InvalidOperationException("Heroi não encontrado");

        _repository.Delete(hero);
        await _repository.SaveChangesAsync();

        return Unit.Value;
    }
}
