using AutoMapper;
using TelepathyLabs.ShowReels.Api.Dto;
using TelepathyLabs.ShowReels.Domain.Entity;

namespace TelepathyLabs.ShowReels.Api.Mapper
{
    public class VideoClipProfile : Profile
    {
        public VideoClipProfile()
        {
            CreateMap<VideoClipRequestDto, VideoClip>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, o => o.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, o => o.MapFrom(src => src.Description))
                .ForMember(dest => dest.VideoDefinition, o => o.MapFrom(src => src.VideoDefinition))
                .ForMember(dest => dest.VideoStandard, o => o.MapFrom(src => src.VideoStandard))
                .ForMember(dest => dest.StartTimeCode, o => o.MapFrom(src => src.StartTimeCode))
                .ForMember(dest => dest.EndTimeCode, o => o.MapFrom(src => src.EndTimeCode))
                .ReverseMap();
        }
    }
}
