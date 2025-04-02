using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.DTOs;
using Restaurants.Application.Restaurants;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantsService.GetAllAsync();
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurantById([FromRoute] int id)
    {
        var restaurant = await restaurantsService.GetRestaurantById(id);
        if (restaurant is null) return NotFound();
        return Ok(restaurant);
    }

    [HttpPost("add")]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var id = await restaurantsService.Create(createRestaurantDto);
        return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
    }
}