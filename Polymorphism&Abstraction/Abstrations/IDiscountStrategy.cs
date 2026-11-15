using Polymorphism_Abstraction.Models;

namespace Polymorphism_Abstraction.Abstrations;

public interface IDiscountStrategy
{
    decimal CalculateDiscount(Order order);
}
