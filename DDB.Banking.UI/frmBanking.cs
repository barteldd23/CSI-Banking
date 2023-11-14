using DDB.Banking.BL;
using DDB.Banking.BL.Models;
using Microsoft.VisualBasic.Devices;

namespace DDB.Banking.UI
{
    public partial class frmBanking : Form
    {
        List<Customer> customers;
        public frmBanking()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBanking_Load(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                customers = CustomerManager.Populate();
                Refresh();

                lblStatus.Text = customers.Count.ToString() + " customers loaded...";
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        private void Refresh()
        {
            lbxCustomers.DataSource = null;
            lbxCustomers.DataSource = customers;
            lbxCustomers.DisplayMember = "FullName";

        }

        private void lbxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                if (lbxCustomers.SelectedIndex >= 0)
                {
                    Customer customer = lbxCustomers.SelectedItem as Customer;
                    txtFirstName.Text = customer.FirstName;
                    txtLastName.Text = customer.LastName;
                    txtSSN.Text = customer.SSN.Substring(0, 3) + "-" +
                                  customer.SSN.Substring(3, 2) + "-" + customer.SSN.Substring(5, 4);
                    txtId.Text = customer.Id.ToString();
                    dtpDOB.Value = customer.BirthDate;

                    RefreshDeposits(customer.Deposits);
                    RefreshWithdrawals(customer.Withdrawals);
                }

            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        public void RefreshDeposits(List<Deposit> deposits)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                dgvDeposits.DataSource = deposits;
                dgvDeposits.Columns[1].DefaultCellStyle.Format = "C";


            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        public void RefreshWithdrawals(List<Withdrawal> withdrawals)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                dgvWithdrawals.DataSource = withdrawals;
                dgvWithdrawals.Columns[1].DefaultCellStyle.Format = "C";
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                frmDeposit frmDeposit = new frmDeposit(ScreenMode.Add);
                Customer selectedCustomer = lbxCustomers.SelectedItem as Customer;
                frmDeposit.customer = selectedCustomer;

                frmDeposit.ShowDialog();

                RefreshDeposits(selectedCustomer.Deposits);

                //var row = dgvDeposits.SelectedRows[0];
                //Deposit selectedDeposit = row.DataBoundItem as Deposit;

                //frmDeposit.deposit = selectedDeposit;

            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }
    }
}