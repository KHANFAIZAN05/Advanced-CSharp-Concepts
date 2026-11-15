using Polymorphism_Abstraction.Abstrations;
using Polymorphism_Abstraction.Models;

namespace Polymorphism_Abstraction.DiscountStrategies;

public class ThresholdDiscount : IDiscountStrategy
{
    private readonly decimal _threshold = 0m;
    private readonly decimal _discountAmount = 0m;
    public ThresholdDiscount(decimal minimumThreshold, decimal discountAmount)
    {
        _threshold = minimumThreshold;
        _discountAmount = discountAmount;
    }
    public decimal CalculateDiscount(Order order)
    {
        if (order.Subtotal >= _threshold)
        {
            return _discountAmount;
        }
        return 0m;
    }
}
