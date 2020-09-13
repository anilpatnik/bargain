using Bargain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bargain.Repositories.Contexts
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Movie>()
                .HasOne(x => x.Genre)
                .WithMany()
                .HasForeignKey(x => x.GenreId);

            modelBuilder.Entity<Genre>().HasData 
            (
                new Genre { Id = 101, Name = "Action", Desc = "Action" }, // Id set manually due to in-memory provider
                new Genre { Id = 102, Name = "Adventure", Desc = "Adventure" },
                new Genre { Id = 103, Name = "Comedy", Desc = "Comedy" },
                new Genre { Id = 104, Name = "Crime", Desc = "Crime" },
                new Genre { Id = 105, Name = "Drama", Desc = "Drama" },
                new Genre { Id = 106, Name = "Fiction", Desc = "Fiction" },
                new Genre { Id = 107, Name = "Horror", Desc = "Horror" },
                new Genre { Id = 108, Name = "Romance", Desc = "Romance" },
                new Genre { Id = 109, Name = "Thriller", Desc = "Thriller" },
                new Genre { Id = 110, Name = "Animation", Desc = "Animation" }
            );

            modelBuilder.Entity<Movie>().HasData
            (
                new Movie { Id = 101, Name = "Avengers Endgame", Code = "TT4154796", Slug = "https://www.imdumb.com/title/tt4154796", GenreId = 101 }, // Id set manually due to in-memory provider
                new Movie { Id = 102, Name = "The Witcher", Code = "TT4154334", Slug = "https://www.imdumb.com/title/tt4154334", GenreId = 107 },
                new Movie { Id = 103, Name = "The Good Place", Code = "TT41456896", Slug = "https://www.imdumb.com/title/tt41456896", GenreId = 108 },
                new Movie { Id = 104, Name = "Friends", Code = "TT0108778", Slug = "https://www.imdumb.com/title/tt0108778", GenreId = 101 },
                new Movie { Id = 105, Name = "The Good Place", Code = "TT22244796", Slug = "https://www.imdumb.com/title/tt22244796", GenreId = 105 },
                new Movie { Id = 106, Name = "The Lion King", Code = "TT12455796", Slug = "https://www.imdumb.com/title/tt12455796", GenreId = 110 },
                new Movie { Id = 107, Name = "The Witcher", Code = "TT4176696", Slug = "https://www.imdumb.com/title/tt4176696", GenreId = 101 },
                new Movie { Id = 108, Name = "Avengers Endgame", Code = "TT9974596", Slug = "https://www.imdumb.com/title/tt9974596", GenreId = 102 },
                new Movie { Id = 109, Name = "The Witcher", Code = "TT6676096", Slug = "https://www.imdumb.com/title/tt6676096", GenreId = 107 },
                new Movie { Id = 110, Name = "The Outsider", Code = "TT40076596", Slug = "https://www.imdumb.com/title/tt40076596", GenreId = 104 }
            );
        }
    }
}
