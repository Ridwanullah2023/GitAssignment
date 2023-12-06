using Library_Management_System.Models;
using Library_Management_System.Repository.Implementation;
using Library_Management_System.Repository.Interface;
using Library_Management_System.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Services.Implementation
{
    public class BookServiceImplementation : IBookService
    {
        private static IBookRepository bookRepo = new BookRepositoryImpl();

        public void AddBook(string title, string author, int genre)
        {
            int id = bookRepo.GetBookCount();
            Genre g = GetGenre(genre);

            Book book = new Book
            {
                Id = id,
                Title = title,
                Author = author,
                Genre = g,
                IsAvailable = true
            };

            if (bookRepo.AddBook(book) != null)
            {
                Console.WriteLine("{0} by {1} has been added successfully with id: {2}", book.Title, book.Author, book.Id);

            }
            else
            {
                Console.WriteLine("Unable to add book");
            }
        }

        public void Delete(int id)
        {
            if (bookRepo.Delete(id))
            {
                Console.WriteLine("Book deleted successfully");
            }
            else
            {
                Console.WriteLine("Unable to delete book");
            }
        }

        public List<Book> Filter(string filter)
        {
            return bookRepo.Filter(filter); 
        }

        public List<Book> GetAll()
        {
            return bookRepo.GetAll();
        }

        public List<Book> GetAvailableBook()
        {
            return bookRepo.GetAvailableBook();
        }

        public Book GetBook(int id)
        {
            return bookRepo.GetBook(id);
        }

        public bool IsAvailable(int id)
        {
            return bookRepo.IsAvailableBook(id);
        }

        public void PrintBooks(List<Book> books)
        {
            Console.WriteLine("***Book Information***\n" +
                "ID \t TITLE \t AUTHOR \t GENRE \t STATUS");
            foreach (var b in books)
            {
                b.Print();
            }
        }

        public void Update(int id, string title, string author)
        {
            var book = bookRepo.GetBook(id);
            if(book != null)
            {
                book.Author = author;
                book.Title = title;

                if (bookRepo.Update(id, book) != null)
                {
                    Console.WriteLine("Book information updated successfully");

                }
                else
                {
                    Console.WriteLine("Unable to update information");

                }

            }
            Console.WriteLine("Unable to find book");

        }

        public bool Update(int id, bool status)
        {
            var book = bookRepo.GetBook(id);
            book.IsAvailable = status;
            if(book != null)
            {
                if(bookRepo.Update(id, book) != null)
                {
                    return true;
                }

            }

            return false;
        }

        private Genre GetGenre(int id)
        {
            Genre g = new Genre();
            switch(id)
            {
                case 0:
                    g = Genre.Fiction; break;
                case 1:
                    g= Genre.Horror; break;
                case 2:
                    g = Genre.Educational; break;
                case 3:
                    g= Genre.Romance; break;
                default:
                    Console.WriteLine("Invalid Genre selected");
                    break;
            }
            return g;

        }
    }
}
