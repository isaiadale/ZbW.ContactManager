namespace ContactManager.UI.WinForms.Forms
{
    partial class EmployeeListForm
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
            BtnAddEmployee = new Button();
            TxtbLastNameSearch = new TextBox();
            DgvEmployeeList = new DataGridView();
            ColEmployeeNumber = new DataGridViewTextBoxColumn();
            ColLastname = new DataGridViewTextBoxColumn();
            ColFirstName = new DataGridViewTextBoxColumn();
            ColDateOfBirth = new DataGridViewTextBoxColumn();
            ColPhone = new DataGridViewTextBoxColumn();
            ColEmail = new DataGridViewTextBoxColumn();
            ColDepartment = new DataGridViewTextBoxColumn();
            ColJobTitle = new DataGridViewTextBoxColumn();
            LblEmployeeListTitle = new Label();
            LblLastName = new Label();
            LblFirstName = new Label();
            LblDateOfBirth = new Label();
            TxtbFirstNameSearch = new TextBox();
            TxtbDateOfBirthSearch = new TextBox();
            BtnReturnToHome = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvEmployeeList).BeginInit();
            SuspendLayout();
            // 
            // BtnAddEmployee
            // 
            BtnAddEmployee.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnAddEmployee.Location = new Point(1044, 122);
            BtnAddEmployee.Margin = new Padding(5, 4, 5, 4);
            BtnAddEmployee.Name = "BtnAddEmployee";
            BtnAddEmployee.Size = new Size(292, 43);
            BtnAddEmployee.TabIndex = 5;
            BtnAddEmployee.Text = "Neue Mitarbeitende";
            BtnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // TxtbLastNameSearch
            // 
            TxtbLastNameSearch.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbLastNameSearch.Location = new Point(229, 119);
            TxtbLastNameSearch.Margin = new Padding(5, 4, 5, 4);
            TxtbLastNameSearch.Name = "TxtbLastNameSearch";
            TxtbLastNameSearch.Size = new Size(240, 32);
            TxtbLastNameSearch.TabIndex = 4;
            TxtbLastNameSearch.Text = "...";
            // 
            // DgvEmployeeList
            // 
            DgvEmployeeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvEmployeeList.Columns.AddRange(new DataGridViewColumn[] { ColEmployeeNumber, ColLastname, ColFirstName, ColDateOfBirth, ColPhone, ColEmail, ColDepartment, ColJobTitle });
            DgvEmployeeList.Location = new Point(52, 327);
            DgvEmployeeList.Margin = new Padding(5, 4, 5, 4);
            DgvEmployeeList.Name = "DgvEmployeeList";
            DgvEmployeeList.RowHeadersWidth = 62;
            DgvEmployeeList.Size = new Size(1284, 278);
            DgvEmployeeList.TabIndex = 7;
            // 
            // ColEmployeeNumber
            // 
            ColEmployeeNumber.HeaderText = "MA-Nr.";
            ColEmployeeNumber.MinimumWidth = 8;
            ColEmployeeNumber.Name = "ColEmployeeNumber";
            ColEmployeeNumber.Width = 80;
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
            // ColDepartment
            // 
            ColDepartment.HeaderText = "Abteilung";
            ColDepartment.MinimumWidth = 8;
            ColDepartment.Name = "ColDepartment";
            ColDepartment.Width = 150;
            // 
            // ColJobTitle
            // 
            ColJobTitle.HeaderText = "Rolle";
            ColJobTitle.MinimumWidth = 8;
            ColJobTitle.Name = "ColJobTitle";
            ColJobTitle.Width = 150;
            // 
            // LblEmployeeListTitle
            // 
            LblEmployeeListTitle.Dock = DockStyle.Top;
            LblEmployeeListTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblEmployeeListTitle.Location = new Point(0, 0);
            LblEmployeeListTitle.Name = "LblEmployeeListTitle";
            LblEmployeeListTitle.Size = new Size(1388, 70);
            LblEmployeeListTitle.TabIndex = 8;
            LblEmployeeListTitle.Text = "Übersicht Mitarbeitende";
            LblEmployeeListTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // LblLastName
            // 
            LblLastName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblLastName.Location = new Point(52, 122);
            LblLastName.Name = "LblLastName";
            LblLastName.Size = new Size(170, 35);
            LblLastName.TabIndex = 9;
            LblLastName.Text = "Nachname";
            // 
            // LblFirstName
            // 
            LblFirstName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblFirstName.Location = new Point(52, 175);
            LblFirstName.Name = "LblFirstName";
            LblFirstName.Size = new Size(170, 35);
            LblFirstName.TabIndex = 10;
            LblFirstName.Text = "Vorname";
            // 
            // LblDateOfBirth
            // 
            LblDateOfBirth.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblDateOfBirth.Location = new Point(52, 228);
            LblDateOfBirth.Name = "LblDateOfBirth";
            LblDateOfBirth.Size = new Size(170, 35);
            LblDateOfBirth.TabIndex = 11;
            LblDateOfBirth.Text = "Geburtsdatum";
            // 
            // TxtbFirstNameSearch
            // 
            TxtbFirstNameSearch.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbFirstNameSearch.Location = new Point(229, 171);
            TxtbFirstNameSearch.Margin = new Padding(5, 4, 5, 4);
            TxtbFirstNameSearch.Name = "TxtbFirstNameSearch";
            TxtbFirstNameSearch.Size = new Size(240, 32);
            TxtbFirstNameSearch.TabIndex = 12;
            TxtbFirstNameSearch.Text = "...";
            // 
            // TxtbDateOfBirthSearch
            // 
            TxtbDateOfBirthSearch.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbDateOfBirthSearch.Location = new Point(229, 226);
            TxtbDateOfBirthSearch.Margin = new Padding(5, 4, 5, 4);
            TxtbDateOfBirthSearch.Name = "TxtbDateOfBirthSearch";
            TxtbDateOfBirthSearch.Size = new Size(240, 32);
            TxtbDateOfBirthSearch.TabIndex = 13;
            TxtbDateOfBirthSearch.Text = "...";
            // 
            // BtnReturnToHome
            // 
            BtnReturnToHome.Font = new Font("Century Gothic", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnReturnToHome.Location = new Point(25, 27);
            BtnReturnToHome.Margin = new Padding(5, 4, 5, 4);
            BtnReturnToHome.Name = "BtnReturnToHome";
            BtnReturnToHome.Size = new Size(192, 43);
            BtnReturnToHome.TabIndex = 21;
            BtnReturnToHome.Text = "Zurück (ev. mit Icon)";
            BtnReturnToHome.UseVisualStyleBackColor = true;
            BtnReturnToHome.Click += BtnReturnToHome_Click;
            // 
            // EmployeeListForm
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
            Controls.Add(LblEmployeeListTitle);
            Controls.Add(DgvEmployeeList);
            Controls.Add(TxtbLastNameSearch);
            Controls.Add(BtnAddEmployee);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EmployeeListForm";
            Text = "ContactManager - Mitarbeitende";
            ((System.ComponentModel.ISupportInitialize)DgvEmployeeList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnAddEmployee;
        private TextBox TxtbLastNameSearch;
        private DataGridView DgvEmployeeList;
        private Label LblEmployeeListTitle;
        private DataGridViewTextBoxColumn ColEmployeeNumber;
        private DataGridViewTextBoxColumn ColLastname;
        private DataGridViewTextBoxColumn ColFirstName;
        private DataGridViewTextBoxColumn ColDateOfBirth;
        private DataGridViewTextBoxColumn ColPhone;
        private DataGridViewTextBoxColumn ColEmail;
        private DataGridViewTextBoxColumn ColDepartment;
        private DataGridViewTextBoxColumn ColJobTitle;
        private Label LblLastName;
        private Label LblFirstName;
        private Label LblDateOfBirth;
        private TextBox TxtbFirstNameSearch;
        private TextBox TxtbDateOfBirthSearch;
        private Button BtnReturnToHome;
    }
}