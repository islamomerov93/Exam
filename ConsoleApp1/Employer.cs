using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchingSystem
{
    class Employer : User
    {
        public Employer(string usename, string email, string password) : base(usename, email, password){}
        public List<Announcement> announces = new List<Announcement>();
        public Dictionary<int, List<CV>> Apply = new Dictionary<int, List<CV>>();
        public void CVsByAnnounces(List<Employee> employees, int userIndex)
        {
            int i = 1;
            foreach (var item in announces)
            {
                var wkers = from x in employees
                            where x.CV.Category == item.Category && x.CV.WorkExperience == item.WorkExperience && x.CV.Education == item.Education
                            select x;
                Console.WriteLine($"Employees' CVs for {i++}. announcement");
                foreach (var wker in wkers)
                {
                    wker.ShowCV();
                }
            }
        }
        public void ShowAnnounces()
        {
            int i = 1;
            foreach (var announce in announces)
            {
                Console.WriteLine($"Announce number {i++}");
                Console.WriteLine($"Name of work                     : {announce.WorkName}");
                Console.WriteLine($"Name of Company                  : {announce.CompanyName}");
                Console.WriteLine($"Category of work                 : {announce.Category}");
                Console.WriteLine($"Description about work           : {announce.AboutWork}");
                Console.WriteLine($"City                             : {announce.City}");
                Console.WriteLine($"Required mininun age             : {announce.Age}");
                Console.WriteLine($"Required mininun education level : {announce.Education}");
                Console.WriteLine($"Required mininun work experience : {announce.WorkExperience}");
                Console.WriteLine($"Salary                           : {announce.Salary}");
                Console.WriteLine($"Contact number                   : {announce.ContactNumber}\n");
            }
            if (i == 1) Tools.ShowMessage("There is not any announcement that corresponds to that category ", ConsoleColor.Red);
        }
    }
}
