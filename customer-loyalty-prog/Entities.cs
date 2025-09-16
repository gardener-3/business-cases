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
        public required ShoppingCart Cart { get; set; }
    }

    public class ShoppingCart
    {
        public int CartId { get; set; }
        public decimal TotalCartValue { get; set; }
    }

    public class Reward
    {

        public decimal RewardValue { get; set; }
        public RewardType Type { get; set; }
        public Product? Product { get; set; }
        public enum RewardType
        {
            CashDiscount,
            FreeItem,
        }
    }

    public class Product
    {
        public int ItemId { get; set; }
        public decimal Price { get; set; }

    }

    public class Invoice
    {
        public Reward? Reward { get; set; }
    }

}
