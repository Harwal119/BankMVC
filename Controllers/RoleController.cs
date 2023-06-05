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
    public class RoleController :Controller
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(CreateRoleRequestModel model)
        {
            
            if (ModelState.IsValid)
            {
                var response = _roleService.Create(model);
                TempData["message"] = response.Message;
                if (response.Status)
                {
                    return RedirectToAction("List");
                }

            }
            return View(model);
        }


        [Authorize]
        [HttpGet]
        public IActionResult Delete (string id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ActualDelete (string id)
        {
            _roleService.Delete(id);
            return RedirectToAction("List");
        }


        [Authorize]
        [HttpGet]
        public IActionResult Details(string id)
        {
            var role = _roleService.Get(id);

            return View(role.Data);
        }

        [Authorize]
        [HttpGet]
        public IActionResult List()
        {
            var roles = _roleService.GetAll();
            return View(roles.Data);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        

        [Authorize]
        [HttpPost]
        public IActionResult Update(UpdateRoleRequestModel roleModel)
        {
            return View();
        }
    }
}