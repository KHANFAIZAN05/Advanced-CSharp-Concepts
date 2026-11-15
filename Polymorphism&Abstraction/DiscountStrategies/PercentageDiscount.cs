using Polymorphism_Abstraction.Abstrations;
using Polymorphism_Abstraction.Models;

namespace Polymorphism_Abstraction.DiscountStrategies;

public class PercentageDiscount : IDiscountStrategy
{
    private readonly decimal _percentage = 0.10m;
    public PercentageDiscount(decimal percentage)
    {
        if (percentage < 0m || percentage > 1m)
        {
            throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage must be between 0 and 1.");
        }
        _percentage = percentage;
    }
    public decimal CalculateDiscount(Order order)
    {
        return order.Subtotal * _percentage;
    }
}
