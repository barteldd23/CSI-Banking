using DDB.Banking.BL.Models;
using System.Xml.Serialization;
using DDB.Utility.PL;

namespace DDB.Banking.BL
{
    public static class CustomerManager
    {
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
            customers.Add(customer);

            customer = new Customer();

            customer.Id = 2;
            customer.FirstName = "Morty";
            customer.LastName = "Smith";
            customer.SSN = "856724358";
            customer.BirthDate = new DateTime(1999, 12, 2);
            customer.Deposits = DepositManager.Populate(customer.Id);
            customer.Withdrawals = WithdrawalManager.Populate(customer.Id);
            customers.Add(customer);

            customer = new Customer();

            customer.Id = 3;
            customer.FirstName = "Snow";
            customer.LastName = "Ball";
            customer.SSN = "987654321";
            customer.BirthDate = new DateTime(1983, 5, 6);
            customer.Deposits = DepositManager.Populate(customer.Id);
            customer.Withdrawals = WithdrawalManager.Populate(customer.Id);
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
    }
    
}