using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using HeroRegistry.Application.Commands.Herois.Atualizar;
using HeroRegistry.Application.Commands.Herois.BuscaPaginada;
using HeroRegistry.Application.Commands.Herois.BuscarPorId;
using HeroRegistry.Application.Commands.Herois.Criar;
using HeroRegistry.Application.Commands.Herois.Remover;
using HeroRegistry.Application.Dtos.Herois;
using HeroRegistry.Domain.Models.Herois;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;
using HeroRegistry.Api.Controllers;

namespace HeroRegistry.Tests.Controllers
{
    public class HeroisControllerTests
    {
        private readonly IMediator _mediatorMock;
        private readonly IMapper _mapperMock;
        private readonly HeroisController _controller;

        public HeroisControllerTests()
        {
            _mediatorMock = Substitute.For<IMediator>();
            _mapperMock = Substitute.For<IMapper>();
            _controller = new HeroisController(_mediatorMock, _mapperMock);
        }

        [Fact]
        public async Task BuscarTodosHeroisPaginados_ShouldReturnOk_WithListOfHeroes()
        {
            var heroes = new List<Heroi>
            {
                new Heroi("Nome1","Heroi1",DateTime.Now.AddYears(-20),1.8f,70),
                new Heroi("Nome2","Heroi2",DateTime.Now.AddYears(-25),1.75f,65)
            };

            _mediatorMock.Send(Arg.Any<BuscarHeroisPaginadosCommand>(), Arg.Any<CancellationToken>())
                         .Returns(Task.FromResult(heroes));

            var result = await _controller.BuscarTodosHeroisPaginados();

            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(heroes);
        }

        [Fact]
        public async Task BuscarHeroiPorId_ShouldReturnOk_WithMappedHero()
        {
            var heroi = new Heroi("Nome1","Heroi1",DateTime.Now.AddYears(-20),1.8f,70);
            var outputDto = new BuscarHeroiOutputDto { NomeHeroi = "Heroi1" };

            _mediatorMock.Send(Arg.Any<BuscarPorIdHeroiCommand>(), Arg.Any<CancellationToken>())
                         .Returns(Task.FromResult<Heroi?>(heroi));
            _mapperMock.Map<BuscarHeroiOutputDto>(heroi).Returns(outputDto);

            var result = await _controller.BuscarTodosHeroisPaginados(1);

            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().BeEquivalentTo(outputDto);
        }

        [Fact]
        public async Task AtualizarHeroi_ShouldReturnBadRequest_WhenIdIsInvalid()
        {
            var result = await _controller.AtualizarHeroi(0, new AtualizarHeroiInputDto());
            var badRequestResult = result as BadRequestObjectResult;
            badRequestResult.Should().NotBeNull();
            badRequestResult!.Value.Should().Be("Id inválido");
        }

        [Fact]
        public async Task AtualizarHeroi_ShouldReturnOk_WhenHeroIsValid()
        {
            var id = 1;
            var dto = new AtualizarHeroiInputDto { NomeHeroi = "HeroiAtualizado" };
            var heroi = new Heroi("Nome", "HeroiAtualizado", DateTime.Now.AddYears(-20), 1.8f, 70);

            _mapperMock.Map<Heroi>(dto).Returns(heroi);
            _mediatorMock.Send(Arg.Any<AtualizarHeroiCommand>(), Arg.Any<CancellationToken>())
                         .Returns(Task.FromResult(id));

            var result = await _controller.AtualizarHeroi(id, dto);

            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().Be(id);
        }

        [Fact]
        public async Task AtualizarHeroi_ShouldReturnBadRequest_WhenMediatorThrowsException()
        {
            var id = 1;
            var dto = new AtualizarHeroiInputDto { NomeHeroi = "HeroiAtualizado" };
            var heroi = new Heroi("Nome", "HeroiAtualizado", DateTime.Now.AddYears(-20), 1.8f, 70);

            _mapperMock.Map<Heroi>(dto).Returns(heroi);
            _mediatorMock.Send(Arg.Any<AtualizarHeroiCommand>(), Arg.Any<CancellationToken>())
                         .Returns<Task<int>>(x => throw new InvalidOperationException("Erro ao atualizar"));

            var result = await _controller.AtualizarHeroi(id, dto);

            var badRequestResult = result as BadRequestObjectResult;
            badRequestResult.Should().NotBeNull();
            badRequestResult!.Value.Should().Be("Erro ao atualizar");
        }

        [Fact]
        public async Task RemoverHeroi_ShouldReturnBadRequest_WhenIdIsInvalid()
        {
            var result = await _controller.RemoverHeroi(0);
            var badRequestResult = result as BadRequestObjectResult;
            badRequestResult.Should().NotBeNull();
            badRequestResult!.Value.Should().Be("Id inválido");
        }

        [Fact]
        public async Task RemoverHeroi_ShouldReturnOk_WhenIdIsValid()
        {
            var id = 1;
            _mediatorMock.Send(Arg.Any<RemoverHeroiCommand>(), Arg.Any<CancellationToken>())
                         .Returns(Task.FromResult(Unit.Value));

            var result = await _controller.RemoverHeroi(id);

            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.Value.Should().Be(id);
        }
    }
}
