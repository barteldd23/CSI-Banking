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
    }
}
