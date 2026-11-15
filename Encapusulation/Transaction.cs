namespace BankingApp;
public record Transaction(DateTimeOffset Timestampt, TransactionType Type, decimal Amount);