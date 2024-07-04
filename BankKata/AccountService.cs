using Tests;

namespace BankKata;



public class AccountService
{
    Printer printer;
    Clock clock;
    public AccountService(Printer printer, Clock clock)
    {
        this.printer = printer;
        this.clock = clock;
    }

    public void deposit(int amount)
    {
        
    }

    public void withdraw(int amount)
    {
        
    }

    public void printStatement()
    {
        this.printer.printLine("DATE | AMOUNT | BALANCE");
    }
}