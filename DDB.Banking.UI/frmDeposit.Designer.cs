namespace DDB.Banking.UI
{
    partial class frmDeposit
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
            lblCustomer = new Label();
            dtpDepositDate = new DateTimePicker();
            lblDepositeDate = new Label();
            lblHeading = new Label();
            lblDepositAmount = new Label();
            txtDepositAmount = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblCustomer.Location = new Point(12, 9);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(132, 32);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Cust Name";
            // 
            // dtpDepositDate
            // 
            dtpDepositDate.Format = DateTimePickerFormat.Short;
            dtpDepositDate.Location = new Point(115, 150);
            dtpDepositDate.Name = "dtpDepositDate";
            dtpDepositDate.Size = new Size(174, 23);
            dtpDepositDate.TabIndex = 14;
            // 
            // lblDepositeDate
            // 
            lblDepositeDate.AutoSize = true;
            lblDepositeDate.Location = new Point(12, 156);
            lblDepositeDate.Name = "lblDepositeDate";
            lblDepositeDate.Size = new Size(77, 15);
            lblDepositeDate.TabIndex = 13;
            lblDepositeDate.Text = "Deposit Date:";
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblHeading.Location = new Point(12, 51);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(248, 32);
            lblHeading.TabIndex = 15;
            lblHeading.Text = "New Dep / Edit Dep #";
            // 
            // lblDepositAmount
            // 
            lblDepositAmount.AutoSize = true;
            lblDepositAmount.Location = new Point(12, 112);
            lblDepositAmount.Name = "lblDepositAmount";
            lblDepositAmount.Size = new Size(97, 15);
            lblDepositAmount.TabIndex = 16;
            lblDepositAmount.Text = "Deposit Amount:";
            // 
            // txtDepositAmount
            // 
            txtDepositAmount.Location = new Point(115, 109);
            txtDepositAmount.Name = "txtDepositAmount";
            txtDepositAmount.Size = new Size(174, 23);
            txtDepositAmount.TabIndex = 17;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(295, 215);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(95, 46);
            btnSave.TabIndex = 18;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // frmDeposit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 324);
            Controls.Add(btnSave);
            Controls.Add(txtDepositAmount);
            Controls.Add(lblDepositAmount);
            Controls.Add(lblHeading);
            Controls.Add(dtpDepositDate);
            Controls.Add(lblDepositeDate);
            Controls.Add(lblCustomer);
            Name = "frmDeposit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Deposit Form";
            Load += frmDeposit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomer;
        private DateTimePicker dtpDepositDate;
        private Label lblDepositeDate;
        private Label lblHeading;
        private Label lblDepositAmount;
        private TextBox txtDepositAmount;
        private Button btnSave;
    }
}