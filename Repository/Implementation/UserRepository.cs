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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(Context context)
        {
            _context = context;
        }
        public User Get(string id)
        {
            return _context.Users
           .Include(a => a.Role)
           .Where(a => a.IsDeleted == false)
           .SingleOrDefault(a => a.Id == id);
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            return _context.Users
           .Include(a => a.Role)
           .Where(a => a.IsDeleted == false)
           .SingleOrDefault(expression);
        }

        public IEnumerable<User> GetAll()
        {
             return _context.Users
           .Include(a => a.Role)
           .Where(a => a.IsDeleted == false)
           .ToList();
        }

        public List<User> GetSelected(List<string> ids)
        {
            return _context.Users
            .Include(a => a.Role)
            .Where(a => ids.Contains(a.Id) && a.IsDeleted == false)
            .ToList();
        }

        public List<User> GetSelected(Expression<Func<User, bool>> expression)
        {
            return _context.Users
           .Include(a => a.Role)
           .Where(expression)
           .ToList();
        }
    }
}