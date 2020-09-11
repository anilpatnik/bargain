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
    public class MoviesController : BaseController
    {
        private readonly IMoviesService _moviesService;
        private readonly ILogger<MoviesController> _logger;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="moviesService"></param>
        /// <param name="logger"></param>
        public MoviesController(
            IMoviesService moviesService
            , ILogger<MoviesController> logger)
        {
            _moviesService = moviesService;
            _logger = logger;         
        }
        
        private async Task<IActionResult> GetResponse(Func<Task<Response<Movie>>> func)
        {
            var response = await Task.Run(func);

            if (response.Success) return Ok(response.Resource);
            
            _logger.LogInformation(response.Message);
                
            return BadRequest(new Error(response.Message));
        }

        /// <summary>
        /// Lists all movie.
        /// </summary>
        /// <returns>List movie.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Movie>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _moviesService.ListAsync());
        }

        /// <summary>
        /// Get movie for a given identifier.
        /// </summary>
        /// <param name="id">Movie identifier.</param>
        /// <returns>Get movie.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _moviesService.GetAsync(id));
        }

        /// <summary>
        /// Saves a new movie.
        /// </summary>
        /// <param name="model">Movie data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostAsync([FromBody] Movie model)
        {
            return await GetResponse(() => _moviesService.SaveAsync(model));
        }

        /// <summary>
        /// Updates an existing movie according to an identifier.
        /// </summary>
        /// <param name="id">Movie identifier.</param>
        /// <param name="model">Updated movie data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Movie model)
        {
            return await GetResponse(() => _moviesService.UpdateAsync(id, model));
        }

        /// <summary>
        /// Deletes a given movie according to an identifier.
        /// </summary>
        /// <param name="id">Movie identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await GetResponse(() => _moviesService.DeleteAsync(id));
        }
    }
}
