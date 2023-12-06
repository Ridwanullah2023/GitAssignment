using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Repository.Interface
{
    public interface ILentRepository
    {
        Lent Borrow(Lent l);
        bool Return(int id, Lent l);
        int GetLentCount();
        List<Lent> GetAll();
        List<Lent> GetAllByUser(int userId);
        List<Lent> GetAllPendingReturn();
        Lent GetLent(int id);
    }
}
