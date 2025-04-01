namespace Restaurant.Domain.Repositories;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurants.Domain.Entities.Restaurant>> GetAllAsync();
}