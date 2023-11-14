using DDB.Banking.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Banking.BL
{
    public static class WithdrawalManager
    {
        public static List<Withdrawal> Populate(int id)
        {
            List<Withdrawal> withdrawals = new List<Withdrawal>();
            Withdrawal withdrawal = new Withdrawal();

            switch (id)
            {
                case 1:
                    withdrawal.WithdrawalId = 1;
                    withdrawal.WithdrawalAmount = 25;
                    withdrawal.WithdrawalDate = new DateTime(2023, 2, 1);
                    withdrawals.Add(withdrawal);
                    break;

                case 2:
                    withdrawal.WithdrawalId = 1;
                    withdrawal.WithdrawalAmount = 76.25;
                    withdrawal.WithdrawalDate = new DateTime(2023, 2, 18);
                    withdrawals.Add(withdrawal);

                    withdrawal = new Withdrawal();

                    withdrawal.WithdrawalId = 2;
                    withdrawal.WithdrawalAmount = 1000.01;
                    withdrawal.WithdrawalDate = new DateTime(2023, 4, 5);
                    withdrawals.Add(withdrawal);
                    break;

                case 3:
                    withdrawal.WithdrawalId = 1;
                    withdrawal.WithdrawalAmount = 1000.99;
                    withdrawal.WithdrawalDate = new DateTime(2023, 9, 1);
                    withdrawals.Add(withdrawal);

                    withdrawal = new Withdrawal();

                    withdrawal.WithdrawalId = 2;
                    withdrawal.WithdrawalAmount = 10000;
                    withdrawal.WithdrawalDate = new DateTime(2023, 10, 1);
                    withdrawals.Add(withdrawal);

                    withdrawal = new Withdrawal();

                    withdrawal.WithdrawalId = 3;
                    withdrawal.WithdrawalAmount = 100000;
                    withdrawal.WithdrawalDate = new DateTime(2023, 11, 1);
                    withdrawals.Add(withdrawal);
                    break;
            }

            return withdrawals;
        }
    }
}
