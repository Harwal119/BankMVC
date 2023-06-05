using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingMVC.Models.Entities
{
    public class Customer :BaseEntity
    {
        public string UserId{ get;set; }
        public User User{ get;set; }
        public ICollection<CustomerTransaction> CustomerTransactions = new HashSet<CustomerTransaction>();

    }
}