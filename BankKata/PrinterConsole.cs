using Tests;

namespace BankKata;

public class PrinterConsole: Printer
{
    public void printLine(string line)
    {
        System.Console.WriteLine(line);
    }
}