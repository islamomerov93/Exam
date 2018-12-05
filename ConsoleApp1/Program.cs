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
                Console.Write("Enter username     : ");
                var username = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(username))
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
                    break;
                }
                else if (status == "2")
                {
                    Employee employee = new Employee(username, email, password);
                    employees.Add(employee);
                    Tools.ShowMessage($"Congrulation {employee.Usename}! Registration is succesfull", ConsoleColor.DarkGreen);
                    Thread.Sleep(2000);
                    while (true)
                    {
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
                                    Console.Write("Name            : ");
                                    name:;
                                    employee.CV.Name = Console.ReadLine();
                                    if (Tools.NullErrorMessage(employee.CV.Name)) goto name;
                                    Console.Write("Surname         : ");
                                    surname:;
                                    employee.CV.Surname = Console.ReadLine();
                                    if (Tools.NullErrorMessage(employee.CV.Surname)) goto surname;
                                    Console.WriteLine("Sex");
                                    Console.Write("1.Male/2.Female): ");
                                    sex:;
                                    var sex = Console.ReadLine();
                                    if (sex == "1") employee.CV.Sex = "Male";
                                    else if (sex == "2") employee.CV.Sex = "Female";
                                    else Tools.ShowMessage("Invalide value",ConsoleColor.Red);
                                    Console.Write("Age             : ");
                                    age:;
                                    try
                                    {
                                        employee.CV.Age = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Tools.ShowMessage("Enter correct number", ConsoleColor.DarkRed);
                                        goto age;
                                    }
                                    Console.Write("Education       : ");
                                    employee.CV.Name = Console.ReadLine();
                                    Console.Write("Work experience : ");
                                    employee.CV.Name = Console.ReadLine();
                                    Console.Write("Category        : ");
                                    employee.CV.Name = Console.ReadLine();
                                    Console.Write("City            : ");
                                    employee.CV.Name = Console.ReadLine();
                                    Console.Write("Minimum salary  : ");
                                    employee.CV.Name = Console.ReadLine();
                                    Console.Write("Phone number    : ");
                                    employee.CV.Name = Console.ReadLine();
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
                            case "6":
                                break;
                            default:
                                break;
                        }
                        break;
                    }
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
