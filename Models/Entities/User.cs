using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Enums;

namespace BankingMVC.Models.Entities
{
    public class User :BaseEntity
    {
        public string FirstName{ get;set; }
        public string MiddleName{ get;set; }
        public string LastName{ get;set;}
        public Gender Gender{ get;set; }
        public string Email{ get;set; }
        public string Address{ get;set;}
        public string PhoneNumber{ get;set; }
        public string Pin{ get;set; }
        public string RoleId{ get;set; }
        public Role Role{ get;set; }
        
        // public FormFile ProfilePhoto{ get;set; }
    }
}