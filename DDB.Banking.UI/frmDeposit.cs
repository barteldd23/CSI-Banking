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

    public enum DepositMode
    {
        Add = 0,
        Edit
    }
    public partial class frmDeposit : Form
    {

        //properties to be set before the form loads on the screen.
        private DepositMode depositMode;

        public Customer customer { get; set; }

        // Index is only needed if Editing
        public int depositIndex { get; set; }


        public frmDeposit(DepositMode depositMode)
        {
            InitializeComponent();
            this.depositMode = depositMode;
            this.Text = depositMode.ToString() + " Deposit";
        }

        private void frmDeposit_Load(object sender, EventArgs e)
        {
            lblCustomer.Text = customer.FullName;
            if (depositMode == DepositMode.Add)
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

        // Check if valid amount. If so, update the customer objects data by adding a new or editing current selection.
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                double depositValue;
                if(double.TryParse(txtDepositAmount.Text, out depositValue))
                {
                    if (depositValue > 0)
                    {
                        if(depositMode == DepositMode.Add)
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}
