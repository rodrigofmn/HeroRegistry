using HeroRegistry.Application.Commands.Herois.Atualizar;
using HeroRegistry.Application.Commands.Herois.BuscaPaginada;
using HeroRegistry.Application.Commands.Herois.Criar;
using HeroRegistry.Application.Commands.Herois.Remover;
using HeroRegistry.Application.Dtos.Herois;
using HeroRegistry.Domain.Models.Herois;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HeroRegistry.Api.Controllers;

/// <summary>
/// Controlador responsável pelo gerenciamento de heróis.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class HeroisController : ControllerBase
{
    private readonly IMediator _mediator;

    public HeroisController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Busca todos os heróis do sistema com suporte a paginação.
    /// </summary>
    /// <param name="pagina">Número da página a ser retornada. Padrão: 1.</param>
    /// <param name="tamanhoPagina">Quantidade de registros por página. Padrão: 10.</param>
    /// <returns>Retorna uma lista paginada de heróis.</returns>
    [HttpGet]
    public async Task<IActionResult> BuscarTodosHeroisPaginados([FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
    {
        var command = new BuscarHeroisPaginadosCommand(pagina, tamanhoPagina);

        var heroes = await _mediator.Send(command);
        return Ok(heroes);
    }

    /// <summary>
    /// Cria um novo herói no sistema.
    /// </summary>
    /// <param name="heroiDto">Dados necessários para a criação do herói.</param>
    /// <returns>Retorna o ID do herói criado.</returns>
    [HttpPost]
    public async Task<IActionResult> CriarHeroi(CriarHeroiInputDto heroiDto)
    {
        var command = new CriarHeroiCommand(heroiDto);

        var hero = await _mediator.Send(command);

        return Ok(hero);
    }

    /// <summary>
    /// Atualiza os dados de um herói existente.
    /// </summary>
    /// <param name="id">Identificador do herói.</param>
    /// <param name="heroiDto">Dados atualizados do herói.</param>
    /// <returns>Retorna o herói atualizado.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> CriarHeroi(int id, AtualizarHeroiInputDto heroiDto)
    {
        if (id == 0)
            return BadRequest("Id inválido");

        var command = new AtualizarHeroiCommand(id, heroiDto);

        var hero = await _mediator.Send(command);

        return Ok(hero);
    }

    /// <summary>
    /// Remove um herói do sistema.
    /// </summary>
    /// <param name="id">Identificador do herói a ser removido.</param>
    /// <returns>Retorna o ID do herói removido.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverHeroi(int id)
    {
        if (id == 0)
            return BadRequest("Id inválido");

        var command = new RemoverHeroiCommand(id);

        var hero = await _mediator.Send(command);

        return Ok(hero);
    }
    
}
