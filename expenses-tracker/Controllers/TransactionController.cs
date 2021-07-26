using expenses_tracker.DTOs;
using ExpensesTracker.Models;
using ExpensesTracker.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _repo;
        public TransactionController(ITransactionRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> Index()
        {
            var transactions = await _repo.GetAll();
            return Ok(transactions);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Transaction>> Get(int id)
        {
            var transaction = await _repo.Get(id);
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TransactionDTO transactionDTO)
        {
            var transaction = new Transaction
            {
                Amount = transactionDTO.Amount,
                TransactionType = transactionDTO.TransactionType
            };
            await _repo.Add(transaction);
            return Ok();
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repo.Delete(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TransactionDTO transactionDTO)
        {
            var transaction = new Transaction
            {
                TransactionId = id,
                Amount = transactionDTO.Amount,
                TransactionType = transactionDTO.TransactionType
            };
            await _repo.Update(transaction);
            return Ok();
        }


    }
}
