using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;
using BankingMVC.Models.Entities;

namespace BankingMVC.Repository.Interface
{
    public interface IWalletRepository :IBaseRepository<Wallet>
    {
    Wallet Get(string id);
    Wallet Get(Expression<Func<Wallet,bool>> expression);
    IEnumerable<Wallet> GetSelected(List<string> ids);
    Wallet GetbyUserId(string userId);
    IEnumerable<Wallet> GetSelected(Expression<Func<Wallet,bool>> expression);
    IEnumerable<Wallet> GetAll();
    Wallet Add(Wallet wallet);
    }
}