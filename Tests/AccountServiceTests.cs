using BankKata;
using NSubstitute;

namespace Tests;


public class AccountServiceTests
{
    [Fact]
    public void AcceptanceTest()
    {
        var printer = Substitute.For<Printer>();
        var clock = Substitute.For<Clock>();
        clock.today().Returns("01/04/2014", "02/04/2014", "10/04/2014");
        var accountService = new AccountService(printer, clock);
        accountService.deposit(1000);
        accountService.deposit(2000);
        accountService.withdraw(500);

        accountService.printStatement();

        Received.InOrder(() =>
        {
            printer.Received().printLine("DATE | AMOUNT | BALANCE");
            printer.Received().printLine("14/01/2012 | -500 | 2500");
            printer.Received().printLine("13/01/2012 | 2000 | 3000");
            printer.Received().printLine("10/01/2012 | 1000 | 1000");
        });
    }
}