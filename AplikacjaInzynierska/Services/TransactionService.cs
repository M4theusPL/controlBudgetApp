using AplikacjaInzynierska.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace AplikacjaInzynierska.Services
{
    public class TransactionService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public TransactionService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        public List<TransactionsClass> displaytransactions()
        {
            return _dbcontext.transactions.ToList();
        }

        public TransactionsClass? GetByTransaction(int id_user_transaction)
        {
            return _dbcontext.transactions.FirstOrDefault(x => x.id_user_transaction == id_user_transaction);
        }

        
        public bool AddNewTransaction(TransactionsClass gc)
        {
            _dbcontext.transactions.Add(gc);
            _dbcontext.SaveChanges();
            return true;
        }
    }
}
