using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;

namespace BankingMVC.Service.Interface
{
    public interface ICustomerTransactionService
    {
        public BaseResponse<CustomerTransactionDto> Create(string customerId, CreateCustomerTransactionRequestModel model);
        public BaseResponse<CustomerTransactionDto> Get( string id );
        public BaseResponse<IEnumerable<CustomerTransactionDto>> GetAll(); 
        public BaseResponse<List<CustomerTransactionDto>> GetCustomerTransactions(string id);
    }
}