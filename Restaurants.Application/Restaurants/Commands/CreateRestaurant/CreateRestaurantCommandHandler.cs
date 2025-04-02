using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository):IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new restaurant");
        var restaurant = mapper.Map<Domain.Entities.Restaurant>(request);
        int id = await restaurantsRepository.CreateRestaurant(restaurant);
        return id;
    }
}