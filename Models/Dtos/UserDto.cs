using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Entities;
using BankingMVC.Models.Enums;

namespace BankingMVC.Models.Dtos
{
    public class UserDto
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
        public string Pin{ get;set; }
        [Required]
        public string RoleId{ get;set; }
        [Required]
        public RoleDto Role{ get;set; }
    }

    public class LoginUserRequestModel
    {
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please enter a valid email address")]
        public string Email{ get;set; }
        [Required]
        public string Pin{ get;set; }
    }
}