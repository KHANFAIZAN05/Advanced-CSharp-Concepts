public class InsufficientFundsException : Exception
{
    public decimal CurrentBalance { get; }
    public decimal AttemptedAmount { get; }
    public decimal Shortfall { get; }

    public InsufficientFundsException(decimal currentBalance, decimal attemptedAmount)
        : base($"Insufficient funds: Attempted to withdraw {attemptedAmount:C}, but current balance is {currentBalance:C} (Shortfall: {attemptedAmount - currentBalance:C}).")
    {
        CurrentBalance = currentBalance;
        AttemptedAmount = attemptedAmount;
        Shortfall = attemptedAmount - currentBalance;
    }
}