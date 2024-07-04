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
        var thereAreTransactions = this.transactions.Count > 0;
        var newBalance = thereAreTransactions ? currentBalance() + amount : amount;
        this.transactions.Add(new AccountTransaction(amount, this.clock.today(), newBalance));
    }

    private int currentBalance()
    {
        return this.transactions.Last().getBalance();
    }

    public void withdraw(int amount)
    {
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
        if (accountTransactions.Count > 0)
        {
            var lastTransaction = accountTransactions.Last();
            this.printer.printLine($"{lastTransaction.getDate()} || {lastTransaction.getAmount()} || {lastTransaction.getBalance()}");
            
            printTransactions(accountTransactions.GetRange(0, accountTransactions.Count - 1));
        }
    }
}