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
            TxtbDateOfBirthSearch = new TextBox();
            TxtbFirstNameSearch = new TextBox();
            LblDateOfBirth = new Label();
            LblFirstName = new Label();
            LblLastName = new Label();
            TxtbLastNameSearch = new TextBox();
            BtnReturnToHome = new Button();
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
            DgvCustomerList.Location = new Point(87, 327);
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
            // TxtbDateOfBirthSearch
            // 
            TxtbDateOfBirthSearch.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbDateOfBirthSearch.Location = new Point(262, 226);
            TxtbDateOfBirthSearch.Margin = new Padding(5, 4, 5, 4);
            TxtbDateOfBirthSearch.Name = "TxtbDateOfBirthSearch";
            TxtbDateOfBirthSearch.Size = new Size(240, 32);
            TxtbDateOfBirthSearch.TabIndex = 19;
            TxtbDateOfBirthSearch.Text = "...";
            // 
            // TxtbFirstNameSearch
            // 
            TxtbFirstNameSearch.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbFirstNameSearch.Location = new Point(262, 171);
            TxtbFirstNameSearch.Margin = new Padding(5, 4, 5, 4);
            TxtbFirstNameSearch.Name = "TxtbFirstNameSearch";
            TxtbFirstNameSearch.Size = new Size(240, 32);
            TxtbFirstNameSearch.TabIndex = 18;
            TxtbFirstNameSearch.Text = "...";
            // 
            // LblDateOfBirth
            // 
            LblDateOfBirth.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblDateOfBirth.Location = new Point(87, 228);
            LblDateOfBirth.Name = "LblDateOfBirth";
            LblDateOfBirth.Size = new Size(170, 35);
            LblDateOfBirth.TabIndex = 17;
            LblDateOfBirth.Text = "Geburtsdatum";
            // 
            // LblFirstName
            // 
            LblFirstName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblFirstName.Location = new Point(87, 175);
            LblFirstName.Name = "LblFirstName";
            LblFirstName.Size = new Size(170, 35);
            LblFirstName.TabIndex = 16;
            LblFirstName.Text = "Vorname";
            // 
            // LblLastName
            // 
            LblLastName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblLastName.Location = new Point(87, 122);
            LblLastName.Name = "LblLastName";
            LblLastName.Size = new Size(170, 35);
            LblLastName.TabIndex = 15;
            LblLastName.Text = "Nachname";
            // 
            // TxtbLastNameSearch
            // 
            TxtbLastNameSearch.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbLastNameSearch.Location = new Point(262, 119);
            TxtbLastNameSearch.Margin = new Padding(5, 4, 5, 4);
            TxtbLastNameSearch.Name = "TxtbLastNameSearch";
            TxtbLastNameSearch.Size = new Size(240, 32);
            TxtbLastNameSearch.TabIndex = 14;
            TxtbLastNameSearch.Text = "...";
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
            // CustomerListForm
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1388, 654);
            Controls.Add(BtnReturnToHome);
            Controls.Add(TxtbDateOfBirthSearch);
            Controls.Add(TxtbFirstNameSearch);
            Controls.Add(LblDateOfBirth);
            Controls.Add(LblFirstName);
            Controls.Add(LblLastName);
            Controls.Add(TxtbLastNameSearch);
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
        private TextBox TxtbDateOfBirthSearch;
        private TextBox TxtbFirstNameSearch;
        private Label LblDateOfBirth;
        private Label LblFirstName;
        private Label LblLastName;
        private TextBox TxtbLastNameSearch;
        private Button BtnReturnToHome;
    }
}