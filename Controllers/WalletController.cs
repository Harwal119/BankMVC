using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BankingMVC.Controllers
{
    public class WalletController : Controller
    {
        private readonly IWalletService _walletService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WalletController(IWalletService walletService, IHttpContextAccessor httpContextAccessor)
        {
            _walletService = walletService;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreditWallet(string id)
        {
            var wallet = _walletService.GetbyUserId(id);
            return View(wallet.Data);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreditWallet(double amount)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (amount <= 0)
            {
                ModelState.AddModelError("Amount", "amount must be greater than Zero");
            }
            if (ModelState.IsValid)
            {
                var response = _walletService.CreditWallet(userId, amount);

                if (response.Status != false) return RedirectToAction("Customer", "User");
            }
            else
            {
                var wallet = _walletService.GetbyUserId(userId);
                return View(wallet.Data);
            }
            return View();
        }

        [Authorize]

        public IActionResult Get(string id)
        {
            var wallet = _walletService.Get(id);
            return View(wallet.Data);
        }


        [Authorize]
        [HttpGet]
        public IActionResult DebitWallet(string id)
        {
            var wallet = _walletService.GetbyUserId(id);
            return View(wallet.Data);
        }

        [Authorize]
        [HttpPost]
        public IActionResult DebitWallet(string id, double amount, string accountNumber)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (amount <= 0)
            {
                ModelState.AddModelError("Amount", "amount must be less than Zero");
            }
            if (ModelState.IsValid)
            {
                _walletService.DebitWallet(id, amount, accountNumber);
                return RedirectToAction("Customer", "User");
            }
            else
            {
                var wallet = _walletService.GetbyUserId(id);
                return View(wallet.Data);
            }
        }

    }
}