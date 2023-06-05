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
    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public BaseResponse<RoleDto> Create(CreateRoleRequestModel model)
        {
            var roleExist = _roleRepository.Get(a => a.Name == model.Name);
            if (roleExist is null)
            {
                Role role = new Role();
                role.Name = model.Name;
                role.Description = model.Description;

                _roleRepository.Create(role);
                _roleRepository.Save();
                return new BaseResponse<RoleDto>
                {
                    Message = $"{model.Name} created",
                    Status = true,
                    Data = new RoleDto
                    {
                        Id = role.Id,
                        Name = role.Name,
                        Description = role.Description
                    }
                };
            }

            return new BaseResponse<RoleDto>
            {
                Message = $"{model.Name} already exist",
                Status = false,
            };  
        }

        public BaseResponse<RoleDto> Delete(string id)
        {
            var role = _roleRepository.Get(id);
            if (role is not null )
            {

                 role.IsDeleted = true;
                _roleRepository.Update(role);
                _roleRepository.Save();
                return new BaseResponse<RoleDto>
                {
                    Message = "Found",
                    Status = true,
                };
            }
            return new BaseResponse<RoleDto>{
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<RoleDto> Get(string id)
        {
            var role = _roleRepository.Get(id);
            if (role is not null)
            {
                return new BaseResponse<RoleDto>
                {
                    Message = "Found",
                    Status = true,
                    Data = new RoleDto
                    {
                        Id =role.Id,
                        Name = role.Name,
                        Description = role.Description
                    }
                };
            }
            return new BaseResponse<RoleDto>
            {
                Message = "Not found",
                Status = false
            };
        }

        public BaseResponse<IEnumerable<RoleDto>> GetAll()
        {
            var role = _roleRepository.GetAll();
            if (role is not null )
            {
                return new BaseResponse<IEnumerable<RoleDto>>
                {
                    Message = "Found",
                    Status = true,
                    Data = role.Select( r => new RoleDto{
                        Id = r.Id,
                        Name = r.Name,
                        Description = r.Description
                    }).ToList()
                };
            }
            return new BaseResponse<IEnumerable<RoleDto>>
            {
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<RoleDto> Update(string id, UpdateRoleRequestModel model)
        {
           var role = _roleRepository.Get(id);
           if (role is not null)
           {
                role.Name = model.Name;
                role.Description = model.Description;

                _roleRepository.Update(role);
                _roleRepository.Save();

                return new BaseResponse<RoleDto>
                {
                    Message = " Found",
                    Status = true,
                    Data = new RoleDto{
                        Id = role.Id,
                        Name = role.Name,
                        Description = role.Description
                    }
                };
           }
           return new BaseResponse<RoleDto>
           {
            Message = "Not Found",
            Status = false
           };
        }
    }
}