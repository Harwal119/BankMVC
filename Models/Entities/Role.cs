using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingMVC.Models.Entities
{
    public class Role :BaseEntity
    {
        public string Name{ get; set; }
        public string Description{ get; set; }
        public string UserId{ get;set; }
        public ICollection<User> User { get;set; } = new HashSet<User>();
    }
}