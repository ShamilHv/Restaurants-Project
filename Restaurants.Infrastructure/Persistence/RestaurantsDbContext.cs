using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence;

public class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
{
    internal DbSet<Domain.Entities.Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Domain.Entities.Restaurant>().OwnsOne(r => r.Address);

        modelBuilder.Entity<Domain.Entities.Restaurant>().HasMany(r => r.Dishes).WithOne()
            .HasForeignKey(d => d.RestaurantId);
    }
}