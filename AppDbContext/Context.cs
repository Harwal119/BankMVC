using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingMVC.AppDbContext
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) :base(dbContextOptions)
        {

        }

        public DbSet<Customer> Customers { get;set; }
        public DbSet<CustomerTransaction> CustomerTransactions { get;set; }
        public DbSet<Manager> Managers{ get;set; }
        public DbSet<User> Users { get;set; }
        public DbSet<Role> Roles{ get;set; }
        public DbSet<Wallet> Wallets { get;set; }
    }
}