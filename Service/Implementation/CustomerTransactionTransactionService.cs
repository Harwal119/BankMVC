using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using BankingMVC.Models.Dtos;
using BankingMVC.Repository.Interface;
using BankingMVC.Service.Interface;

namespace BankingMVC.Service.Implementation
{
    // 519911678782
    public class CustomerTransactionService : ICustomerTransactionService
    {
        private readonly ICustomerTransactionRepository _customerTransactionRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IWalletRepository _walletRepository;

        public CustomerTransactionService(ICustomerTransactionRepository customerTransactionRepository,IWalletRepository walletRepository, ICustomerRepository customerRepository)
        {
            _customerTransactionRepository = customerTransactionRepository;
            _walletRepository =walletRepository;
            _customerRepository = customerRepository;
        }
        public BaseResponse<CustomerTransactionDto> Create(string customerId, CreateCustomerTransactionRequestModel model)
        {
            var customerTransaction = _customerTransactionRepository.Get(customerId);

            if (customerTransaction == null)
            {
                return new BaseResponse<CustomerTransactionDto>{
                    Message = "Transaction Not Found",
                    Status = false,
                };
            }
            var client = _customerTransactionRepository.Get(c => c.CustomerId == customerId);


        var wallet = _walletRepository.Get(w => w.UserId == customerId);
        wallet.AccountBalance -= customerTransaction.Amount;

        if (wallet.AccountBalance < 0)
        {
            return new BaseResponse<CustomerTransactionDto>
            {
                Message = "Insuficient Balance",
                Status = false,
                Data = new CustomerTransactionDto{}
            };
        }


        _customerTransactionRepository.Create(customerTransaction);
        _customerTransactionRepository.Save();

        return new BaseResponse<CustomerTransactionDto>
        {
            Message = "Added Successful",
            Status = true,
            Data = new CustomerTransactionDto
            {

            }
        };

        }

        public BaseResponse<CustomerTransactionDto> Get(string id)
        {
            var customerTransaction = _customerTransactionRepository.Get(id);
            if (customerTransaction == null)
            {
                return new BaseResponse<CustomerTransactionDto>
                {
                    Message = "Not Found",
                    Status = false,
                };
            }
            return new BaseResponse<CustomerTransactionDto>
            {
                Message = "Transaction Found",
                Status = true,
                Data = new CustomerTransactionDto
                {
                    Date = customerTransaction.Date,
                    Status = customerTransaction.Status,
                    Amount = customerTransaction.Amount,
                    TransactionType = customerTransaction.TransactionType,
                }
            };
        }

        public BaseResponse<IEnumerable<CustomerTransactionDto>> GetAll()
        {
            var customerTransaction = _customerTransactionRepository.GetAll();
            if (customerTransaction == null)
            {
                return new BaseResponse<IEnumerable<CustomerTransactionDto>>
                {
                    Message = "Not Found",
                    Status = false,
                };
            }
            return new BaseResponse<IEnumerable<CustomerTransactionDto>>
            {
                Message = "Transaction Found",
                Status = true,
                Data = customerTransaction.Select(c => new CustomerTransactionDto
                {
                    
                    Date = c.Date,
                    Status = c.Status,
                    Amount = c.Amount,
                    TransactionType = c.TransactionType,
                }).ToList()
            };
            
        }

        public BaseResponse<List<CustomerTransactionDto>> GetCustomerTransactions(string id)
        {
            var customer = _customerRepository.Get(x => x.UserId == id);
            if (customer == null)
            {
                return new BaseResponse<List<CustomerTransactionDto>>
                {
                    Message = "Customer Not Found",
                    Status = false,
                };
            }
            var wallet = _walletRepository.Get(x => x.UserId == customer.UserId);
            var customerTransactions = _customerTransactionRepository.GetSelected(id, wallet.AccountNumber);
            if (customerTransactions == null)
            {
                return new BaseResponse<List<CustomerTransactionDto>>
                {
                    Message = "Transaction Not Found",
                    Status = false,
                };
            }
            return new BaseResponse<List<CustomerTransactionDto>>
            {
                Message = "Transaction Successful",
                Status = true,
                Data = customerTransactions.Select(x => new CustomerTransactionDto
                {
                    Date = x.Date,
                    Status = x.Status,
                    Amount = x.Amount,
                    TransactionType = x.TransactionType,
                }).ToList()
            };
        }

       
    }
}