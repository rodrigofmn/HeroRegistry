using HeroRegistry.Application.Dtos.Herois;
using HeroRegistry.Domain.Models.Herois;
using MediatR;

namespace HeroRegistry.Application.Commands.Herois.Criar;

public record CriarHeroiCommand(Heroi Heroi) : IRequest<int>;
