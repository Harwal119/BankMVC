using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BankingMVC.Models.Entities;

namespace BankingMVC.Repository.Interface
{
    public interface IManagerRepository :IBaseRepository<Manager>
    {
    Manager Get(string id);
    Manager Get(Expression<Func<Manager,bool>> expression);
    IEnumerable<Manager> GetSelected(List<string> ids);
    IEnumerable<Manager> GetSelected(Expression<Func<Manager,bool>> expression);
    IEnumerable<Manager> GetAll();
    }
}