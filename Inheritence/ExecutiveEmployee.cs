namespace Inheritence;

public class ExecutiveEmployee : FullTimeEmployee
{
    public decimal StockStipend { get; }
    public ExecutiveEmployee(int id, string name, decimal baseSalary, decimal stockStipend) : base(id, name, baseSalary, 0)
    {
        if (stockStipend < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(stockStipend), "Stock stipend cannot be negative.");
        }
        StockStipend = stockStipend;
    }
    public sealed override decimal CalculateMonthlyPay() => (base.CalculateMonthlyPay() + StockStipend);
    public override string GetPaySlipSummary() => $"[Executive] {base.GetPaySlipSummary()} ";

}