using System;

// Định nghĩa ngoại lệ tùy chỉnh InsufficientFundsException
public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message)
    {
    }
}

// Định nghĩa ngoại lệ tùy chỉnh NegativeAmountException
public class NegativeAmountException : Exception
{
    public NegativeAmountException(string message) : base(message)
    {
    }
}

// Lớp BankAccount để mô phỏng tài khoản ngân hàng
public class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
    }

    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new NegativeAmountException("Số dư ban đầu không thể là số âm.");
        }
        
        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException("Số tiền nạp không thể là số âm.");
        }
        
        balance += amount;
        Console.WriteLine($"Nạp thành công: {amount:C}. Số dư hiện tại: {balance:C}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount < 0)
        {
            throw new NegativeAmountException("Số tiền rút không thể là số âm.");
        }

        if (balance - amount < 0)
        {
            throw new InsufficientFundsException("Số dư không đủ để rút số tiền yêu cầu.");
        }
        
        balance -= amount;
        Console.WriteLine($"Rút thành công: {amount:C}. Số dư hiện tại: {balance:C}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Nhập số dư ban đầu: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());
            BankAccount account = new BankAccount(initialBalance);

            Console.Write("Nhập số tiền cần nạp: ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            account.Deposit(depositAmount);

            Console.Write("Nhập số tiền cần rút: ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
            account.Withdraw(withdrawAmount);
        }
        catch (NegativeAmountException ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Lỗi: Vui lòng nhập một số hợp lệ.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi không xác định: " + ex.Message);
        }
    }
}