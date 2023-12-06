using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Services.Interface
{
    public interface ILentService
    {
        void Borrow(int userId, int bookId);
        void Return(int lentId);
        List<Lent> GetAll();
        List<Lent> GetAllByUser(int userId);
        List<Lent> GetAllPendingReturn();
        Lent GetLent(int id);
        void PrintLents(List<Lent> lentList);
        void PrintLentByUser(List<Lent> lentListByUser);
    }
}
