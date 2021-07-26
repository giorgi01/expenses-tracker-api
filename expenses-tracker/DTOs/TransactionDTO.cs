using ExpensesTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace expenses_tracker.DTOs
{
    public class TransactionDTO
    {
        public double Amount { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
