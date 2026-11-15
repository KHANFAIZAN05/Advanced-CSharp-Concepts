using Polymorphism_Abstraction.Abstrations;
using Polymorphism_Abstraction.Models;

namespace Polymorphism_Abstraction.DiscountStrategies;

public class BuyOneGetOneFreeDiscount : IDiscountStrategy
{
    private readonly int _targetItemId = 0;
    public BuyOneGetOneFreeDiscount(int targetItemId)
    {
        _targetItemId = targetItemId;
    }
    public decimal CalculateDiscount(Order order)
    {
        decimal discount = 0m;

        foreach (var item in order.Items)
        {
            if (item.Id == _targetItemId && item.Quantity >= 2)
            {
                discount = (item.Quantity / 2) * item.UnitPrice;
            }
        }
        return discount;
    }
}