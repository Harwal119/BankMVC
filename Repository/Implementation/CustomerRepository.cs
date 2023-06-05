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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Context context)
        {
            _context = context;
        }
        public Customer Get(string id)
        {
            return _context.Customers
            .Where(a => a.IsDeleted == false)
            .Include(a => a.User)
            // .ThenInclude(a =>a.Account)
            .SingleOrDefault(a => a.Id == id);
        }

        public Customer Get(Expression<Func<Customer, bool>> expression)
        {
            return _context.Customers
            .Where(a => a.IsDeleted == false)
            .Include(a => a.User)
            .SingleOrDefault(expression);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers
            .Where(a => a.IsDeleted == false)
            .Include(a => a.User)
            .ToList();
        }

        public IEnumerable<Customer> GetSelected(List<string> ids)
        {
            return _context.Customers
            .Where(a =>ids.Contains(a.Id) && a.IsDeleted == false)
            .Include(a => a.User)
            .ToList();
        }

        public IEnumerable<Customer> GetSelected(Expression<Func<Customer, bool>> expression)
        {
            return _context.Customers
            .Where(expression)
            .Include(a => a.User)
            .ToList();
        }
    }
}