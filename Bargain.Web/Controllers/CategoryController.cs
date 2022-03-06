using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Services.Common;
using Bargain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bargain.Web.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _lookupService;

        public CategoryController(ICategoryService lookupService, ILogger<CategoryController> logger) : base(logger)
        {
            _lookupService = lookupService;
        }

        /// <summary>
        /// Lists all categories
        /// </summary>
        /// <returns>Categories</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Category>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(bool? inactive)
        {
            return Ok(await _lookupService.ListAsync(inactive));
        }

        /// <summary>
        /// Category by identifier
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>Response for the request</returns>
        [HttpGet(Constants.RouteParams.ID)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindByIdAsync(string id)
        {
            return Ok(await _lookupService.FindByIdAsync(id));
        }

        /// <summary>
        /// Saves a new category
        /// </summary>
        /// <param name="model">New category data</param>
        /// <returns>Response for the request</returns>
        [AuthorizeRoles(RoleType.DataAdmin)]
        [HttpPost]
        [ProducesResponseType(typeof(Category), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostAsync([FromBody] Category model)
        {
            return await GetResponse(() => _lookupService.SaveAsync(model));
        }

        /// <summary>
        /// Updates an existing category by identifier
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <param name="model">Updated category data</param>
        /// <returns>Response for the request</returns>
        [AuthorizeRoles(RoleType.DataAdmin)]
        [HttpPut(Constants.RouteParams.ID)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAsync(string id, [FromBody] Category model)
        {
            return await GetResponse(() => _lookupService.UpdateAsync(id, model));
        }

        /// <summary>
        /// Deletes category by identifier
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <param name="model">Updated category data</param>
        /// <returns>Response for the request</returns>
        [AuthorizeRoles(RoleType.DataAdmin)]
        [HttpDelete(Constants.RouteParams.ID)]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(string id, [FromBody] Category model)
        {
            return await GetResponse(() => _lookupService.UpdateAsync(id, model));
        }
    }
}
