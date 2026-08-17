namespace ContactManager.UI.WinForms.Forms
{
    partial class CustomerDetailForm
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
            LblCustomerInfos = new Label();
            TxtbFirstName = new TextBox();
            LblDateOfBirth = new Label();
            LblFirstName = new Label();
            LblLastName = new Label();
            TxtbLastName = new TextBox();
            LblGender = new Label();
            CombGender = new ComboBox();
            LblCustomerNr = new Label();
            TxtbCustomerNr = new TextBox();
            GrpPersonalData = new GroupBox();
            CombStatus = new ComboBox();
            LblStatus = new Label();
            TxtbTitle = new TextBox();
            LblTitle = new Label();
            CombSalutation = new ComboBox();
            LblSalutation = new Label();
            DtpDateOfBirth = new DateTimePicker();
            GrpAddress = new GroupBox();
            LblCity = new Label();
            TxtbCity = new TextBox();
            LblStreet = new Label();
            LblPostalCode = new Label();
            TxtbPostalCode = new TextBox();
            GrpContactData = new GroupBox();
            TxtbBusinessPhone = new TextBox();
            LblBusinessPhone = new Label();
            LblMobilePhone = new Label();
            TxtbMobilePhone = new TextBox();
            LblEmail = new Label();
            TxtbEmail = new TextBox();
            BtnSave = new Button();
            GrpProtocolNotes = new GroupBox();
            DgvEmployeeList = new DataGridView();
            ColDateTime = new DataGridViewTextBoxColumn();
            ColText = new DataGridViewTextBoxColumn();
            TxtbProtocolNotes = new TextBox();
            GrpPersonalData.SuspendLayout();
            GrpAddress.SuspendLayout();
            GrpContactData.SuspendLayout();
            GrpProtocolNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvEmployeeList).BeginInit();
            SuspendLayout();
            // 
            // LblCustomerInfos
            // 
            LblCustomerInfos.Dock = DockStyle.Top;
            LblCustomerInfos.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCustomerInfos.Location = new Point(0, 0);
            LblCustomerInfos.Name = "LblCustomerInfos";
            LblCustomerInfos.Size = new Size(1615, 70);
            LblCustomerInfos.TabIndex = 9;
            LblCustomerInfos.Text = "Kunden-Nr., Name, Vorname (mittels Code)";
            LblCustomerInfos.TextAlign = ContentAlignment.BottomCenter;
            // 
            // TxtbFirstName
            // 
            TxtbFirstName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbFirstName.Location = new Point(203, 152);
            TxtbFirstName.Margin = new Padding(5, 4, 5, 4);
            TxtbFirstName.Name = "TxtbFirstName";
            TxtbFirstName.Size = new Size(240, 32);
            TxtbFirstName.TabIndex = 18;
            TxtbFirstName.Text = "...";
            // 
            // LblDateOfBirth
            // 
            LblDateOfBirth.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblDateOfBirth.Location = new Point(27, 206);
            LblDateOfBirth.Name = "LblDateOfBirth";
            LblDateOfBirth.Size = new Size(170, 35);
            LblDateOfBirth.TabIndex = 17;
            LblDateOfBirth.Text = "Geburtsdatum";
            // 
            // LblFirstName
            // 
            LblFirstName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblFirstName.Location = new Point(27, 155);
            LblFirstName.Name = "LblFirstName";
            LblFirstName.Size = new Size(170, 35);
            LblFirstName.TabIndex = 16;
            LblFirstName.Text = "Vorname";
            // 
            // LblLastName
            // 
            LblLastName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblLastName.Location = new Point(27, 104);
            LblLastName.Name = "LblLastName";
            LblLastName.Size = new Size(170, 35);
            LblLastName.TabIndex = 15;
            LblLastName.Text = "Nachname";
            // 
            // TxtbLastName
            // 
            TxtbLastName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbLastName.Location = new Point(203, 101);
            TxtbLastName.Margin = new Padding(5, 4, 5, 4);
            TxtbLastName.Name = "TxtbLastName";
            TxtbLastName.Size = new Size(240, 32);
            TxtbLastName.TabIndex = 14;
            TxtbLastName.Text = "...";
            // 
            // LblGender
            // 
            LblGender.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblGender.Location = new Point(541, 155);
            LblGender.Name = "LblGender";
            LblGender.Size = new Size(170, 35);
            LblGender.TabIndex = 20;
            LblGender.Text = "Geschlecht";
            // 
            // CombGender
            // 
            CombGender.DropDownStyle = ComboBoxStyle.DropDownList;
            CombGender.FormattingEnabled = true;
            CombGender.Location = new Point(717, 152);
            CombGender.Name = "CombGender";
            CombGender.Size = new Size(240, 29);
            CombGender.TabIndex = 21;
            // 
            // LblCustomerNr
            // 
            LblCustomerNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblCustomerNr.Location = new Point(28, 53);
            LblCustomerNr.Name = "LblCustomerNr";
            LblCustomerNr.Size = new Size(170, 32);
            LblCustomerNr.TabIndex = 27;
            LblCustomerNr.Text = "Kundennummer";
            // 
            // TxtbCustomerNr
            // 
            TxtbCustomerNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbCustomerNr.Location = new Point(203, 50);
            TxtbCustomerNr.Margin = new Padding(5, 4, 5, 4);
            TxtbCustomerNr.Name = "TxtbCustomerNr";
            TxtbCustomerNr.Size = new Size(110, 32);
            TxtbCustomerNr.TabIndex = 26;
            TxtbCustomerNr.TabStop = false;
            TxtbCustomerNr.Text = "...";
            // 
            // GrpPersonalData
            // 
            GrpPersonalData.Controls.Add(CombStatus);
            GrpPersonalData.Controls.Add(LblStatus);
            GrpPersonalData.Controls.Add(TxtbTitle);
            GrpPersonalData.Controls.Add(LblTitle);
            GrpPersonalData.Controls.Add(CombSalutation);
            GrpPersonalData.Controls.Add(LblSalutation);
            GrpPersonalData.Controls.Add(DtpDateOfBirth);
            GrpPersonalData.Controls.Add(LblDateOfBirth);
            GrpPersonalData.Controls.Add(TxtbFirstName);
            GrpPersonalData.Controls.Add(LblCustomerNr);
            GrpPersonalData.Controls.Add(LblFirstName);
            GrpPersonalData.Controls.Add(TxtbCustomerNr);
            GrpPersonalData.Controls.Add(TxtbLastName);
            GrpPersonalData.Controls.Add(LblLastName);
            GrpPersonalData.Controls.Add(LblGender);
            GrpPersonalData.Controls.Add(CombGender);
            GrpPersonalData.Location = new Point(43, 122);
            GrpPersonalData.Name = "GrpPersonalData";
            GrpPersonalData.Size = new Size(1010, 260);
            GrpPersonalData.TabIndex = 30;
            GrpPersonalData.TabStop = false;
            GrpPersonalData.Text = "GRUNDDATEN";
            // 
            // CombStatus
            // 
            CombStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            CombStatus.FormattingEnabled = true;
            CombStatus.Location = new Point(717, 200);
            CombStatus.Name = "CombStatus";
            CombStatus.Size = new Size(240, 29);
            CombStatus.TabIndex = 37;
            // 
            // LblStatus
            // 
            LblStatus.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblStatus.Location = new Point(541, 201);
            LblStatus.Name = "LblStatus";
            LblStatus.Size = new Size(170, 35);
            LblStatus.TabIndex = 36;
            LblStatus.Text = "Status";
            // 
            // TxtbTitle
            // 
            TxtbTitle.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbTitle.Location = new Point(717, 101);
            TxtbTitle.Margin = new Padding(5, 4, 5, 4);
            TxtbTitle.Name = "TxtbTitle";
            TxtbTitle.Size = new Size(240, 32);
            TxtbTitle.TabIndex = 31;
            TxtbTitle.Text = "...";
            // 
            // LblTitle
            // 
            LblTitle.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblTitle.Location = new Point(541, 104);
            LblTitle.Name = "LblTitle";
            LblTitle.Size = new Size(170, 35);
            LblTitle.TabIndex = 27;
            LblTitle.Text = "Titel";
            // 
            // CombSalutation
            // 
            CombSalutation.DropDownStyle = ComboBoxStyle.DropDownList;
            CombSalutation.FormattingEnabled = true;
            CombSalutation.Location = new Point(717, 52);
            CombSalutation.Name = "CombSalutation";
            CombSalutation.Size = new Size(240, 29);
            CombSalutation.TabIndex = 30;
            // 
            // LblSalutation
            // 
            LblSalutation.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblSalutation.Location = new Point(541, 53);
            LblSalutation.Name = "LblSalutation";
            LblSalutation.Size = new Size(170, 35);
            LblSalutation.TabIndex = 26;
            LblSalutation.Text = "Anrede";
            // 
            // DtpDateOfBirth
            // 
            DtpDateOfBirth.Format = DateTimePickerFormat.Short;
            DtpDateOfBirth.Location = new Point(203, 206);
            DtpDateOfBirth.Name = "DtpDateOfBirth";
            DtpDateOfBirth.Size = new Size(240, 30);
            DtpDateOfBirth.TabIndex = 35;
            // 
            // GrpAddress
            // 
            GrpAddress.Controls.Add(TxtbProtocolNotes);
            GrpAddress.Controls.Add(LblCity);
            GrpAddress.Controls.Add(TxtbCity);
            GrpAddress.Controls.Add(LblStreet);
            GrpAddress.Controls.Add(LblPostalCode);
            GrpAddress.Controls.Add(TxtbPostalCode);
            GrpAddress.Location = new Point(43, 411);
            GrpAddress.Name = "GrpAddress";
            GrpAddress.Size = new Size(502, 198);
            GrpAddress.TabIndex = 31;
            GrpAddress.TabStop = false;
            GrpAddress.Text = "ADRESSE";
            // 
            // LblCity
            // 
            LblCity.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblCity.Location = new Point(34, 155);
            LblCity.Name = "LblCity";
            LblCity.Size = new Size(170, 35);
            LblCity.TabIndex = 24;
            LblCity.Text = "Ort";
            // 
            // TxtbCity
            // 
            TxtbCity.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbCity.Location = new Point(211, 152);
            TxtbCity.Margin = new Padding(5, 4, 5, 4);
            TxtbCity.Name = "TxtbCity";
            TxtbCity.Size = new Size(240, 32);
            TxtbCity.TabIndex = 25;
            TxtbCity.Text = "...";
            // 
            // LblStreet
            // 
            LblStreet.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblStreet.Location = new Point(34, 53);
            LblStreet.Name = "LblStreet";
            LblStreet.Size = new Size(170, 35);
            LblStreet.TabIndex = 17;
            LblStreet.Text = "Strasse und Nr.";
            // 
            // LblPostalCode
            // 
            LblPostalCode.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPostalCode.Location = new Point(34, 104);
            LblPostalCode.Name = "LblPostalCode";
            LblPostalCode.Size = new Size(170, 35);
            LblPostalCode.TabIndex = 22;
            LblPostalCode.Text = "Postleitzahl";
            // 
            // TxtbPostalCode
            // 
            TxtbPostalCode.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbPostalCode.Location = new Point(210, 101);
            TxtbPostalCode.Margin = new Padding(5, 4, 5, 4);
            TxtbPostalCode.Name = "TxtbPostalCode";
            TxtbPostalCode.Size = new Size(240, 32);
            TxtbPostalCode.TabIndex = 23;
            TxtbPostalCode.Text = "...";
            // 
            // GrpContactData
            // 
            GrpContactData.Controls.Add(TxtbBusinessPhone);
            GrpContactData.Controls.Add(LblBusinessPhone);
            GrpContactData.Controls.Add(LblMobilePhone);
            GrpContactData.Controls.Add(TxtbMobilePhone);
            GrpContactData.Controls.Add(LblEmail);
            GrpContactData.Controls.Add(TxtbEmail);
            GrpContactData.Location = new Point(1059, 122);
            GrpContactData.Name = "GrpContactData";
            GrpContactData.Size = new Size(502, 260);
            GrpContactData.TabIndex = 32;
            GrpContactData.TabStop = false;
            GrpContactData.Text = "KONTAKTDATEN";
            // 
            // TxtbBusinessPhone
            // 
            TxtbBusinessPhone.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbBusinessPhone.Location = new Point(210, 49);
            TxtbBusinessPhone.Margin = new Padding(5, 4, 5, 4);
            TxtbBusinessPhone.Name = "TxtbBusinessPhone";
            TxtbBusinessPhone.Size = new Size(240, 32);
            TxtbBusinessPhone.TabIndex = 27;
            TxtbBusinessPhone.Text = "...";
            // 
            // LblBusinessPhone
            // 
            LblBusinessPhone.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblBusinessPhone.Location = new Point(34, 53);
            LblBusinessPhone.Name = "LblBusinessPhone";
            LblBusinessPhone.Size = new Size(170, 35);
            LblBusinessPhone.TabIndex = 26;
            LblBusinessPhone.Text = "Telefon";
            // 
            // LblMobilePhone
            // 
            LblMobilePhone.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblMobilePhone.Location = new Point(34, 104);
            LblMobilePhone.Name = "LblMobilePhone";
            LblMobilePhone.Size = new Size(170, 35);
            LblMobilePhone.TabIndex = 17;
            LblMobilePhone.Text = "Mobile";
            // 
            // TxtbMobilePhone
            // 
            TxtbMobilePhone.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbMobilePhone.Location = new Point(211, 101);
            TxtbMobilePhone.Margin = new Padding(5, 4, 5, 4);
            TxtbMobilePhone.Name = "TxtbMobilePhone";
            TxtbMobilePhone.Size = new Size(240, 32);
            TxtbMobilePhone.TabIndex = 19;
            TxtbMobilePhone.Text = "...";
            // 
            // LblEmail
            // 
            LblEmail.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblEmail.Location = new Point(34, 155);
            LblEmail.Name = "LblEmail";
            LblEmail.Size = new Size(170, 35);
            LblEmail.TabIndex = 22;
            LblEmail.Text = "E-Mail";
            // 
            // TxtbEmail
            // 
            TxtbEmail.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbEmail.Location = new Point(210, 152);
            TxtbEmail.Margin = new Padding(5, 4, 5, 4);
            TxtbEmail.Name = "TxtbEmail";
            TxtbEmail.Size = new Size(240, 32);
            TxtbEmail.TabIndex = 23;
            TxtbEmail.Text = "...";
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(1449, 36);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(112, 34);
            BtnSave.TabIndex = 34;
            BtnSave.Text = "Speichern";
            BtnSave.UseVisualStyleBackColor = true;
            // 
            // GrpProtocolNotes
            // 
            GrpProtocolNotes.Controls.Add(DgvEmployeeList);
            GrpProtocolNotes.Location = new Point(554, 411);
            GrpProtocolNotes.Name = "GrpProtocolNotes";
            GrpProtocolNotes.Size = new Size(1010, 198);
            GrpProtocolNotes.TabIndex = 38;
            GrpProtocolNotes.TabStop = false;
            GrpProtocolNotes.Text = "PROTOKOLLIERUNG";
            // 
            // DgvEmployeeList
            // 
            DgvEmployeeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvEmployeeList.Columns.AddRange(new DataGridViewColumn[] { ColDateTime, ColText });
            DgvEmployeeList.Location = new Point(30, 30);
            DgvEmployeeList.Margin = new Padding(5, 4, 5, 4);
            DgvEmployeeList.Name = "DgvEmployeeList";
            DgvEmployeeList.RowHeadersWidth = 62;
            DgvEmployeeList.Size = new Size(944, 154);
            DgvEmployeeList.TabIndex = 8;
            // 
            // ColDateTime
            // 
            ColDateTime.HeaderText = "Erstellung";
            ColDateTime.MinimumWidth = 8;
            ColDateTime.Name = "ColDateTime";
            ColDateTime.ReadOnly = true;
            ColDateTime.Width = 120;
            // 
            // ColText
            // 
            ColText.HeaderText = "Text";
            ColText.MinimumWidth = 8;
            ColText.Name = "ColText";
            ColText.ReadOnly = true;
            ColText.Width = 760;
            // 
            // TxtbProtocolNotes
            // 
            TxtbProtocolNotes.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbProtocolNotes.Location = new Point(210, 50);
            TxtbProtocolNotes.Margin = new Padding(5, 4, 5, 4);
            TxtbProtocolNotes.Name = "TxtbProtocolNotes";
            TxtbProtocolNotes.Size = new Size(240, 32);
            TxtbProtocolNotes.TabIndex = 26;
            TxtbProtocolNotes.Text = "...";
            // 
            // CustomerDetailForm
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1615, 660);
            Controls.Add(GrpProtocolNotes);
            Controls.Add(BtnSave);
            Controls.Add(GrpContactData);
            Controls.Add(GrpAddress);
            Controls.Add(GrpPersonalData);
            Controls.Add(LblCustomerInfos);
            Name = "CustomerDetailForm";
            Text = "Kunden - Details";
            GrpPersonalData.ResumeLayout(false);
            GrpPersonalData.PerformLayout();
            GrpAddress.ResumeLayout(false);
            GrpAddress.PerformLayout();
            GrpContactData.ResumeLayout(false);
            GrpContactData.PerformLayout();
            GrpProtocolNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvEmployeeList).EndInit();
            ResumeLayout(false);
        }
        #endregion
        private Label LblCustomerInfos;
        private TextBox TxtbFirstName;
        private Label LblDateOfBirth;
        private Label LblFirstName;
        private Label LblLastName;
        private TextBox TxtbLastName;
        private Label LblGender;
        private ComboBox CombGender;
        private Label LblCustomerNr;
        private TextBox TxtbCustomerNr;
        private GroupBox GrpPersonalData;
        private TextBox TxtbTitle;
        private Label LblTitle;
        private Label LblSalutation;
        private ComboBox CombSalutation;
        private DateTimePicker DtpDateOfBirth;
        private GroupBox GrpAddress;
        private Label LblStreet;
        private Label LblPostalCode;
        private TextBox TxtbPostalCode;
        private Label LblCity;
        private TextBox TxtbCity;
        private GroupBox GrpContactData;
        private Label LblBusinessPhone;
        private Label LblMobilePhone;
        private TextBox TxtbMobilePhone;
        private Label LblEmail;
        private TextBox TxtbEmail;
        private TextBox TxtbBusinessPhone;
        private Button BtnSave;
        private Label LblStatus;
        private ComboBox CombStatus;
        private GroupBox GrpProtocolNotes;
        private DataGridView DgvEmployeeList;
        private DataGridViewTextBoxColumn ColDateTime;
        private DataGridViewTextBoxColumn ColText;
        private TextBox TxtbProtocolNotes;
    }
}
