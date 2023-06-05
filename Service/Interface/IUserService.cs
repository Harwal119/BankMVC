using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;

namespace BankingMVC.Service.Interface
{
    public interface IUserService
    {
        BaseResponse<UserDto> Login(LoginUserRequestModel model);
        BaseResponse<UserDto> Get(string id);
        BaseResponse<IEnumerable<UserDto>> GetAll();
    }
}