using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customer_loyalty_prog
{
    public interface IRewardStrategy
    {
        Reward? DetermineReward(Customer customer);
    }

    public class RegularCustomerRewardStrategy : IRewardStrategy
    {
        private int _minVisits;
        private decimal _discountPercentage;
        public RegularCustomerRewardStrategy(int minVisits, decimal discountPercentage /* refactor this as a type*/)
        {
            _minVisits = minVisits;
            _discountPercentage = discountPercentage;
        }
        public Reward? DetermineReward(Customer customer)
        {
            if (customer.NoOfVisits >= _minVisits)
            {
                return new Reward
                {
                    Type = Reward.RewardType.CashDiscount,
                    RewardValue = _discountPercentage * customer.Cart.TotalCartValue
                };
            }
            return null;
        }
    }

    public class HighSpendingCustomerRewardStrategy : IRewardStrategy
    {
        private int _spendingThreshold;
        private Product? _product;
        private readonly decimal _averageTransactionThreshold;
        private decimal _discountPercentage;

        public HighSpendingCustomerRewardStrategy(int spendingThreshold, decimal averageTransactionThreshold, decimal discountPercentage, Product product)
        {
            _spendingThreshold = spendingThreshold;
            _averageTransactionThreshold = averageTransactionThreshold;
            _discountPercentage = discountPercentage;
            _product = product;
        }
        public Reward? DetermineReward(Customer customer)
        {
            if (customer.TotalSpending >= _spendingThreshold)
            {
                if (customer.TransactionsPerMonth >= _averageTransactionThreshold)
                {
                    if (_product == null)
                    {
                        return new Reward()
                        {
                            Type = Reward.RewardType.CashDiscount,
                            RewardValue = _discountPercentage * customer.Cart.TotalCartValue
                        };
                    }
                    else
                    {
                        return new Reward()
                        {
                            Product = _product,
                            RewardValue = _product.Price,
                            Type = Reward.RewardType.FreeItem
                        };
                    }
                }
                else
                {
                    return new Reward()
                    {
                        Type = Reward.RewardType.CashDiscount,
                        RewardValue = _discountPercentage * customer.Cart.TotalCartValue
                    };
                }
            }
            return null;
        }
    }

    public class CheckOutProcess
    {
        public IRewardStrategy _rewardStrategies { get; set; }
        public CheckOutProcess(IRewardStrategy rewardStrategies)
        {
            _rewardStrategies = rewardStrategies;
        }

        public Invoice CalculateBillingAmount(Customer customer)
        {
            var reward = _rewardStrategies.DetermineReward(customer);
            var invoice = new Invoice();
            invoice.Reward = reward;
            return invoice;
        }
    }

   
}
