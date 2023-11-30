using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Banking.BL.Models
{
    public class Withdrawal
    {
        public int WithdrawalId { get; set; }
        public int CustomerId { get; set; }
        public double WithdrawalAmount { get; set; }
        public DateTime WithdrawalDate { get; set; }
    }
}
