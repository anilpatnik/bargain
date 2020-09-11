using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Repositories.Interfaces;
using Bargain.Services.Common;
using Bargain.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Bargain.Services
{
    public class GenresService : IGenresService
    {
        private readonly IGenresRepository _genresRepository;
        private readonly ISaveRepository _unitOfWork;
        private readonly IMemoryCache _cache;
        private readonly ILogger<GenresService> _logger;

        public GenresService(
            IGenresRepository genresRepository
            , ISaveRepository unitOfWork
            , IMemoryCache cache
            , ILogger<GenresService> logger)
        {
            _genresRepository = genresRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<Genre>> ListAsync()
        {
            // Get the genres list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the genres from the repository.
            /*
            var genres = await _cache.GetOrCreateAsync(CacheKeys.GenresList, (entry) => 
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);

                return _genresRepository.ListAsync();
            });

            return genres;
            */

            return await _genresRepository.ListAsync();
        }

        public async Task<Response<Genre>> SaveAsync(Genre genre)
        {
            try
            {
                await _genresRepository.AddAsync(genre);

                await _unitOfWork.CompleteAsync();

                return new Response<Genre>(genre);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GenresService)} {nameof(SaveAsync)} {ex.Message}");

                return new Response<Genre>(ex.Message);
            }
        }

        public async Task<Response<Genre>> UpdateAsync(int id, Genre genre)
        {
            var existingGenre = await _genresRepository.FindByIdAsync(id);

            if (existingGenre == null)
            {
                return new Response<Genre>("Genre not found.");
            }

            existingGenre.Name = genre.Name;
            existingGenre.Desc = genre.Desc;

            try
            {
                _genresRepository.Update(existingGenre);

                await _unitOfWork.CompleteAsync();

                return new Response<Genre>(existingGenre);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GenresService)} {nameof(UpdateAsync)} {ex.Message}");

                return new Response<Genre>(ex.Message);                
            }
        }

        public async Task<Response<Genre>> DeleteAsync(int id)
        {
            var existingGenre = await _genresRepository.FindByIdAsync(id);

            if (existingGenre == null)
            {
                return new Response<Genre>("Genre not found.");
            }

            try
            {
                _genresRepository.Remove(existingGenre);

                await _unitOfWork.CompleteAsync();

                return new Response<Genre>(existingGenre);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GenresService)} {nameof(DeleteAsync)} {ex.Message}");

                return new Response<Genre>(ex.Message);
            }
        }
    }
}
