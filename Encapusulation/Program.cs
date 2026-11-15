using BankingApp;

BankAccount bankAccount = new BankAccount(100M);

bankAccount.Withdraw(90);
bankAccount.Deposit(50);
bankAccount.Deposit(10);

foreach (var transactions in bankAccount.Transactions)
{
    Console.WriteLine(transactions.Timestampt + "," + transactions.Type + "," + transactions.Amount);
}

