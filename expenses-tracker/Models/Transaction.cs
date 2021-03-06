using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracker.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;   
    }
}