using Microsoft.EntityFrameworkCore;
using webapi.Data.Entities;

namespace webapi.webapi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<LoginEntity> Logins { get; set; }
        public DbSet<CreatorEntity> Creators { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoginEntity>()
                .HasDiscriminator<string>("LoginType")
                .HasValue<AdminEntity>("AdminEntity")
                .HasValue<UserEntity>("UserEntity");
        }
    }
}
