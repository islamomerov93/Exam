using System;

namespace SearchingSystem
{
    class Announcement
    {
        public int ID = 0;
        public string WorkName { get; set; }
        public string CompanyName { get; set; }
        public Category Category { get; set; }
        public string AboutWork { get; set; }
        public City City { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
        public Education Education { get; set; }
        public WorkExperience WorkExperience { get; set; }
        public string ContactNumber { get; set; }
        public void ShowAnnounce()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Name of work                     : {WorkName}");
            Console.WriteLine($"Name of Company                  : {CompanyName}");
            Console.WriteLine($"Category of work                 : {Category}");
            Console.WriteLine($"Description about work           : {AboutWork}");
            Console.WriteLine($"City                             : {City}");
            Console.WriteLine($"Required mininun age             : {Age}");
            Console.WriteLine($"Required mininun education level : {Education}");
            Console.WriteLine($"Required mininun work experience : {WorkExperience}");
            Console.WriteLine($"Salary                           : {Salary}");
            Console.WriteLine($"Contact number                   : {ContactNumber}\n");
            Console.WriteLine("----------------------------------------------------");
        }
    }
}
