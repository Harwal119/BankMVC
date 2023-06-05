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
    public class ManagerRepository : BaseRepository<Manager>, IManagerRepository
    {
        public ManagerRepository(Context context)
        {
            _context = context;
        }
        public Manager Get(string id)
        {
            return _context.Managers
            .Where(a => a.IsDeleted == false)
            .Include( a => a.User)
            // .Include(a =>a.ManagerRegNo)
            .SingleOrDefault(a => a.Id == id);
        }

        public Manager Get(Expression<Func<Manager, bool>> expression)
        {
           return _context.Managers
           .Where( a => a.IsDeleted == false)
           .Include( a => a.User)
        //    .Include(a =>a.ManagerRegNo)
           .SingleOrDefault(expression);
        }

        public IEnumerable<Manager> GetAll()
        {
            return _context.Managers
            .Where(m => m.IsDeleted== false)
            .Include(m => m.User)
            // .Include(a =>a.ManagerRegNo)
            .ToList();
        }

        public IEnumerable<Manager> GetSelected(List<string> ids)
        {
            return _context.Managers
            .Where(m =>ids.Contains(m.Id) && m.IsDeleted == false)
            .Include(m => m.User)
            // .Include(a =>a.ManagerRegNo)
            .ToList();
        }

        public IEnumerable<Manager> GetSelected(Expression<Func<Manager, bool>> expression)
        {
           return _context.Managers
           .Where(expression)
           .Include(m => m.User)
        //    .Include(a =>a.ManagerRegNo)
           .ToList();
        }
    }
}