using DDB.Utility.PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Banking.PL.Test
{
    [TestClass]
    public class utDatabase
    {
        [TestMethod]
        public void OpenTest()
        {
            Database database = new Database();
            ConnectionState actual = database.Open();
            database.Close();
            Assert.AreEqual(ConnectionState.Open, actual);
        }

        [TestMethod]
        public void CloseTest()
        {
            Database database = new Database();
            database.Open();
            ConnectionState actual = database.Close();
            database.Close();
            Assert.AreEqual(ConnectionState.Closed, actual);
        }

        [TestMethod]
        public void LoadCustomersTest()
        {
            Database db = new Database();
            string sql = "select * from tblCustomer";
            SqlCommand command = new SqlCommand(sql);
            DataTable dt = new DataTable();
            dt = db.Select(command);
            Assert.AreEqual(3,dt.Rows.Count);
            
        }

        [TestMethod]
        public void LoadDepositOfCustomer()
        {
            Database db = new Database();
            string sql = "select * from tblDeposit where CustomerId = 1";
            SqlCommand command = new SqlCommand(sql);
            DataTable dt = new DataTable();
            dt = db.Select(command);
            Assert.AreEqual(2, dt.Rows.Count);

        }

        [TestMethod]
        public void InsertTest()
        {
            Database db = new Database();
            string sql = "Insert into tblWithdrawal (Id, CustomerId, Amount, Date) ";
            sql += "Values (-99, 3, 1234, '20231210 12:19:00')";
            SqlCommand command = new SqlCommand(sql);
            Assert.AreEqual(1, db.Insert(command, true));

        }

        [TestMethod]
        public void UpdateTest()
        {
            Database db = new Database();
            string sql = "Update tblCustomer set FirstName = 'test' where id=1";
            SqlCommand command = new SqlCommand(sql);
            Assert.AreEqual(1, db.Update(command, true));

        }

        [TestMethod]
        public void DeleteTest()
        {
            Database db = new Database();
            string sql = "Delete tblCustomer where id=1";
            SqlCommand command = new SqlCommand(sql);
            Assert.AreEqual(1, db.Delete(command, true));

        }

    }
}
