using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CV
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int MinimumSalary { get; set; }
        public string Number { get; set; }
        public Sex Sex { get; set; }
        public Education Education { get; set; }
        public WorkExperience WorkExperience { get; set; }
        public Category Category { get; set; }
        public City City { get; set; }
    }
    
    public enum Sex
    {
        Male = 1,
        Female
    }
    public enum Education
    {
        Secondary = 1,
        IncompleteHigher,
        Higher
    }
    public enum WorkExperience
    {
        LessThan_1_Year = 1,
        Form_1_To_3_Year,
        Form_3_To_5_Year,
        MoreThan_5_Year
    }
    public enum Category
    {
        Programmer = 1,
        ItSpecialist,
        Doctor,
        Teacher,
        Journalist,
        Translator
    }
    public enum City
    {
        Baku = 1,
        Ganja,
        Sumqayit,
        Nakhcivan
    }
}
