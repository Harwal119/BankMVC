using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;

namespace BankingMVC.Service.Interface
{
    public interface IAccountService
    {
        BaseResponse<AccountDto> Get(string id);
        BaseResponse<IEnumerable<AccountDto>> GetAll();
    }
}