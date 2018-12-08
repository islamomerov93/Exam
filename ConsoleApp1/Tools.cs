using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;

namespace SearchingSystem
{
    class Tools
    {
        public static class Check
        {
            public static bool CorrectEmail(string email)
            {
                return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            }
            public static bool CorrectPassword(string password)
            {
                return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
            }
            public static bool CorrectNumber(string number)
            {
                return Regex.IsMatch(number, @"^[50|51|55|70|77]{2}[0-9]{7}$");
            }
        }
        public static void ShowMessage(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Yellow; ;
        }
        public static bool NullErrorMessage(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Tools.ShowMessage("Invalide entry (empty field not accepted), try again :", ConsoleColor.Red);
                return true;
            }
            return false;
        }
        public static void AnimatedHeader(object tmp)
        {
            string main = tmp as string;
            var title = "";
            for (int i = 0; i < main.Length; i++)
            {
                title += main[i];
                Console.Title = title;
                Thread.Sleep(100);
            }

        }
        public static string GenerateConfirmationCode()
        {
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder();
            again:
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            if (!Regex.IsMatch(result.ToString(), @"^[a-zA-Z0-9]+$")) goto again;
            return result.ToString();
        }
        public static void EmployeeMenu(List<Employee> employees, List<Employer> employers, int userIndex)
        {
            while (true)
            {
                Console.Clear();
                bool check = false;
                Console.WriteLine("1. Write CV");
                Console.WriteLine("2. Works that correspond to Cv");
                Console.WriteLine("3. Search a job by category");
                Console.WriteLine("4. CV information");
                Console.WriteLine("5. All job announcements");
                Console.WriteLine("6. Aplied jobs");
                Console.WriteLine("7. Log out");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        if (employees[userIndex].CV != null)
                        {
                            Tools.ShowMessage("You have CV already", ConsoleColor.Red);
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
                                Tools.ShowMessage("Enter correct number", ConsoleColor.Red);
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
                                Tools.ShowMessage("Enter correct number", ConsoleColor.Red);
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
                                Tools.ShowMessage("Enter correct number", ConsoleColor.Red);
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
                                Tools.ShowMessage("Enter correct number", ConsoleColor.Red);
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
                                Tools.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto city;
                            }
                            Console.Write("Minimum salary    : ");
                            minSal:
                            if (int.TryParse(Console.ReadLine(), out int b)) employees[userIndex].CV.MinimumSalary = b;
                            else
                            {
                                Tools.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto minSal;
                            }
                            Console.Write("Phone number      : ");
                            number:
                            employees[userIndex].CV.Number = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(employees[userIndex].CV.Number))
                            {
                                Tools.ShowMessage("Invalide entry (empty number not accepted), try again :", ConsoleColor.Red);
                                goto number;
                            }
                            else if (!Tools.Check.CorrectNumber(employees[userIndex].CV.Number))
                            {
                                Tools.ShowMessage("Invalid number, try again :", ConsoleColor.Red);
                                goto number;
                            }
                            Tools.ShowMessage("CV added successfully", ConsoleColor.Green);
                            Thread.Sleep(2000);
                            break;
                        }
                        continue;
                    case "2":
                        if (employees[userIndex].CV == null)
                        {
                            ShowMessage("You don't have CV yet", ConsoleColor.Red);
                            Thread.Sleep(2000);
                            continue;
                        }
                        employees[userIndex].AnnouncesForCV(employers);
                        Console.ReadKey();
                        continue;
                    case "3":
                        employees[userIndex].AnnouncesByCategory(employers);
                        continue; ;
                    case "4":
                        if (employees[userIndex].CV == null)
                        {
                            ShowMessage("You don't have CV yet", ConsoleColor.Red);
                            Thread.Sleep(2000);
                            continue;
                        }
                        employees[userIndex].ShowCV();
                        Console.ReadKey();
                        continue;
                    case "5":
                        anons:
                        int i = 0;
                        foreach (var employer in employers)
                        {
                            foreach (var announce in employer.announces) Console.WriteLine($"{i}. announce.Category");
                        }
                        int.TryParse(Console.ReadLine(), out int id);
                        foreach (var employer in employers)
                        {
                            foreach (var announce in employer.announces)
                            {
                                if (announce.ID == id)
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
                                    Console.WriteLine("Apply for job (Y/N)");
                                    choice:
                                    Console.Write("Answer : ");
                                    var apply = Console.ReadLine().ToLower();
                                    if (apply == "y")
                                    {
                                        employer.Apply[id].Add(employees[userIndex].CV);
                                        employees[userIndex].announceIDs.Add(announce.ID);
                                        ShowMessage("CV sended successfully", ConsoleColor.Green);
                                        Thread.Sleep(2000);
                                        continue;
                                    }
                                    else if (apply == "n")
                                    {
                                        Console.Clear();
                                        goto anons;
                                    }
                                    else
                                    {
                                        ShowMessage("Invalid imput, enter again", ConsoleColor.Red);
                                        goto choice;
                                    }
                                }
                            }
                        }
                        continue;
                    case "6":
                        int o = 1;
                        foreach (var employer in employers)
                        {
                            var result = from z in employees[userIndex].announceIDs
                                         join t in employer.announces on z equals t.ID
                                         select t;
                            if (result != null)
                            {
                                foreach (var item in result)
                                {
                                    Console.WriteLine($"Announce number {o++}");
                                    Console.WriteLine($"Name of work                     : {item.WorkName}");
                                    Console.WriteLine($"Name of Company                  : {item.CompanyName}");
                                    Console.WriteLine($"Category of work                 : {item.Category}");
                                    Console.WriteLine($"Description about work           : {item.AboutWork}");
                                    Console.WriteLine($"City                             : {item.City}");
                                    Console.WriteLine($"Required mininun age             : {item.Age}");
                                    Console.WriteLine($"Required mininun education level : {item.Education}");
                                    Console.WriteLine($"Required mininun work experience : {item.WorkExperience}");
                                    Console.WriteLine($"Salary                           : {item.Salary}");
                                    Console.WriteLine($"Contact number                   : {item.ContactNumber}\n");
                                }
                             }
                        }
                        Console.ReadKey();
                        continue;
                    case "7":
                        check = true;
                        break;
                    default:
                        Console.Clear();
                        Tools.ShowMessage("Invalid imput, enter again", ConsoleColor.Red);
                        continue;
                }
                if (check == true) break;
            }
        }
        public static void EmployerMenu(List<Employer> employers, List<Employee> employees, int userIndex)
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                EmployerMenu:
                bool check = false;
                Console.WriteLine("1. Add announcement");
                Console.WriteLine("2. Search employee");
                Console.WriteLine("3. Applications");
                Console.WriteLine("4. Log out");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        while (true)
                        {
                            Announcement announce = new Announcement();
                            Console.WriteLine("Name of work     : ");
                            workname:
                            announce.WorkName = Console.ReadLine();
                            if (Tools.NullErrorMessage(announce.WorkName)) goto workname;
                            Console.WriteLine("2. Name of company  : ");
                            companyname:
                            announce.WorkName = Console.ReadLine();
                            if (Tools.NullErrorMessage(announce.WorkName)) goto companyname;
                            Console.WriteLine("Category");
                            Console.WriteLine("1.Programmer     : ");
                            Console.WriteLine("2.ItSpecialist   : ");
                            Console.WriteLine("3.Doctor         : ");
                            Console.WriteLine("4.Teacher        : ");
                            Console.WriteLine("5.Journalist     : ");
                            Console.WriteLine("6.Translator     : ");
                            cat:
                            var category = Console.ReadLine();
                            if (category == "1") announce.Category = Category.Programmer;
                            else if (category == "2") announce.Category = Category.ItSpecialist;
                            else if (category == "3") announce.Category = Category.Doctor;
                            else if (category == "4") announce.Category = Category.Teacher;
                            else if (category == "5") announce.Category = Category.Journalist;
                            else if (category == "6") announce.Category = Category.Translator;
                            else
                            {
                                Tools.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto cat;
                            }
                            Console.WriteLine("About work       : ");
                            aboutwork:
                            announce.AboutWork = Console.ReadLine();
                            if (Tools.NullErrorMessage(announce.AboutWork)) goto aboutwork;
                            Console.WriteLine("City");
                            Console.WriteLine("1.Baku           : ");
                            Console.WriteLine("2.Ganja          :");
                            Console.WriteLine("3.Sumgait        :");
                            Console.WriteLine("4.Nakhcivan      :");
                            city:
                            var city = Console.ReadLine();
                            if (city == "1") announce.City = City.Baku;
                            else if (city == "2") announce.City = City.Ganja;
                            else if (city == "3") announce.City = City.Sumqayit;
                            else if (city == "4") announce.City = City.Nakhcivan;
                            else
                            {
                                Tools.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto city;
                            }
                            Console.WriteLine("Salary           : ");
                            salary:
                            if (int.TryParse(Console.ReadLine(), out int b)) announce.Salary = b;
                            else
                            {
                                Tools.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto salary;
                            }
                            Console.WriteLine("Age              : ");
                            age:
                            if (int.TryParse(Console.ReadLine(), out int a)) announce.Age = a;
                            else
                            {
                                Tools.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto age;
                            }
                            Console.WriteLine("Education");
                            Console.WriteLine("1.Secondary       : ");
                            Console.WriteLine("2.IncompleteHigher: ");
                            Console.WriteLine("3.Higher          : ");
                            education:
                            var Educ = Console.ReadLine();
                            if (Educ == "1") announce.Education = Education.Secondary;
                            else if (Educ == "2") announce.Education = Education.IncompleteHigher;
                            else if (Educ == "3") announce.Education = Education.Higher;
                            else
                            {
                                Tools.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto education;
                            }
                            Console.WriteLine("Work experience");
                            Console.WriteLine("1.LessThan 1 Year : ");
                            Console.WriteLine("2.Form 1 to 3 Year:");
                            Console.WriteLine("3.Form 3 to 5 Year:");
                            Console.WriteLine("4.MoreThan_5_Year :");
                            workExp:
                            var we = Console.ReadLine();
                            if (we == "1") announce.WorkExperience = WorkExperience.LessThan_1_Year;
                            else if (we == "2") announce.WorkExperience = WorkExperience.Form_1_To_3_Year;
                            else if (we == "3") announce.WorkExperience = WorkExperience.Form_3_To_5_Year;
                            else if (we == "4") announce.WorkExperience = WorkExperience.MoreThan_5_Year;
                            else
                            {
                                Tools.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto workExp;
                            }
                            Console.WriteLine("Contact number   : ");
                            number:
                            announce.ContactNumber = Console.ReadLine();
                            if (Tools.NullErrorMessage(announce.ContactNumber)) goto number;
                            ++announce.ID;
                            employers[userIndex].Apply[announce.ID] = null;
                            employers[userIndex].announces.Add(announce);
                            Tools.ShowMessage("Announce added successfully", ConsoleColor.Green);
                            break;
                        }
                        break;
                    case "2":
                        employers[userIndex].CVsByAnnounces(employees, userIndex);
                        break;
                    case "3":
                        foreach (var item in employers[userIndex].Apply)
                        {
                            if (item.Key != null)
                            {
                                foreach (var i in item.Value)
                                {
                                    Console.WriteLine("Name            : " + i.Name);
                                    Console.WriteLine("SUrname         : " + i.Surname);
                                    Console.WriteLine("Sex             : " + i.Sex);
                                    Console.WriteLine("Age             : " + i.Age);
                                    Console.WriteLine("Education       : " + i.Education);
                                    Console.WriteLine("Work experience : " + i.WorkExperience);
                                    Console.WriteLine("Category        : " + i.Category);
                                    Console.WriteLine("City            : " + i.City);
                                    Console.WriteLine("Minimum salary  : " + i.MinimumSalary);
                                    Console.WriteLine("Phone number    : " + i.Number);
                                }
                            }
                        }
                        break;
                    case "4":
                        check = true;
                        break;
                    default:
                        Console.Clear();
                        Tools.ShowMessage("Invalid imput, enter again", ConsoleColor.Red);
                        goto EmployerMenu;
                }
                if (check == true) break;
            }
        }
        public static void Registration(List<Employee> employees, List<Employer> employers)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Registration");
                Console.Write("Enter username       : ");
                username:
                var username = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(username))
                {
                    ShowMessage("Invalide entry (empty username not accepted), try again :", ConsoleColor.Red);
                    goto username;
                }
                else if (employees.Exists(x => x.Usename == username))
                {
                    ShowMessage("This username already exists, try again :", ConsoleColor.Red);
                    goto username;
                }
                Console.Write("Enter email          : ");
                email:
                var email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email))
                {
                    ShowMessage("Invalide entry (empty email not accepted), try again :", ConsoleColor.Red);
                    goto email;
                }
                else if (!Check.CorrectEmail(email))
                {
                    ShowMessage("Invalid email, try again :", ConsoleColor.Red);
                    goto email;
                }
                Console.Write("Enter password       : ");
                password1:
                var password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(password))
                {
                    ShowMessage("Invalide entry (empty password not accepted), try again :", ConsoleColor.Red);
                    goto password1;
                }
                else if (!Check.CorrectPassword(password))
                {
                    ShowMessage("Invalid password, try again :", ConsoleColor.Red);
                    goto password1;
                }
                Console.Write("Enter password again : ");
                password2:
                var password2 = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(password2))
                {
                    ShowMessage("Invalide entry (empty password not accepted), try again :", ConsoleColor.Red);
                    goto password1;
                }
                else if (password != password2)
                {
                    ShowMessage("Password didn't match, try again :", ConsoleColor.Red);
                    goto password2;
                }
                Console.WriteLine("Cofirmation code");
                confirm:
                var ConfirmmationCode = Tools.GenerateConfirmationCode();
                Console.WriteLine($"Code                 : {ConfirmmationCode}");
                Console.Write("Code                 : ");
                var confirm = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(confirm))
                {
                    Tools.ShowMessage("Invalide entry (empty code not accepted), try again :", ConsoleColor.Red);
                    goto confirm;
                }
                else if (confirm != ConfirmmationCode)
                {
                    ShowMessage("Invalid code, try again :", ConsoleColor.Red);
                    goto confirm;
                }
                Console.Clear();
                Console.WriteLine("1. Employer   2. Employee\nChoose your status : ");
                status:
                var status = Console.ReadLine();
                if (status == "1")
                {
                    Employer employer = new Employer(username, email, password);
                    employers.Add(employer);
                    ShowMessage($"Congrulation {employer.Usename} ! Registration is succesfull", ConsoleColor.Green);
                    Thread.Sleep(2000);
                    Console.Clear();
                    EmployerMenu(employers, employees, employers.IndexOf(employer));
                    break;
                }
                else if (status == "2")
                {
                    Employee employee = new Employee(username, email, password);
                    employees.Add(employee);
                    ShowMessage($"Congrulation {employee.Usename}! Registration is succesfull", ConsoleColor.Green);
                    Thread.Sleep(2000);
                    Console.Clear();
                    EmployeeMenu(employees, employers, employees.IndexOf(employee));
                    break;
                }
                else
                {
                    Tools.ShowMessage("Invalid status, try again :", ConsoleColor.Red);
                    goto status;
                }
            }
        }
    }
}
