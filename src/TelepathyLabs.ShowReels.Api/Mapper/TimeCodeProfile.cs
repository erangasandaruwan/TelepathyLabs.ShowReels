using AutoMapper;
using TelepathyLabs.ShowReels.Api.Dto;
using TelepathyLabs.ShowReels.Domain.Entity;

namespace TelepathyLabs.ShowReels.Api.Mapper
{
    public class TimeCodeProfile : Profile
    {
        public TimeCodeProfile()
        {
            CreateMap<TimeCodeRequestDto, TimeCode>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Hours, o => o.MapFrom(src => src.Hours))
                .ForMember(dest => dest.Minutes, o => o.MapFrom(src => src.Minutes))
                .ForMember(dest => dest.Seconds, o => o.MapFrom(src => src.Seconds))
                .ForMember(dest => dest.Frames, o => o.MapFrom(src => src.Frames))
                .ReverseMap();
        }
    }
}
