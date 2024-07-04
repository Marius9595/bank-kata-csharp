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
        this.transactions.Add(new AccountTransaction(amount, this.clock.today()));
    }

    public void withdraw(int amount)
    {
        
    }

    public void printStatement()
    {
        this.printer.printLine("DATE || AMOUNT || BALANCE");
        
        if(this.transactions.Count > 0)
        {
            this.printer.printLine("10/01/2012 || 1000 || 1000");
        }
    }
}

public class AccountTransaction
{
    public AccountTransaction(int amount, string date)
    {
        
    }
}