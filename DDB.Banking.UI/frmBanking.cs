using DDB.Banking.BL;
using DDB.Banking.BL.Models;
using Microsoft.VisualBasic.Devices;
using Microsoft.Extensions.Configuration;
using DDB.Utility.PL;


/*
 * Dean Bartel
 * 14 Nov 2023
 * Banking #5
 */

namespace DDB.Banking.UI
{
    public partial class frmBanking : Form
    {
        List<Customer> customers;
        MySettings settings;
        public frmBanking()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        // On Load: Get the list of customers and display them in the listbox with Refresh() function.
        private void frmBanking_Load(object sender, EventArgs e)
        {
            try
            {
                settings = Program.Configuration.GetSection("MySettings").Get<MySettings>();

                this.Text = settings.Text;

                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                customers = CustomerManager.ReadDB();

                //~~~~~~~~~~~~~~~~~~~~XML STUFF~~~~~~~~~~~~~~~~~~~~~~~~~~~
                //~~~~~~~~~~~Create Default Data Files~~~~~~~~~~~~~~~~~~~
                //customers = CustomerManger.Populate();
                //List<Deposit> allDeposits = new List<Deposit>();
                //List<Withdrawal> allWithdrawals = new List<Withdrawal>();
                //foreach (Customer customer in customers)
                //{
                //    foreach (Deposit deposit in customer.Deposits)
                //    {
                //        allDeposits.Add(deposit);
                //    }
                //    foreach (Withdrawal withdrawal in customer.Withdrawals)
                //    {
                //        allWithdrawals.Add(withdrawal);
                //    }
                //}
                // CustomerManager.WriteXML(customers, settings.CustomerXMLFileName);
                //DepositManager.WriteXML(allDeposits, settings.DepositXMLFileName);
                //WithdrawalManager.WriteXML(allWithdrawals, settings.WithdrawalXMLFileName);
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



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
            // Get Data by Reading the xml files
            customers = CustomerManager.ReadXML(settings.CustomerXMLFileName);

            lbxCustomers.DataSource = null;
            lbxCustomers.DataSource = customers;
            lbxCustomers.DisplayMember = "FullName";

        }

        private void Refresh(string statusMsg, int selectedCustomer)
        {
            // Get Data by Reading the xml files
            customers = CustomerManager.ReadXML(settings.CustomerXMLFileName);

            lbxCustomers.DataSource = null;
            lbxCustomers.DataSource = customers;
            lbxCustomers.DisplayMember = "FullName";

            lbxCustomers.SelectedIndex = selectedCustomer;
            lblStatus.ForeColor = Color.Blue;
            lblStatus.Text = statusMsg;

        }


        // When a customer is selected in the listbox: Display their info on the txtboxes.
        // populate their deposts and withdrawals in the data grid views using RefreshDeposits(List<deposit>) RefreshWithdrawals(List<withdrawal>) functions
        private void lbxCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                if (lbxCustomers.SelectedIndex >= 0)
                {
                    // lbx.SelectedItem can grab the entier Customer Object and insert its data into this customer variable object.
                    Customer customer = lbxCustomers.SelectedItem as Customer;
                    txtFirstName.Text = customer.FirstName;
                    txtLastName.Text = customer.LastName;

                    // Make SSN Display Fancy if its 9 characters long.
                    if (customer.SSN.Length == 9)
                    {
                        txtSSN.Text = customer.SSN.Substring(0, 3) + "-" +
                                  customer.SSN.Substring(3, 2) + "-" + customer.SSN.Substring(5, 4);
                    }
                    else
                    {
                        txtSSN.Text = customer.SSN;
                    }

                    txtId.Text = customer.Id.ToString();
                    dtpDOB.Value = customer.BirthDate;

                    RefreshDeposits(customer.Deposits);
                    RefreshWithdrawals(customer.Withdrawals);
                }
                else
                {
                    ClearScreen();
                }

            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        private void ClearScreen()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtSSN.Text = string.Empty;
            txtId.Text = string.Empty;
            dtpDOB.Value = DateTime.Now;
            List<Deposit> nullDeposits = null;
            List<Withdrawal> nullWithdrawals = null;
            RefreshDeposits(nullDeposits);
            RefreshWithdrawals(nullWithdrawals);
        }

        public void RefreshDeposits(List<Deposit> deposits)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                //Need =null to reset the dgv. format amounts to curencty and dates to mm/dd/yyyy
                dgvDeposits.DataSource = null;
                if (deposits != null)
                {
                    if (deposits.Count > 0)
                    {
                        dgvDeposits.DataSource = deposits;
                        dgvDeposits.Columns[1].Visible = false;
                        dgvDeposits.Columns[2].DefaultCellStyle.Format = "C";
                        dgvDeposits.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy";
                    }

                }



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

                //Need =null to reset the dgv. format amounts to curencty and dates to mm/dd/yyyy
                dgvWithdrawals.DataSource = null;

                if (withdrawals != null)
                {
                    if (withdrawals.Count > 0)
                    {
                        dgvWithdrawals.DataSource = withdrawals;
                        dgvWithdrawals.Columns[1].Visible = false;
                        dgvWithdrawals.Columns[2].DefaultCellStyle.Format = "C";
                        dgvWithdrawals.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy";
                    }

                }

            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }


        // on Add Click: declare a new form. set Mode and current Customer Properties.
        private void btnAddDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                frmDeposit frmDeposit = new frmDeposit(DepositMode.Add);
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

        // on Edit Click: declare a new form. set Mode and current Customer Properties. Set selected index to populate the form with data.
        private void btnEditDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                frmDeposit frmDeposit = new frmDeposit(DepositMode.Edit);
                Customer selectedCustomer = lbxCustomers.SelectedItem as Customer;
                frmDeposit.customer = selectedCustomer;
                frmDeposit.depositIndex = dgvDeposits.CurrentRow.Index;

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

        // on Add Click: declare a new form. set Mode and current Customer Properties.
        private void btnAddWithdrawal_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                frmWithdrawal frmWithdrawal = new frmWithdrawal(WithdrawalMode.Add);
                Customer selectedCustomer = lbxCustomers.SelectedItem as Customer;
                frmWithdrawal.customer = selectedCustomer;

                frmWithdrawal.ShowDialog();

                RefreshWithdrawals(selectedCustomer.Withdrawals);


            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        // on Edit Click: declare a new form. set Mode and current Customer Properties. Set selected index to populate the form with data.
        private void btnEditWithdrawal_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                frmWithdrawal frmWithdrawal = new frmWithdrawal(WithdrawalMode.Edit);
                Customer selectedCustomer = lbxCustomers.SelectedItem as Customer;
                frmWithdrawal.customer = selectedCustomer;
                frmWithdrawal.withdrawalIndex = dgvWithdrawals.CurrentRow.Index;

                frmWithdrawal.ShowDialog();

                RefreshWithdrawals(selectedCustomer.Withdrawals);

            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
                {
                    txtFirstName.Focus();
                    txtFirstName.SelectAll();
                    MessageBox.Show("Must enter a First Name");
                }
                else
                {
                    if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
                    {
                        txtLastName.Focus();
                        txtLastName.SelectAll();
                        MessageBox.Show("Must enter a Last Name");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtSSN.Text.Trim()))
                        {
                            txtSSN.Focus();
                            txtSSN.SelectAll();
                            MessageBox.Show("Must enter a SSN");
                        }
                        else
                        {
                            if (dtpDOB.Value.CompareTo(DateTime.Now) >= 0)
                            {
                                dtpDOB.Focus();
                                MessageBox.Show("Must enter a valid Birth Date");
                            }
                            else
                            {
                                int selectedCustIndex = lbxCustomers.SelectedIndex;
                                customers[selectedCustIndex].FirstName = txtFirstName.Text.Trim();
                                customers[selectedCustIndex].LastName = txtLastName.Text.Trim();
                                customers[selectedCustIndex].SSN = txtSSN.Text.Trim();
                                customers[selectedCustIndex].BirthDate = dtpDOB.Value;

                                CustomerManager.WriteXML(customers, settings.CustomerXMLFileName);

                                string message = "Added " + customers[selectedCustIndex].FullName;
                                Refresh(message, selectedCustIndex);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbxCustomers.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = string.Empty;

                // Only Add if Id is empty, other wise they might mean edit.
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    Customer customer = new Customer();
                    customer.FirstName = txtFirstName.Text;
                    customer.LastName = txtLastName.Text;
                    customer.SSN = txtSSN.Text;
                    customer.BirthDate = dtpDOB.Value;
                    customer.Id = customers.Max(x => x.Id) + 1;

                    customers.Add(customer);
                    CustomerManager.WriteXML(customers, settings.CustomerXMLFileName);



                    string message = "Updated " + customer.FullName;
                    Refresh(message, customers.Count - 1);

                }
                else
                {
                    MessageBox.Show("Did you mean Save? Clear the screen If you want to Add New Customer");
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("You must select a customer to Delete");
            }
            else
            {
                Customer customer = lbxCustomers.SelectedItem as Customer;
                DialogResult result = MessageBox.Show("Delete " + customer.FullName + " ?", "Are You sure?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    customers.RemoveAt(lbxCustomers.SelectedIndex);
                    CustomerManager.WriteXML(customers, settings.CustomerXMLFileName);
                    Refresh();
                }

            }
        }

        private void btnWriteToFile_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerManager.Write(customers, settings.CustomersFileName);
                lblStatus.ForeColor = Color.Blue;
                lblStatus.Text = "Wrote to: " + settings.CustomersFileName;
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
            }
        }
    }
}