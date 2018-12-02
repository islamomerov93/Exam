using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public static bool IsEmail(string mail)
    {
        string MailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        return Regex.IsMatch(mail, MailPattern);
    }

    public static bool IsPassword(string password)
    {
        string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
        return Regex.IsMatch(password, PasswordPattern);
    }

    public static bool IsNumber(string num)
    {
        string pNumberPattern = @"^[50|51|55|70|77]{2}[0-9]{7}$";
        return Regex.IsMatch(num, pNumberPattern);
    }
}
