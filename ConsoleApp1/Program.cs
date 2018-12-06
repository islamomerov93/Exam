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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = false;
            List<Employee> employees = new List<Employee>();
            List<Employer> employers = new List<Employer>();
            while (true)
            {
                Console.WriteLine("1.Sign in || 2.Sign up || 3.Log out");
                var menu = Console.ReadLine();
                #region Sign_In
                if (menu == "1")
                {
                    int userType;
                    int userIndex;
                    Console.Write("Username : ");
                    var username = Console.ReadLine();
                    if ((userIndex = employees.FindIndex(x => x.Usename == username)) != -1) userType = 1;
                    else if ((userIndex = employers.FindIndex(x => x.Usename == username)) != -1) userType = 2;
                    else
                    {
                        Tools.ShowMessage("There is not like username, try again", ConsoleColor.DarkRed);
                        Console.Clear();
                        continue;
                    }
                    Console.Write("Password : ");
                    menu1_2:
                    var password = Console.ReadLine();
                    if (userType == 1)
                    {
                        if (!employees.Exists(x => x.Password == password))
                        {
                            Tools.ShowMessage("Wrong password, try again", ConsoleColor.DarkRed);
                            goto menu1_2;
                        }
                        else
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
                                        if (employees[userIndex].CV != null)
                                        {
                                            Tools.ShowMessage("You have CV already", ConsoleColor.DarkRed);
                                            Thread.Sleep(2000);
                                            continue;
                                        }
                                        while (true)
                                        {
                                            employees[userIndex].CV = new CV();
                                            Console.Write("Name              : ");
                                            name:
                                            employees[userIndex].CV.Name = Console.ReadLine();
                                            if (Tools.NullErrorMessage(employees[userIndex].CV.Name)) goto name;
                                            Console.Write("Surname           : ");
                                            surname:
                                            employees[userIndex].CV.Surname = Console.ReadLine();
                                            if (Tools.NullErrorMessage(employees[userIndex].CV.Surname)) goto surname;
                                            Console.WriteLine("Sex");
                                            Console.Write("1.Male/2.Female)  : ");
                                            sex:
                                            var sex = Console.ReadLine();
                                            if (sex == "1") employees[userIndex].CV.Sex = Sex.Male;
                                            else if (sex == "2") employees[userIndex].CV.Sex = Sex.Female;
                                            else
                                            {
                                                Tools.ShowMessage("Invalide value", ConsoleColor.Red);
                                                goto sex;
                                            }
                                            Console.Write("Age               : ");
                                            age:
                                            if (int.TryParse(Console.ReadLine(), out int a)) employees[userIndex].CV.Age = a;
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
                                            if (Educ == "1") employees[userIndex].CV.Education = Education.Secondary;
                                            else if (Educ == "2") employees[userIndex].CV.Education = Education.IncompleteHigher;
                                            else if (Educ == "3") employees[userIndex].CV.Education = Education.Higher;
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
                                            if (we == "1") employees[userIndex].CV.WorkExperience = WorkExperience.LessThan_1_Year;
                                            else if (we == "2") employees[userIndex].CV.WorkExperience = WorkExperience.Form_1_To_3_Year;
                                            else if (we == "3") employees[userIndex].CV.WorkExperience = WorkExperience.Form_3_To_5_Year;
                                            else if (we == "4") employees[userIndex].CV.WorkExperience = WorkExperience.MoreThan_5_Year;
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
                                            if (category == "1") employees[userIndex].CV.Category = Category.Programmer;
                                            else if (category == "2") employees[userIndex].CV.Category = Category.ItSpecialist;
                                            else if (category == "3") employees[userIndex].CV.Category = Category.Doctor;
                                            else if (category == "4") employees[userIndex].CV.Category = Category.Teacher;
                                            else if (category == "5") employees[userIndex].CV.Category = Category.Journalist;
                                            else if (category == "6") employees[userIndex].CV.Category = Category.Translator;
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
                                            if (city == "1") employees[userIndex].CV.City = City.Baku;
                                            else if (city == "2") employees[userIndex].CV.City = City.Ganja;
                                            else if (city == "3") employees[userIndex].CV.City = City.Sumqayit;
                                            else if (city == "4") employees[userIndex].CV.City = City.Nakhcivan;
                                            else
                                            {
                                                Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                                goto city;
                                            }
                                            Console.Write("Minimum salary    : ");
                                            minSal:
                                            if (int.TryParse(Console.ReadLine(), out int b)) employees[userIndex].CV.MinimumSalary = b;
                                            else
                                            {
                                                Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                                goto minSal;
                                            }
                                            Console.Write("Phone number      : ");
                                            number:
                                            employees[userIndex].CV.Number = Console.ReadLine();
                                            if (Tools.NullErrorMessage(employees[userIndex].CV.Number)) goto number;
                                            Tools.ShowMessage("CV added successfully", ConsoleColor.DarkGreen);
                                            break;
                                        }
                                        break;
                                    case "2":
                                        break;
                                    case "3":
                                        break;
                                    case "4":
                                        if (employees[userIndex].CV == null)
                                        {
                                            Tools.ShowMessage("You don't have CV yet", ConsoleColor.DarkRed);
                                            Thread.Sleep(2000);
                                            continue;
                                        }
                                        Console.WriteLine("Name            : " + employees[userIndex].CV.Name);
                                        Console.WriteLine("SUrname         : " + employees[userIndex].CV.Name);
                                        Console.WriteLine("Sex             : " + employees[userIndex].CV.Name);
                                        Console.WriteLine("Age             : " + employees[userIndex].CV.Name);
                                        Console.WriteLine("Education       : " + employees[userIndex].CV.Name);
                                        Console.WriteLine("Work experience : " + employees[userIndex].CV.Name);
                                        Console.WriteLine("Category        : " + employees[userIndex].CV.Name);
                                        Console.WriteLine("City            : " + employees[userIndex].CV.Name);
                                        Console.WriteLine("Minimum salary  : " + employees[userIndex].CV.Name);
                                        Console.WriteLine("Phone number    : " + employees[userIndex].CV.Name);
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
                    else if (userType == 2)
                    {
                        if (!employers.Exists(x => x.Password == password))
                        {
                            Tools.ShowMessage("Wrong password, try again", ConsoleColor.DarkRed);
                            goto menu1_2;
                        }
                        else
                        {
                            Console.Clear();
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
                                        while (true)
                                        {
                                            Console.WriteLine("Name of work     : ");
                                            workname:
                                            employers[userIndex].Announcement.WorkName = Console.ReadLine();
                                            if (Tools.NullErrorMessage(employers[userIndex].Announcement.WorkName)) goto workname;
                                            Console.WriteLine("2. Name of company  : ");
                                            companyname:
                                            employers[userIndex].Announcement.WorkName = Console.ReadLine();
                                            if (Tools.NullErrorMessage(employers[userIndex].Announcement.WorkName)) goto companyname;
                                            Console.WriteLine("Category");
                                            Console.WriteLine("1.Programmer     : ");
                                            Console.WriteLine("2.ItSpecialist   : ");
                                            Console.WriteLine("3.Doctor         : ");
                                            Console.WriteLine("4.Teacher        : ");
                                            Console.WriteLine("5.Journalist     : ");
                                            Console.WriteLine("6.Translator     : ");
                                            cat:
                                            var category = Console.ReadLine();
                                            if (category == "1") employers[userIndex].Announcement.Category = Category.Programmer;
                                            else if (category == "2") employers[userIndex].Announcement.Category = Category.ItSpecialist;
                                            else if (category == "3") employers[userIndex].Announcement.Category = Category.Doctor;
                                            else if (category == "4") employers[userIndex].Announcement.Category = Category.Teacher;
                                            else if (category == "5") employers[userIndex].Announcement.Category = Category.Journalist;
                                            else if (category == "6") employers[userIndex].Announcement.Category = Category.Translator;
                                            else
                                            {
                                                Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                                goto cat;
                                            }
                                            Console.WriteLine("About work       : ");
                                            aboutwork:
                                            employers[userIndex].Announcement.AboutWork = Console.ReadLine();
                                            if (Tools.NullErrorMessage(employers[userIndex].Announcement.AboutWork)) goto aboutwork;
                                            Console.WriteLine("City");
                                            Console.WriteLine("1.Baku           : ");
                                            Console.WriteLine("2.Ganja          :");
                                            Console.WriteLine("3.Sumgait        :");
                                            Console.WriteLine("4.Nakhcivan      :");
                                            city:
                                            var city = Console.ReadLine();
                                            if (city == "1") employers[userIndex].Announcement.City = City.Baku;
                                            else if (city == "2") employers[userIndex].Announcement.City = City.Ganja;
                                            else if (city == "3") employers[userIndex].Announcement.City = City.Sumqayit;
                                            else if (city == "4") employers[userIndex].Announcement.City = City.Nakhcivan;
                                            else
                                            {
                                                Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                                goto city;
                                            }
                                            Console.WriteLine("Salary           : ");
                                            salary:
                                            if (int.TryParse(Console.ReadLine(), out int b)) employers[userIndex].Announcement.Salary = b;
                                            else
                                            {
                                                Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                                goto salary;
                                            }
                                            Console.WriteLine("Age              : ");
                                            age:
                                            if (int.TryParse(Console.ReadLine(), out int a)) employers[userIndex].Announcement.Age = a;
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
                                            if (Educ == "1") employers[userIndex].Announcement.Education = Education.Secondary;
                                            else if (Educ == "2") employers[userIndex].Announcement.Education = Education.IncompleteHigher;
                                            else if (Educ == "3") employers[userIndex].Announcement.Education = Education.Higher;
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
                                            if (we == "1") employers[userIndex].Announcement.WorkExperience = WorkExperience.LessThan_1_Year;
                                            else if (we == "2") employers[userIndex].Announcement.WorkExperience = WorkExperience.Form_1_To_3_Year;
                                            else if (we == "3") employers[userIndex].Announcement.WorkExperience = WorkExperience.Form_3_To_5_Year;
                                            else if (we == "4") employers[userIndex].Announcement.WorkExperience = WorkExperience.MoreThan_5_Year;
                                            else
                                            {
                                                Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                                goto workExp;
                                            }
                                            Console.WriteLine("Contact number   : ");
                                            number:
                                            employers[userIndex].Announcement.ContactNumber = Console.ReadLine();
                                            if (Tools.NullErrorMessage(employers[userIndex].Announcement.ContactNumber)) goto number;
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
                        }
                    }
                }
                #endregion
                #region SIgn_Up
                else if (menu == "2")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Registration");
                        Console.Write("Enter username     : ");
                        username:
                        var username = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(username))
                        {
                            Tools.ShowMessage("Invalide entry (empty username not accepted), try again :", ConsoleColor.DarkRed);
                            goto username;
                        }
                        else if (employees.Exists(x => x.Usename == username))
                        {
                            Tools.ShowMessage("This username exists, try again :", ConsoleColor.DarkRed);
                            goto username;
                        }
                        Console.Write("Enter email        : ");
                        email:
                        var email = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(email))
                        {
                            Tools.ShowMessage("Invalide entry (empty email not accepted), try again :", ConsoleColor.DarkRed);
                            goto email;
                        }
                        else if (!Tools.Check.CorrectEmail(email))
                        {
                            Tools.ShowMessage("Invalid email, try again :", ConsoleColor.DarkRed);
                            goto email;
                        }
                        Console.Write("Enter password     : ");
                        password:
                        var password = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(password))
                        {
                            Tools.ShowMessage("Invalide entry (empty password not accepted), try again :", ConsoleColor.Red);
                            goto password;
                        }
                        else if (!Tools.Check.CorrectPassword(password))
                        {
                            Tools.ShowMessage("Invalid password, try again :", ConsoleColor.DarkRed);
                            goto password;
                        }
                        Console.WriteLine("1. Employer   2. Employee\nChoose your status : ");
                        status:
                        var status = Console.ReadLine();
                        if (status == "1")
                        {
                            Employer employer = new Employer(username, email, password);
                            employers.Add(employer);
                            Tools.ShowMessage($"Congrulation {employer.Usename} ! Registration is succesfull", ConsoleColor.DarkGreen);
                            Thread.Sleep(2000);
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
                            goto status;
                        }
                    }
                    Console.Clear();
                    continue;
                }
                #endregion
                #region Exit
                else if (menu == "3")
                {
                    Tools.ShowMessage("You are welcome", ConsoleColor.DarkGreen);
                    Thread.Sleep(2000);
                    break;
                }
                #endregion
                else
                {
                    Tools.ShowMessage("Invalid imput, enter again", ConsoleColor.DarkRed);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }
    }
}
