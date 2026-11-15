namespace Inheritence;

public class FullTimeEmployee : Employee
{
    public decimal AnnualBonus { get; }
    public FullTimeEmployee(int id, string name, decimal baseSalary, decimal annualBonus) : base(id, name, baseSalary)
    {
        if (annualBonus < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(annualBonus), "Annual bonus must be greater than zero.");
        }
        AnnualBonus = annualBonus;
    }
    public override decimal CalculateMonthlyPay() => BaseSalary + (AnnualBonus / 12m);
    public override string GetPaySlipSummary() => $"[Full-Time] {base.GetPaySlipSummary()} ";

}
