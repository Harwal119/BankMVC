using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;
using BankingMVC.Models.Entities;

namespace BankingMVC.Service.Interface
{
    public interface ICustomerService
    {
        BaseResponse<CustomerDto> Get(string id);
        BaseResponse<IEnumerable<CustomerDto>> GetAll();
        public BaseResponse<CustomerDto> Delete( string id );
        BaseResponse<CustomerDto> Register(CreateCustomerRequestModel model);
        BaseResponse<CustomerDto> Update(string id, UpdateCustomerRequestModel model);
    }
}