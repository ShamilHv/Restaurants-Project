using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Repositories;
using Restaurants.Application.DTOs;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(
    IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsService> logger,
    IMapper mapper)
    : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllAsync()
    {

    }

    public async Task<RestaurantDto?> GetRestaurantById(int id)
    {
        logger.LogInformation("Getting restaurant with id " + id);
        var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(id);
        var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);
        return restaurantDto;
    }
    
}