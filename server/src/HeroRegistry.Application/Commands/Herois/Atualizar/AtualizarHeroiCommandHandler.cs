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
        if (await _repository.ExisteNomeHeroiIgualAsync(request.Heroi.NomeHeroi, request.Heroi.Id))
            throw new InvalidOperationException("Já existe um herói com esse nome.");

        await _repository.AtualizarHeroiAsync(request.Heroi);
        await _repository.SaveChangesAsync();

        return request.Heroi.Id;
    }
}
