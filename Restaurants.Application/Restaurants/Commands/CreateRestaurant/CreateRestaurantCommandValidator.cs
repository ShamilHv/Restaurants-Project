using FluentValidation;
using Restaurants.Application.DTOs;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;

namespace Restaurants.Application.Validators;

public class CreateRestaurantCommandValidator:AbstractValidator< CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name).Length(4, 100); 
        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Enter valid description");
        RuleFor(dto => dto.Category).NotEmpty().WithMessage("Ener valid Category");
        RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Enter valid email");
        RuleFor(dto => dto.PostalCode).Matches(@"^\d{2}-\d{3}$}").WithMessage("Please enter a valid postal code (XX-XXX).");
    }
}