using DDB.Banking.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Banking.BL
{
    public static class DepositManager
    {
        public static List<Deposit> Populate(int id)
        {
            List<Deposit> deposits = new List<Deposit>();
            Deposit deposit = new Deposit();

            switch (id)
            {
                case 1: 
                    deposit.DepositId = 1;
                    deposit.DepositAmount = 1000;
                    deposit.DepositeDate = new DateTime(2023, 1,15);
                    deposits.Add(deposit);

                    deposit.DepositId = 2;
                    deposit.DepositAmount = 575.95;
                    deposit.DepositeDate = new DateTime(2023, 6, 23);
                    deposits.Add(deposit);

                    deposit.DepositId = 3;
                    deposit.DepositAmount = 1111.01;
                    deposit.DepositeDate = DateTime.Now;
                    deposits.Add(deposit);
                    break;

                case 2:
                    deposit.DepositId = 1;
                    deposit.DepositAmount = 431;
                    deposit.DepositeDate = new DateTime(2023, 3, 5);
                    deposits.Add(deposit);

                    deposit.DepositId = 2;
                    deposit.DepositAmount = 15000.65;
                    deposit.DepositeDate = new DateTime(2023, 7, 20);
                    deposits.Add(deposit);
                    break;

                case 3:
                    deposit.DepositId = 1;
                    deposit.DepositAmount = 1000000;
                    deposit.DepositeDate = new DateTime(2023, 8, 23);
                    deposits.Add(deposit);

                    deposit.DepositId = 2;
                    deposit.DepositAmount = 1.01;
                    deposit.DepositeDate = new DateTime(2023, 11, 11);
                    deposits.Add(deposit);
                    break;
            }

            return deposits;
        }
    }
}
