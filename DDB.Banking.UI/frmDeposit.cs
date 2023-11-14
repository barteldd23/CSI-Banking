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
    }
}
