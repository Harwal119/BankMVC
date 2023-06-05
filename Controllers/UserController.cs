using System.Net;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Dtos;
using BankingMVC.Service.Implementation;
using BankingMVC.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BankingMVC.Controllers
{
    public class UserController :Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult Login(LoginUserRequestModel model)
        {
            var user = _userService.Login(model);
            TempData["message"] = user.Message;
            if(user.Status)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Data.Id),
                    new Claim(ClaimTypes.Email, user.Data.Email),
                    new Claim(ClaimTypes.Name, user.Data.FirstName),
                    new Claim(ClaimTypes.HomePhone, user.Data.PhoneNumber)
                };
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsAdd = new   ClaimsPrincipal(claimIdentity);
                HttpContext.SignInAsync(claimsAdd);
                TempData["Successful"] = user.Message;
                
                if(user.Data.Role.Name == "Super-admin")
                {
                    return RedirectToAction("Super");
                }
                else if(user.Data.Role.Name == "Manager")
                {
                    return RedirectToAction("Manager");
                }
                else if(user.Data.Role.Name == "Customer")
                {
                    return RedirectToAction("CUstomer");
                }

            }
            return View();
        }

        public IActionResult Super()
        {
            return View();
        }

        public IActionResult Manager()
        {
            return View();
        }

        public IActionResult Customer()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}