using Library_Management_System.Models;
using Library_Management_System.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Repository.Implementation
{
    public class BookRepositoryImpl : IBookRepository
    {
        private static List<Book> books = new List<Book>();

        public BookRepositoryImpl() {
            books.Add(new Book
            {
                Id = 1,
                Title = "Ada the faithfull girl",
                Author = "Tijani AbdulBasit",
                Genre = Genre.Fiction,
                IsAvailable = true
            });
        
        }

        public Book AddBook(Book book)
        {
            if(book != null)
            {
                books.Add(book);
                return book;
            }
            return null;
            
        }

        public bool Delete(int id)
        {
            Book b = GetBook(id);
            if(b != null)
            {
                books.Remove(b);
                return true;
            }
            return false;
            
        }

        public List<Book> Filter(string filter)
        {
            var query = from book in books
                        where book.Title == filter ||
                        book.Author == filter ||
                        book.Genre.ToString() ==  filter
                        select book;

            return query.ToList();
                        
        }

        public List<Book> GetAll()
        {
            var query = from book in books select book;

            return query.ToList();
        }

        public List<Book> GetAvailableBook()
        {
            var query = from book in books
                        where book.IsAvailable == true
                        select book;

            return query.ToList();
        }

        public Book GetBook(int id)
        {

            return books.Where(b => b.Id == id).FirstOrDefault();
        }

        public int GetBookCount()
        {
            return books.Count() != 0 ? books[books.Count - 1].Id + 1 : 1;
        }

        public bool IsAvailableBook(int id)
        {
          Book b = GetBook(id);
            if (b != null && b.IsAvailable == true)
            {
                return true;
                
            }
            return false;

        }

        public Book Update(int id, Book book)
        {
            if(books.Exists(b=> b.Id == id))
            {
                books[id - 1].Title = book.Title;
                books[id - 1].Author = book.Author;
                books[id - 1].IsAvailable = book.IsAvailable;
                
                return book;
            }

            return null;
        }
    }
}
