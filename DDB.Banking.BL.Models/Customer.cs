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
        public  List<Deposit> Deposits { get; set; }
        public List<Withdrawal> Withdrawals { get; set; }
    }
}
