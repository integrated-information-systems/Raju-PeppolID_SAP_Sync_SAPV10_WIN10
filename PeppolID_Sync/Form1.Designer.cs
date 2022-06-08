namespace PeppolID_Sync
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bttnSync = new System.Windows.Forms.Button();
            this.CustomerGrid = new System.Windows.Forms.DataGridView();
            this.SeqNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lictradnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U_custpeppolid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblError = new System.Windows.Forms.Label();
            this.lblCompanyAndDB = new System.Windows.Forms.Label();
            this.bttnGetNextCustomers = new System.Windows.Forms.Button();
            this.lblPageSizeMsg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.lblCustomerSearch = new System.Windows.Forms.Label();
            this.bttnGOSearch = new System.Windows.Forms.Button();
            this.bttnRefreshFromDB = new System.Windows.Forms.Button();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttnSync
            // 
            this.bttnSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnSync.Location = new System.Drawing.Point(507, 31);
            this.bttnSync.Name = "bttnSync";
            this.bttnSync.Size = new System.Drawing.Size(179, 25);
            this.bttnSync.TabIndex = 4;
            this.bttnSync.Text = "Peppol ID SAP Sync";
            this.bttnSync.UseVisualStyleBackColor = true;
            this.bttnSync.Click += new System.EventHandler(this.bttnSync_Click);
            // 
            // CustomerGrid
            // 
            this.CustomerGrid.AllowUserToAddRows = false;
            this.CustomerGrid.AllowUserToDeleteRows = false;
            this.CustomerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.CustomerGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.CustomerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeqNum,
            this.CardCode,
            this.CardName,
            this.lictradnum,
            this.U_custpeppolid,
            this.SyncStatus});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CustomerGrid.DefaultCellStyle = dataGridViewCellStyle10;
            this.CustomerGrid.Location = new System.Drawing.Point(1, 59);
            this.CustomerGrid.Name = "CustomerGrid";
            this.CustomerGrid.ReadOnly = true;
            this.CustomerGrid.RowTemplate.Height = 24;
            this.CustomerGrid.Size = new System.Drawing.Size(973, 446);
            this.CustomerGrid.TabIndex = 5;
            // 
            // SeqNum
            // 
            this.SeqNum.DataPropertyName = "SeqNum";
            this.SeqNum.HeaderText = "Seq Num";
            this.SeqNum.Name = "SeqNum";
            this.SeqNum.ReadOnly = true;
            this.SeqNum.Width = 95;
            // 
            // CardCode
            // 
            this.CardCode.DataPropertyName = "CardCode";
            this.CardCode.HeaderText = "Customer Code";
            this.CardCode.Name = "CardCode";
            this.CardCode.ReadOnly = true;
            this.CardCode.Width = 134;
            // 
            // CardName
            // 
            this.CardName.DataPropertyName = "CardName";
            this.CardName.HeaderText = "Customer Name";
            this.CardName.Name = "CardName";
            this.CardName.ReadOnly = true;
            this.CardName.Width = 138;
            // 
            // lictradnum
            // 
            this.lictradnum.DataPropertyName = "lictradnum";
            this.lictradnum.HeaderText = "UEN";
            this.lictradnum.Name = "lictradnum";
            this.lictradnum.ReadOnly = true;
            this.lictradnum.Width = 66;
            // 
            // U_custpeppolid
            // 
            this.U_custpeppolid.DataPropertyName = "U_custpeppolid";
            this.U_custpeppolid.HeaderText = "Peppol ID";
            this.U_custpeppolid.Name = "U_custpeppolid";
            this.U_custpeppolid.ReadOnly = true;
            this.U_custpeppolid.Width = 98;
            // 
            // SyncStatus
            // 
            this.SyncStatus.DataPropertyName = "U_peppol";
            this.SyncStatus.HeaderText = "Sync Status";
            this.SyncStatus.Name = "SyncStatus";
            this.SyncStatus.ReadOnly = true;
            this.SyncStatus.Width = 112;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(-2, 524);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(74, 17);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "errorLabel";
            // 
            // lblCompanyAndDB
            // 
            this.lblCompanyAndDB.AutoSize = true;
            this.lblCompanyAndDB.Location = new System.Drawing.Point(12, 9);
            this.lblCompanyAndDB.Name = "lblCompanyAndDB";
            this.lblCompanyAndDB.Size = new System.Drawing.Size(485, 17);
            this.lblCompanyAndDB.TabIndex = 3;
            this.lblCompanyAndDB.Text = " Company Server : <CompanySever>    Database Name : <DatabaseName>";
            // 
            // bttnGetNextCustomers
            // 
            this.bttnGetNextCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnGetNextCustomers.ForeColor = System.Drawing.Color.Black;
            this.bttnGetNextCustomers.Location = new System.Drawing.Point(318, 31);
            this.bttnGetNextCustomers.Name = "bttnGetNextCustomers";
            this.bttnGetNextCustomers.Size = new System.Drawing.Size(183, 25);
            this.bttnGetNextCustomers.TabIndex = 3;
            this.bttnGetNextCustomers.Text = "Get Next Customers";
            this.bttnGetNextCustomers.UseVisualStyleBackColor = true;
            this.bttnGetNextCustomers.Click += new System.EventHandler(this.bttnbttnGetNextCustomers_Click);
            // 
            // lblPageSizeMsg
            // 
            this.lblPageSizeMsg.AutoSize = true;
            this.lblPageSizeMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageSizeMsg.Location = new System.Drawing.Point(704, 508);
            this.lblPageSizeMsg.Name = "lblPageSizeMsg";
            this.lblPageSizeMsg.Size = new System.Drawing.Size(270, 15);
            this.lblPageSizeMsg.TabIndex = 12;
            this.lblPageSizeMsg.Text = "** <PageSize> records will be synched at a time.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCustomerCode);
            this.panel1.Controls.Add(this.lblCustomerSearch);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 24);
            this.panel1.TabIndex = 13;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(82, 1);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(137, 22);
            this.txtCustomerCode.TabIndex = 1;
            // 
            // lblCustomerSearch
            // 
            this.lblCustomerSearch.Location = new System.Drawing.Point(4, 5);
            this.lblCustomerSearch.Name = "lblCustomerSearch";
            this.lblCustomerSearch.Size = new System.Drawing.Size(100, 17);
            this.lblCustomerSearch.TabIndex = 0;
            this.lblCustomerSearch.Text = "Customer Code:";
            // 
            // bttnGOSearch
            // 
            this.bttnGOSearch.Location = new System.Drawing.Point(225, 31);
            this.bttnGOSearch.Name = "bttnGOSearch";
            this.bttnGOSearch.Size = new System.Drawing.Size(40, 22);
            this.bttnGOSearch.TabIndex = 2;
            this.bttnGOSearch.Text = "Go";
            this.bttnGOSearch.UseVisualStyleBackColor = true;
            this.bttnGOSearch.Click += new System.EventHandler(this.bttnGOSearch_Click);
            // 
            // bttnRefreshFromDB
            // 
            this.bttnRefreshFromDB.Location = new System.Drawing.Point(832, 5);
            this.bttnRefreshFromDB.Name = "bttnRefreshFromDB";
            this.bttnRefreshFromDB.Size = new System.Drawing.Size(142, 23);
            this.bttnRefreshFromDB.TabIndex = 14;
            this.bttnRefreshFromDB.Text = "Refresh From DB";
            this.bttnRefreshFromDB.UseVisualStyleBackColor = true;
            this.bttnRefreshFromDB.Click += new System.EventHandler(this.bttnRefreshFromDB_Click);
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(407, 5);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(121, 24);
            this.cmbDatabase.TabIndex = 15;
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 574);
            this.Controls.Add(this.cmbDatabase);
            this.Controls.Add(this.bttnRefreshFromDB);
            this.Controls.Add(this.bttnGOSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPageSizeMsg);
            this.Controls.Add(this.bttnGetNextCustomers);
            this.Controls.Add(this.lblCompanyAndDB);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.CustomerGrid);
            this.Controls.Add(this.bttnSync);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Peppol ID SAP Sync";
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttnSync;
        private System.Windows.Forms.DataGridView CustomerGrid;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblCompanyAndDB;
        private System.Windows.Forms.Button bttnGetNextCustomers;
        private System.Windows.Forms.Label lblPageSizeMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeqNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lictradnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn U_custpeppolid;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bttnGOSearch;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label lblCustomerSearch;
        private System.Windows.Forms.Button bttnRefreshFromDB;
        private System.Windows.Forms.ComboBox cmbDatabase;
    }
}

