using Library_Management_System.Services.Implementation;
using Library_Management_System.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Menu
{
    public class BookMenu
    {
        private IBookService _bookService = new BookServiceImplementation();
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
                        Console.WriteLine("Enter Book Title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter Author name");
                        string author = Console.ReadLine();
                        Console.WriteLine("Select Book Genre\n" +
                            "0.\t Fiction\n" +
                            "1. \t Horror\n" +
                            "2. \t Education\n" +
                            "3. \t Romance");
                        int genre =Convert.ToInt32(Console.ReadLine());
                        _bookService.AddBook(title, author, genre);
                        break;
                    case 2:
                        Console.WriteLine("Enter Book Id");
                        int id = Convert.ToInt32(Console.ReadLine());
                        string Newtitle = Console.ReadLine();
                        Console.WriteLine("Enter Author name");
                        string Newauthor = Console.ReadLine();
                        _bookService.Update(id, Newtitle, Newauthor);
                        break;
                    case 3:
                        var res = _bookService.GetAll();
                        if (res != null && res.Count != 0)
                        {
                            _bookService.PrintBooks(res);
                        }
                        else
                        {
                            Console.WriteLine("No book found");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Book Id");
                        int bid = Convert.ToInt32(Console.ReadLine());
                        _bookService.Delete(bid);
                        break;
                    case 5:
                        Console.WriteLine("Enter Book Id");
                        int ids = Convert.ToInt32(Console.ReadLine());
                        var b = _bookService.GetBook(ids);
                        if(b != null)
                        {
                            Console.WriteLine("***Book Information***\n" +
                                "ID \t TITLE \t AUTHOR \t GENRE \t STATUS");
                            b.Print();
                        }
                        else
                        {
                            Console.WriteLine("Book with id {0} does not exist", ids);

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
        public void PrintMenu()
        {
            Console.WriteLine("Kindly select the Operation to Perform\n" +
              "1. \t Add Book\n" +
              "2. \t Update Book\n" +
              "3. \t Get All Books\n" +
              "4. \t Delete Book\n" +
              "5. \t Print Book Detail\n" +
              "0. \t Go back to Admin menu\n");
        }
    }
}
