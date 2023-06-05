using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Entities;
using BankingMVC.Models.Enums;

namespace BankingMVC.Models.Dtos
{
    public class CustomerTransactionDto
    {
        [Required]
        public string CustomerId{ get;set; }
        [Required]
        public Customer Customer{ get;set; }
        [Required]
        public double Amount{ get;set; }
        [Required]
        public DateTime Date{ get;set;}
        [Required]
        public Status Status{ get;set; }
        [Required]
        public TransactionType TransactionType{ get;set; }
    }

    public class CreateCustomerTransactionRequestModel
    {
        [Required]
        public string CustomerId{ get;set; }
        [Required]
        public Status Status{ get;set; }
        [Required]
        public double Amount{ get;set; }
    }
}