using ExpensesTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracker.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> Get(int id);
        Task<IEnumerable<Transaction>> GetAll();
        Task Add(Transaction transaction);
        Task Delete(int id);
        Task Update(Transaction transaction);
    }
}
