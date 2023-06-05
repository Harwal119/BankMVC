using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;
using BankingMVC.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingMVC.Controllers
{
    public class CustomerController :Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        
        [HttpPost]
        public IActionResult Register(CreateCustomerRequestModel model)
        {
            var customer = _customerService.Register(model);
            if(customer is not null)
            {
                TempData["Exist"] = "Passenger created Successfully";
            }
            return RedirectToAction("Login", "User");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(string id)
        {
           var customer = _customerService.Get(id);
            return View(customer.Data);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult RealDelete(string id)
        {
            _customerService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult Get(string id)
        {
            var customer= _customerService.Get(id);
            return View(customer.Data);
        }


        
        [HttpGet]
        public IActionResult GetAll()
        {
            var customer= _customerService.GetAll();
            return View(customer.Data);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update(string id)
        {
            var customer = _customerService.Get(id);
            var model  = new UpdateCustomerRequestModel
            {
                FirstName = customer.Data.FirstName,
                MiddleName = customer.Data.MiddleName,
                LastName = customer.Data.LastName,
                PhoneNumber = customer.Data.PhoneNumber,
                Address = customer.Data.Address,

            };
            return View(model);
        }

        // [Authorize]
        [HttpPost]
        public IActionResult Update(string id,UpdateCustomerRequestModel model)
        {
            
            _customerService.Update(id,model);
            return RedirectToAction("Customer","User");
        }

    }
}