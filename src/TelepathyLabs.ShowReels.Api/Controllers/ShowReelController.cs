using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TelepathyLabs.ShowReels.Api.Dto;
using TelepathyLabs.ShowReels.Api.Handler.ShowReels;
using TelepathyLabs.ShowReels.Core;
using TelepathyLabs.ShowReels.Core.Log;

namespace TelepathyLabs.ShowReels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowReelController : ControllerBase
    {
        private readonly IShowReelCreateHandler _createHandler;
        private readonly IShowReelGetHandler _getHandler;
        private readonly ILoggerManager _logger;

        public ShowReelController(IShowReelCreateHandler createHandler, 
            IShowReelGetHandler getHandler, ILoggerManager logger)
        {
            _logger = logger;
            _getHandler = getHandler;
            _createHandler = createHandler;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ObjectResult Get()
        {
            try
            {
                var response = _getHandler.Handle();
                return new ObjectResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + "/n" + ex.StackTrace);
                var errorResponse = new ObjectResult("Something went wrong. Please try again shortly or contact administrator.");
                errorResponse.StatusCode = 500;
                return errorResponse;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ObjectResult Post(ShowReelRequestDto request)
        {
            try
            {
                var response = _createHandler.Handle(request);
                _logger.LogInfo("Showreel created successfully.");
                return new ObjectResult(response);
            }
            catch (ShowReelException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + "/n" + ex.StackTrace);
                var errorResponse = new ObjectResult("Something went wrong. Please try again shortly or contact administrator.");
                errorResponse.StatusCode = 500;
                return errorResponse;
            }
        }
    }
}
