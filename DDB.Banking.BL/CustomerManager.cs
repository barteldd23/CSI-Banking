using DDB.Banking.BL.Models;
using System.Xml.Serialization;
using DDB.Utility.PL;
using System.Data;
using System.Data.SqlClient;

namespace DDB.Banking.BL
{
    public static class CustomerManager
    {
        #region "File Stuff"
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
            customer.LastDepositAmount = customer.Deposits[customer.Deposits.Count - 1].DepositAmount;
            customer.LastDepositDate = customer.Deposits[customer.Deposits.Count - 1].DepositeDate;
            customer.LastWithdrawalAmount = customer.Withdrawals[customer.Withdrawals.Count - 1].WithdrawalAmount;
            customer.LastWithdrawalDate = customer.Withdrawals[customer.Withdrawals.Count - 1].WithdrawalDate;
            customers.Add(customer);

            customer = new Customer();

            customer.Id = 2;
            customer.FirstName = "Morty";
            customer.LastName = "Smith";
            customer.SSN = "856724358";
            customer.BirthDate = new DateTime(1999, 12, 2);
            customer.Deposits = DepositManager.Populate(customer.Id);
            customer.Withdrawals = WithdrawalManager.Populate(customer.Id);
            customer.LastDepositAmount = customer.Deposits[customer.Deposits.Count - 1].DepositAmount;
            customer.LastDepositDate = customer.Deposits[customer.Deposits.Count - 1].DepositeDate;
            customer.LastWithdrawalAmount = customer.Withdrawals[customer.Withdrawals.Count - 1].WithdrawalAmount;
            customer.LastWithdrawalDate = customer.Withdrawals[customer.Withdrawals.Count - 1].WithdrawalDate;
            customers.Add(customer);

            customer = new Customer();

            customer.Id = 3;
            customer.FirstName = "Snow";
            customer.LastName = "Ball";
            customer.SSN = "987654321";
            customer.BirthDate = new DateTime(1983, 5, 6);
            customer.Deposits = DepositManager.Populate(customer.Id);
            customer.Withdrawals = WithdrawalManager.Populate(customer.Id);
            customer.LastDepositAmount = customer.Deposits[customer.Deposits.Count - 1].DepositAmount;
            customer.LastDepositDate = customer.Deposits[customer.Deposits.Count - 1].DepositeDate;
            customer.LastWithdrawalAmount = customer.Withdrawals[customer.Withdrawals.Count - 1].WithdrawalAmount;
            customer.LastWithdrawalDate = customer.Withdrawals[customer.Withdrawals.Count - 1].WithdrawalDate;
            customers.Add(customer);

            return customers;
        }

        public static bool WriteXML(List<Customer> customers, string filePath)
        {
            try
            {
                FileIO.Delete(filePath);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
                TextWriter writer = new StreamWriter(filePath);
                serializer.Serialize(writer, customers);
                writer.Close();
                writer = null;
                serializer = null;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Customer> ReadXML(string xmlfilepath)
        {
            try
            {
                List<Customer> computers = new List<Customer>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));

                TextReader reader = new StreamReader(xmlfilepath);

                computers.AddRange((List<Customer>)serializer.Deserialize(reader));

                reader.Close();
                reader = null;
                serializer = null;
                return computers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Write(List<Customer> customers, string filePath)
        {
            try
            {
                FileIO.Delete(filePath);
                foreach (Customer customer in customers)
                {
                    FileIO.Write(filePath, customer.DataFormat);

                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "DB Stuff"

        public static List<Customer> ReadDB()
        {
            try
            {
                List<Customer> customers = new List<Customer>();

                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "Select * from tblCustomer";
                SqlCommand command = new SqlCommand(sql);
                dt = db.Select(command);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Customer customer = new Customer();
                        customer.Id = Convert.ToInt32(dr["ID"]);
                        customer.SSN = dr["SSN"].ToString();
                        customer.FirstName = dr["FirstName"].ToString();
                        customer.LastName = dr["LastName"].ToString();
                        customer.BirthDate = Convert.ToDateTime(dr["DOB"]);

                        customers.Add(customer);
                    }
                }
                return customers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Customer ReadDB(int id)
        {
            try
            {
                Customer customer = new Customer();
                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "Select * from tblCustomer where Id = @id";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@id", id);
                dt = db.Select(command);
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    customer.Id = Convert.ToInt32(dr["Id"]);
                    customer.FirstName = dr["FirstName"].ToString();
                    customer.LastName = dr["LastName"].ToString();
                    customer.BirthDate = Convert.ToDateTime(dr["DOB"]);
                    customer.Deposits = DepositManager.ReadDB(customer.Id);
                    customer.Withdrawals = WithdrawalManager.ReadDB(customer.Id);
                }
                else
                {
                    throw new Exception("Customer Does not Exist");
                }

                return customer;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Insert(Customer customer, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "Insert into tblCustomer (Id, SSN, FirstName, LastName, DOB) ";
                sql += "Values (@id, @SSN, @FirstName, @LastName, @DOB)";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@id", customer.Id);
                command.Parameters.AddWithValue("@SSN", customer.SSN);
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@DOB", customer.BirthDate.Date);

                int iRows = db.Insert(command);

                if(customer.Deposits.Any())
                {
                    foreach (Deposit deposit in customer.Deposits)
                    {
                        iRows += DepositManager.Insert(deposit, rollback);
                    }
                }

                if (customer.Withdrawals.Any())
                {
                    foreach (Withdrawal withdrawal in customer.Withdrawals)
                    {
                        iRows += WithdrawalManager.Insert(withdrawal, rollback);
                    }
                }

                return iRows;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Update(Customer customer, int maxDepositId, int maxWithdrawalId bool rollback = false)
        {
            try
            {
                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "Insert into tblCustomer (Id, SSN, FirstName, LastName, DOB) ";
                sql += "Values (@id, @SSN, @FirstName, @LastName, @DOB)";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@id", customer.Id);
                command.Parameters.AddWithValue("@SSN", customer.SSN);
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@DOB", customer.BirthDate.Date);

                int iRows = db.Insert(command);

                DepositManager.DeleteByCustId(customer.Id, rollback);
                WithdrawalManager.DeleteByCustId(customer.Id, rollback);

                if (customer.Deposits.Any())
                {
                    List<Deposit> allDeposits = DepositManager.ReadAll();
                    int max = allDeposits.Max(i => i.DepositId);
                    foreach (Deposit deposit in customer.Deposits)
                    {
                        deposit.DepositId = ++maxDepositId;
                        iRows += DepositManager.Insert(deposit, rollback);
                    }
                }

                if (customer.Withdrawals.Any())
                {
                    foreach (Withdrawal withdrawal in customer.Withdrawals)
                    {
                        withdrawal.WithdrawalId = ++maxWithdrawalId;
                        iRows += WithdrawalManager.Insert(withdrawal, rollback);
                    }
                }

                return iRows;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Delete(Customer customer, bool rollback = false)
        {
            try
            {
                Database db = new Database();
                DataTable dt = new DataTable();
                string sql = "delete from tblCustomer where Id = @id ";
                SqlCommand command = new SqlCommand(sql);
                command.Parameters.AddWithValue("@id", customer.Id);

                int iRows = db.Delete(command);

                DepositManager.DeleteByCustId(customer.Id, rollback);
                WithdrawalManager.DeleteByCustId(customer.Id, rollback);

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