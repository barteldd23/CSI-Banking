using DDB.Banking.BL.Models;
using Microsoft.VisualBasic.Devices;
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
    public enum ScreenMode
    {
        Add = 0,
        Edit
    }
    public partial class frmDeposit : Form
    {
        private ScreenMode screenMode;

        public Customer customer { get; set; }

        public int depositIndex { get; set; }


        public frmDeposit(ScreenMode screenMode)
        {
            InitializeComponent();
            this.screenMode = screenMode;
            this.Text = screenMode.ToString() + " Deposit";
        }

        private void frmDeposit_Load(object sender, EventArgs e)
        {
            lblCustomer.Text = customer.FullName;
            if (screenMode == ScreenMode.Add)
            {
                lblHeading.Text = "Add New Deposit";
            }
            else
            {
                lblHeading.Text = "Edit Deposit No. " + customer.Deposits[depositIndex].DepositId;
                txtDepositAmount.Text = customer.Deposits[depositIndex].DepositAmount.ToString();
                dtpDepositDate.Value = customer.Deposits[depositIndex].DepositeDate;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                double depositValue;
                if(double.TryParse(txtDepositAmount.Text, out depositValue))
                {
                    if (depositValue > 0)
                    {
                        if(screenMode == ScreenMode.Add)
                        {
                            Deposit deposit = new Deposit();
                            deposit.DepositAmount = depositValue;
                            deposit.DepositeDate = dtpDepositDate.Value;
                            deposit.DepositId = customer.Deposits.Any() ? customer.Deposits.Max(d => d.DepositId) + 1 : 1;

                            customer.Deposits.Add(deposit);
                        }
                        else
                        {
                            customer.Deposits[depositIndex].DepositAmount = depositValue;
                            customer.Deposits[depositIndex].DepositeDate = dtpDepositDate.Value;
                        }
                    }
                    else
                    {
                        throw new Exception("Not a valid deposit.");
                    }
                }
                else
                {
                    throw new Exception("Not a valid deposit.");
                }

                this.Close(); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
