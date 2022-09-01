using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelepathyLabs.ShowReels.Api.Dto;
using TelepathyLabs.ShowReels.Domain.Service;

namespace TelepathyLabs.ShowReels.Api.Handler.ShowReels
{
    public interface IShowReelGetHandler
    {
        IEnumerable<ShowReelRequestDto> Handle();
    }

    public class ShowReelGetHandler : IShowReelGetHandler
    {
        private readonly IMapper _mapper;
        private readonly IShowReelService _showReelService;

        public ShowReelGetHandler(IShowReelService showReelService, IMapper mapper)
        {
            _mapper = mapper;
            _showReelService = showReelService;
        }


        public IEnumerable<ShowReelRequestDto> Handle()
        {
            var results = _showReelService.GetAll();

            var output = _mapper.Map<List<ShowReelRequestDto>>(results);

            return output;
        }
    }
}
