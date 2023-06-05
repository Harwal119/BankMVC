using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BankingMVC.Models.Entities;

namespace BankingMVC.Repository.Interface
{
    public interface ICustomerRepository :IBaseRepository<Customer>
    {
        Customer Get(string id);
        Customer Get(Expression<Func<Customer,bool>> expression);
        IEnumerable<Customer> GetSelected(List<string> ids);
        IEnumerable<Customer> GetSelected(Expression<Func<Customer,bool>> expression);
        IEnumerable<Customer> GetAll(); 
    }
}