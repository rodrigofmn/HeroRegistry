using HeroRegistry.Application.Dtos.Herois;
using HeroRegistry.Domain.Models.Herois;
using MediatR;

namespace HeroRegistry.Application.Commands.Herois.BuscaPaginada;

public record BuscarHeroisPaginadosCommand(int Pagina, int TamanhoPagina) : IRequest<List<Heroi>>;
