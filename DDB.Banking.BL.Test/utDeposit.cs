using DDB.Banking.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Banking.BL.Test
{
    [TestClass]
    public class utDeposit
    {
        [TestMethod]
        public void PopulateTest()
        {
            List<Deposit> list1 = DepositManager.Populate(1);
            List<Deposit> list2 = DepositManager.Populate(2);
            List<Deposit> list3 = DepositManager.Populate(3);

            Assert.AreEqual(list1.Count, 3);
            Assert.AreEqual(list2.Count, 2);
            Assert.AreEqual(list3.Count, 2);
        }

        [TestMethod]
        public void ReadDBTest()
        {
            List<Deposit> cdeposits = DepositManager.ReadAll();
            Assert.AreEqual(4, cdeposits.Count);
        }

        [TestMethod]
        public void ReadOneDBTest()
        {
            List<Deposit> deposits = DepositManager.ReadDB(1);
            Assert.AreEqual(2, deposits.Count);
        }

        [TestMethod]
        public void InsertDBTest()
        {
            Deposit deposit = new Deposit();
            deposit.DepositId = -99;
            deposit.CustomerId = 3;
            deposit.DepositAmount = 123;
            deposit.DepositeDate = DateTime.Now;
            Assert.AreEqual(1, DepositManager.Insert(deposit, true));
        }

        [TestMethod]
        public void UpdateDBTest()
        {
            Deposit deposit = DepositManager.ReadDB(3)[0];
            deposit.DepositAmount = 12314;
            Assert.AreEqual(1, DepositManager.Update(deposit, true));
        }

        [TestMethod]
        public void DeleteDBTest()
        {
            Deposit deposit = DepositManager.ReadDB(1)[1];
            Assert.AreEqual(1, DepositManager.Delete(deposit, true));
        }

        [TestMethod]
        public void DeleteByCustIdDBTest()
        {
            Assert.AreEqual(2, DepositManager.DeleteByCustId(1, true));
        }
    }

    
}
