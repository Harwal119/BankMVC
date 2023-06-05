using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;
using BankingMVC.Models.Enums;
using BankingMVC.Repository.Interface;
using BankingMVC.Service.Interface;

namespace BankingMVC.Service.Implementation
{
    public class UserService : IUserService
    {
         private readonly IUserRepository _userRepository;

         public UserService(IUserRepository userRepository)
         {
            _userRepository = userRepository;
         }

        public BaseResponse<UserDto> Get(string id)
        {
            var user = _userRepository.Get(id);
            if (user is not null)
            {
                return new BaseResponse<UserDto>
                {
                    Message = "Found",
                    Status = true,
                    Data = new UserDto
                    {
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName,
                        Gender = (int)user.Gender,
                        Email = user.Email,
                        Address = user.Address,
                        Pin = user.Pin,
                        PhoneNumber = user.PhoneNumber
                    }
                };
                
            }
            return new BaseResponse<UserDto>
            {
                Message = "Not Found",
                Status = false
            };
        }

        public BaseResponse<IEnumerable<UserDto>> GetAll()
        {
            var user = _userRepository.GetAll();
            if (user is not null)
            {
                return new BaseResponse<IEnumerable<UserDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = user.Select(n => new UserDto
                    {
                        FirstName = n.FirstName,
                        MiddleName = n.MiddleName,
                        LastName = n.LastName,
                        Gender = (int)n.Gender,
                        Email = n.Email,
                        Address = n.Address,
                        Pin = n.Pin,
                        PhoneNumber = n.PhoneNumber
                    }).ToList()
                    
                };
            }
            return new BaseResponse<IEnumerable<UserDto>>
            {
                Message = " Not Found",
                Status = false
            };
        }

        public BaseResponse<UserDto> Login(LoginUserRequestModel model)
        {
            var getUser = _userRepository.Get(a =>a.Email == model.Email && a.Pin == model.Pin);
            if (getUser is  not null)
            {
                return new BaseResponse<UserDto>
                {
                    Message = "Login Successful",
                    Status = true,
                    Data = new UserDto
                    {
                        Id = getUser.Id,
                        FirstName = getUser.FirstName,
                        LastName = getUser.LastName,
                        Email = getUser.Email,
                        PhoneNumber = getUser.PhoneNumber,
                        Role = new RoleDto{
                            Id = getUser.Role.Id,
                            Name = getUser.Role.Name,
                            Description = getUser.Role.Description
                        },
                    }
                };
    
            }

            return new BaseResponse<UserDto>{
                Message = "Email or Password not correct",
                Status = false
            };
        }
    }
}
