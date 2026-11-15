using Polymorphism_Abstraction.Abstrations;

namespace Polymorphism_Abstraction.Models;

public class Order
{
    public int Id { get; set; }
    public IReadOnlyList<OrderItem> Items { get; set; } = new List<OrderItem>();
    public decimal Subtotal => Items.Sum(item => item.UnitPrice * item.Quantity);
    public decimal GetTotal(IEnumerable<IDiscountStrategy> strategies)
    {
        decimal totalDiscount = 0m;
        foreach (var strategy in strategies)
        {
            totalDiscount += strategy.CalculateDiscount(this);
        }
        return Math.Max(0m, Subtotal - totalDiscount);
    }
}