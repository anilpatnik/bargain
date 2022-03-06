using Bargain.Services.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Bargain.Web.Controllers
{    
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ILogger _logger;

        public BaseController(ILogger logger)
        {            
            _logger = logger;
        }

        public async Task<IActionResult> GetResponse<T>(Func<Task<Response<T>>> func)
        {
            var response = await Task.Run(func);

            if (response.Success) return Ok(response.Resource);

            _logger.LogInformation(response.Message);

            return BadRequest(new Error(response.Message));
        }
    }
}
