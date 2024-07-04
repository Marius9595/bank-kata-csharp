using Tests;

namespace BankKata;

public class ClockSystem: Clock
{
    public string today()
    {
        return System.DateTime.Now.ToString("dd/MM/yyyy");
    }
}