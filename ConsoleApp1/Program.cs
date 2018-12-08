using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SearchingSystem
{
    class Program
    {
        static List<Employee> employees = new List<Employee>();
        static List<Employer> employers = new List<Employer>();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = false;
            
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
                        Tools.EmployeeMenu(employees, employers, userIndex);
                    }
                    else if (userType == 2)
                    {
                        if (!employers.Exists(x => x.Password == password))
                        {
                            Tools.ShowMessage("Wrong password, try again", ConsoleColor.DarkRed);
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
