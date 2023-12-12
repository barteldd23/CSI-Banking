using DDB.Banking.BL.Models;

namespace DDB.Banking.BL.Test
{
    [TestClass]
    public class utCustomer
    {
        [TestMethod]
        public void PopulateTest()
        {
            List<Customer> list = CustomerManager.Populate();

            Assert.AreEqual(list.Count, 3);
        }

        [TestMethod]
        public void ReadDBTest()
        {
            List<Customer> customers = CustomerManager.ReadDB();
            Assert.AreEqual(3, customers.Count);
            Assert.AreEqual(3, customers[0].Deposits.Count);
            Assert.AreEqual(3, customers[0].Withdrawals.Count);
        }

        [TestMethod]
        public void ReadOneDBTest()
        {
            Customer customer = CustomerManager.ReadDB(2);
            Assert.AreEqual(2, customer.Id);
        }

        [TestMethod]
        public void InsertDBTest()
        {
            Customer customer = new Customer();
            customer.Id = -99;
            customer.SSN = "123456789";
            customer.FirstName = "test";
            customer.LastName = "test";
            customer.BirthDate = DateTime.Now;
            Assert.AreEqual(1, CustomerManager.Insert(customer, true));
        }

        [TestMethod]
        public void UpdateDBTest()
        {
            Customer customer = CustomerManager.ReadDB(3);
            customer.FirstName = "Test";
            Assert.AreEqual(1, CustomerManager.Update(customer, true));
        }

        [TestMethod]
        public void DeleteDBTest()
        {
            Customer customer = CustomerManager.ReadDB(3);
            Assert.AreEqual(1, CustomerManager.Delete(customer, true));
        }


    }
}