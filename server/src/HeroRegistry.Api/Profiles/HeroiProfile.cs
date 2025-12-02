using AutoMapper;
using HeroRegistry.Application.Dtos.Herois;
using HeroRegistry.Domain.Models.Herois;

namespace HeroRegistry.Api.Profiles;

public class HeroiProfile : Profile
{
    public HeroiProfile()
    {
        CreateMap<CriarHeroiInputDto, Heroi>();
        CreateMap<AtualizarHeroiInputDto, Heroi>();
    }
}