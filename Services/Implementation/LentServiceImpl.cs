using Library_Management_System.Models;
using Library_Management_System.Repository.Implementation;
using Library_Management_System.Repository.Interface;
using Library_Management_System.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Management_System.Services.Implementation
{
    public class LentServiceImpl : ILentService
    {
        private static ILentRepository lentRepository = new LentRepositoryImpl();
        private IBookService bookService;
        private IUserService userService;
        public LentServiceImpl()
        {
            bookService = new BookServiceImplementation();
            userService = new UserServiceImpl();
        }
        public void Borrow(int userId, int bookId)
        {
            int id = lentRepository.GetLentCount();
            User user = userService.GetUser(userId);
            if(user != null)
            {
                Book book = bookService.GetBook(bookId);
                if(book != null)
                {
                    if(book.IsAvailable)
                    {
                        if(bookService.Update(id, false))
                        {
                            Lent l = new Lent
                            {
                                Id = id,
                                User = user,
                                Book = book,
                                DateBorrowed = DateTime.Now,
                                isReturned = false,
                                DateReturned = null
                            };
                            if(lentRepository.Borrow(l) != null)
                            {
                                Console.WriteLine("Book borrowed with RefId: {0}", id);
                            }
                            else
                            {
                                Console.WriteLine("Unable to Lend book");

                            }
                           
                        }
                    }
                    else { Console.WriteLine("Book Not available"); }

                }
                else { Console.WriteLine("Book Not found"); }

            }
            else { Console.WriteLine("User Not found"); }
            
        }

        public List<Lent> GetAll()
        {
            return lentRepository.GetAll();
        }

        public List<Lent> GetAllByUser(int userId)
        {
            if(userService.GetUser(userId) != null)
            {
                return lentRepository.GetAllByUser(userId);
            }
            return null;
        }

        public List<Lent> GetAllPendingReturn()
        {
            return lentRepository.GetAllPendingReturn();
        }

        public Lent GetLent(int id)
        {
            return lentRepository.GetLent(id);
        }

        public void PrintLentByUser(List<Lent> lentListByUser)
        {
            Console.WriteLine("***Lent Information***\n" +
                 "Id \t Book Title \t Date Borrowed \t Status \t Date Returned");
            foreach (var l in lentListByUser)
            {
                l.PrintByUser();
            }
        }

        public void PrintLents(List<Lent> lentList)
        {
            Console.WriteLine("***Lent Information***\n" +
                 "Id \t UserName \t Book Title \t Date Borrowed \t Status \t Date Returned");
            foreach (var l in lentList)
            {
                l.Print();
            }
        }

        public void Return(int lentId)
        {
            Lent l = lentRepository.GetLent(lentId);
            if(l != null) { 
                Book b = bookService.GetBook(l.Book.Id);
                if(b != null)
                {
                    l.isReturned = true;
                    l.DateReturned = DateTime.Now;
                    if(lentRepository.Return(lentId, l))
                    {
                        if (bookService.Update(b.Id, true))
                        {
                            Console.WriteLine("Book returned successfuly");

                        }
                        

                    }

                }
                else
                {
                    Console.WriteLine("Unable to return book");

                }

            }
            else
            {
                Console.WriteLine("Unable to find Lent record");

            }
           
        }
    }
}
