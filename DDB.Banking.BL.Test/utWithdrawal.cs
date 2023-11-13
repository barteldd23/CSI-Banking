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
    }
}
