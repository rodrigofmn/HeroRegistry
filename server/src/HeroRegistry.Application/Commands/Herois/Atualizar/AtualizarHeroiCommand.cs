using HeroRegistry.Application.Dtos.Herois;
using MediatR;

namespace HeroRegistry.Application.Commands.Herois.Atualizar;

public record AtualizarHeroiCommand(int Id, AtualizarHeroiInputDto AtualizarHeroiInputDto) : IRequest<int>;
