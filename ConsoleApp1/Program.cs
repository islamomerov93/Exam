using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<Employer> employers = new List<Employer>();
            while (true)
            {
                Console.WriteLine("1.Sign in || 2.Sign up || 3.Log out");
                var menu = Console.ReadLine();
                if (menu == "1")
                {
                    Console.Write("Username : ");
                    menu1_1:
                    var username = Console.ReadLine();
                    if (!employees.Exists(x => x.Usename == username))
                    {
                        Tools.ShowMessage("There is not like username",ConsoleColor.DarkRed);
                        goto menu1_1;
                    }
                    Console.Write("Password : ");
                    menu1_2:
                    var password = Console.ReadLine();
                    if (!employees.Exists(x => x.Password == password))
                    {
                        Tools.ShowMessage("Wrong password", ConsoleColor.DarkRed);
                        goto menu1_2;
                    }
                    if (true)
                    {
                        while (true)
                        {
                            Console.Clear();
                            bool check = false;
                            Console.WriteLine("1. Write CV");
                            Console.WriteLine("2. Jobs according to your cv");
                            Console.WriteLine("3. Search job due to category");
                            Console.WriteLine("4. Your CV");
                            Console.WriteLine("5. All jobs");
                            Console.WriteLine("6. Aplied jobs");
                            Console.WriteLine("6. Log out");
                            var choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    Console.Clear();
                                    while (true)
                                    {
                                        Console.Write("Name              : ");
                                        name:
                                        employee.CV.Name = Console.ReadLine();
                                        if (Tools.NullErrorMessage(employee.CV.Name)) goto name;
                                        Console.Write("Surname           : ");
                                        surname:
                                        employee.CV.Surname = Console.ReadLine();
                                        if (Tools.NullErrorMessage(employee.CV.Surname)) goto surname;
                                        Console.WriteLine("Sex");
                                        Console.Write("1.Male/2.Female)  : ");
                                        sex:
                                        var sex = Console.ReadLine();
                                        if (sex == "1") employee.CV.Sex = Sex.Male;
                                        else if (sex == "2") employee.CV.Sex = Sex.Female;
                                        else
                                        {
                                            Tools.ShowMessage("Invalide value", ConsoleColor.Red);
                                            goto sex;
                                        }
                                        Console.Write("Age               : ");
                                        age:
                                        if (int.TryParse(Console.ReadLine(), out int a)) employee.CV.Age = a;
                                        else
                                        {
                                            Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                            goto age;
                                        }
                                        Console.WriteLine("Education");
                                        Console.WriteLine("1.Secondary       : ");
                                        Console.WriteLine("2.IncompleteHigher: ");
                                        Console.WriteLine("3.Higher          : ");
                                        education:
                                        var Educ = Console.ReadLine();
                                        if (Educ == "1") employee.CV.Education = Education.Secondary;
                                        else if (Educ == "2") employee.CV.Education = Education.IncompleteHigher;
                                        else if (Educ == "3") employee.CV.Education = Education.Higher;
                                        else
                                        {
                                            Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                            goto education;
                                        }
                                        Console.WriteLine("Work experience");
                                        Console.WriteLine("1.LessThan 1 Year : ");
                                        Console.WriteLine("2.Form 1 to 3 Year:");
                                        Console.WriteLine("3.Form 3 to 5 Year:");
                                        Console.WriteLine("4.MoreThan_5_Year :");
                                        workExp:
                                        var we = Console.ReadLine();
                                        if (we == "1") employee.CV.WorkExperience = WorkExperience.LessThan_1_Year;
                                        else if (we == "2") employee.CV.WorkExperience = WorkExperience.Form_1_To_3_Year;
                                        else if (we == "3") employee.CV.WorkExperience = WorkExperience.Form_3_To_5_Year;
                                        else if (we == "4") employee.CV.WorkExperience = WorkExperience.MoreThan_5_Year;
                                        else
                                        {
                                            Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                            goto workExp;
                                        }
                                        Console.WriteLine("Category");
                                        Console.WriteLine("1.Programmer  : ");
                                        Console.WriteLine("2.ItSpecialist: ");
                                        Console.WriteLine("3.Doctor      : ");
                                        Console.WriteLine("4.Teacher     : ");
                                        Console.WriteLine("5.Journalist  : ");
                                        Console.WriteLine("6.Translator  : ");
                                        cat:
                                        var category = Console.ReadLine();
                                        if (category == "1") employee.CV.Category = Category.Programmer;
                                        else if (category == "2") employee.CV.Category = Category.ItSpecialist;
                                        else if (category == "3") employee.CV.Category = Category.Doctor;
                                        else if (category == "4") employee.CV.Category = Category.Teacher;
                                        else if (category == "5") employee.CV.Category = Category.Journalist;
                                        else if (category == "6") employee.CV.Category = Category.Translator;
                                        else
                                        {
                                            Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                            goto cat;
                                        }
                                        Console.WriteLine("City");
                                        Console.WriteLine("1.Baku       : ");
                                        Console.WriteLine("2.Ganja      :");
                                        Console.WriteLine("3.Sumgait    :");
                                        Console.WriteLine("4.Nakhcivan  :");
                                        city:
                                        var city = Console.ReadLine();
                                        if (city == "1") employee.CV.City = City.Baku;
                                        else if (city == "2") employee.CV.City = City.Ganja;
                                        else if (city == "3") employee.CV.City = City.Sumqayit;
                                        else if (city == "4") employee.CV.City = City.Nakhcivan;
                                        else
                                        {
                                            Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                            goto city;
                                        }
                                        Console.Write("Minimum salary    : ");
                                        minSal:
                                        if (int.TryParse(Console.ReadLine(), out int b)) employee.CV.MinimumSalary = b;
                                        else
                                        {
                                            Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                            goto minSal;
                                        }
                                        Console.Write("Phone number      : ");
                                        number:
                                        employee.CV.Number = Console.ReadLine();
                                        if (Tools.NullErrorMessage(employee.CV.Number)) goto number;
                                        Tools.ShowMessage("CV added successfully", ConsoleColor.DarkGreen);
                                        break;
                                    }
                                    break;
                                case "2":
                                    break;
                                case "3":
                                    break;
                                case "4":
                                    Console.WriteLine("Name            : " + employee.CV.Name);
                                    Console.WriteLine("SUrname         : " + employee.CV.Name);
                                    Console.WriteLine("Sex             : " + employee.CV.Name);
                                    Console.WriteLine("Age             : " + employee.CV.Name);
                                    Console.WriteLine("Education       : " + employee.CV.Name);
                                    Console.WriteLine("Work experience : " + employee.CV.Name);
                                    Console.WriteLine("Category        : " + employee.CV.Name);
                                    Console.WriteLine("City            : " + employee.CV.Name);
                                    Console.WriteLine("Minimum salary  : " + employee.CV.Name);
                                    Console.WriteLine("Phone number    : " + employee.CV.Name);
                                    Console.WriteLine("\nEnter any button for going back");
                                    Console.ReadKey();
                                    break;
                                case "5":
                                    break;
                                case "6":
                                    check = true;
                                    break;
                                default:
                                    break;
                            }
                            if (check == true) break;
                        }
                    }
                }
                else if (menu == "2")
                {
                    while (true)
                    {
                        Console.Write("Enter username     : ");
                        var username = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(username))
                        {
                            Tools.ShowMessage("Invalide entry (empty username not accepted), try again :", ConsoleColor.DarkRed);
                            continue;
                        }
                        else if (employees.Exists(x => x.Usename == username))
                        {
                            Tools.ShowMessage("This username exists, try again :", ConsoleColor.DarkRed);
                            continue;
                        }
                        Console.Write("Enter email        : ");
                        var email = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(email))
                        {
                            Tools.ShowMessage("Invalide entry (empty email not accepted), try again :", ConsoleColor.DarkRed);
                            continue;
                        }
                        else if (!Tools.Check.CorrectEmail(email))
                        {
                            Tools.ShowMessage("Invalid email, try again :", ConsoleColor.DarkRed);
                            continue;
                        }
                        Console.Write("Enter password     : ");
                        var password = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(password))
                        {
                            Tools.ShowMessage("Invalide entry (empty password not accepted), try again :", ConsoleColor.Red);
                            continue;
                        }
                        else if (!Tools.Check.CorrectPassword(password))
                        {
                            Tools.ShowMessage("Invalid password, try again :", ConsoleColor.DarkRed);
                            continue;
                        }
                        Console.WriteLine("1. Employer   2. Employee\nChoose your status : ");
                        var status = Console.ReadLine();
                        if (status == "1")
                        {
                            Employer employer = new Employer(username, email, password);
                            employers.Add(employer);
                            Tools.ShowMessage($"Congrulation {employer.Usename} ! Registration is succesfull", ConsoleColor.DarkGreen);
                            Thread.Sleep(2000);
                            while (true)
                            {
                                Console.Clear();
                                bool check = false;
                                Console.WriteLine("1. Add announcement");
                                Console.WriteLine("2. Search employee");
                                Console.WriteLine("3. Search by category");
                                Console.WriteLine("4. Applications");
                                Console.WriteLine("5. Log out");
                                var choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1":
                                        Console.Clear();
                                        while (true)
                                        {
                                            Console.WriteLine("Name of work     : ");
                                            workname:
                                            employer.Announcement.WorkName = Console.ReadLine();
                                            if (Tools.NullErrorMessage(employer.Announcement.WorkName)) goto workname;
                                            Console.WriteLine("2. Name of company  : ");
                                            companyname:
                                            employer.Announcement.WorkName = Console.ReadLine();
                                            if (Tools.NullErrorMessage(employer.Announcement.WorkName)) goto companyname;
                                            Console.WriteLine("Category");
                                            Console.WriteLine("1.Programmer     : ");
                                            Console.WriteLine("2.ItSpecialist   : ");
                                            Console.WriteLine("3.Doctor         : ");
                                            Console.WriteLine("4.Teacher        : ");
                                            Console.WriteLine("5.Journalist     : ");
                                            Console.WriteLine("6.Translator     : ");
                                            cat:
                                            var category = Console.ReadLine();
                                            if (category == "1") employer.Announcement.Category = Category.Programmer;
                                            else if (category == "2") employer.Announcement.Category = Category.ItSpecialist;
                                            else if (category == "3") employer.Announcement.Category = Category.Doctor;
                                            else if (category == "4") employer.Announcement.Category = Category.Teacher;
                                            else if (category == "5") employer.Announcement.Category = Category.Journalist;
                                            else if (category == "6") employer.Announcement.Category = Category.Translator;
                                            else
                                            {
                                                Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                                goto cat;
                                            }
                                            Console.WriteLine("About work       : ");
                                            aboutwork:
                                            employer.Announcement.AboutWork = Console.ReadLine();
                                            if (Tools.NullErrorMessage(employer.Announcement.AboutWork)) goto aboutwork;
                                            Console.WriteLine("City");
                                            Console.WriteLine("1.Baku           : ");
                                            Console.WriteLine("2.Ganja          :");
                                            Console.WriteLine("3.Sumgait        :");
                                            Console.WriteLine("4.Nakhcivan      :");
                                            city:
                                            var city = Console.ReadLine();
                                            if (city == "1") employer.Announcement.City = City.Baku;
                                            else if (city == "2") employer.Announcement.City = City.Ganja;
                                            else if (city == "3") employer.Announcement.City = City.Sumqayit;
                                            else if (city == "4") employer.Announcement.City = City.Nakhcivan;
                                            else
                                            {
                                                Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                                goto city;
                                            }
                                            Console.WriteLine("Salary           : ");
                                            salary:
                                            if (int.TryParse(Console.ReadLine(), out int b)) employer.Announcement.Salary = b;
                                            else
                                            {
                                                Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                                goto salary;
                                            }
                                            Console.WriteLine("Age              : ");
                                            age:
                                            if (int.TryParse(Console.ReadLine(), out int a)) employer.Announcement.Age = a;
                                            else
                                            {
                                                Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                                goto age;
                                            }
                                            Console.WriteLine("Education");
                                            Console.WriteLine("1.Secondary       : ");
                                            Console.WriteLine("2.IncompleteHigher: ");
                                            Console.WriteLine("3.Higher          : ");
                                            education:
                                            var Educ = Console.ReadLine();
                                            if (Educ == "1") employer.Announcement.Education = Education.Secondary;
                                            else if (Educ == "2") employer.Announcement.Education = Education.IncompleteHigher;
                                            else if (Educ == "3") employer.Announcement.Education = Education.Higher;
                                            else
                                            {
                                                Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                                goto education;
                                            }
                                            Console.WriteLine("Work experience");
                                            Console.WriteLine("1.LessThan 1 Year : ");
                                            Console.WriteLine("2.Form 1 to 3 Year:");
                                            Console.WriteLine("3.Form 3 to 5 Year:");
                                            Console.WriteLine("4.MoreThan_5_Year :");
                                            workExp:
                                            var we = Console.ReadLine();
                                            if (we == "1") employer.Announcement.WorkExperience = WorkExperience.LessThan_1_Year;
                                            else if (we == "2") employer.Announcement.WorkExperience = WorkExperience.Form_1_To_3_Year;
                                            else if (we == "3") employer.Announcement.WorkExperience = WorkExperience.Form_3_To_5_Year;
                                            else if (we == "4") employer.Announcement.WorkExperience = WorkExperience.MoreThan_5_Year;
                                            else
                                            {
                                                Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                                goto workExp;
                                            }
                                            Console.WriteLine("Contact number   : ");
                                            number:
                                            employer.Announcement.ContactNumber = Console.ReadLine();
                                            if (Tools.NullErrorMessage(employer.Announcement.ContactNumber)) goto number;
                                            Tools.ShowMessage("Announce added successfully", ConsoleColor.DarkGreen);
                                            break;
                                        }
                                        break;
                                    case "2":
                                        break;
                                    case "3":
                                        break;
                                    case "4":
                                        break;
                                    case "5":
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            }
                            break;
                        }
                        else if (status == "2")
                        {
                            Employee employee = new Employee(username, email, password);
                            employees.Add(employee);
                            Tools.ShowMessage($"Congrulation {employee.Usename}! Registration is succesfull", ConsoleColor.DarkGreen);
                            Thread.Sleep(2000);
                            break;
                        }
                        else
                        {
                            Tools.ShowMessage("Invalid status, try again :", ConsoleColor.DarkRed);
                            continue;
                        }
                    }
                }
                
            }
        }
    }
}
