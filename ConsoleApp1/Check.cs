using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Tools
    {
        public static void ShowMessage(string message,ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.DarkYellow; ;
        }
        public static bool NullErrorMessage(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Tools.ShowMessage("Invalide entry (empty field not accepted), try again :", ConsoleColor.Red);
                return true;
            }
            return false;
        }
        public static class Check
        {
            public static bool CorrectEmail(string email)
            {
                return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            }
            public static bool CorrectPassword(string password)
            {
                return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
            }
            public static bool CorrectNumber(string number)
            {
                return Regex.IsMatch(number, @"^[50|51|55|70|77]{2}[0-9]{7}$");
            }
        }
    }
}
