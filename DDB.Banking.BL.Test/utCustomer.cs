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
    }
}