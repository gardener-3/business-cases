#using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customer_loyalty_prog
{
    internal class RewardStrategies
    {
    }

    interface IRewardStrategy
    {
        Reward DetermineReward(Customer customer);
    }
}
