using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BankingMVC.AppDbContext;
using BankingMVC.Models.Entities;
using BankingMVC.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BankingMVC.Repository.Implementation
{
    public class CustomerTransactionRepository : BaseRepository<CustomerTransaction>, ICustomerTransactionRepository
    {
        public CustomerTransactionRepository(Context context)
        {
            _context = context;
        }
        public CustomerTransaction Get(string id)
        {
            return _context.CustomerTransactions
            .Where( a => a.IsDeleted == false)
            .Include(a => a.Customer)
            .SingleOrDefault(a => a.Id == id);
        }

        public CustomerTransaction Get(Expression<Func<CustomerTransaction, bool>> expression)
        {
            return _context.CustomerTransactions
            .Where(a => a.IsDeleted == false)
            .Include( a => a.Customer)
            .SingleOrDefault(expression);
        }

        public IEnumerable<CustomerTransaction> GetAll()
        {
            return _context.CustomerTransactions
            .Where(a => a.IsDeleted == false)
            .Include(a => a.Customer)
            .ToList();
        }

        public IEnumerable<CustomerTransaction> GetSelected(List<string> ids)
        {
            return _context.CustomerTransactions
            .Where(a =>ids.Contains(a.Id) && a.IsDeleted == false)
            .Include(a => a.Customer)
            .ToList();
        }

        public IEnumerable<CustomerTransaction> GetSelected(Expression<Func<CustomerTransaction, bool>> expression)
        {
            return _context.CustomerTransactions
            .Where(expression)
            .Include(a => a.Customer)
            .ToList();
        }
        public IEnumerable<CustomerTransaction> GetSelected(string id, string accountnumber)
        {
            return _context.CustomerTransactions
            .Where(x => x.CustomerId == id || x.RecieverAcctNumber == accountnumber)
            .Include(a => a.Customer)
            .ToList();
        }
    }
}