using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;

namespace BankingMVC.Service.Interface
{
    public interface IRoleService
    {
        BaseResponse<RoleDto> Create(CreateRoleRequestModel model);
        BaseResponse<RoleDto> Update(string id, UpdateRoleRequestModel model);
        BaseResponse<RoleDto> Get(string id);
        BaseResponse<IEnumerable<RoleDto>> GetAll();
        BaseResponse<RoleDto> Delete(string id);
    }
}