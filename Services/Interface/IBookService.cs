using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Services.Interface
{
    public interface IBookService
    {
        void AddBook(string title, string author, int genre);
        void Update(int id, string title, string author);
        void Delete(int id);
        List<Book> GetAll();
        List<Book> GetAvailableBook();
        List<Book> Filter(string filter);
        Book GetBook(int id);
        bool IsAvailable(int id);
        void PrintBooks(List<Book> books);
        bool Update(int id, bool status);
    }
}
