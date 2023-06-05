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
    public class ManagerController :Controller
    {
        private IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateManagerRequestModel model)
        {
            var manager = _managerService.Create(model);
            if(manager is not null)
            {
                TempData["Exist"] = "Manager created Successfully";
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List()
        {
            var manager = _managerService.GetAll();
            return View(manager.Data);
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var manager = _managerService.Get(id);
            var updateModel  = new UpdateManagerRequestModel
            {
                FirstName = manager.Data.FirstName,
                MiddleName = manager.Data.MiddleName,
                LastName = manager.Data.LastName,
                PhoneNumber = manager.Data.PhoneNumber,
                Address = manager.Data.Address,

            };
            return View(updateModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(string id,UpdateManagerRequestModel model)
        {
            
            _managerService.Update(id,model);
            return RedirectToAction("Register");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Details(string id)
        {
            var manager = _managerService.Get(id);

            return View(manager.Data);
        }
        

        [Authorize]
        [HttpGet]
        public IActionResult Delete (string id)
        {
            return View();
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult ActualDelete (string id)
        {
            _managerService.Delete(id);
            return RedirectToAction("List");
        }
    }
}