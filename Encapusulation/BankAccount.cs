using System.Transactions;

namespace BankingApp;

public class BankAccount
{
    public decimal InitalBalance { get; init; }
    public decimal CurrentBalance { get; private set; }
    private readonly List<Transaction> _transactions = new();
    public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();
    public BankAccount(decimal amount)
    {
        InitalBalance = amount;
        CurrentBalance = amount;
        _transactions.Add(new Transaction(DateTimeOffset.UtcNow, TransactionType.Deposit, amount));

    }
    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Initial balance cannot be negative.");
        }

        CurrentBalance = CurrentBalance + amount;

        _transactions.Add(new Transaction(DateTimeOffset.UtcNow, TransactionType.Deposit, amount));
    }
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Withdrawl amount should be greater than 0");
        }

        if (amount > CurrentBalance)
        {
            throw new InsufficientFundsException(CurrentBalance, amount);
        }

        CurrentBalance = CurrentBalance - amount;

        _transactions.Add(new Transaction(DateTimeOffset.UtcNow, TransactionType.Withdrawl, amount));

    }
}


