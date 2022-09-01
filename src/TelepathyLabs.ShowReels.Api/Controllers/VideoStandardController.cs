using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelepathyLabs.ShowReels.Api.Handler.VideoStandards;

namespace TelepathyLabs.ShowReels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoStandardController : ControllerBase
    {
        private readonly IVideoStandardGetHandler _getHandler;

        public VideoStandardController(IVideoStandardGetHandler getHandler)
        {
            _getHandler = getHandler;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ObjectResult Get()
        {
            var values = _getHandler.Handle();

            return new ObjectResult(values);
        }
    }
}
