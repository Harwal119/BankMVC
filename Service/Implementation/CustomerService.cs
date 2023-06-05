using System.Net;
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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IRoleRepository _roleRepository;
        

        public CustomerService(ICustomerRepository customerRepository, IUserRepository userRepository,IWalletRepository walletRepository, IRoleRepository roleRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _walletRepository = walletRepository;
            _roleRepository = roleRepository;
        }
        public BaseResponse<CustomerDto> Get(string id)
        {
            var customer = _customerRepository.Get(a =>a.UserId == id || a.Id == id);
            var wallet = _walletRepository.Get(a =>a.UserId == customer.UserId);
            if (customer is not null )
            {
                return new BaseResponse<CustomerDto>
                {
                    Message = "Found",
                    Status = true,
                    Data = new CustomerDto
                    {
                        Id = customer.Id,
                        FirstName = customer.User.FirstName,
                        MiddleName = customer.User.MiddleName,
                        LastName = customer.User.LastName,
                        Email = customer.User.Email,
                        Gender = (int)customer.User.Gender,
                        Address = customer.User.Address,
                        PhoneNumber = customer.User.PhoneNumber,
                        AccountNumber = wallet.AccountNumber,
                    }
                };
            }
            return new BaseResponse<CustomerDto>
            {
                Message = " Not Found ",
                Status = false
            };
        }

        public BaseResponse<IEnumerable<CustomerDto>> GetAll()
        {
            var customer = _customerRepository.GetAll();
            if (customer is not null )
            {
                return new BaseResponse<IEnumerable<CustomerDto>>
                {
                    Message = "Successful",
                    Status = true,
                    Data = customer.Select(c => new CustomerDto
                    {
                        Id = c.Id,
                        FirstName = c.User.FirstName,
                        MiddleName = c.User.MiddleName,
                        LastName = c.User.LastName,
                        Email = c.User.Email,
                        Gender = (int)c.User.Gender,
                        Address = c.User.Address,
                        PhoneNumber = c.User.PhoneNumber,
                    }).ToList()
                };
            }
            return new BaseResponse<IEnumerable<CustomerDto>>
            {
                Message = "Not Successful",
                Status = false
            };
        }

        public BaseResponse<CustomerDto> Register(CreateCustomerRequestModel model)
        {
            var userExist = _userRepository.Get(a => a.Email == model .Email);
            if (userExist != null)
            {
                    return new BaseResponse<CustomerDto>{
                    Message = "Already Exist",
                    Status = false
                };
            }

            
                var role = _roleRepository.Get(r => r.Name == "Customer");

                User user = new User();
                user.FirstName = model.FirstName;
                user.MiddleName = model.MiddleName;
                user.LastName = model.LastName;
                user.Email= model.Email;
                user.Gender = (Gender)model.Gender;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;
                user.CreatedBy = "Manager";
                user.RoleId = role.Id;
                user.Pin = model.Pin;
                _userRepository.Create(user);
                _userRepository.Save();

                

                Wallet wallet = new Wallet
                {
                    AccountBalance = 0,
                    UserId = user.Id,
                    // customer = customer,
                    IsDeleted = false,
                    AccountNumber = GenerateAcctNo(),
                    CreatedBy = "Customer"
                    
                };
               
                 

                Customer customer = new Customer();
                customer.UserId = user.Id;
                customer.CreatedBy = "Manager";
                _customerRepository.Create(customer);
                _walletRepository.Add(wallet);
                _customerRepository.Save();

            

                return new BaseResponse<CustomerDto>
                {
                    Message = "Successfully",
                    Status = true,
                    Data = new CustomerDto
                    {
                        Id = customer.Id,
                        FirstName = customer.User.FirstName,
                        MiddleName = customer.User.MiddleName,
                        LastName = customer.User.LastName,
                        Email = customer.User.Email,
                        Address = customer.User.Address,
                        Gender = (int)customer.User.Gender,
                        PhoneNumber = customer.User.PhoneNumber,
                        
                    }
                };
            
        }

       
        public BaseResponse<CustomerDto> Update(string id, UpdateCustomerRequestModel model)
        {
            var customer = _customerRepository.Get(x => x.UserId == id);
            if (customer is not null)
            {
                customer.User.FirstName = model.FirstName;
                customer.User.MiddleName = model.MiddleName;
                customer.User.LastName = model.LastName;
                customer.User.PhoneNumber = model.PhoneNumber;
                customer.User.Address = model.Address;
                _customerRepository.Update(customer);
                _customerRepository.Save();


                return new BaseResponse<CustomerDto>{
                    Message = "Successful",
                    Status = true,
                    Data = new CustomerDto{
                        FirstName = customer.User.FirstName,
                        MiddleName = customer.User.MiddleName,
                        LastName = customer.User.LastName,
                        Address = customer.User.Address,
                        PhoneNumber = customer.User.PhoneNumber
                    }
                };
            }
            return new BaseResponse<CustomerDto>
            {
                Message = "Not Found ",
                Status = false
            };
        }


        public BaseResponse<CustomerDto> Delete(string id)
        {
            var customerExist = _customerRepository.Get(c => c.Id == id);
            if (customerExist is not null)
            {
                 customerExist.IsDeleted = true;
                _customerRepository.Update(customerExist);
                _customerRepository.Save();

                return new BaseResponse<CustomerDto>()
                {
                    Message = "Deleted Successfully",
                    Status = true
                };
            }
            return new BaseResponse<CustomerDto>()
            {
                Message = "Not Found",
                Status = false
            };
        }

        
        private static string GenerateAcctNo()
        {
            Random rand = new Random();
            return rand.Next(100000000,999999999).ToString();
        }

        
    }
}