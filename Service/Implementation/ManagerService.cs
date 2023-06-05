using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;
using BankingMVC.Models.Entities;
using BankingMVC.Models.Enums;
using BankingMVC.Repository.Interface;
using BankingMVC.Service.Interface;

namespace BankingMVC.Service.Implementation
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public ManagerService(IManagerRepository managerRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _managerRepository = managerRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }
        public BaseResponse<ManagerDto> Create(CreateManagerRequestModel model)
        {
            var managerExist = _userRepository.Get(a =>a.Email == model.Email);
            if (managerExist != null)
            {
                        return new BaseResponse<ManagerDto>
                    {
                        Message = "Manager already exist",
                        Status = false,
                    };

            }
            var role = _roleRepository.Get(r => r.Name == "Manager");

                User user = new User{
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Email =  model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Pin=model.Pin,
                    Gender = (Gender)model.Gender,
                    RoleId = role.Id,
                    CreatedBy = "Super-admin"
                };
                Manager manager = new Manager();
                manager.UserId = user.Id;
                manager.CreatedBy = "Sper-admin";
                manager.ManagerRegNo  = GenerateEmploymentNumber();
                _userRepository.Create(user);
                _managerRepository.Create(manager);
                _managerRepository.Save();

                return new BaseResponse<ManagerDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new ManagerDto
                    {
                        Id = manager.Id,
                        UserId = manager.UserId,
                    }
                };
        
        }


         

        public BaseResponse<ManagerDto> Delete(string id)
        {
            var manager = _managerRepository.Get(id);
            if (manager == null)
            {
                return new BaseResponse<ManagerDto>
                {
                    Message = "Not Found",
                    Status = false,
                };
            }

            manager.IsDeleted = true;
            _managerRepository.Update(manager);
            _managerRepository.Save();

            return new BaseResponse<ManagerDto>
            {
                Message = "Successful",
                Status = true
            };
        }



       

        public BaseResponse<ManagerDto> Get(string id)
        {
            var manager = _managerRepository.Get(id);
            if (manager == null)
            {
                return new BaseResponse<ManagerDto>
                {
                    Message = " manager already exist",
                    Status = false,
                };
            }
            return new BaseResponse<ManagerDto>
            {
                Message = "Successful",
                Status = true,
                Data = new ManagerDto
                {
                    Id = manager.Id,
                    Address = manager.User.Address,
                    FirstName = manager.User.FirstName,
                    MiddleName = manager.User.MiddleName,
                    LastName = manager.User.LastName,
                    Email = manager.User.Email,
                    PhoneNumber = manager.User.PhoneNumber,
                    User = manager.User
                }
            };
        }

        public BaseResponse<IEnumerable<ManagerDto>> GetAll()
        {
            var manager = _managerRepository.GetAll();
            if (manager is not null)
            {
                return new BaseResponse<IEnumerable<ManagerDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = manager.Select(m => new ManagerDto
                    {
                        Id = m.Id,
                        UserId = m.UserId,
                        FirstName = m.User.FirstName,
                        MiddleName = m.User.MiddleName,
                        LastName = m.User.LastName,
                        Email = m.User.Email,
                        Address = m.User.Address,
                        PhoneNumber = m.User.PhoneNumber,
                        Gender = (int)m.User.Gender,
                    }).ToList()
                };
            }
            return new BaseResponse<IEnumerable<ManagerDto>>
            {
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<ManagerDto> Update(string id, UpdateManagerRequestModel model)
        {
            var manager = _managerRepository.Get(id);
            if (manager is not null)
            {
                manager.Id = model.Id;
                manager.UserId = model.FirstName;
                manager.User.MiddleName = model.MiddleName;
                manager.User.LastName = model.LastName;
                manager.User.Address = model.Address;
                _managerRepository.Update(manager);
                _managerRepository.Save();

                return new BaseResponse<ManagerDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new ManagerDto
                    {
                        FirstName = manager.User.FirstName,
                        MiddleName = manager.User.MiddleName,
                        LastName = manager.User.LastName,
                        PhoneNumber = manager.User.PhoneNumber,
                        Address = manager.User.Address,
                    }
                };
            }
            return new BaseResponse<ManagerDto>
            {
                Message = "Not Found",
                Status = false,
            };
        }

         private string GenerateEmploymentNumber(){
            var staffs = _managerRepository.GetAll();
            return $"MNG/0000{staffs.Count() + 1}";
        }
    }
}