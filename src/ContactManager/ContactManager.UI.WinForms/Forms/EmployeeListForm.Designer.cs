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
            TxtbSearch = new TextBox();
            BtnDeleteEmployee = new Button();
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
            ((System.ComponentModel.ISupportInitialize)DgvEmployeeList).BeginInit();
            SuspendLayout();
            // 
            // BtnAddEmployee
            // 
            BtnAddEmployee.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnAddEmployee.Location = new Point(31, 77);
            BtnAddEmployee.Name = "BtnAddEmployee";
            BtnAddEmployee.Size = new Size(186, 35);
            BtnAddEmployee.TabIndex = 5;
            BtnAddEmployee.Text = "Neue Mitarbeitende";
            BtnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // TxtbSearch
            // 
            TxtbSearch.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbSearch.Location = new Point(412, 77);
            TxtbSearch.Multiline = true;
            TxtbSearch.Name = "TxtbSearch";
            TxtbSearch.Size = new Size(200, 35);
            TxtbSearch.TabIndex = 4;
            TxtbSearch.Text = " * Textbox für Suche";
            // 
            // BtnDeleteEmployee
            // 
            BtnDeleteEmployee.Location = new Point(857, 422);
            BtnDeleteEmployee.Name = "BtnDeleteEmployee";
            BtnDeleteEmployee.Size = new Size(130, 35);
            BtnDeleteEmployee.TabIndex = 6;
            BtnDeleteEmployee.Text = "Löschen";
            BtnDeleteEmployee.UseVisualStyleBackColor = true;
            // 
            // DgvEmployeeList
            // 
            DgvEmployeeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvEmployeeList.Columns.AddRange(new DataGridViewColumn[] { ColEmployeeNumber, ColLastname, ColFirstName, ColDateOfBirth, ColPhone, ColEmail, ColDepartment, ColJobTitle });
            DgvEmployeeList.Location = new Point(31, 132);
            DgvEmployeeList.Name = "DgvEmployeeList";
            DgvEmployeeList.Size = new Size(963, 270);
            DgvEmployeeList.TabIndex = 7;
            // 
            // ColEmployeeNumber
            // 
            ColEmployeeNumber.HeaderText = "Nr.";
            ColEmployeeNumber.Name = "ColEmployeeNumber";
            ColEmployeeNumber.Width = 40;
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
            // ColDepartment
            // 
            ColDepartment.HeaderText = "Abteilung";
            ColDepartment.Name = "ColDepartment";
            ColDepartment.Width = 120;
            // 
            // ColJobTitle
            // 
            ColJobTitle.HeaderText = "Rolle";
            ColJobTitle.Name = "ColJobTitle";
            ColJobTitle.Width = 120;
            // 
            // LblEmployeeListTitle
            // 
            LblEmployeeListTitle.Dock = DockStyle.Top;
            LblEmployeeListTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblEmployeeListTitle.Location = new Point(0, 0);
            LblEmployeeListTitle.Margin = new Padding(2, 0, 2, 0);
            LblEmployeeListTitle.Name = "LblEmployeeListTitle";
            LblEmployeeListTitle.Size = new Size(1024, 57);
            LblEmployeeListTitle.TabIndex = 8;
            LblEmployeeListTitle.Text = "Mitarbeitende";
            LblEmployeeListTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // EmployeeListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 471);
            Controls.Add(LblEmployeeListTitle);
            Controls.Add(DgvEmployeeList);
            Controls.Add(BtnDeleteEmployee);
            Controls.Add(TxtbSearch);
            Controls.Add(BtnAddEmployee);
            Margin = new Padding(2);
            Name = "EmployeeListForm";
            Text = "ContactManager - Mitarbeitende";
            ((System.ComponentModel.ISupportInitialize)DgvEmployeeList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnAddEmployee;
        private TextBox TxtbSearch;
        private Button BtnDeleteEmployee;
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
    }
}