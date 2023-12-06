using System;
using Library_Management_System.Models;
using Library_Management_System.Services.Implementation;
using Library_Management_System.Services.Interface;

namespace Library_Management_System.Menu
{
    public class UserMenu
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly ILentService _lentService;

        private readonly User _user;

        public UserMenu(User u) {
            _userService = new UserServiceImpl();
            _bookService = new BookServiceImplementation();
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
                        Console.WriteLine("Input new username");
                        string newUsername = Console.ReadLine();
                        _userService.UpdateUser(_user.Id, newUsername);
                        break;
                   case 2:
                       User u =  _userService.GetUser(_user.Id);
                        if (u != null) {
                            u.PrintUser();
                        }
                        else
                        { 
                            Console.WriteLine("Details not found"); 
                        }
                       break;
                   case 3:
                        Console.WriteLine("You can either search for a book with the Title, Author " +
                            "or Genre\n Kindly input your search term");
                        string filter = Console.ReadLine();
                        var results = _bookService.Filter(filter);
                        if (results != null && results.Count != 0)
                        {
                            
                            _bookService.PrintBooks(results);
                        }
                        else
                        {
                            Console.WriteLine("No results found");
                        }
                        break;
                    case 4:
                        var availablebooks = _bookService.GetAvailableBook();
                        if(availablebooks != null && availablebooks.Count != 0)
                        {
                            _bookService.PrintBooks(availablebooks);
                            Console.WriteLine("Input Id of the book");
                            int bookId = Convert.ToInt32(Console.ReadLine());
                            _lentService.Borrow(_user.Id, bookId);

                        }
                        else
                        {
                            Console.WriteLine("No available books");
                        }
                        
                        break;
                    case 5:
                        var history = _lentService.GetAllByUser(_user.Id);
                        if (history != null && history.Count != 0)
                        {
                            _lentService.PrintLentByUser(history);
                        }
                        else
                        {
                            Console.WriteLine("No history for {0}", _user.Username);
                        }
                        break;
                    case 6:
                        var result = _bookService.GetAvailableBook();
                        if (result != null && result.Count != 0)
                        {
                            _bookService.PrintBooks(result);
                        }
                        else
                        {
                            Console.WriteLine("No available book found");
                        }
                        break;
                    case 7:
                        var response = _bookService.GetAll();
                        if (response != null && response.Count != 0)
                        {
                            _bookService.PrintBooks(response);
                        }
                        else
                        {
                            Console.WriteLine("No book found");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Input Lent Reference Id");
                        int reference = Convert.ToInt32(Console.ReadLine());
                        _lentService.Return(reference);
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

        private static void PrintMenu()
        {
            Console.WriteLine("Kindly select the Operation to Perform\n" +
              "1. \t Update information\n" +
              "2. \t Print my Information\n" +
              "3. \t Search for a book\n" +
              "4. \t Lend a book\n" +
              "5. \t Get all my History\n" +
              "6. \t Get All Available books\n" +
              "7. \t Get All Books\n" +
              "8. \t Return Book\n" +
              "0. \t Go back to main menu\n");
        }
    }
}
