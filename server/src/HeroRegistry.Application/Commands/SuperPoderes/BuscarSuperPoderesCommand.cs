using HeroRegistry.Domain.Models.SuperPoderes;
using MediatR;

namespace HeroRegistry.Application.Commands.SuperPoderes;

public record BuscarSuperPoderesCommand() : IRequest<List<Poder>>;