using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Entities;

namespace BankingMVC.Models.Dtos
{
    public class RoleDto
    {
        [Required]
        public string Id{ get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public string Description{ get; set; }
        [Required]
        public ICollection<User> User { get;set; } = new HashSet<User>();
    }

    public class CreateRoleRequestModel
    {
        [Required]
        public string Name{ get; set; }
        [Required]
        public string Description{ get; set; }
    }

    public class UpdateRoleRequestModel
    {
        [Required]
        public string Name{ get; set; }
        [Required]
        public string Description{ get; set; }
    }

}