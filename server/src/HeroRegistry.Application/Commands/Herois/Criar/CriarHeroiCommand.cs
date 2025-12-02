using HeroRegistry.Application.Dtos.Herois;
using MediatR;

namespace HeroRegistry.Application.Commands.Herois.Criar;

public record CriarHeroiCommand(CriarHeroiInputDto CriarHeroiInputDto) : IRequest<int>;
