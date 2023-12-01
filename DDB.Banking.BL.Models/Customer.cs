using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Banking.BL.Models
{
    public class Customer : Person
    {
        const string DELIM = "|";

        public int Id { get; set; }
        public  List<Deposit> Deposits { get; set; } = new List<Deposit>();
        public List<Withdrawal> Withdrawals { get; set; } = new List<Withdrawal>();
        public double LastDepositAmount { get; set; } //Calculate from Transactions?
        public DateTime LastDepositDate { get; set; } //Calculate from Transactions?
        public  double LastWithdrawalAmount { get; set; } //Calculate from Transactions?
        public DateTime LastWithdrawalDate { get; set; } //Calculate from Transactions?

        public string DataFormat
        {
            get {
                string output = Id + DELIM
                     + "Last Deposit: " + LastDepositAmount.ToString("C") + DELIM
                     + LastDepositDate.Date + DELIM
                     + "Last Withdrawal: " + LastWithdrawalAmount.ToString("C") + DELIM
                     + LastWithdrawalDate.Date.ToString() + DELIM;

                foreach (Deposit deposit in Deposits)
                {
                    output += deposit.DepositId.ToString() + deposit.DepositAmount.ToString("C") + deposit.DepositeDate.Date.ToString();
                    output += DELIM;
                }

                foreach (Withdrawal withdrawal in Withdrawals)
                {
                    output += withdrawal.WithdrawalId.ToString() + withdrawal.WithdrawalAmount.ToString("C") + withdrawal.WithdrawalDate.Date.ToString();
                    output += DELIM;
                }

                return output;
                }
        }
    }
}
