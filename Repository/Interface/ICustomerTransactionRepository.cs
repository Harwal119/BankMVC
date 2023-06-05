using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BankingMVC.Models.Entities;

namespace BankingMVC.Repository.Interface
{
    public interface ICustomerTransactionRepository :IBaseRepository<CustomerTransaction>
    {

        CustomerTransaction Get(string id);
        CustomerTransaction Get(Expression<Func<CustomerTransaction,bool>> expression);
        IEnumerable<CustomerTransaction> GetSelected(List<string> ids);
        IEnumerable<CustomerTransaction> GetSelected(string id, string accountnumber);
        IEnumerable<CustomerTransaction> GetSelected(Expression<Func<CustomerTransaction,bool>> expression);
        IEnumerable<CustomerTransaction> GetAll(); 
    }
}