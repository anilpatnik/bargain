using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Repositories.Interfaces;
using Bargain.Services.Common;
using Bargain.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Bargain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISaveRepository _unitOfWork;
        private readonly IMemoryCache _cache;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(
            ICategoryRepository categoryRepository, 
            ISaveRepository unitOfWork, 
            IMemoryCache cache, 
            ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<Category>> ListAsync(bool? inactive)
        {
            // Get the Search Engines list from the memory cache.
            // If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire 12 hours ahead and
            // returning the Task that lists the Search Engines from the repository.
            var payload = await _cache.GetOrCreateAsync(CacheKeys.SearchEngines, (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(12);

                return _categoryRepository.ListAsync();
            });

            return inactive.HasValue ? payload.Where(x => x.Inactive == inactive) : payload;
        }

        public async Task<Response<Category>> FindByIdAsync(string id)
        {
            var payload = await _categoryRepository.FindByIdAsync(id);

            return payload == null ? 
                new Response<Category>("Category not found.") : 
                new Response<Category>(payload);
        }

        public async Task<Response<Category>> SaveAsync(Category payload)
        {
            try
            {
                var category = new Category { Name = payload.Name, CreatedBy = payload.CreatedBy };

                _categoryRepository.Add(category);

                await _unitOfWork.CompleteAsync();

                return new Response<Category>(category);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(CategoryService)} {nameof(SaveAsync)} {ex.Message}");

                return new Response<Category>(ex.Message);
            }
        }

        public async Task<Response<Category>> UpdateAsync(string id, Category payload)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
            {
                return new Response<Category>("Category not found.");
            }

            existingCategory.RecordId = payload.RecordId;
            existingCategory.Name = payload.Name;
            existingCategory.Inactive = payload.Inactive;
            existingCategory.UpdatedBy = payload.UpdatedBy;

            try
            {
                _categoryRepository.Update(existingCategory);

                await _unitOfWork.CompleteAsync();

                return new Response<Category>(existingCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(CategoryService)} {nameof(UpdateAsync)} {ex.Message}");

                return new Response<Category>(ex.Message);                
            }
        }
    }
}
