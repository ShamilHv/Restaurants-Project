namespace Restaurant.Domain.Repositories;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurants.Domain.Entities.Restaurant>> GetAllAsync();
    Task<Restaurants.Domain.Entities.Restaurant?> GetRestaurantByIdAsync(int id);
    Task<int> CreateRestaurant(Restaurants.Domain.Entities.Restaurant restaurant);
}