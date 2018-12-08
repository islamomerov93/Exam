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
    }
}
