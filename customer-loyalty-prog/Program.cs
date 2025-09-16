namespace customer_loyalty_prog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // setup strategy
            IRewardStrategy currentRewardStrategy = new RegularCustomerRewardStrategy(10, 0.10M);
           var cust0 = new Customer()
            {
                Cart = new ShoppingCart()
                {
                    CartId = 1001,
                    TotalCartValue = 32.10M
                },
                DateOfBirth = DateTime.Today,
                IsCakeDay = false,
                ID = 101,
                LastInvoice = 12.20M,
                NoOfVisits = 21,
                TotalSpending = 540.21M,
                TransactionsPerMonth = 45.01M,

            };


            CheckOutProcess checkOutProcess = new CheckOutProcess(currentRewardStrategy);
            var invoice = checkOutProcess.CalculateBillingAmount(cust0);
            

        }
    }
}
