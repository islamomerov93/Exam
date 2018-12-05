using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Employer : User
    {
        public Employer(string usename, string email, string password) : base(usename, email, password){}
        public Announcement Announcement = new Announcement();
    }
}
