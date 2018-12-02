using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class User
    {
        public string Usename { get; set; }
        string email { get; set; }
        string password;
        public User(string usename, string email, string password)
        {
            Usename = usename;
            Email = email;
            Password = password;
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                Regex EmailPattern = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (EmailPattern.IsMatch(value)) email = value;
                else throw new Exception("Wrong email format");
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                Regex PasswordPattern = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
                if (PasswordPattern.IsMatch(value)) password = value;
                else throw new Exception("Wrong password format");
            }
        }
    }
}
