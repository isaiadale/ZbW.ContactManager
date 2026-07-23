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
            BtnAddCustomer = new Button();
            DgvCustomerList = new DataGridView();
            ColCustomerNumber = new DataGridViewTextBoxColumn();
            ColLastname = new DataGridViewTextBoxColumn();
            ColFirstName = new DataGridViewTextBoxColumn();
            ColTitle = new DataGridViewTextBoxColumn();
            ColDateOfBirth = new DataGridViewTextBoxColumn();
            ColPhone = new DataGridViewTextBoxColumn();
            ColEmail = new DataGridViewTextBoxColumn();
            ColStatus = new DataGridViewTextBoxColumn();
            TxtbFirstNameSearch = new TextBox();
            TxtbLastNameSearch = new TextBox();
            LblFirstName = new Label();
            LblLastName = new Label();
            LblCustomerNr = new Label();
            TxtbCustomerNrSearch = new TextBox();
            BtnReturnToHome = new Button();
            TxtbDateOfBirthSearch = new TextBox();
            LblDateOfBirth = new Label();
            ((System.ComponentModel.ISupportInitialize)DgvCustomerList).BeginInit();
            SuspendLayout();
            // 
            // LblCustomerListTitle
            // 
            LblCustomerListTitle.Dock = DockStyle.Top;
            LblCustomerListTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCustomerListTitle.Location = new Point(0, 0);
            LblCustomerListTitle.Name = "LblCustomerListTitle";
            LblCustomerListTitle.Size = new Size(1388, 70);
            LblCustomerListTitle.TabIndex = 1;
            LblCustomerListTitle.Text = "Übersicht Kundschaft";
            LblCustomerListTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // BtnAddCustomer
            // 
            BtnAddCustomer.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnAddCustomer.Location = new Point(1050, 122);
            BtnAddCustomer.Margin = new Padding(5, 4, 5, 4);
            BtnAddCustomer.Name = "BtnAddCustomer";
            BtnAddCustomer.Size = new Size(251, 43);
            BtnAddCustomer.TabIndex = 3;
            BtnAddCustomer.Text = "Neuer Kontakt";
            BtnAddCustomer.UseVisualStyleBackColor = true;
            // 
            // DgvCustomerList
            // 
            DgvCustomerList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvCustomerList.Columns.AddRange(new DataGridViewColumn[] { ColCustomerNumber, ColLastname, ColFirstName, ColTitle, ColDateOfBirth, ColPhone, ColEmail, ColStatus });
            DgvCustomerList.Location = new Point(87, 350);
            DgvCustomerList.Margin = new Padding(5, 4, 5, 4);
            DgvCustomerList.Name = "DgvCustomerList";
            DgvCustomerList.RowHeadersWidth = 62;
            DgvCustomerList.Size = new Size(1214, 278);
            DgvCustomerList.TabIndex = 5;
            // 
            // ColCustomerNumber
            // 
            ColCustomerNumber.HeaderText = "KD-Nr.";
            ColCustomerNumber.MinimumWidth = 8;
            ColCustomerNumber.Name = "ColCustomerNumber";
            ColCustomerNumber.Width = 80;
            // 
            // ColLastname
            // 
            ColLastname.HeaderText = "Nachname";
            ColLastname.MinimumWidth = 8;
            ColLastname.Name = "ColLastname";
            ColLastname.Width = 160;
            // 
            // ColFirstName
            // 
            ColFirstName.HeaderText = "Vorname";
            ColFirstName.MinimumWidth = 8;
            ColFirstName.Name = "ColFirstName";
            ColFirstName.Width = 160;
            // 
            // ColTitle
            // 
            ColTitle.HeaderText = "Titel";
            ColTitle.MinimumWidth = 8;
            ColTitle.Name = "ColTitle";
            ColTitle.Width = 150;
            // 
            // ColDateOfBirth
            // 
            ColDateOfBirth.HeaderText = "Geburtsdatum";
            ColDateOfBirth.MinimumWidth = 8;
            ColDateOfBirth.Name = "ColDateOfBirth";
            ColDateOfBirth.Width = 150;
            // 
            // ColPhone
            // 
            ColPhone.HeaderText = "Telefon";
            ColPhone.MinimumWidth = 8;
            ColPhone.Name = "ColPhone";
            ColPhone.Width = 150;
            // 
            // ColEmail
            // 
            ColEmail.HeaderText = "E-Mail";
            ColEmail.MinimumWidth = 8;
            ColEmail.Name = "ColEmail";
            ColEmail.Width = 220;
            // 
            // ColStatus
            // 
            ColStatus.HeaderText = "Status";
            ColStatus.MinimumWidth = 8;
            ColStatus.Name = "ColStatus";
            ColStatus.Width = 80;
            // 
            // TxtbFirstNameSearch
            // 
            TxtbFirstNameSearch.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbFirstNameSearch.Location = new Point(262, 233);
            TxtbFirstNameSearch.Margin = new Padding(5, 4, 5, 4);
            TxtbFirstNameSearch.Name = "TxtbFirstNameSearch";
            TxtbFirstNameSearch.Size = new Size(240, 32);
            TxtbFirstNameSearch.TabIndex = 19;
            TxtbFirstNameSearch.Text = "...";
            // 
            // TxtbLastNameSearch
            // 
            TxtbLastNameSearch.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbLastNameSearch.Location = new Point(262, 176);
            TxtbLastNameSearch.Margin = new Padding(5, 4, 5, 4);
            TxtbLastNameSearch.Name = "TxtbLastNameSearch";
            TxtbLastNameSearch.Size = new Size(240, 32);
            TxtbLastNameSearch.TabIndex = 18;
            TxtbLastNameSearch.Text = "...";
            // 
            // LblFirstName
            // 
            LblFirstName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblFirstName.Location = new Point(87, 236);
            LblFirstName.Name = "LblFirstName";
            LblFirstName.Size = new Size(170, 32);
            LblFirstName.TabIndex = 17;
            LblFirstName.Text = "Vorname";
            // 
            // LblLastName
            // 
            LblLastName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblLastName.Location = new Point(87, 179);
            LblLastName.Name = "LblLastName";
            LblLastName.Size = new Size(170, 32);
            LblLastName.TabIndex = 16;
            LblLastName.Text = "Nachname";
            // 
            // LblCustomerNr
            // 
            LblCustomerNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblCustomerNr.Location = new Point(87, 122);
            LblCustomerNr.Name = "LblCustomerNr";
            LblCustomerNr.Size = new Size(170, 32);
            LblCustomerNr.TabIndex = 15;
            LblCustomerNr.Text = "KD-Nummer";
            // 
            // TxtbCustomerNrSearch
            // 
            TxtbCustomerNrSearch.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbCustomerNrSearch.Location = new Point(262, 119);
            TxtbCustomerNrSearch.Margin = new Padding(5, 4, 5, 4);
            TxtbCustomerNrSearch.Name = "TxtbCustomerNrSearch";
            TxtbCustomerNrSearch.Size = new Size(240, 32);
            TxtbCustomerNrSearch.TabIndex = 14;
            TxtbCustomerNrSearch.Text = "...";
            // 
            // BtnReturnToHome
            // 
            BtnReturnToHome.Font = new Font("Century Gothic", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnReturnToHome.Location = new Point(25, 27);
            BtnReturnToHome.Margin = new Padding(5, 4, 5, 4);
            BtnReturnToHome.Name = "BtnReturnToHome";
            BtnReturnToHome.Size = new Size(192, 43);
            BtnReturnToHome.TabIndex = 20;
            BtnReturnToHome.Text = "Zurück (ev. mit Icon)";
            BtnReturnToHome.UseVisualStyleBackColor = true;
            BtnReturnToHome.Click += BtnReturnToHome_Click;
            // 
            // TxtbDateOfBirthSearch
            // 
            TxtbDateOfBirthSearch.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbDateOfBirthSearch.Location = new Point(262, 290);
            TxtbDateOfBirthSearch.Margin = new Padding(5, 4, 5, 4);
            TxtbDateOfBirthSearch.Name = "TxtbDateOfBirthSearch";
            TxtbDateOfBirthSearch.Size = new Size(240, 32);
            TxtbDateOfBirthSearch.TabIndex = 22;
            TxtbDateOfBirthSearch.Text = "...";
            // 
            // LblDateOfBirth
            // 
            LblDateOfBirth.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblDateOfBirth.Location = new Point(87, 293);
            LblDateOfBirth.Name = "LblDateOfBirth";
            LblDateOfBirth.Size = new Size(170, 32);
            LblDateOfBirth.TabIndex = 21;
            LblDateOfBirth.Text = "Geburtsdatum";
            // 
            // CustomerListForm
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1388, 654);
            Controls.Add(TxtbDateOfBirthSearch);
            Controls.Add(LblDateOfBirth);
            Controls.Add(BtnReturnToHome);
            Controls.Add(TxtbFirstNameSearch);
            Controls.Add(TxtbLastNameSearch);
            Controls.Add(LblFirstName);
            Controls.Add(LblLastName);
            Controls.Add(LblCustomerNr);
            Controls.Add(TxtbCustomerNrSearch);
            Controls.Add(DgvCustomerList);
            Controls.Add(BtnAddCustomer);
            Controls.Add(LblCustomerListTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CustomerListForm";
            Text = "ContactManager - Kundschaft";
            ((System.ComponentModel.ISupportInitialize)DgvCustomerList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblCustomerListTitle;
        private Button BtnAddCustomer;
        private DataGridView DgvCustomerList;
        private DataGridViewTextBoxColumn ColCustomerNumber;
        private DataGridViewTextBoxColumn ColLastname;
        private DataGridViewTextBoxColumn ColFirstName;
        private DataGridViewTextBoxColumn ColTitle;
        private DataGridViewTextBoxColumn ColDateOfBirth;
        private DataGridViewTextBoxColumn ColPhone;
        private DataGridViewTextBoxColumn ColEmail;
        private DataGridViewTextBoxColumn ColStatus;
        private TextBox TxtbFirstNameSearch;
        private TextBox TxtbLastNameSearch;
        private Label LblFirstName;
        private Label LblLastName;
        private Label LblCustomerNr;
        private TextBox TxtbCustomerNrSearch;
        private Button BtnReturnToHome;
        private TextBox TxtbDateOfBirthSearch;
        private Label LblDateOfBirth;
    }
}