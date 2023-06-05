using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;
using BankingMVC.Models.Entities;
using BankingMVC.Repository.Interface;
using BankingMVC.Service.Interface;

namespace BankingMVC.Service.Implementation
{
    public class WalletService : IWalletService
    {
        public readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public BaseResponse<Wallet> CreditWallet(string userId, double amount)
        {
            if (amount < 0)
            {
                return new BaseResponse<Wallet>
                {
                    Message = "Amount must be graeter than Zero",
                    Status = false,
                };
            }

            var wallet = _walletRepository.GetbyUserId(userId);
            wallet.AccountBalance += amount;
            _walletRepository.Update(wallet);
            _walletRepository.Save();
            return new BaseResponse<Wallet>
            {
                Message = "Successful",
                Status = true,
            };
        }

        public BaseResponse<Wallet> DebitWallet(string userId, double amount, string accountNumber)
        {
            var wallet = _walletRepository.GetbyUserId(userId);
            if (wallet.AccountBalance < amount)
            {
                return new BaseResponse<Wallet>
                {
                    Message = "Pls Found ur wallet",
                    Status = false,
                };
            }
            var recipientWallet = _walletRepository.Get(x => x.AccountNumber == accountNumber);
            recipientWallet.AccountBalance += amount;
            wallet.AccountBalance -= amount;
            _walletRepository.Save();
            return new BaseResponse<Wallet>
            {
                Message = "Successful",
                Status = true,
            };
        }

        public BaseResponse<Wallet> Get(string id)
        {
            var wallet = _walletRepository.Get(w => w.UserId == id);
            if (wallet == null)
            {
                return new BaseResponse<Wallet>
                {
                    Message = "Not Found",
                    Status = false,
                };
            }
            return new BaseResponse<Wallet>
            {
                Message = "Found",
                Status = true,
                Data = new Wallet
                {
                    Id = wallet.UserId,
                    AccountBalance = wallet.AccountBalance,
                    AccountNumber = wallet.AccountNumber,
                }
            };
        }

        public BaseResponse<IEnumerable<Wallet>> GetAll()
        {
            throw new NotImplementedException();
        }
        
        public BaseResponse<Wallet> GetbyUserId(string userId)
        {
            var wallet = _walletRepository.Get(w => w.UserId == userId);
            if (wallet == null)
            {
                return new BaseResponse<Wallet>
                {
                    Message = "Not Found",
                    Status = false,
                };
            }
            return new BaseResponse<Wallet>
            {
                Message = "Found",
                Status = true,
                Data = wallet,
            };
        }
    }
}