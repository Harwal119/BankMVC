using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;
using BankingMVC.Models.Entities;

namespace BankingMVC.Service.Interface
{
    public interface IWalletService
    {
        BaseResponse<IEnumerable<Wallet>> GetAll();
        BaseResponse<Wallet> Get(string id);
        BaseResponse<Wallet> GetbyUserId(string userId);
        BaseResponse<Wallet> DebitWallet(string userId, double amount,string accountNumber);
        BaseResponse<Wallet> CreditWallet(string userId, double amount);
    }
}