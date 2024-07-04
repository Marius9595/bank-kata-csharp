using System.Transactions;
using Tests;

namespace BankKata;

public class AccountService
{
    Printer printer;
    Clock clock;
    List<AccountTransaction> transactions = new List<AccountTransaction>();

    public AccountService(Printer printer, Clock clock)
    {
        this.printer = printer;
        this.clock = clock;
    }

    public void deposit(int amount)
    {
        var newBalance = thereAreTransactions(this.transactions) ? currentBalance() + amount : amount;
        this.transactions.Add(new AccountTransaction(amount, this.clock.today(), newBalance));
    }

    private int currentBalance()
    {
        return this.transactions.Last().getBalance();
    }

    public void withdraw(int amount)
    {
        var newBalance = thereAreTransactions(this.transactions) ? currentBalance() - amount : -amount;
        this.transactions.Add(new AccountTransaction(-amount, this.clock.today(), newBalance));
    }

    public void printStatement()
    {
        printHeader();
        printTransactions(this.transactions);
    }

    private void printHeader()
    {
        this.printer.printLine("DATE || AMOUNT || BALANCE");
    }

    private void printTransactions(List<AccountTransaction> accountTransactions)
    {
        if (thereAreTransactions(accountTransactions)) return;
        
        var lastTransaction = accountTransactions.Last();
        this.printer.printLine($"{lastTransaction.getDate()} || {lastTransaction.getAmount()} || {lastTransaction.getBalance()}");
            
        printTransactions(removeLastTransaction(accountTransactions));
    }

    private static bool thereAreTransactions(List<AccountTransaction> accountTransactions)
    {
        return accountTransactions.Count <= 0;
    }

    private static List<AccountTransaction> removeLastTransaction(List<AccountTransaction> accountTransactions)
    {
        return accountTransactions.GetRange(0, accountTransactions.Count - 1);
    }
}