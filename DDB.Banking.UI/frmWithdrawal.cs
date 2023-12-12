using DDB.Banking.BL;
using DDB.Banking.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDB.Banking.UI
{
    public enum WithdrawalMode
    {
        Add = 0,
        Edit
    }

    public partial class frmWithdrawal : Form
    {

        private WithdrawalMode withdrawalMode;

        public Customer customer { get; set; }

        public int withdrawalIndex { get; set; }

        public frmWithdrawal(WithdrawalMode withdrawalMode)
        {
            InitializeComponent();
            this.withdrawalMode = withdrawalMode;
            this.Text = withdrawalMode.ToString() + " Withdrawal";
        }

        private void frmWithdrawal_Load(object sender, EventArgs e)
        {
            lblCustomer.Text = customer.FullName;
            if (withdrawalMode == WithdrawalMode.Add)
            {
                lblHeading.Text = "Add New Withdrawal";
            }
            else
            {
                lblHeading.Text = "Edit Withdrawal No. " + customer.Withdrawals[withdrawalIndex].WithdrawalId;
                txtWithdrawalAmount.Text = customer.Withdrawals[withdrawalIndex].WithdrawalAmount.ToString();
                dtpWithdrawalDate.Value = customer.Withdrawals[withdrawalIndex].WithdrawalDate;

            }
        }

        // Check if valid amount. If so, update the customer objects data by adding a new or editing current selection.
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                double withdrawalValue;
                if (double.TryParse(txtWithdrawalAmount.Text, out withdrawalValue))
                {
                    if (withdrawalValue > 0)
                    {
                        if (withdrawalMode == WithdrawalMode.Add)
                        {
                            Withdrawal withdrawal = new Withdrawal();
                            withdrawal.CustomerId = customer.Id;
                            withdrawal.WithdrawalAmount = withdrawalValue;
                            withdrawal.WithdrawalDate = dtpWithdrawalDate.Value;
                            withdrawal.WithdrawalId = WithdrawalManager.ReadAll().Any() ? WithdrawalManager.ReadAll().Max(d => d.WithdrawalId) + 1 : 1;

                            customer.Withdrawals.Add(withdrawal);
                            WithdrawalManager.Insert(withdrawal);
                            customer.LastWithdrawalAmount = withdrawal.WithdrawalAmount;
                            customer.LastWithdrawalDate = withdrawal.WithdrawalDate;
                        }
                        else
                        {
                            customer.Withdrawals[withdrawalIndex].WithdrawalAmount = withdrawalValue;
                            customer.Withdrawals[withdrawalIndex].WithdrawalDate = dtpWithdrawalDate.Value;
                            WithdrawalManager.Update(customer.Withdrawals[withdrawalIndex]);
                        }
                    }
                    else
                    {
                        throw new Exception("Not a valid withdrawal.");
                    }
                }
                else
                {
                    throw new Exception("Not a valid withdrawal.");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
