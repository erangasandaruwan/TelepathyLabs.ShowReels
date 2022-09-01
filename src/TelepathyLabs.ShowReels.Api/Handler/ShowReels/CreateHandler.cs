using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelepathyLabs.ShowReels.Api.Dto;
using TelepathyLabs.ShowReels.Domain.Entity;
using TelepathyLabs.ShowReels.Domain.Service;

namespace TelepathyLabs.ShowReels.Api.Handler.ShowReels
{
    public interface IShowReelCreateHandler
    {
        Task<ShowReelRequestDto> Handle(ShowReelRequestDto showReel);
    }

    public class ShowReelCreateHandler : IShowReelCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IShowReelService _showReelService;

        public ShowReelCreateHandler(IShowReelService showReelService, IMapper mapper)
        {
            _mapper = mapper;
            _showReelService = showReelService;
        }

        public Task<ShowReelRequestDto> Handle(ShowReelRequestDto showReel)
        {
            var entity = _mapper.Map<ShowReel>(showReel);

            var result = _showReelService.Create(entity);

            var output = _mapper.Map<ShowReelRequestDto>(result);

            return Task.FromResult(output);
        }
    }
}
