using System;

// Định nghĩa ngoại lệ tùy chỉnh AgeOutOfRangeException
public class AgeOutOfRangeException : Exception
{
    public AgeOutOfRangeException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Nhập tuổi của sinh viên: ");
            int age = int.Parse(Console.ReadLine());

            // Kiểm tra độ tuổi
            CheckAgeForAdmission(age);

            Console.WriteLine("Sinh viên đủ điều kiện nhập học.");
        }
        catch (AgeOutOfRangeException ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên hợp lệ.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi không xác định: " + ex.Message);
        }
    }

    static void CheckAgeForAdmission(int age)
    {
        if (age < 18 || age > 25)
        {
            throw new AgeOutOfRangeException("Tuổi của sinh viên phải nằm trong khoảng từ 18 đến 25.");
        }
    }
}