using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingMVC.Models.Entities
{
    public class Wallet :BaseEntity
    {
        public string UserId{ get;set; }
        public User user{ get;set; }
        public double Amount{ get;set; }
       public double AccountBalance{ get; set; } 
       public string AccountNumber{ get;set; } 
    }
}