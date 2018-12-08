using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchingSystem
{
    class User
    {
        public string Usename { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string usename, string email, string password)
        {
            Usename = usename;
            Email = email;
            Password = password;
        }
    }
}
