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
        var balance = this.transactions.Count > 0 ? this.transactions.Last().getBalance() + amount : amount;
        this.transactions.Add(new AccountTransaction(amount, this.clock.today(), balance));
    }

    public void withdraw(int amount)
    {
    }

    public void printStatement()
    {
        this.printer.printLine("DATE || AMOUNT || BALANCE");

        printTransactions(this.transactions);
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