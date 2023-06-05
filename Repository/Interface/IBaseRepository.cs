using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingMVC.Repository.Interface
{
    public interface IBaseRepository<T>
    {
    int Save();
    T Create (T entity);
    T Update(T entity);
    }
}