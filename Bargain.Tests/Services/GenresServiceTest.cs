using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Repositories.Interfaces;
using Bargain.Services;
using Bargain.Services.Interfaces;
using Bargain.Tests.Helpers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bargain.Tests.Services
{
    [TestClass]
    public class GenresServiceTest
    {
        // private DbContextOptionsBuilder _builder;
        // private AppDbContext _context;
        
        private Mock<IGenresRepository> _genresRepository;
        private Mock<ISaveRepository> _unitOfWork;
        private Mock<IMemoryCache> _cache;
        private Mock<AbstractLogger<GenresService>> _logger;
        private IGenresService _genresService;
        
        [TestInitialize]
        public void Initialize()              
        {
            // _builder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            // _context = new AppDbContext(_builder.Options);

            _genresRepository = new Mock<IGenresRepository>();
            _unitOfWork = new Mock<ISaveRepository>();
            _cache = new Mock<IMemoryCache>();
            _logger = new Mock<AbstractLogger<GenresService>>();
            _genresService = new GenresService(
                _genresRepository.Object
                , _unitOfWork.Object
                , _cache.Object
                , _logger.Object);
        }
        
        [TestMethod]
        public async Task ListAsync_Verify()
        {
            // Arrange
            var genres = new List<Genre>
            {
                new Genre { Id = 101, Name = "Action", Desc = "Action" },
                new Genre { Id = 102, Name = "Adventure", Desc = "Adventure" }
            };
            _genresRepository.Setup(x => x.ListAsync()).ReturnsAsync(genres).Verifiable();

            // Act
            var result = await _genresService.ListAsync();
            
            // Assert
            Assert.AreEqual(2, result.Count());
        }
        
        [TestMethod]
        public async Task SaveAsync_Verify()
        {
            // Arrange
            var genre = new Genre { Id = 105, Name = "Drama", Desc = "Drama" };
            _genresRepository.Setup(x => x.AddAsync(genre)).Verifiable();
            _unitOfWork.Setup(x => x.CompleteAsync()).Verifiable();

            // Act
            var result = await _genresService.SaveAsync(genre);
            
            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(genre.Id, result.Resource.Id);
            Assert.AreEqual(genre.Name, result.Resource.Name);
            Assert.AreEqual(genre.Desc, result.Resource.Desc);
        }
        
        [TestMethod]
        public async Task SaveAsync_Error()
        {
            // Arrange
            var genre = new Genre { Id = 105, Name = "Drama", Desc = "Drama" };
            _genresRepository.Setup(x => x.AddAsync(genre)).Verifiable();
            _unitOfWork.Setup(x => x.CompleteAsync()).Throws(new InvalidOperationException()).Verifiable();

            // Act
            await _genresService.SaveAsync(genre);
            
            // Assert
            _logger.Verify(x => x.Log(LogLevel.Error, It.IsAny<Exception>(),
                "GenresService SaveAsync Operation is not valid due to the current state of the object."), Times.Once);
        }
    }
}