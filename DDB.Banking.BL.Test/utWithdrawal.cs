using DDB.Banking.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Banking.BL.Test
{
    [TestClass]
    public class utWithdrawal
    {
        [TestMethod]
        public void PopulateTest()
        {
            List<Withdrawal> list1 = WithdrawalManager.Populate(1);
            List<Withdrawal> list2 = WithdrawalManager.Populate(2);
            List<Withdrawal> list3 = WithdrawalManager.Populate(3);

            Assert.AreEqual(list1.Count, 1);
            Assert.AreEqual(list2.Count, 2);
            Assert.AreEqual(list3.Count, 3);
        }

        [TestMethod]
        public void ReadDBTest()
        {
            List<Withdrawal> cwithdrawals = WithdrawalManager.ReadAll();
            Assert.AreEqual(4, cwithdrawals.Count);
        }

        [TestMethod]
        public void ReadOneDBTest()
        {
            List<Withdrawal> withdrawals = WithdrawalManager.ReadDB(1);
            Assert.AreEqual(2, withdrawals.Count);
        }

        [TestMethod]
        public void InsertDBTest()
        {
            Withdrawal withdrawal = new Withdrawal();
            withdrawal.WithdrawalId = -99;
            withdrawal.CustomerId = 3;
            withdrawal.WithdrawalAmount = 123;
            withdrawal.WithdrawalDate = DateTime.Now;
            Assert.AreEqual(1, WithdrawalManager.Insert(withdrawal, true));
        }

        [TestMethod]
        public void UpdateDBTest()
        {
            Withdrawal withdrawal = WithdrawalManager.ReadDB(3)[0];
            withdrawal.WithdrawalAmount = 12314;
            Assert.AreEqual(1, WithdrawalManager.Update(withdrawal, true));
        }

        [TestMethod]
        public void DeleteDBTest()
        {
            Withdrawal withdrawal = WithdrawalManager.ReadDB(1)[1];
            Assert.AreEqual(1, WithdrawalManager.Delete(withdrawal, true));
        }

        [TestMethod]
        public void DeleteByCustIdDBTest()
        {
            Assert.AreEqual(2, WithdrawalManager.DeleteByCustId(1, true));
        }
    }
}
