//6y.using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Entities;
using BankingMVC.Models.Enums;

namespace BankingMVC.Models.Dtos
{
    public class CustomerDto
    {
        [Required]
        public string Id{ get;set; }
        [Required]
        public string FirstName{ get;set; }
        [Required]
        public string MiddleName{ get;set; }
        [Required]
        
        public string LastName{ get;set;}
        [Required]
        public int Gender{ get;set; }
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please enter a valid email address")]
        public string Email{ get;set; }
        [Required]
        public string Address{ get;set;}
        [Required]
        [MinLength(11, ErrorMessage ="Enter a valid Phone Number")]
        public string PhoneNumber{ get;set; }
        [Required]
        public string UserId{ get;set; }
        [Required]
        public User User{ get;set; }
        [Required]
        public string AccountNumber{ get; set; }
    }


    public class CreateCustomerRequestModel
    {
        [Required]
        public string FirstName{ get;set; }
        [Required]
        public string MiddleName{ get;set; }
        [Required]
        
        public string LastName{ get;set;}
        [Required]
        public int Gender{ get;set; }
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please enter a valid email address")]
        public string Email{ get;set; }
        [Required]
        public string Address{ get;set;}
        [Required]
        [MinLength(11, ErrorMessage ="Enter a valid Phone Number")]
        public string PhoneNumber{ get;set; }
        [Required]
        public string Pin{ get;set; }
        [Required]
        public AccountType AccountType{ get;set; }
    }
    public class UpdateCustomerRequestModel
    {
        [Required]
        public string FirstName{ get;set; }
        [Required]
        public string MiddleName{ get;set; }
        [Required]
        public string LastName{ get;set;}
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please enter a valid email address")]
        public string Email{ get;set; }
        [Required]
        public string Address{ get;set;}
        [Required]
        [MinLength(11, ErrorMessage ="Enter a valid Phone Number")]
        public string PhoneNumber{ get;set; }
        [Required]
        public string Pin{ get;set; }
    }
}