namespace DDB.Banking.UI
{
    partial class frmBanking
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbxCustomers = new ListBox();
            lblCustomers = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblSSN = new Label();
            lblId = new Label();
            lblDOB = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtSSN = new TextBox();
            txtId = new TextBox();
            dtpDOB = new DateTimePicker();
            dgvDeposits = new DataGridView();
            lblDeposits = new Label();
            btnAddDeposit = new Button();
            btnEditDeposit = new Button();
            btnEditWithdrawal = new Button();
            btnAddWithdrawal = new Button();
            lblWithdrawals = new Label();
            dgvWithdrawals = new DataGridView();
            btnExit = new Button();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dgvDeposits).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvWithdrawals).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lbxCustomers
            // 
            lbxCustomers.FormattingEnabled = true;
            lbxCustomers.ItemHeight = 15;
            lbxCustomers.Location = new Point(12, 29);
            lbxCustomers.Name = "lbxCustomers";
            lbxCustomers.Size = new Size(321, 184);
            lbxCustomers.TabIndex = 0;
            lbxCustomers.SelectedIndexChanged += lbxCustomers_SelectedIndexChanged;
            // 
            // lblCustomers
            // 
            lblCustomers.AutoSize = true;
            lblCustomers.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCustomers.Location = new Point(12, 11);
            lblCustomers.Name = "lblCustomers";
            lblCustomers.Size = new Size(66, 15);
            lblCustomers.TabIndex = 1;
            lblCustomers.Text = "Customers";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(359, 11);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(67, 15);
            lblFirstName.TabIndex = 2;
            lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(359, 57);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(66, 15);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Last Name:";
            // 
            // lblSSN
            // 
            lblSSN.AutoSize = true;
            lblSSN.Location = new Point(359, 103);
            lblSSN.Name = "lblSSN";
            lblSSN.Size = new Size(31, 15);
            lblSSN.TabIndex = 4;
            lblSSN.Text = "SSN:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(359, 149);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 5;
            lblId.Text = "Id:";
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(359, 195);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(62, 15);
            lblDOB.TabIndex = 6;
            lblDOB.Text = "Birth Date:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(442, 8);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(174, 23);
            txtFirstName.TabIndex = 7;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(442, 54);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(174, 23);
            txtLastName.TabIndex = 8;
            // 
            // txtSSN
            // 
            txtSSN.Location = new Point(442, 100);
            txtSSN.Name = "txtSSN";
            txtSSN.Size = new Size(174, 23);
            txtSSN.TabIndex = 9;
            txtSSN.TextAlign = HorizontalAlignment.Right;
            // 
            // txtId
            // 
            txtId.Location = new Point(442, 146);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(174, 23);
            txtId.TabIndex = 10;
            txtId.TextAlign = HorizontalAlignment.Right;
            // 
            // dtpDOB
            // 
            dtpDOB.Format = DateTimePickerFormat.Short;
            dtpDOB.Location = new Point(442, 189);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(174, 23);
            dtpDOB.TabIndex = 12;
            // 
            // dgvDeposits
            // 
            dgvDeposits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeposits.Location = new Point(12, 265);
            dgvDeposits.Name = "dgvDeposits";
            dgvDeposits.RowTemplate.Height = 25;
            dgvDeposits.Size = new Size(604, 150);
            dgvDeposits.TabIndex = 13;
            // 
            // lblDeposits
            // 
            lblDeposits.AutoSize = true;
            lblDeposits.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDeposits.Location = new Point(12, 247);
            lblDeposits.Name = "lblDeposits";
            lblDeposits.Size = new Size(55, 15);
            lblDeposits.TabIndex = 14;
            lblDeposits.Text = "Deposits";
            // 
            // btnAddDeposit
            // 
            btnAddDeposit.Location = new Point(410, 421);
            btnAddDeposit.Name = "btnAddDeposit";
            btnAddDeposit.Size = new Size(100, 27);
            btnAddDeposit.TabIndex = 15;
            btnAddDeposit.Text = "Add Deposit";
            btnAddDeposit.UseVisualStyleBackColor = true;
            // 
            // btnEditDeposit
            // 
            btnEditDeposit.Location = new Point(516, 421);
            btnEditDeposit.Name = "btnEditDeposit";
            btnEditDeposit.Size = new Size(100, 27);
            btnEditDeposit.TabIndex = 16;
            btnEditDeposit.Text = "Edit Deposit";
            btnEditDeposit.UseVisualStyleBackColor = true;
            // 
            // btnEditWithdrawal
            // 
            btnEditWithdrawal.Location = new Point(427, 621);
            btnEditWithdrawal.Name = "btnEditWithdrawal";
            btnEditWithdrawal.Size = new Size(100, 27);
            btnEditWithdrawal.TabIndex = 20;
            btnEditWithdrawal.Text = "Edit Withdrawal";
            btnEditWithdrawal.UseVisualStyleBackColor = true;
            // 
            // btnAddWithdrawal
            // 
            btnAddWithdrawal.Location = new Point(321, 621);
            btnAddWithdrawal.Name = "btnAddWithdrawal";
            btnAddWithdrawal.Size = new Size(100, 27);
            btnAddWithdrawal.TabIndex = 19;
            btnAddWithdrawal.Text = "Add Withdrawal";
            btnAddWithdrawal.UseVisualStyleBackColor = true;
            // 
            // lblWithdrawals
            // 
            lblWithdrawals.AutoSize = true;
            lblWithdrawals.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblWithdrawals.Location = new Point(12, 447);
            lblWithdrawals.Name = "lblWithdrawals";
            lblWithdrawals.Size = new Size(76, 15);
            lblWithdrawals.TabIndex = 18;
            lblWithdrawals.Text = "Withdrawals";
            // 
            // dgvWithdrawals
            // 
            dgvWithdrawals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWithdrawals.Location = new Point(12, 465);
            dgvWithdrawals.Name = "dgvWithdrawals";
            dgvWithdrawals.RowTemplate.Height = 25;
            dgvWithdrawals.Size = new Size(604, 150);
            dgvWithdrawals.TabIndex = 17;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(533, 621);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(83, 27);
            btnExit.TabIndex = 21;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 646);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(658, 22);
            statusStrip1.TabIndex = 22;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(38, 17);
            lblStatus.Text = "status";
            // 
            // frmBanking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(658, 668);
            Controls.Add(statusStrip1);
            Controls.Add(btnExit);
            Controls.Add(btnEditWithdrawal);
            Controls.Add(btnAddWithdrawal);
            Controls.Add(lblWithdrawals);
            Controls.Add(dgvWithdrawals);
            Controls.Add(btnEditDeposit);
            Controls.Add(btnAddDeposit);
            Controls.Add(lblDeposits);
            Controls.Add(dgvDeposits);
            Controls.Add(dtpDOB);
            Controls.Add(txtId);
            Controls.Add(txtSSN);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblDOB);
            Controls.Add(lblId);
            Controls.Add(lblSSN);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(lblCustomers);
            Controls.Add(lbxCustomers);
            Name = "frmBanking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Information";
            Load += frmBanking_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDeposits).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvWithdrawals).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbxCustomers;
        private Label lblCustomers;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblSSN;
        private Label lblId;
        private Label lblDOB;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtSSN;
        private TextBox txtId;
        private DateTimePicker dtpDOB;
        private DataGridView dgvDeposits;
        private Label lblDeposits;
        private Button btnAddDeposit;
        private Button btnEditDeposit;
        private Button btnEditWithdrawal;
        private Button btnAddWithdrawal;
        private Label lblWithdrawals;
        private DataGridView dgvWithdrawals;
        private Button btnExit;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}