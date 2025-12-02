using MediatR;

namespace HeroRegistry.Application.Commands.Herois.Remover;

public record RemoverHeroiCommand(int Id) : IRequest<Unit>;
