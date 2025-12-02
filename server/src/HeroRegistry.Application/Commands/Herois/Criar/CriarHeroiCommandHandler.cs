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
        if (await _repository.ExisteNomeHeroiIgualAsync(request.Heroi.NomeHeroi))
            throw new InvalidOperationException("Já existe um herói com esse nome.");

        await _repository.AdicionarHeroiAsync(request.Heroi);
        await _repository.SaveChangesAsync();

        return request.Heroi.Id;
    }
}
