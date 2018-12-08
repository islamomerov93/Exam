using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchingSystem
{
    class Employee : User
    {
        public List<int> announceIDs = new  List<int>();
        public Employee(string usename, string email, string password) : base(usename, email, password){}
        public CV CV = null;
        public void ShowCV()
        {
            Console.WriteLine("Name            : " + CV.Name);
            Console.WriteLine("SUrname         : " + CV.Surname);
            Console.WriteLine("Sex             : " + CV.Sex);
            Console.WriteLine("Age             : " + CV.Age);
            Console.WriteLine("Education       : " + CV.Education);
            Console.WriteLine("Work experience : " + CV.WorkExperience);
            Console.WriteLine("Category        : " + CV.Category);
            Console.WriteLine("City            : " + CV.City);
            Console.WriteLine("Minimum salary  : " + CV.MinimumSalary);
            Console.WriteLine("Phone number    : " + CV.Number);
        }
        public void AnnouncesForCV(List<Employer> employers)
        {
            int i = 1;
            foreach (var employer in employers)
            {
                var announces = from x in employer.announces
                            where CV.Category == x.Category && CV.WorkExperience == x.WorkExperience && CV.Education == x.Education
                            select x;
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
            }
            if (i == 1) Tools.ShowMessage("There is not any announcement that corresponds to your CV ", ConsoleColor.Red);
        }
        public void AnnouncesByCategory(List<Employer> employers)
        {
            Console.WriteLine("Select any option");
            Console.WriteLine("1. Category");
            Console.WriteLine("2. Education");
            Console.WriteLine("3. City");
            Console.WriteLine("4. Salary");
            Console.WriteLine("5. Work experience");
            option:
            int.TryParse(Console.ReadLine(), out int option);
            if (option < 1 && option > 5)
            {
                Tools.ShowMessage("Invalid imput, try again", ConsoleColor.Red);
                goto option;
            }
            bool check = false;
            switch (option)
            {
                case 1:
                    foreach (var employer in employers)
                    {
                        var announces = from x in employer.announces
                                        where x.Category.ToString().Contains(CV.Category.ToString())
                                        select x;
                        foreach (var item in announces)
                        {
                            check = true;
                            item.ShowAnnounce();
                        }
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    foreach (var employer in employers)
                    {
                        var announces = from x in employer.announces
                                        where x.Education.ToString().Contains(CV.Education.ToString())
                                        select x;
                        foreach (var item in announces)
                        {
                            check = true;
                            item.ShowAnnounce();
                        }
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    foreach (var employer in employers)
                    {
                        var announces = from x in employer.announces
                                        where x.City.ToString().Contains(CV.City.ToString())
                                        select x;
                        foreach (var item in announces)
                        {
                            check = true;
                            item.ShowAnnounce();
                        }
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    foreach (var employer in employers)
                    {
                        var announces = from x in employer.announces
                                        where x.Salary.ToString().Contains(CV.MinimumSalary.ToString())
                                        select x;
                        foreach (var item in announces)
                        {
                            check = true;
                            item.ShowAnnounce();
                        }
                    }
                    Console.ReadKey();
                    break;
                case 5:
                    foreach (var employer in employers)
                    {
                        var announces = from x in employer.announces
                                        where x.WorkExperience.ToString().Contains(CV.WorkExperience.ToString())
                                        select x;
                        foreach (var item in announces)
                        {
                            check = true;
                            item.ShowAnnounce();
                        }
                    }
                    Console.ReadKey();
                    break;
            }
            if (!check) Tools.ShowMessage("There is not any announcement that corresponds to choice ", ConsoleColor.Red);
        }
    }
}
