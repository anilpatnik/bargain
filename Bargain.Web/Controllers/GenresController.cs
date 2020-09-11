using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Services.Common;
using Bargain.Services.Interfaces;
using Bargain.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bargain.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class GenresController : BaseController
    {
        private readonly IGenresService _genresService;
        private readonly ILogger<GenresController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="genresService"></param>
        /// <param name="logger"></param>
        public GenresController(
            IGenresService genresService
            , ILogger<GenresController> logger)
        {
            _genresService = genresService;
            _logger = logger;
        }
        
        private async Task<IActionResult> GetResponse(Func<Task<Response<Genre>>> func)
        {
            var response = await Task.Run(func);

            if (response.Success) return Ok(response.Resource);
            
            _logger.LogInformation(response.Message);
                
            return BadRequest(new Error(response.Message));
        }

        /// <summary>
        /// Lists all genre.
        /// </summary>
        /// <returns>List genre.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Genre>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _genresService.ListAsync());
        }

        /// <summary>
        /// Saves a new genre.
        /// </summary>
        /// <param name="model">Genre data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostAsync([FromBody] Genre model)
        {
            return await GetResponse(() => _genresService.SaveAsync(model));
        }

        /// <summary>
        /// Updates an existing genre according to an identifier.
        /// </summary>
        /// <param name="id">Genre identifier.</param>
        /// <param name="model">Updated genre data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Genre model)
        {
            return await GetResponse(() => _genresService.UpdateAsync(id, model));
        }

        /// <summary>
        /// Deletes a given genre according to an identifier.
        /// </summary>
        /// <param name="id">Genre identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await GetResponse(() => _genresService.DeleteAsync(id));
        }
    }
}
