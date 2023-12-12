using DDB.Banking.BL.Models;
using DDB.Utility.PL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DDB.Banking.BL
{
    
    public static class DepositManager
    {

        #region "File stuff"
        public static List<Deposit> Populate(int id)
        {
            List<Deposit> deposits = new List<Deposit>();
            Deposit deposit = new Deposit();

            switch (id)
            {
                case 1: 
                    deposit.DepositId = 1;
                    deposit.DepositId = id;
                    deposit.DepositAmount = 1000;
                    deposit.DepositeDate = new DateTime(2023, 1,15);
                    deposits.Add(deposit);

                    deposit = new Deposit();

                    deposit.DepositId = 2;
                    deposit.DepositId = id;
                    deposit.DepositAmount = 575.95;
                    deposit.DepositeDate = new DateTime(2023, 6, 23);
                    deposits.Add(deposit);

                    deposit = new Deposit();

                    deposit.DepositId = 3;
                    deposit.DepositId = id;
                    deposit.DepositAmount = 1111.01;
                    deposit.DepositeDate = DateTime.Now;
                    deposits.Add(deposit);
                    break;

                case 2:
                    deposit.DepositId = 1;
                    deposit.DepositId = id;
                    deposit.DepositAmount = 431;
                    deposit.DepositeDate = new DateTime(2023, 3, 5);
                    deposits.Add(deposit);

                    deposit = new Deposit();

                    deposit.DepositId = 2;
                    deposit.DepositId = id;
                    deposit.DepositAmount = 15000.65;
                    deposit.DepositeDate = new DateTime(2023, 7, 20);
                    deposits.Add(deposit);
                    break;

                case 3:
                    deposit.DepositId = 1;
                    deposit.DepositId = id;
                    deposit.DepositAmount = 1000000;
                    deposit.DepositeDate = new DateTime(2023, 8, 23);
                    deposits.Add(deposit);

                    deposit = new Deposit();

                    deposit.DepositId = 2;
                    deposit.DepositId = id;
                    deposit.DepositAmount = 1.01;
                    deposit.DepositeDate = new DateTime(2023, 11, 11);
                    deposits.Add(deposit);
                    break;
            }

            return deposits;
        }

        #endregion

        #region "DB Stuff"

        public static List<Deposit> ReadDB(int custId)
        {
            try
            {
                List<Deposit> deposits = new List<Deposit>();

                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "Select * from tblDeposit where Id = @custId";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@custId", custId);
                dt = db.Select(command);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Deposit deposit = new Deposit();
                        deposit.DepositId = Convert.ToInt32(dr["ID"]);
                        deposit.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                        deposit.DepositAmount = Convert.ToDouble(dr["Amount"]);
                        deposit.DepositeDate = Convert.ToDateTime(dr["Date"]);

                        deposits.Add(deposit);
                    }
                }
                return deposits;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Deposit> ReadAll()
        {
            try
            {
                List<Deposit> deposits = new List<Deposit>();

                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "Select * from tblDeposit";
                SqlCommand command = new SqlCommand(sql);
                dt = db.Select(command);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Deposit deposit = new Deposit();
                        deposit.DepositId = Convert.ToInt32(dr["ID"]);
                        deposit.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                        deposit.DepositAmount = Convert.ToDouble(dr["Amount"]);
                        deposit.DepositeDate = Convert.ToDateTime(dr["Date"]);

                        deposits.Add(deposit);
                    }
                }
                return deposits;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public static Deposit ReadDB(short id)
        //{
        //    try
        //    {
        //        Deposit deposit = new Deposit();
        //        Database db = new Database();
        //        DataTable dt = new DataTable();
        //        string sql = "Select * from tblDeposit where Id = @id";
        //        SqlCommand command = new SqlCommand(sql);
        //        command.Parameters.AddWithValue("@id", id);
        //        dt = db.Select(command);
        //        if (dt.Rows.Count == 1)
        //        {
        //            DataRow dr = dt.Rows[0];
        //            deposit.Id = Convert.ToInt32(dr["Id"]);
        //            deposit.FirstName = dr["FirstName"].ToString();
        //            deposit.LastName = dr["LastName"].ToString();
        //            deposit.BirthDate = Convert.ToDateTime(dr["DOB"]);
        //        }
        //        else
        //        {
        //            throw new Exception("Deposit Does not Exist");
        //        }

        //        return deposit;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public static int Insert(Deposit deposit, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "Insert into tblDeposit (Id, CustomerId, Amount, Date) ";
                sql += "Values (@id, @CustomerId, @Amount, @Date)";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@id", deposit.DepositId);
                command.Parameters.AddWithValue("@CustomerId", deposit.CustomerId);
                command.Parameters.AddWithValue("@Amount", deposit.DepositAmount);
                command.Parameters.AddWithValue("@Date", deposit.DepositeDate);

                int iRows = db.Insert(command, rollback);

                return iRows;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Update(Deposit deposit, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "Update tblDeposit set Id = @id, CustomerId = @CustomerId, Amount = @Amount, Date = @Date where Id = @id) ";
                
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@id", deposit.DepositId);
                command.Parameters.AddWithValue("@CustomerId", deposit.CustomerId);
                command.Parameters.AddWithValue("@Amount", deposit.DepositAmount);
                command.Parameters.AddWithValue("@Date", deposit.DepositeDate);

                int iRows = db.Update(command, rollback);

                return iRows;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Delete(Deposit deposit, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "delete from tblDeposit where Id = @id ";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@id", deposit.DepositId);

                int iRows = db.Delete(command, rollback);

                return iRows;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int DeleteByCustId(int custId, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "delete from tblDeposit where CustomerId = @custId ";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@custId", custId);

                int iRows = db.Delete(command, rollback);

                return iRows;
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion


    }
}
