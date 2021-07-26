using ExpensesTracker.Data;
using ExpensesTracker.Models;
using ExpensesTracker.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracker.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Transactions.FindAsync(id);
            if (itemToDelete == null)
            {
                throw new NullReferenceException();
            }
            _context.Transactions.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Transaction> Get(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task Update(Transaction transaction)
        {
            var itemToUpdate = await _context.Transactions.FindAsync(transaction.TransactionId);
            if (itemToUpdate == null)
            {
                throw new NullReferenceException();
            }
            itemToUpdate.TransactionType = transaction.TransactionType;
            itemToUpdate.Amount = transaction.Amount;
            await _context.SaveChangesAsync();
        }
    }
}
