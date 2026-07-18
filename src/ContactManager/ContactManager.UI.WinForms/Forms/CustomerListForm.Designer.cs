namespace ContactManager.UI.WinForms.Forms
{
    partial class CustomerListForm
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
            LblCustomerListTitle = new Label();
            TxtbSearch = new TextBox();
            BtnAddCustomer = new Button();
            BtnDeleteCustomer = new Button();
            DgvCustomerList = new DataGridView();
            ColCustomerNumber = new DataGridViewTextBoxColumn();
            ColLastname = new DataGridViewTextBoxColumn();
            ColFirstName = new DataGridViewTextBoxColumn();
            ColTitle = new DataGridViewTextBoxColumn();
            ColDateOfBirth = new DataGridViewTextBoxColumn();
            ColPhone = new DataGridViewTextBoxColumn();
            ColEmail = new DataGridViewTextBoxColumn();
            ColStatus = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)DgvCustomerList).BeginInit();
            SuspendLayout();
            // 
            // LblCustomerListTitle
            // 
            LblCustomerListTitle.Dock = DockStyle.Top;
            LblCustomerListTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCustomerListTitle.Location = new Point(0, 0);
            LblCustomerListTitle.Margin = new Padding(2, 0, 2, 0);
            LblCustomerListTitle.Name = "LblCustomerListTitle";
            LblCustomerListTitle.Size = new Size(1024, 57);
            LblCustomerListTitle.TabIndex = 1;
            LblCustomerListTitle.Text = "Kundschaft";
            LblCustomerListTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // TxtbSearch
            // 
            TxtbSearch.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbSearch.Location = new Point(379, 77);
            TxtbSearch.Multiline = true;
            TxtbSearch.Name = "TxtbSearch";
            TxtbSearch.Size = new Size(266, 35);
            TxtbSearch.TabIndex = 2;
            TxtbSearch.Text = " * Textbox für Suche";
            // 
            // BtnAddCustomer
            // 
            BtnAddCustomer.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnAddCustomer.Location = new Point(61, 77);
            BtnAddCustomer.Name = "BtnAddCustomer";
            BtnAddCustomer.Size = new Size(160, 35);
            BtnAddCustomer.TabIndex = 3;
            BtnAddCustomer.Text = "Neuer Kontakt";
            BtnAddCustomer.UseVisualStyleBackColor = true;
            // 
            // BtnDeleteCustomer
            // 
            BtnDeleteCustomer.Location = new Point(834, 422);
            BtnDeleteCustomer.Name = "BtnDeleteCustomer";
            BtnDeleteCustomer.Size = new Size(130, 35);
            BtnDeleteCustomer.TabIndex = 4;
            BtnDeleteCustomer.Text = "Löschen";
            BtnDeleteCustomer.UseVisualStyleBackColor = true;
            // 
            // DgvCustomerList
            // 
            DgvCustomerList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvCustomerList.Columns.AddRange(new DataGridViewColumn[] { ColCustomerNumber, ColLastname, ColFirstName, ColTitle, ColDateOfBirth, ColPhone, ColEmail, ColStatus });
            DgvCustomerList.Location = new Point(61, 132);
            DgvCustomerList.Name = "DgvCustomerList";
            DgvCustomerList.Size = new Size(903, 270);
            DgvCustomerList.TabIndex = 5;
            DgvCustomerList.CellContentClick += DgvCustomerList_CellContentClick;
            // 
            // ColCustomerNumber
            // 
            ColCustomerNumber.HeaderText = "Nr.";
            ColCustomerNumber.Name = "ColCustomerNumber";
            ColCustomerNumber.Width = 40;
            // 
            // ColLastname
            // 
            ColLastname.HeaderText = "Nachname";
            ColLastname.Name = "ColLastname";
            ColLastname.Width = 120;
            // 
            // ColFirstName
            // 
            ColFirstName.HeaderText = "Vorname";
            ColFirstName.Name = "ColFirstName";
            ColFirstName.Width = 120;
            // 
            // ColTitle
            // 
            ColTitle.HeaderText = "Titel";
            ColTitle.Name = "ColTitle";
            // 
            // ColDateOfBirth
            // 
            ColDateOfBirth.HeaderText = "Geburtsdatum";
            ColDateOfBirth.Name = "ColDateOfBirth";
            // 
            // ColPhone
            // 
            ColPhone.HeaderText = "Telefon";
            ColPhone.Name = "ColPhone";
            // 
            // ColEmail
            // 
            ColEmail.HeaderText = "E-Mail";
            ColEmail.Name = "ColEmail";
            ColEmail.Width = 200;
            // 
            // ColStatus
            // 
            ColStatus.HeaderText = "Status";
            ColStatus.Name = "ColStatus";
            ColStatus.Width = 80;
            // 
            // CustomerListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 471);
            Controls.Add(DgvCustomerList);
            Controls.Add(BtnDeleteCustomer);
            Controls.Add(BtnAddCustomer);
            Controls.Add(TxtbSearch);
            Controls.Add(LblCustomerListTitle);
            Margin = new Padding(2);
            Name = "CustomerListForm";
            Text = "ContactManager - Kundschaft";
            ((System.ComponentModel.ISupportInitialize)DgvCustomerList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblCustomerListTitle;
        private TextBox TxtbSearch;
        private Button BtnAddCustomer;
        private Button BtnDeleteCustomer;
        private DataGridView DgvCustomerList;
        private DataGridViewTextBoxColumn ColCustomerNumber;
        private DataGridViewTextBoxColumn ColLastname;
        private DataGridViewTextBoxColumn ColFirstName;
        private DataGridViewTextBoxColumn ColTitle;
        private DataGridViewTextBoxColumn ColDateOfBirth;
        private DataGridViewTextBoxColumn ColPhone;
        private DataGridViewTextBoxColumn ColEmail;
        private DataGridViewTextBoxColumn ColStatus;
    }
}