using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Repositories.Interfaces;
using Bargain.Services.Common;
using Bargain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Bargain.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly ISaveRepository _unitOfWork;
        private readonly ILogger<MoviesService> _logger;

        public MoviesService(
            IMoviesRepository moviesRepository
            , ISaveRepository unitOfWork
            , ILogger<MoviesService> logger)
        {
            _moviesRepository = moviesRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<dynamic>> ListAsync()
        {
            return await _moviesRepository.ListAsync();
        }

        public async Task<Movie> GetAsync(int id)
        {
            return await _moviesRepository.GetAsync(id);
        }

        public async Task<Response<Movie>> SaveAsync(Movie movie)
        {
            try
            {
                await _moviesRepository.AddAsync(movie);

                await _unitOfWork.CompleteAsync();

                return new Response<Movie>(movie);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(MoviesService)} {nameof(SaveAsync)} {ex.Message}");

                return new Response<Movie>(ex.Message);
            }
        }

        public async Task<Response<Movie>> UpdateAsync(int id, Movie movie)
        {
            var existingMovie = await _moviesRepository.FindByIdAsync(id);

            if (existingMovie == null)
            {
                return new Response<Movie>("Movie not found.");
            }

            existingMovie.Name = movie.Name;
            existingMovie.Code = movie.Code;
            existingMovie.Slug = movie.Slug;
            existingMovie.GenreId = movie.GenreId;            

            try
            {
                _moviesRepository.Update(existingMovie);

                await _unitOfWork.CompleteAsync();

                return new Response<Movie>(existingMovie);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(MoviesService)} {nameof(UpdateAsync)} {ex.Message}");
                
                return new Response<Movie>(ex.Message);                
            }
        }

        public async Task<Response<Movie>> DeleteAsync(int id)
        {
            var existingMovie = await _moviesRepository.FindByIdAsync(id);

            if (existingMovie == null)
            {
                return new Response<Movie>("Movie not found.");
            }

            try
            {
                _moviesRepository.Remove(existingMovie);

                await _unitOfWork.CompleteAsync();

                return new Response<Movie>(existingMovie);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(MoviesService)} {nameof(DeleteAsync)} {ex.Message}");

                return new Response<Movie>(ex.Message);
            }
        }
    }
}
