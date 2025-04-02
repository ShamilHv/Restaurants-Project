using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

public class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantsRepository
{
    public async Task<IEnumerable<Domain.Entities.Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants.Include(r => r.Dishes).ToListAsync();
        return restaurants;
    }

    public async Task<Domain.Entities.Restaurant?> GetRestaurantByIdAsync(int id)
    {
        var restaurant = await dbContext.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }

    public async Task<int> CreateRestaurant(Domain.Entities.Restaurant restaurant)
    {
        dbContext.Restaurants.Add(restaurant);
        await dbContext.SaveChangesAsync();
        return restaurant.Id;
        
    }
}