using System.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingMVC.Models.Enums;

namespace BankingMVC.Models.Entities
{
    public class CustomerTransaction :BaseEntity
    {
        public string CustomerId{ get;set; }
        public Customer Customer{ get;set; }
        public double Amount{ get;set; }
        public DateTime Date{ get;set;} = DateTime.Now;
        public Status Status{ get;set; }
        public TransactionType TransactionType{ get;set; }
        public string RecieverAcctNumber{ get;set; }
    }
}