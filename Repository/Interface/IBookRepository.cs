using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Repository.Interface
{
    public interface IBookRepository
    {
        Book AddBook(Book book);
        Book Update(int id, Book book);
        bool Delete(int id);
        List<Book> GetAll();
        List<Book> GetAvailableBook();
        List<Book> Filter(string filter);
        Book GetBook(int id);
        int GetBookCount();
        bool IsAvailableBook(int id);
    }
}
