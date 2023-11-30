using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Banking.BL.Models
{
    public class Customer : Person
    {
        public int Id { get; set; }
        public  List<Deposit> Deposits { get; set; } = new List<Deposit>();
        public List<Withdrawal> Withdrawals { get; set; } = new List<Withdrawal>();
        public double LastDepositAmount { get; set; } //Calculate from Transactions?
        public DateTime LastDepositDate { get; set; } //Calculate from Transactions?
        public  double LastWithdrawalAmount { get; set; } //Calculate from Transactions?
        public DateTime LastWithdrawalDate { get; set; } //Calculate from Transactions?
    }
}
