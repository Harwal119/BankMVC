using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BankingMVC.AppDbContext;
using BankingMVC.Models.Entities;
using BankingMVC.Repository.Interface;

namespace BankingMVC.Repository.Implementation
{
    public class BaseRepository<T> :IBaseRepository<T> where T: BaseEntity, new()
    {
        protected Context _context;

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}