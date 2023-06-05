using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;

namespace BankingMVC.Service.Interface
{
    public interface IManagerService
    {
        BaseResponse<ManagerDto> Get(string id);
        BaseResponse<ManagerDto> Create(CreateManagerRequestModel model);
        BaseResponse<ManagerDto> Update( string id, UpdateManagerRequestModel model);
        BaseResponse<ManagerDto> Delete(string id);
        BaseResponse<IEnumerable<ManagerDto>> GetAll();
    }
}