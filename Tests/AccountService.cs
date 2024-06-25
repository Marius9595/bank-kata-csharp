using BankKata;
using NSubstitute;

namespace Tests;


public class AccountServiceTests
{
    [Fact]
    public void AcceptanceTest()
    {
        var printer = Substitute.For<Printer>();
        var accountService = new AccountService(printer);
        accountService.deposit(1000);
        accountService.deposit(2000);
        accountService.withdraw(500);
        
        accountService.printStatement();
        
        printer.Received().printLine("DATE | AMOUNT | BALANCE");
        printer.Received().printLine("10/04/2014 | 500.00 | 2500.00");
        printer.Received().printLine("02/04/2014 | -100.00 | 1400.00");
        printer.Received().printLine("01/04/2014 | 1000.00 | 1000.00");
    }
}