namespace DDB.Banking.UI
{
    partial class frmWithdrawal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            txtWithdrawalAmount = new TextBox();
            lblWithdrawalAmount = new Label();
            lblHeading = new Label();
            dtpWithdrawalDate = new DateTimePicker();
            lblWithdrawalDate = new Label();
            lblCustomer = new Label();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(295, 215);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(95, 46);
            btnSave.TabIndex = 25;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtWithdrawalAmount
            // 
            txtWithdrawalAmount.Location = new Point(135, 109);
            txtWithdrawalAmount.Name = "txtWithdrawalAmount";
            txtWithdrawalAmount.Size = new Size(174, 23);
            txtWithdrawalAmount.TabIndex = 24;
            // 
            // lblWithdrawalAmount
            // 
            lblWithdrawalAmount.AutoSize = true;
            lblWithdrawalAmount.Location = new Point(12, 112);
            lblWithdrawalAmount.Name = "lblWithdrawalAmount";
            lblWithdrawalAmount.Size = new Size(117, 15);
            lblWithdrawalAmount.TabIndex = 23;
            lblWithdrawalAmount.Text = "Withdrawal Amount:";
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblHeading.Location = new Point(12, 51);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(248, 32);
            lblHeading.TabIndex = 22;
            lblHeading.Text = "New Dep / Edit Dep #";
            // 
            // dtpWithdrawalDate
            // 
            dtpWithdrawalDate.Format = DateTimePickerFormat.Short;
            dtpWithdrawalDate.Location = new Point(135, 150);
            dtpWithdrawalDate.Name = "dtpWithdrawalDate";
            dtpWithdrawalDate.Size = new Size(174, 23);
            dtpWithdrawalDate.TabIndex = 21;
            // 
            // lblWithdrawalDate
            // 
            lblWithdrawalDate.AutoSize = true;
            lblWithdrawalDate.Location = new Point(12, 156);
            lblWithdrawalDate.Name = "lblWithdrawalDate";
            lblWithdrawalDate.Size = new Size(97, 15);
            lblWithdrawalDate.TabIndex = 20;
            lblWithdrawalDate.Text = "Withdrawal Date:";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblCustomer.Location = new Point(12, 9);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(132, 32);
            lblCustomer.TabIndex = 19;
            lblCustomer.Text = "Cust Name";
            // 
            // frmWithdrawal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 324);
            Controls.Add(btnSave);
            Controls.Add(txtWithdrawalAmount);
            Controls.Add(lblWithdrawalAmount);
            Controls.Add(lblHeading);
            Controls.Add(dtpWithdrawalDate);
            Controls.Add(lblWithdrawalDate);
            Controls.Add(lblCustomer);
            Name = "frmWithdrawal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Withdrawal Form";
            Load += frmWithdrawal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private TextBox txtWithdrawalAmount;
        private Label lblWithdrawalAmount;
        private Label lblHeading;
        private DateTimePicker dtpWithdrawalDate;
        private Label lblWithdrawalDate;
        private Label lblCustomer;
    }
}