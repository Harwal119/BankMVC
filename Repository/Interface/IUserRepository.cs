using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BankingMVC.Models.Entities;

namespace BankingMVC.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
    User Get(string id);
    User Get(Expression<Func<User, bool>> expression);
    List<User> GetSelected(List<string> ids);
    List<User> GetSelected(Expression<Func<User, bool>> expression);
    IEnumerable<User> GetAll();
    }
}