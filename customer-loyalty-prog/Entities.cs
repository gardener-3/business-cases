using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customer_loyalty_prog
{
    public class Customer
    {
        public int ID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NoOfVisits { get; set; }
        public decimal TotalSpending { get; set; }
        public decimal LastInvoice { get; set; }
        public bool IsCakeDay { get; set; }
        public decimal TransactionsPerMonth { get; set; }
    }

    public class Reward
    {

        public decimal RewardValue { get; set; }
        public RewardType Type { get; set; }

        public string? ItemId { get; set; }


        public enum RewardType
        {
            CashDiscount,
            FreeItem,
        }
    }

}
