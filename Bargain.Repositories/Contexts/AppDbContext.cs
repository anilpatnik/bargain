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

        #region Table Names

        private const string TABLE_REGIONS = "Regions";
        private const string TABLE_LOCATIONS = "Locations";
        private const string TABLE_CATEGORIES = "Categories";                
        private const string TABLE_USERS = "Users";
        private const string TABLE_TRADES = "Trades";
        private const string TABLE_TRADE_FILES = "TradeFiles";
        private const string TABLE_TRADE_USERS = "TradeUsers";
        private const string TABLE_DEALS = "Deals";
        private const string TABLE_DEAL_TYPES = "DealTypes";
        private const string TABLE_DEAL_FILES = "DealFiles";
        private const string TABLE_TRADE_DEALS = "TradeDeals";
        private const string TABLE_USER_DEALS = "UserDeals";

        #endregion

        #region Table Definitions

        public DbSet<Region> Regions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<TradeFile> TradeFiles { get; set; }
        public DbSet<TradeUser> TradeUsers { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealType> DealTypes { get; set; }
        public DbSet<DealFile> DealFiles { get; set; }
        public DbSet<TradeDeal> TradeDeals { get; set; }
        public DbSet<UserDeal> UserDeals { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Region>().ToTable(TABLE_REGIONS);
            modelBuilder.Entity<Region>().HasData(MockDatabase.Regions);

            modelBuilder.Entity<Location>().ToTable(TABLE_LOCATIONS);
            modelBuilder.Entity<Location>().HasData(MockDatabase.Locations);

            modelBuilder.Entity<Category>().ToTable(TABLE_CATEGORIES);
            modelBuilder.Entity<Category>().HasData(MockDatabase.Categories);                     

            modelBuilder.Entity<User>().ToTable(TABLE_USERS);
            modelBuilder.Entity<User>().HasData(MockDatabase.Users);

            modelBuilder.Entity<Trade>().ToTable(TABLE_TRADES);
            modelBuilder.Entity<Trade>().HasData(MockDatabase.Trades);
            modelBuilder.Entity<Trade>().HasOne(x => x.Location).WithMany().HasForeignKey(x => x.LocationId);

            modelBuilder.Entity<TradeFile>().ToTable(TABLE_TRADE_FILES);
            modelBuilder.Entity<TradeFile>().HasData(MockDatabase.TradeFiles);

            modelBuilder.Entity<TradeUser>().ToTable(TABLE_TRADE_USERS);
            modelBuilder.Entity<TradeUser>().HasData(MockDatabase.TradeUsers);
            modelBuilder.Entity<TradeUser>().HasKey(x => new { x.TradeId, x.UserId });            
            modelBuilder.Entity<TradeUser>().HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Deal>().ToTable(TABLE_DEALS);
            modelBuilder.Entity<Deal>().HasData(MockDatabase.Deals);
            modelBuilder.Entity<Deal>().HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<DealType>().ToTable(TABLE_DEAL_TYPES);
            modelBuilder.Entity<DealType>().HasData(MockDatabase.DealTypes);

            modelBuilder.Entity<DealFile>().ToTable(TABLE_DEAL_FILES);
            modelBuilder.Entity<DealFile>().HasData(MockDatabase.DealFiles);
            modelBuilder.Entity<DealFile>().HasKey(x => new { x.DealId, x.TradeFileId });
            modelBuilder.Entity<DealFile>().HasOne(x => x.TradeFile).WithMany().HasForeignKey(x => x.TradeFileId);

            modelBuilder.Entity<TradeDeal>().ToTable(TABLE_TRADE_DEALS);
            modelBuilder.Entity<TradeDeal>().HasData(MockDatabase.TradeDeals);
            modelBuilder.Entity<TradeDeal>().HasKey(x => new { x.TradeId, x.DealId });            
            modelBuilder.Entity<TradeDeal>().HasOne(x => x.Deal).WithMany().HasForeignKey(x => x.DealId);

            modelBuilder.Entity<UserDeal>().ToTable(TABLE_USER_DEALS);
            modelBuilder.Entity<UserDeal>().HasKey(x => new { x.UserId, x.DealId });            
            modelBuilder.Entity<UserDeal>().HasOne(x => x.Deal).WithMany().HasForeignKey(x => x.DealId);
        }
    }
}
