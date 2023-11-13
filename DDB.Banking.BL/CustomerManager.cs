using DDB.Banking.BL.Models;

namespace DDB.Banking.BL
{
    public static class CustomerManager
    {
        public static List<Customer> Populate()
        {
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer();


            customer.Id = 1;
            customer.FirstName = "Rick";
            customer.LastName = "Sanchez";
            customer.SSN = "123456789";
            customer.BirthDate = new DateTime(1990, 2, 11);
            customer.Deposits = DepositManager.Populate(customer.Id);
            customer.Withdrawals = WithdrawalManager.Populate(customer.Id);
            customers.Add(customer);

            customer.Id = 2;
            customer.FirstName = "Morty";
            customer.LastName = "Smith";
            customer.SSN = "856724358";
            customer.BirthDate = new DateTime(1999, 12, 2);
            customer.Deposits = DepositManager.Populate(customer.Id);
            customer.Withdrawals = WithdrawalManager.Populate(customer.Id);
            customers.Add(customer);

            customer.Id = 3;
            customer.FirstName = "Snow";
            customer.LastName = "Ball";
            customer.SSN = "987654321";
            customer.BirthDate = new DateTime(1983, 5, 6);
            customer.Deposits = DepositManager.Populate(customer.Id);
            customer.Withdrawals = WithdrawalManager.Populate(customer.Id);
            customers.Add(customer);

            return customers;
        }
    }
}