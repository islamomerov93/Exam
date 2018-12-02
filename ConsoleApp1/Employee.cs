using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Employee : User
    {
        public Employee(string usename, string email, string password) : base(usename, email, password){}
    }
}
