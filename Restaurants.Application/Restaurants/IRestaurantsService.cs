using Restaurants.Application.DTOs;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;

namespace Restaurants.Application.Restaurants;

public interface IRestaurantsService
{
    Task<IEnumerable<RestaurantDto>> GetAllAsync();
    Task<RestaurantDto?> GetRestaurantById(int id);
}