namespace Inheritence;

public class ContractEmployee : Employee
{
    public decimal HourlyRate { get; }
    public int HoursWorked { get; }

    public ContractEmployee(int id, string name, decimal baseSalary, decimal hourlyRate, int hoursWorked) : base(id, name, baseSalary)
    {
        if (hourlyRate <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(hourlyRate), "Hourly rate must be greater than zero.");
        }

        if (hoursWorked < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(hoursWorked), "Hours worked cannot be negative.");
        }

        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }
    public override decimal CalculateMonthlyPay() => HourlyRate * HoursWorked;
    public override string GetPaySlipSummary() => $"[Contract] {base.GetPaySlipSummary()} ";

}
