using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelepathyLabs.ShowReels.Api.Handler.VideoDefinitions;
using TelepathyLabs.ShowReels.Core.Log;

namespace TelepathyLabs.ShowReels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoDefinitionController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IVideoDefinitionGetHandler _getHandler;

        public VideoDefinitionController(IVideoDefinitionGetHandler getHandler, ILoggerManager logger)
        {
            _logger = logger;
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
