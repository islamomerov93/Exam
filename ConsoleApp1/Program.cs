using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SearchingSystem
{
    class Program
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Thread ATThread = new Thread(Tools.AnimatedHeader);
            ATThread.Start("Welcome to Islam's job seraching system :)  ");
            List<Employee> employees = new List<Employee>();
            List<Employer> employers = new List<Employer>();
            if (File.Exists("Employers.json") && File.Exists("Employees.json"))
            {
                string JsonEmployers = File.ReadAllText("Employers.json");
                employers = JsonConvert.DeserializeObject<List<Employer>>(JsonEmployers);
                string jsonEmployees = File.ReadAllText("Employees.json");
                employees = JsonConvert.DeserializeObject<List<Employee>>(jsonEmployees);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" ___________________________________________");
                Console.WriteLine("|             ||             ||             |");
                Console.WriteLine("|  1.Sign in  ||  2.Sign up  ||  3.Log out  |");
                Console.WriteLine("|_____________||_____________||_____________|");
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
                        logger.Error("Wrong username entry");
                        Tools.ShowMessage("There is not like username, try again", ConsoleColor.Red);
                        Thread.Sleep(2000);
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
                            logger.Error($"User {username} : Wrong password entry");
                            Tools.ShowMessage("Wrong password, try again", ConsoleColor.Red);
                            goto menu1_2;
                        }
                        Tools.EmployeeMenu(employees, employers, userIndex);
                    }
                    else if (userType == 2)
                    {
                        if (!employers.Exists(x => x.Password == password))
                        {
                            logger.Error($"User {username} : Wrong password entry");
                            Tools.ShowMessage("Wrong password, try again", ConsoleColor.Red);
                            goto menu1_2;
                        }
                        Tools.EmployerMenu(employers, employees, userIndex);
                    }
                }
                #endregion
                #region Sign_Up
                else if (menu == "2")
                {
                    Tools.Registration(employees, employers);
                    Console.Clear();
                    continue;
                }
                #endregion
                #region Exit
                else if (menu == "3")
                {
                    Tools.ShowMessage("You are welcome", ConsoleColor.Green);
                    string JsonEmployer = JsonConvert.SerializeObject(employers);
                    File.WriteAllText("Employers.json", JsonEmployer);
                    string JsonEmployee = JsonConvert.SerializeObject(employees);
                    File.WriteAllText("Employees.json", JsonEmployee);
                    Thread.Sleep(2000);
                    break;
                }
                #endregion
                else
                {
                    Tools.ShowMessage("Invalid imput, enter again", ConsoleColor.Red);
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            Environment.Exit(0);
        }
    }
}
