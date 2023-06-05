using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Entities;

namespace BankingMVC.Models.Dtos
{
    public class WalletDto
    {
        [Required]
        public  string Id{ get;set; }
        [Required]
        public string customerId{ get;set; }
        [Required]
        public Customer Customer{ get;set; }
        [Required]
       public int WalletPassword{ get;set;}
       [Required]
       public double AccountBalance{ get; set; }

    //    shockyou7
    }

    

    public class UpdateWalletRequestModel
    {
        [Required]
        public int WalletPassword{ get;set;}
    }
}