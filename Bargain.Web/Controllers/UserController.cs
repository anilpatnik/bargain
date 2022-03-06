using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Services.Common;
using Bargain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bargain.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, ILogger<UserController> logger) : base(logger)
        {
            _userService = userService;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="model">User data</param>
        /// <returns>Response for the request</returns>
        [AllowAnonymous]
        [HttpPost(Constants.Routes.AUTHENTICATE)]
        [ProducesResponseType(typeof(Trade), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAuthUserAsync([FromBody] User model)
        {
            return await GetResponse(() => _userService.GetAuthUserAsync(model));
        }                
    }
}
