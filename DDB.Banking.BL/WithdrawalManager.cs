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
    public static class WithdrawalManager
    {
        #region "File stuff"
        public static List<Withdrawal> Populate(int id)
        {
            List<Withdrawal> withdrawals = new List<Withdrawal>();
            Withdrawal withdrawal = new Withdrawal();

            switch (id)
            {
                case 1:
                    withdrawal.WithdrawalId = 1;
                    withdrawal.CustomerId = id;
                    withdrawal.WithdrawalAmount = 25;
                    withdrawal.WithdrawalDate = new DateTime(2023, 2, 1);
                    withdrawals.Add(withdrawal);
                    break;

                case 2:
                    withdrawal.WithdrawalId = 1;
                    withdrawal.CustomerId = id;
                    withdrawal.WithdrawalAmount = 76.25;
                    withdrawal.WithdrawalDate = new DateTime(2023, 2, 18);
                    withdrawals.Add(withdrawal);

                    withdrawal = new Withdrawal();

                    withdrawal.WithdrawalId = 2;
                    withdrawal.CustomerId = id;
                    withdrawal.WithdrawalAmount = 1000.01;
                    withdrawal.WithdrawalDate = new DateTime(2023, 4, 5);
                    withdrawals.Add(withdrawal);
                    break;

                case 3:
                    withdrawal.WithdrawalId = 1;
                    withdrawal.CustomerId = id;
                    withdrawal.WithdrawalAmount = 1000.99;
                    withdrawal.WithdrawalDate = new DateTime(2023, 9, 1);
                    withdrawals.Add(withdrawal);

                    withdrawal = new Withdrawal();

                    withdrawal.WithdrawalId = 2;
                    withdrawal.CustomerId = id;
                    withdrawal.WithdrawalAmount = 10000;
                    withdrawal.WithdrawalDate = new DateTime(2023, 10, 1);
                    withdrawals.Add(withdrawal);

                    withdrawal = new Withdrawal();

                    withdrawal.WithdrawalId = 3;
                    withdrawal.CustomerId = id;
                    withdrawal.WithdrawalAmount = 100000;
                    withdrawal.WithdrawalDate = new DateTime(2023, 11, 1);
                    withdrawals.Add(withdrawal);
                    break;
            }

            return withdrawals;
        }
        #endregion

        #region "DB Stuff"

        public static List<Withdrawal> ReadDB(int custId)
        {
            try
            {
                List<Withdrawal> withdrawals = new List<Withdrawal>();

                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "Select * from tblWithdrawal where Id = @custId";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@custId", custId);
                dt = db.Select(command);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Withdrawal withdrawal = new Withdrawal();
                        withdrawal.WithdrawalId = Convert.ToInt32(dr["ID"]);
                        withdrawal.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                        withdrawal.WithdrawalAmount = Convert.ToDouble(dr["Amount"]);
                        withdrawal.WithdrawalDate = Convert.ToDateTime(dr["Date"]);

                        withdrawals.Add(withdrawal);
                    }
                }
                return withdrawals;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Withdrawal> ReadAll()
        {
            try
            {
                List<Withdrawal> withdrawals = new List<Withdrawal>();

                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "Select * from tblWithdrawal";
                SqlCommand command = new SqlCommand(sql);
                dt = db.Select(command);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Withdrawal withdrawal = new Withdrawal();
                        withdrawal.WithdrawalId = Convert.ToInt32(dr["ID"]);
                        withdrawal.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                        withdrawal.WithdrawalAmount = Convert.ToDouble(dr["Amount"]);
                        withdrawal.WithdrawalDate = Convert.ToDateTime(dr["Date"]);

                        withdrawals.Add(withdrawal);
                    }
                }
                return withdrawals;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public static Withdrawal ReadDB(short id)
        //{
        //    try
        //    {
        //        Withdrawal withdrawal = new Withdrawal();
        //        Database db = new Database();
        //        DataTable dt = new DataTable();
        //        string sql = "Select * from tblWithdrawal where Id = @id";
        //        SqlCommand command = new SqlCommand(sql);
        //        command.Parameters.AddWithValue("@id", id);
        //        dt = db.Select(command);
        //        if (dt.Rows.Count == 1)
        //        {
        //            DataRow dr = dt.Rows[0];
        //            withdrawal.Id = Convert.ToInt32(dr["Id"]);
        //            withdrawal.FirstName = dr["FirstName"].ToString();
        //            withdrawal.LastName = dr["LastName"].ToString();
        //            withdrawal.BirthDate = Convert.ToDateTime(dr["DOB"]);
        //        }
        //        else
        //        {
        //            throw new Exception("Withdrawal Does not Exist");
        //        }

        //        return withdrawal;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public static int Insert(Withdrawal withdrawal, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "Insert into tblWithdrawal (Id, CustomerId, Amount, Date) ";
                sql += "Values (@id, @CustomerId, @Amount, @Date)";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@id", withdrawal.WithdrawalId);
                command.Parameters.AddWithValue("@CustomerId", withdrawal.CustomerId);
                command.Parameters.AddWithValue("@Amount", withdrawal.WithdrawalAmount);
                command.Parameters.AddWithValue("@Date", withdrawal.WithdrawalDate);

                int iRows = db.Insert(command, rollback);

                return iRows;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Update(Withdrawal withdrawal, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "Update tblWithdrawal set Id = @id, CustomerId = @CustomerId, Amount = @Amount, Date = @Date where Id = @id) ";

                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@id", withdrawal.WithdrawalId);
                command.Parameters.AddWithValue("@CustomerId", withdrawal.CustomerId);
                command.Parameters.AddWithValue("@Amount", withdrawal.WithdrawalAmount);
                command.Parameters.AddWithValue("@Date", withdrawal.WithdrawalDate);

                int iRows = db.Update(command, rollback);

                return iRows;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Delete(Withdrawal withdrawal, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "delete from tblWithdrawal where Id = @id ";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@id", withdrawal.WithdrawalId);

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
                string sql = "delete from tblWithdrawal where CustomerId = @custId ";
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
