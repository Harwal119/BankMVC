using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BankingMVC.AppDbContext;
using BankingMVC.Models.Dtos;
using BankingMVC.Models.Entities;
using BankingMVC.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BankingMVC.Repository.Implementation
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(Context context )
        {
            _context = context;
        }
        public Wallet Get(string id)
        {
            return _context .Wallets
            .Where(a => a.IsDeleted == false)
            .Include(a => a.user)
            .SingleOrDefault(a => a.Id == id);
        }

        public Wallet Get(Expression<Func<Wallet, bool>> expression)
        {
            return _context.Wallets
            .Where(a => a .IsDeleted == false)
            .Include(a => a.user)
            // .ThenInclude(a =>a.AccountNumber)
            .SingleOrDefault(expression);
        }

        public IEnumerable<Wallet> GetAll()
        {
            return _context.Wallets
            .Where(a => a.IsDeleted == false)
            .Include(a => a.user)
            .ToList();
        }

        public IEnumerable<Wallet> GetSelected(List<string> ids)
        {
            return _context.Wallets
            .Where(a =>ids.Contains(a.Id) && a.IsDeleted == false)
            .Include(a => a.user)
            .ToList();
        }

        public IEnumerable<Wallet> GetSelected(Expression<Func<Wallet, bool>> expression)
        {
            return _context.Wallets
            .Where(expression)
            .Include( a=> a.user)
            .ToList();
        }

        public Wallet Add(Wallet wallet)
        {
            _context.Set<Wallet>().Add(wallet);
            return wallet;
        }

        public Wallet GetbyUserId(string userId)
        {
           return _context .Wallets
            .Where(a => a.IsDeleted == false)
            .Include(a => a.user)
            .SingleOrDefault(a => a.UserId == userId);
        }
    }
}