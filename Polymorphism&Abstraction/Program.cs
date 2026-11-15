using Polymorphism_Abstraction.Abstrations;
using Polymorphism_Abstraction.DiscountStrategies;
using Polymorphism_Abstraction.Models;

Order order = new Order
{
    Id = 1,
    Items = new List<OrderItem>
    {
        new OrderItem { Id = 1, Name = "Item 1", UnitPrice = 10m, Quantity = 2 },
        new OrderItem { Id = 2, Name = "Item 2", UnitPrice = 20m, Quantity = 1 }
    }
};

var total = order.GetTotal(new List<IDiscountStrategy>
{
    new PercentageDiscount(0.10m), // 10% discount
    new ThresholdDiscount(20m, 5m),  // $5 discount if subtotal >= $20
    new BuyOneGetOneFreeDiscount(1)  // Buy one get one free for item with Id 1
});

Console.WriteLine("Total Amount : " + total);  // expected output: Total Amount : 21.00

/* Explanation of the output:
 
Subtotal:

Item 1: 10m * 2 = 20.00m

Item 2: 20m * 1 = 20.00m

Subtotal = 20.00m + 20.00m = 40.00m

Discounts (all calculated against the 40.00m Subtotal):

PercentageDiscount(0.10m): 40.00m * 0.10m = 4.00m

ThresholdDiscount(20m, 5m): 40.00m >= 20m is true, so = 5.00m

BuyOneGetOneFreeDiscount(1): Item 1 has quantity 2 (2 / 2 = 1 free item at 10m) = 10.00m

Total Discount = 4.00m + 5.00m + 10.00m = 19.00m

Final Total:

40.00m - 19.00m = 21.00m
*/ 