using HeroRegistry.Domain.Models.Herois;
using MediatR;

namespace HeroRegistry.Application.Commands.Herois.BuscarPorId;

public record BuscarPorIdHeroiCommand(int Id) : IRequest<Heroi?>;