using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Services.Common;
using Bargain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bargain.Web.Controllers
{    
    public class TradeController : BaseController
    {
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService, ILogger<TradeController> logger) : base(logger)
        {
            _tradeService = tradeService;
        }

        /// <summary>
        /// List of trades belong to merchant user
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Trades</returns>
        [AuthorizeRoles(RoleType.Merchant, RoleType.SiteAdmin, RoleType.DataAdmin)]
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]        
        public async Task<IActionResult> ListAsync(int id)
        {            
            return Ok(await _tradeService.ListAsync(id));
        }

        /// <summary>
        /// Trade by trade identifier
        /// </summary>
        /// <param name="id">Trade Id</param>
        /// <returns>Response for the request</returns>
        [AuthorizeRoles(RoleType.Merchant)]
        [HttpGet(Constants.RouteParams.ID)]
        [ProducesResponseType(typeof(Trade), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            return Ok(await _tradeService.FindByIdAsync(id));
        }

        /// <summary>
        /// Saves a trade
        /// </summary>
        /// <param name="model">New trade data</param>
        /// <returns>Response for the request</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Trade), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostAsync([FromBody] Trade model)
        {
            return await GetResponse(() => _tradeService.SaveAsync(model));
        }

        /// <summary>
        /// Updates an existing trade by identifier
        /// </summary>
        /// <param name="id">Trade Id</param>
        /// <param name="model">Updated trade data</param>
        /// <returns>Response for the request</returns>
        [HttpPut(Constants.RouteParams.ID)]
        [ProducesResponseType(typeof(Trade), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Trade model)
        {
            return await GetResponse(() => _tradeService.UpdateAsync(id, model));
        }

        /// <summary>
        /// Deletes trade by identifier
        /// </summary>
        /// <param name="id">Trade Id</param>
        /// <returns>Response for the request</returns>
        [HttpDelete(Constants.RouteParams.ID)]
        [ProducesResponseType(typeof(Trade), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await GetResponse(() => _tradeService.DeleteAsync(id));
        }
    }
}
