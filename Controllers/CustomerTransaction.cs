using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BankingMVC.Controllers
{
    public class CustomerTransaction :Controller
    {
        private readonly ICustomerTransactionService _customerTransactionService;

        public CustomerTransaction(ICustomerTransactionService customerTransactionService)
        {
            _customerTransactionService = customerTransactionService;
        }

        public IActionResult GetAll()
        {
            var customerTransaction = _customerTransactionService.GetAll();
            return View(customerTransaction.Data);
        }

        public IActionResult GetCustomerTransactions(string id)
        {
            var GetCustomerTransaction = _customerTransactionService.GetCustomerTransactions(id);
            return View(GetCustomerTransaction.Data);

        }
    }
}