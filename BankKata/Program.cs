// See https://aka.ms/new-console-template for more information

using BankKata;

internal class Program
{
    public static void Main(string[] args)
    {
        ClockSystem clock = new ClockSystem();
        PrinterConsole printer = new PrinterConsole();
        var accountService = new AccountService(printer, clock);
        
        accountService.deposit(1000);
        accountService.deposit(2000);
        accountService.withdraw(500);
        
        accountService.printStatement();
    }
}