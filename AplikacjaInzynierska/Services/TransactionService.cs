using AplikacjaInzynierska.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;

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

        public TransactionsClass? GetByUserTransactions(int id_user)
        {
            return _dbcontext.transactions.FirstOrDefault(x => x.id_user == id_user);
        }

        public List<TransactionsClass> displayUserTransaction(int id_user)
        {
            var transactions = _dbcontext.transactions.Where(x => x.id_user == id_user).ToList();
            return transactions;
        }

        public TransactionsClass? GetByGroupTransactions(int id_group)
        {
            return _dbcontext.transactions.FirstOrDefault(x => x.id_group == id_group);
        }

        public List<TransactionsClass> displayGroupTransaction(int id_group)
        {
            var transactionsGroup = _dbcontext.transactions.Where(x => x.id_group == id_group).ToList();
            return transactionsGroup;
        }

        public bool AddNewTransaction(TransactionsClass gc)
        {
            _dbcontext.transactions.Add(gc);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool EditTransaction(TransactionsClass gc)
        {
            var up = _dbcontext.transactions.Where(u => u.id_user_transaction == gc.id_user_transaction).First();
            if (up != null)
            {
                up.name_transaction = gc.name_transaction;
                up.description = gc.description;
                up.amount = gc.amount;
                up.date_transaction = gc.date_transaction.ToUniversalTime().AddDays(1);
                up.type_transaction = gc.type_transaction;
                up.name_notification = gc.name_notification;
                up.description_notification = gc.description_notification;
                up.date_notification = gc.date_notification.ToUniversalTime().AddDays(1);
                up.time_notification = gc.time_notification;

                _dbcontext.transactions.Update(up);
                _dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteTransaction(int id_user_transaction)
        {
            var up = _dbcontext.transactions.Where(u => u.id_user_transaction == id_user_transaction).First();
            if(up != null)
            {
                _dbcontext.transactions.Remove(up);
                _dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}