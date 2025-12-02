using HeroRegistry.Application.Commands.SuperPoderes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HeroRegistry.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuperPoderesController : ControllerBase
{
    private readonly IMediator _mediator;

    public SuperPoderesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> BuscarTodosSuperPoderes()
    {
        var poderes = await _mediator.Send(new BuscarSuperPoderesCommand());
        return Ok(poderes);
    }
}

