namespace Inheritence;

public abstract class Employee
{
    public int Id { get; }
    public string Name { get; } = string.Empty;
    public decimal BaseSalary { get; }

    protected Employee(int id, string name, decimal baseSalary)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
        }

        if (baseSalary <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(baseSalary), "Base salary must be greater than zero.");
        }

        Id = id;
        Name = name;
        BaseSalary = baseSalary;
    }

    public abstract decimal CalculateMonthlyPay();

    public virtual string GetPaySlipSummary()
    {
        return $"Employee ID: {Id}, Name: {Name}, Monthly Pay: {CalculateMonthlyPay():C}";
    }
}
