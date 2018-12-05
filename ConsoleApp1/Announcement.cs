using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Announcement
    {
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
    }
}
