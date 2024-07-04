namespace BankKata;

public class AccountTransaction
{
    int amount;
    string date;
    int balance;

    public AccountTransaction(int amount, string date, int balance)
    {
        this.amount = amount;
        this.date = date;
        this.balance = balance;
    }

    public int getAmount()
    {
        return this.amount;
    }
    
    public string getDate()
    {
        return this.date;
    }

    public int getBalance()
    {
        return this.balance;
    }
}