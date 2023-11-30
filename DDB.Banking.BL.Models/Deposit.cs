using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Banking.BL.Models
{
    public class Deposit
    {
        public int DepositId { get; set; }
        public int CustomerId { get; set; }
        public double DepositAmount { get; set; }
        public DateTime DepositeDate { get; set; }
    }
}
