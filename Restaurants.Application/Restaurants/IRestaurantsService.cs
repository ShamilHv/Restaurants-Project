namespace Restaurants.Application.Restaurants;

public interface IRestaurantsService
{
    Task<IEnumerable<Domain.Entities.Restaurant>> GetAllAsync();
}