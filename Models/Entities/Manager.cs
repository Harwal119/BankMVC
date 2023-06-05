using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingMVC.Models.Entities
{
    public class Manager :BaseEntity
    {
        public string UserId{ get;set; }
        public User User{ get;set; }

        public string ManagerRegNo{ get;set; } //= GenerateStaffRegNumber();

       
    }
}