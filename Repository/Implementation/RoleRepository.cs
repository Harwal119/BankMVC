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
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(Context context)
        {
            _context = context;
        }
        public Role Get(string id)
        {
            return _context.Roles
            .Where(a => a.IsDeleted == false)
            .Include(a => a.User)
            .SingleOrDefault(a => a.Id == id);
        }

        public Role Get(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles
          .Where(a => !a.IsDeleted)
          .SingleOrDefault(expression);
          //.Include(a => a.User)
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles
            .Where(a => a.IsDeleted ==false)
            .Include(a => a.User)
            .ToList();
        }

        public IEnumerable<Role> GetSelected(List<string> ids)
        {
            return _context.Roles
            .Where(a =>ids.Contains(a.Id) && a.IsDeleted == false)
            .Include(a =>a.User)
            .ToList();
        }

        public IEnumerable<Role> GetSelected(Expression<Func<Role, bool>> expression)
        {
            return _context.Roles
            .Where(expression)
            .Include(a => a.User)
            .ToList();
        }
    }
}