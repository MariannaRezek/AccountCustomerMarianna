using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BsynchroTaskMarianna.Models
{
    public class UserAccount
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public double Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}