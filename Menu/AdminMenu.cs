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
    public class AdminMenu
    {
        private IUserService _userService;
        private ILentService _lentService;
        private User _user;

        public AdminMenu(User u)
        {
            _userService = new UserServiceImpl();
            _lentService = new LentServiceImpl();
            _user = u;
        }

        public void LoadMenu()
        {
            bool exit = false;
            while (!exit)
            {
                PrintMenu();
                int ops = Convert.ToInt32(Console.ReadLine());
                switch (ops)
                {
                    case 1:
                        Console.WriteLine("Input username");
                        string username = Console.ReadLine();

                        if (_userService.AddUser(username, 0) != null)
                        {
                            Console.WriteLine("Admin User added successfully");
                        }
                        else
                        {
                            Console.WriteLine("Unable to add Admin");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter User Id to Delete");
                        int id = Convert.ToInt32(Console.ReadLine());
                        _userService.RemoveUser(id);
                        break;
                    case 3:
                        var result = _userService.GetUsers();
                        if (result != null)
                        {
                            _userService.PrintUsers(result);
                        }else { Console.WriteLine("No user found");
                        }
                        break;
                    case 4:
                        BookMenu bookMenu = new BookMenu();
                        bookMenu.LoadMenu();
                        break;
                    case 5:
                        var lentHistory = _lentService.GetAll();
                        if(lentHistory != null)
                        {
                            _lentService.PrintLents(lentHistory);
                        }
                        else
                        {
                            Console.WriteLine("No lent history found");
                        }
                        break;
                    case 6:
                        var pendings = _lentService.GetAllPendingReturn();
                        if (pendings != null && pendings.Count != 0)
                        {
                            _lentService.PrintLents(pendings);
                        }
                        else
                        {
                            Console.WriteLine("No pendings found");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Input reference id");
                        int reference = Convert.ToInt32(Console.ReadLine());
                        var l = _lentService.GetLent(reference);
                        if(l != null)
                        {
                            Console.WriteLine("***Lent Information***\n" +
                            "Id \t UserName \t Book Title \t Date Borrowed \t Status \t Date Returned");
                            l.Print();
                        }
                        else
                        {
                            Console.WriteLine("Lent information not found");

                        }
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Wrong input");
                        break;

                }

            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("Kindly select the Operation to Perform\n" +
              "1. \t Add Admin\n" +
              "2. \t Delete User\n" +
              "3. \t Get All Users\n" +
              "4. \t BookManagement\n" +
              "5. \t Get All Lent History\n" +
              "6. \t Get All Pending Returned\n" +
              "7. \t Print Lent Information\n" +
              "0. \t Go back to main menu\n");
        } 
    }
}
