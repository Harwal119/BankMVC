using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Entities;
using BankingMVC.Models.Enums;

namespace BankingMVC.Models.Dtos
{
    public class AccountDto
    {
        public string Id{ get;set; }
        [Required]
        public string CustomerId{ get;set; }
        [Required]
        public Customer Customer{ get;set; }
        [Required]
        public AccountType AccountType{ get;set; }
        [Required]
        public string AccountNumber{ get;set; }
    }
}