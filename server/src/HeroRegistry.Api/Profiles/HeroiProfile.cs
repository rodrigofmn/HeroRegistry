using AutoMapper;
using HeroRegistry.Application.Dtos.Herois;
using HeroRegistry.Domain.Models.Herois;
using HeroRegistry.Domain.Models.HeroisSuperPoderes;

namespace HeroRegistry.Api.Profiles;

public class HeroiProfile : Profile
{
    public HeroiProfile()
    {
        CreateMap<CriarHeroiInputDto, Heroi>()
            .ForMember(dest => dest.SuperPoderes,
                opt => opt.MapFrom(src =>
                    src.SuperPoderesIds.Select(id => new HeroiSuperPoder(0, id))
                )
            );

        CreateMap<AtualizarHeroiInputDto, Heroi>()
            .ForMember(dest => dest.SuperPoderes,
                opt => opt.MapFrom(src =>
                    src.SuperPoderesIds.Select(id => new HeroiSuperPoder(0, id))
                )
            );

            CreateMap<Heroi, BuscarHeroiOutputDto>()
                .ForMember(dest => dest.SuperPoderesIds,
                    opt => opt.MapFrom(src =>
                        src.SuperPoderes
                            .Where(hsp => hsp.SuperPoder != null)
                            .Select(hsp => hsp.SuperPoder!.Id)
                            .ToList()
                    )
                );
    }
}