using AplikacjaInzynierska.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;
using System.Security.Cryptography;

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

        public List<TransactionsClass> displayGroupSearchTransaction(int id_group, string searchedText)
        {
            var transactionsGroup = _dbcontext.transactions.Where(x => x.id_group == id_group
            && EF.Functions.Like(x.name_transaction, $"%{searchedText}%")
            || EF.Functions.Like(x.description, $"%{searchedText}%")
            || EF.Functions.Like((string?) Convert.ToString(x.amount), $"%{searchedText}%")
            || EF.Functions.Like((string?) (object) x.date_transaction, $"%{searchedText}%")
            || EF.Functions.Like((string?) Convert.ToString(x.id_user_transaction), $"%{searchedText}%")
            ).ToList();
            return transactionsGroup;
        }

        public bool AddNewTransaction(TransactionsClass gc)
        {
            _dbcontext.transactions.Add(gc);
            _dbcontext.SaveChanges();
            return true;
        }

        public double Expenditure(int id_user)
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var lastDayOfMonth = DateTime.DaysInMonth(year, month);
            var startDate = DateTime.Parse(year + "-" + month + "-01 00:00:00.000").ToUniversalTime();
            var endDate = DateTime.Parse(year + "-" + month + "-" + lastDayOfMonth + " 23:59:59.999").ToUniversalTime();
            return _dbcontext.transactions.Where(x => x.id_user == id_user && x.type_transaction == "Wydatek" && x.date_transaction >= startDate && x.date_transaction <= endDate).Sum(x => x.amount);
        }

        public double Proceeds(int id_user)
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var lastDayOfMonth = DateTime.DaysInMonth(year, month);
            var startDate = DateTime.Parse(year + "-" + month + "-01 00:00:00.000").ToUniversalTime();
            var endDate = DateTime.Parse(year + "-" + month + "-" + lastDayOfMonth + " 23:59:59.999").ToUniversalTime();
            return _dbcontext.transactions.Where(x => x.id_user == id_user && x.type_transaction == "Przychód" && x.date_transaction >= startDate && x.date_transaction <= endDate).Sum(r => r.amount);
        }

        public double Investment(int id_user)
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var lastDayOfMonth = DateTime.DaysInMonth(year, month);
            var startDate = DateTime.Parse(year + "-" + month + "-01 00:00:00.000").ToUniversalTime();
            var endDate = DateTime.Parse(year + "-" + month + "-" + lastDayOfMonth + " 23:59:59.999").ToUniversalTime();
            return _dbcontext.transactions.Where(x => x.id_user == id_user && x.type_transaction == "Inwestycja" && x.date_transaction >= startDate && x.date_transaction <= endDate).Sum(r => r.amount);
        }

        public double ExpenditureYear(int id_user)
        {
            var year = DateTime.Now.Year;
            var startDate = DateTime.Parse(year + "-01-01 00:00:00.000").ToUniversalTime();
            var endDate = DateTime.Parse(year + "-12-31 23:59:59.999").ToUniversalTime();
            return _dbcontext.transactions.Where(x => x.id_user == id_user && x.type_transaction == "Wydatek" && x.date_transaction >= startDate && x.date_transaction <= endDate).Sum(x => x.amount);
        }

        public double ProceedsYear(int id_user)
        {
            var year = DateTime.Now.Year;
            var startDate = DateTime.Parse(year + "-01-01 00:00:00.000").ToUniversalTime();
            var endDate = DateTime.Parse(year + "-12-31 23:59:59.999").ToUniversalTime();
            return _dbcontext.transactions.Where(x => x.id_user == id_user && x.type_transaction == "Przychód" && x.date_transaction >= startDate && x.date_transaction <= endDate).Sum(x => x.amount);
        }

        public double InvestmentYear(int id_user)
        {
            var year = DateTime.Now.Year;
            var startDate = DateTime.Parse(year + "-01-01 00:00:00.000").ToUniversalTime();
            var endDate = DateTime.Parse(year + "-12-31 23:59:59.999").ToUniversalTime();
            return _dbcontext.transactions.Where(x => x.id_user == id_user && x.type_transaction == "Inwestycja" && x.date_transaction >= startDate && x.date_transaction <= endDate).Sum(x => x.amount);
        }

        public double ExpenditureGroupMonth(int id_group)
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var lastDayOfMonth = DateTime.DaysInMonth(year, month);
            var startDate = DateTime.Parse(year + "-" + month + "-01 00:00:00.000").ToUniversalTime();
            var endDate = DateTime.Parse(year + "-" + month + "-" + lastDayOfMonth + " 23:59:59.999").ToUniversalTime();
            return _dbcontext.transactions.Where(x => x.id_group == id_group && x.type_transaction == "Wydatek" && x.date_transaction >= startDate && x.date_transaction <= endDate).Sum(x => x.amount);
        }

        public double ProceedsGroupMonth(int id_group)
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var lastDayOfMonth = DateTime.DaysInMonth(year, month);
            var startDate = DateTime.Parse(year + "-" + month + "-01 00:00:00.000").ToUniversalTime();
            var endDate = DateTime.Parse(year + "-" + month + "-" + lastDayOfMonth + " 23:59:59.999").ToUniversalTime();
            return _dbcontext.transactions.Where(x => x.id_group == id_group && x.type_transaction == "Przychód" && x.date_transaction >= startDate && x.date_transaction <= endDate).Sum(x => x.amount);
        }

        public double InvestmentGroupMonth(int id_group)
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var lastDayOfMonth = DateTime.DaysInMonth(year, month);
            var startDate = DateTime.Parse(year+"-"+month+"-01 00:00:00.000").ToUniversalTime();
            var endDate = DateTime.Parse(year+"-"+month+"-"+lastDayOfMonth+" 23:59:59.999").ToUniversalTime();
            return _dbcontext.transactions.Where(x => x.id_group == id_group && x.type_transaction == "Inwestycja" && x.date_transaction >= startDate && x.date_transaction <= endDate).Sum(x => x.amount);
        }

        public double ExpenditureGroupYear(int id_group)
        {
            var year = DateTime.Now.Year;
            var startDate = DateTime.Parse(year + "-01-01 00:00:00.000").ToUniversalTime();
            var endDate = DateTime.Parse(year + "-12-31 23:59:59.999").ToUniversalTime();
            return _dbcontext.transactions.Where(x => x.id_group == id_group && x.type_transaction == "Wydatek" && x.date_transaction >= startDate && x.date_transaction <= endDate).Sum(x => x.amount);
        }

        public double ProceedsGroupYear(int id_group)
        {
            var year = DateTime.Now.Year;
            var startDate = DateTime.Parse(year + "-01-01 00:00:00.000").ToUniversalTime();
            var endDate = DateTime.Parse(year + "-12-31 23:59:59.999").ToUniversalTime();
            return _dbcontext.transactions.Where(x => x.id_group == id_group && x.type_transaction == "Przychód" && x.date_transaction >= startDate && x.date_transaction <= endDate).Sum(x => x.amount);
        }

        public double InvestmentGroupYear(int id_group)
        {
            var year = DateTime.Now.Year;
            var startDate = DateTime.Parse(year + "-01-01 00:00:00.000").ToUniversalTime();
            var endDate = DateTime.Parse(year + "-12-31 23:59:59.999").ToUniversalTime();
            return _dbcontext.transactions.Where(x => x.id_group == id_group && x.type_transaction == "Inwestycja" && x.date_transaction >= startDate && x.date_transaction <= endDate).Sum(x => x.amount);
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

        public bool RemoveTransactionsGroup(int id_user)
        {
            var up = _dbcontext.transactions.Where(u => u.id_user == id_user).ToList();
            if (up != null)
            {
                foreach (var xr in up)
                {
                    xr.id_user = id_user;
                    xr.id_group = 0;
                    xr.date_notification = xr.date_notification.ToUniversalTime().AddDays(1);
                    xr.date_transaction = xr.date_transaction.ToUniversalTime().AddDays(1);
                    _dbcontext.transactions.Update(xr);
                }
                
                
                _dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool AddTransactionGroup(int id_user, int id_group)
        {
            var up = _dbcontext.transactions.Where(u => u.id_user == id_user).ToList();
            if (up != null)
            {
                foreach (var xr in up)
                {
                    xr.id_user = id_user;
                    xr.id_group = id_group;
                    xr.date_notification = xr.date_notification.ToUniversalTime().AddDays(1);
                    xr.date_transaction = xr.date_transaction.ToUniversalTime().AddDays(1);
                    _dbcontext.transactions.Update(xr);
                }
                
                
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