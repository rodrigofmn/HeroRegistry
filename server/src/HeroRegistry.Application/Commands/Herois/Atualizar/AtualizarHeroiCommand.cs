using HeroRegistry.Application.Dtos.Herois;
using HeroRegistry.Domain.Models.Herois;
using MediatR;

namespace HeroRegistry.Application.Commands.Herois.Atualizar;

public record AtualizarHeroiCommand(int Id, Heroi Heroi) : IRequest<int>;
