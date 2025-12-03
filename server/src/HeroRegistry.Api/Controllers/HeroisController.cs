using AutoMapper;
using HeroRegistry.Application.Commands.Herois.Atualizar;
using HeroRegistry.Application.Commands.Herois.BuscaPaginada;
using HeroRegistry.Application.Commands.Herois.BuscarPorId;
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
[ApiExplorerSettings(GroupName = "v1")]
public class HeroisController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HeroisController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Busca todos os heróis do sistema com paginação.
    /// </summary>
    /// <remarks>
    /// Exemplo de requisição:
    ///
    ///     GET /api/herois?pagina=1&amp;tamanhoPagina=10
    ///
    /// </remarks>
    /// <param name="pagina">Número da página (padrão: 1).</param>
    /// <param name="tamanhoPagina">Quantidade por página (padrão: 10).</param>
    /// <returns>Lista paginada de heróis.</returns>
    /// <response code="200">Retorna a lista de heróis.</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<Heroi>), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarTodosHeroisPaginados(
        [FromQuery] int pagina = 1,
        [FromQuery] int tamanhoPagina = 10)
    {
        var command = new BuscarHeroisPaginadosCommand(pagina, tamanhoPagina);
        var heroes = await _mediator.Send(command);
        return Ok(heroes);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BuscarHeroiOutputDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarTodosHeroisPaginados(int id)
    {
        var command = new BuscarPorIdHeroiCommand(id);
        var heroes = await _mediator.Send(command);
        var result = _mapper.Map<BuscarHeroiOutputDto>(heroes);
        return Ok(result);
    }

    /// <summary>
    /// Cria um novo herói.
    /// </summary>
    /// <param name="heroiDto">Dados do herói.</param>
    /// <returns>ID do herói criado.</returns>
    /// <response code="201">Herói criado com sucesso.</response>
    /// <response code="400">Dados inválidos.</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CriarHeroi([FromBody] CriarHeroiInputDto heroiDto)
    {
        var heroi = _mapper.Map<Heroi>(heroiDto);

        try
        {
            var result = await _mediator.Send(new CriarHeroiCommand(heroi));
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Atualiza os dados de um herói existente.
    /// </summary>
    /// <param name="id">ID do herói.</param>
    /// <param name="heroiDto">Dados atualizados.</param>
    /// <returns>Herói atualizado.</returns>
    /// <response code="200">Herói atualizado.</response>
    /// <response code="400">ID inválido.</response>
    /// <response code="404">Herói não encontrado.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AtualizarHeroi(int id, [FromBody] AtualizarHeroiInputDto heroiDto)
    {
        if (id <= 0)
            return BadRequest("Id inválido");

        var heroi = _mapper.Map<Heroi>(heroiDto);

        try
        {
            var result = await _mediator.Send(new AtualizarHeroiCommand(id, heroi));
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Remove um herói do sistema.
    /// </summary>
    /// <param name="id">ID do herói.</param>
    /// <returns>ID removido.</returns>
    /// <response code="200">Herói removido com sucesso.</response>
    /// <response code="400">ID inválido.</response>
    /// <response code="404">Herói não encontrado.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoverHeroi(int id)
    {
        if (id <= 0)
            return BadRequest("Id inválido");

        var command = new RemoverHeroiCommand(id);
        await _mediator.Send(command);

        return Ok(id);
    }
}
