using Library_Management_System.Models;
using Library_Management_System.Services.Implementation;
using Library_Management_System.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Menu
{
    public class MainMenu
    {
        private static IUserService _userService = new UserServiceImpl();

        public void LoadMenu() 
        {
            bool exit = false;
            while(!exit)
            {
                Console.Clear();
                PrintMenu();
                int ops = Convert.ToInt32(Console.ReadLine());
                switch (ops)
                {
                    case 1:
                        User u = new User();
                        Console.WriteLine("Are you a new User?\n" +
                            "1.\t Yes\n" +
                            "2.\t No");
                        int input = Convert.ToInt32(Console.ReadLine());
                        if (input == 1)
                        {
                            Console.WriteLine("Input username");
                            string username = Console.ReadLine();

                            u = _userService.AddUser(username, 1);
                        }
                        else if(input == 2)
                        {
                            Console.WriteLine("Input Your Id");
                            int userId = Convert.ToInt32(Console.ReadLine());
                            User user = _userService.GetUser(userId);
                            if (user != null)
                            {
                                u = user;
                            }
                            else
                            {
                                Console.WriteLine("Invalid user details");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid option selected");
                            break;
                        }
                        UserMenu userMenu = new UserMenu(u);
                        userMenu.LoadMenu();
                        break;
                    case 2:
                        Console.WriteLine("Input Your Id");
                        int id = Convert.ToInt32(Console.ReadLine()); 
                        if(_userService.IsAdmin(id))
                        {
                            User user = _userService.GetUser(id);
                            AdminMenu adminMenu = new AdminMenu(user);
                            adminMenu.LoadMenu();
                            
                        }
                        else
                        {
                            Console.WriteLine("You are not authorized to access this menu");
                        }
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("invalid input\n " +
                            "Press any key to continue..");
                        Console.ReadKey();
                        break;
                }

            }
         


        }

        private void PrintMenu()
        {
            Console.WriteLine("Kindly select the Operation to Perform\n" +
                "1. \t  UserMenu\n" +
                "2. \t AdminMenu\n" +
                "0. \t Exit");


        }
    }
}
