namespace ContactManager.UI.WinForms.Forms
{
    partial class EmployeeDetailForm
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
            LblEmployeeInfos = new Label();
            TxtbFirstName = new TextBox();
            LblDateOfBirth = new Label();
            LblFirstName = new Label();
            LblLastName = new Label();
            TxtbLastName = new TextBox();
            LblGender = new Label();
            CombGender = new ComboBox();
            TxtbSocialSecNr = new TextBox();
            LblSocialSecNr = new Label();
            LblEmployeeNr = new Label();
            TxtbEmployeeNr = new TextBox();
            CombNationality = new ComboBox();
            LblNationality = new Label();
            GrpPersonalData = new GroupBox();
            GrpPrivateAddress = new GroupBox();
            LblSalutation = new Label();
            LblPrivateCity = new Label();
            TxtbPrivateCity = new TextBox();
            LblPrivateStreet = new Label();
            TxtbPrivateStreet = new TextBox();
            LblPrivatePostalCode = new Label();
            TxtbPrivatePostalCode = new TextBox();
            GrpEmploymentInfo = new GroupBox();
            LblManagementLevel = new Label();
            LblDepartment = new Label();
            LblJobTitle = new Label();
            TxtbJobTitle = new TextBox();
            CombSalutation = new ComboBox();
            CombDepartment = new ComboBox();
            CombManagementLevel = new ComboBox();
            LblHireDate = new Label();
            DtpHireDate = new DateTimePicker();
            DtpDateOfBirth = new DateTimePicker();
            DtpTerminationDate = new DateTimePicker();
            LblTerminationDate = new Label();
            GrpContact = new GroupBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            GrpBusinessAddress = new GroupBox();
            LblBusinessCity = new Label();
            TxtbBusinessCity = new TextBox();
            LblBusinessStreet = new Label();
            TxtbBusinessStreet = new TextBox();
            LblBusinessPostalCode = new Label();
            TxtbBusinessPostalCode = new TextBox();
            GrpApprenticeship = new GroupBox();
            GrpPersonalData.SuspendLayout();
            GrpPrivateAddress.SuspendLayout();
            GrpEmploymentInfo.SuspendLayout();
            GrpContact.SuspendLayout();
            GrpBusinessAddress.SuspendLayout();
            SuspendLayout();
            // 
            // LblEmployeeInfos
            // 
            LblEmployeeInfos.Dock = DockStyle.Top;
            LblEmployeeInfos.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblEmployeeInfos.Location = new Point(0, 0);
            LblEmployeeInfos.Name = "LblEmployeeInfos";
            LblEmployeeInfos.Size = new Size(1615, 70);
            LblEmployeeInfos.TabIndex = 9;
            LblEmployeeInfos.Text = "MA-Nr. Name Vorname";
            LblEmployeeInfos.TextAlign = ContentAlignment.BottomCenter;
            // 
            // TxtbFirstName
            // 
            TxtbFirstName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbFirstName.Location = new Point(938, 119);
            TxtbFirstName.Margin = new Padding(5, 4, 5, 4);
            TxtbFirstName.Name = "TxtbFirstName";
            TxtbFirstName.Size = new Size(240, 32);
            TxtbFirstName.TabIndex = 18;
            TxtbFirstName.Text = "...";
            // 
            // LblDateOfBirth
            // 
            LblDateOfBirth.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblDateOfBirth.Location = new Point(28, 53);
            LblDateOfBirth.Name = "LblDateOfBirth";
            LblDateOfBirth.Size = new Size(170, 35);
            LblDateOfBirth.TabIndex = 17;
            LblDateOfBirth.Text = "Geburtsdatum";
            // 
            // LblFirstName
            // 
            LblFirstName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblFirstName.Location = new Point(822, 122);
            LblFirstName.Name = "LblFirstName";
            LblFirstName.Size = new Size(130, 35);
            LblFirstName.TabIndex = 16;
            LblFirstName.Text = "Vorname";
            // 
            // LblLastName
            // 
            LblLastName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblLastName.Location = new Point(382, 122);
            LblLastName.Name = "LblLastName";
            LblLastName.Size = new Size(130, 35);
            LblLastName.TabIndex = 15;
            LblLastName.Text = "Nachname";
            // 
            // TxtbLastName
            // 
            TxtbLastName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbLastName.Location = new Point(520, 119);
            TxtbLastName.Margin = new Padding(5, 4, 5, 4);
            TxtbLastName.Name = "TxtbLastName";
            TxtbLastName.Size = new Size(240, 32);
            TxtbLastName.TabIndex = 14;
            TxtbLastName.Text = "...";
            // 
            // LblGender
            // 
            LblGender.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblGender.Location = new Point(28, 104);
            LblGender.Name = "LblGender";
            LblGender.Size = new Size(170, 35);
            LblGender.TabIndex = 20;
            LblGender.Text = "Geschlecht";
            // 
            // CombGender
            // 
            CombGender.DropDownStyle = ComboBoxStyle.DropDownList;
            CombGender.FormattingEnabled = true;
            CombGender.Location = new Point(204, 103);
            CombGender.Name = "CombGender";
            CombGender.Size = new Size(240, 29);
            CombGender.TabIndex = 21;
            // 
            // TxtbSocialSecNr
            // 
            TxtbSocialSecNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbSocialSecNr.Location = new Point(204, 152);
            TxtbSocialSecNr.Margin = new Padding(5, 4, 5, 4);
            TxtbSocialSecNr.Name = "TxtbSocialSecNr";
            TxtbSocialSecNr.Size = new Size(240, 32);
            TxtbSocialSecNr.TabIndex = 23;
            TxtbSocialSecNr.Text = "...";
            // 
            // LblSocialSecNr
            // 
            LblSocialSecNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblSocialSecNr.Location = new Point(28, 155);
            LblSocialSecNr.Name = "LblSocialSecNr";
            LblSocialSecNr.Size = new Size(170, 35);
            LblSocialSecNr.TabIndex = 22;
            LblSocialSecNr.Text = "AHV-Nummer";
            // 
            // LblEmployeeNr
            // 
            LblEmployeeNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblEmployeeNr.Location = new Point(52, 122);
            LblEmployeeNr.Name = "LblEmployeeNr";
            LblEmployeeNr.Size = new Size(170, 32);
            LblEmployeeNr.TabIndex = 27;
            LblEmployeeNr.Text = "MA-Nummer";
            // 
            // TxtbEmployeeNr
            // 
            TxtbEmployeeNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbEmployeeNr.Location = new Point(229, 119);
            TxtbEmployeeNr.Margin = new Padding(5, 4, 5, 4);
            TxtbEmployeeNr.Name = "TxtbEmployeeNr";
            TxtbEmployeeNr.Size = new Size(110, 32);
            TxtbEmployeeNr.TabIndex = 26;
            TxtbEmployeeNr.Text = "...";
            // 
            // CombNationality
            // 
            CombNationality.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CombNationality.FormattingEnabled = true;
            CombNationality.Location = new Point(203, 204);
            CombNationality.Name = "CombNationality";
            CombNationality.Size = new Size(240, 29);
            CombNationality.TabIndex = 29;
            // 
            // LblNationality
            // 
            LblNationality.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblNationality.Location = new Point(28, 206);
            LblNationality.Name = "LblNationality";
            LblNationality.Size = new Size(170, 35);
            LblNationality.TabIndex = 28;
            LblNationality.Text = "Nationalität";
            // 
            // GrpPersonalData
            // 
            GrpPersonalData.Controls.Add(DtpDateOfBirth);
            GrpPersonalData.Controls.Add(LblDateOfBirth);
            GrpPersonalData.Controls.Add(CombNationality);
            GrpPersonalData.Controls.Add(LblNationality);
            GrpPersonalData.Controls.Add(LblGender);
            GrpPersonalData.Controls.Add(CombGender);
            GrpPersonalData.Controls.Add(LblSocialSecNr);
            GrpPersonalData.Controls.Add(TxtbSocialSecNr);
            GrpPersonalData.Location = new Point(43, 219);
            GrpPersonalData.Name = "GrpPersonalData";
            GrpPersonalData.Size = new Size(502, 250);
            GrpPersonalData.TabIndex = 30;
            GrpPersonalData.TabStop = false;
            GrpPersonalData.Text = "GRUNDDATEN";
            // 
            // GrpPrivateAddress
            // 
            GrpPrivateAddress.Controls.Add(CombSalutation);
            GrpPrivateAddress.Controls.Add(LblSalutation);
            GrpPrivateAddress.Controls.Add(LblPrivateCity);
            GrpPrivateAddress.Controls.Add(TxtbPrivateCity);
            GrpPrivateAddress.Controls.Add(LblPrivateStreet);
            GrpPrivateAddress.Controls.Add(TxtbPrivateStreet);
            GrpPrivateAddress.Controls.Add(LblPrivatePostalCode);
            GrpPrivateAddress.Controls.Add(TxtbPrivatePostalCode);
            GrpPrivateAddress.Location = new Point(1059, 219);
            GrpPrivateAddress.Name = "GrpPrivateAddress";
            GrpPrivateAddress.Size = new Size(502, 250);
            GrpPrivateAddress.TabIndex = 31;
            GrpPrivateAddress.TabStop = false;
            GrpPrivateAddress.Text = "PRIVATADRESSE";
            // 
            // LblSalutation
            // 
            LblSalutation.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblSalutation.Location = new Point(34, 53);
            LblSalutation.Name = "LblSalutation";
            LblSalutation.Size = new Size(170, 35);
            LblSalutation.TabIndex = 26;
            LblSalutation.Text = "Anrede";
            // 
            // LblPrivateCity
            // 
            LblPrivateCity.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPrivateCity.Location = new Point(34, 206);
            LblPrivateCity.Name = "LblPrivateCity";
            LblPrivateCity.Size = new Size(170, 35);
            LblPrivateCity.TabIndex = 24;
            LblPrivateCity.Text = "Ort";
            // 
            // TxtbPrivateCity
            // 
            TxtbPrivateCity.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbPrivateCity.Location = new Point(211, 203);
            TxtbPrivateCity.Margin = new Padding(5, 4, 5, 4);
            TxtbPrivateCity.Name = "TxtbPrivateCity";
            TxtbPrivateCity.Size = new Size(240, 32);
            TxtbPrivateCity.TabIndex = 25;
            TxtbPrivateCity.Text = "...";
            // 
            // LblPrivateStreet
            // 
            LblPrivateStreet.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPrivateStreet.Location = new Point(34, 104);
            LblPrivateStreet.Name = "LblPrivateStreet";
            LblPrivateStreet.Size = new Size(170, 35);
            LblPrivateStreet.TabIndex = 17;
            LblPrivateStreet.Text = "Strasse und Nr.";
            // 
            // TxtbPrivateStreet
            // 
            TxtbPrivateStreet.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbPrivateStreet.Location = new Point(211, 101);
            TxtbPrivateStreet.Margin = new Padding(5, 4, 5, 4);
            TxtbPrivateStreet.Name = "TxtbPrivateStreet";
            TxtbPrivateStreet.Size = new Size(240, 32);
            TxtbPrivateStreet.TabIndex = 19;
            TxtbPrivateStreet.Text = "...";
            // 
            // LblPrivatePostalCode
            // 
            LblPrivatePostalCode.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPrivatePostalCode.Location = new Point(34, 155);
            LblPrivatePostalCode.Name = "LblPrivatePostalCode";
            LblPrivatePostalCode.Size = new Size(170, 35);
            LblPrivatePostalCode.TabIndex = 22;
            LblPrivatePostalCode.Text = "Postleitzahl";
            // 
            // TxtbPrivatePostalCode
            // 
            TxtbPrivatePostalCode.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbPrivatePostalCode.Location = new Point(210, 152);
            TxtbPrivatePostalCode.Margin = new Padding(5, 4, 5, 4);
            TxtbPrivatePostalCode.Name = "TxtbPrivatePostalCode";
            TxtbPrivatePostalCode.Size = new Size(240, 32);
            TxtbPrivatePostalCode.TabIndex = 23;
            TxtbPrivatePostalCode.Text = "...";
            // 
            // GrpEmploymentInfo
            // 
            GrpEmploymentInfo.Controls.Add(DtpTerminationDate);
            GrpEmploymentInfo.Controls.Add(LblTerminationDate);
            GrpEmploymentInfo.Controls.Add(DtpHireDate);
            GrpEmploymentInfo.Controls.Add(LblHireDate);
            GrpEmploymentInfo.Controls.Add(CombManagementLevel);
            GrpEmploymentInfo.Controls.Add(CombDepartment);
            GrpEmploymentInfo.Controls.Add(LblManagementLevel);
            GrpEmploymentInfo.Controls.Add(LblDepartment);
            GrpEmploymentInfo.Controls.Add(LblJobTitle);
            GrpEmploymentInfo.Controls.Add(TxtbJobTitle);
            GrpEmploymentInfo.Location = new Point(43, 515);
            GrpEmploymentInfo.Name = "GrpEmploymentInfo";
            GrpEmploymentInfo.Size = new Size(502, 301);
            GrpEmploymentInfo.TabIndex = 32;
            GrpEmploymentInfo.TabStop = false;
            GrpEmploymentInfo.Text = "ANSTELLUNG";
            // 
            // LblManagementLevel
            // 
            LblManagementLevel.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblManagementLevel.Location = new Point(27, 155);
            LblManagementLevel.Name = "LblManagementLevel";
            LblManagementLevel.Size = new Size(170, 35);
            LblManagementLevel.TabIndex = 24;
            LblManagementLevel.Text = "Kaderstufe";
            // 
            // LblDepartment
            // 
            LblDepartment.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblDepartment.Location = new Point(28, 53);
            LblDepartment.Name = "LblDepartment";
            LblDepartment.Size = new Size(170, 35);
            LblDepartment.TabIndex = 17;
            LblDepartment.Text = "Abteilung";
            // 
            // LblJobTitle
            // 
            LblJobTitle.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblJobTitle.Location = new Point(27, 104);
            LblJobTitle.Name = "LblJobTitle";
            LblJobTitle.Size = new Size(170, 35);
            LblJobTitle.TabIndex = 22;
            LblJobTitle.Text = "Rolle";
            // 
            // TxtbJobTitle
            // 
            TxtbJobTitle.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbJobTitle.Location = new Point(205, 100);
            TxtbJobTitle.Margin = new Padding(5, 4, 5, 4);
            TxtbJobTitle.Name = "TxtbJobTitle";
            TxtbJobTitle.Size = new Size(240, 32);
            TxtbJobTitle.TabIndex = 23;
            TxtbJobTitle.Text = "...";
            // 
            // CombSalutation
            // 
            CombSalutation.DropDownStyle = ComboBoxStyle.DropDownList;
            CombSalutation.FormattingEnabled = true;
            CombSalutation.Location = new Point(210, 52);
            CombSalutation.Name = "CombSalutation";
            CombSalutation.Size = new Size(240, 29);
            CombSalutation.TabIndex = 30;
            // 
            // CombDepartment
            // 
            CombDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            CombDepartment.FormattingEnabled = true;
            CombDepartment.Location = new Point(204, 52);
            CombDepartment.Name = "CombDepartment";
            CombDepartment.Size = new Size(240, 29);
            CombDepartment.TabIndex = 31;
            // 
            // CombManagementLevel
            // 
            CombManagementLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            CombManagementLevel.FormattingEnabled = true;
            CombManagementLevel.Location = new Point(205, 154);
            CombManagementLevel.Name = "CombManagementLevel";
            CombManagementLevel.Size = new Size(240, 29);
            CombManagementLevel.TabIndex = 32;
            // 
            // LblHireDate
            // 
            LblHireDate.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblHireDate.Location = new Point(29, 206);
            LblHireDate.Name = "LblHireDate";
            LblHireDate.Size = new Size(170, 35);
            LblHireDate.TabIndex = 33;
            LblHireDate.Text = "Eintritt";
            // 
            // DtpHireDate
            // 
            DtpHireDate.Format = DateTimePickerFormat.Short;
            DtpHireDate.Location = new Point(203, 203);
            DtpHireDate.Name = "DtpHireDate";
            DtpHireDate.Size = new Size(240, 30);
            DtpHireDate.TabIndex = 34;
            // 
            // DtpDateOfBirth
            // 
            DtpDateOfBirth.Format = DateTimePickerFormat.Short;
            DtpDateOfBirth.Location = new Point(204, 53);
            DtpDateOfBirth.Name = "DtpDateOfBirth";
            DtpDateOfBirth.Size = new Size(240, 30);
            DtpDateOfBirth.TabIndex = 35;
            // 
            // DtpTerminationDate
            // 
            DtpTerminationDate.Checked = false;
            DtpTerminationDate.Format = DateTimePickerFormat.Short;
            DtpTerminationDate.Location = new Point(203, 252);
            DtpTerminationDate.Name = "DtpTerminationDate";
            DtpTerminationDate.ShowCheckBox = true;
            DtpTerminationDate.Size = new Size(240, 30);
            DtpTerminationDate.TabIndex = 36;
            // 
            // LblTerminationDate
            // 
            LblTerminationDate.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblTerminationDate.Location = new Point(27, 247);
            LblTerminationDate.Name = "LblTerminationDate";
            LblTerminationDate.Size = new Size(170, 35);
            LblTerminationDate.TabIndex = 35;
            LblTerminationDate.Text = "Austritt";
            // 
            // GrpContact
            // 
            GrpContact.Controls.Add(comboBox1);
            GrpContact.Controls.Add(label1);
            GrpContact.Controls.Add(label2);
            GrpContact.Controls.Add(textBox1);
            GrpContact.Controls.Add(label3);
            GrpContact.Controls.Add(textBox2);
            GrpContact.Controls.Add(label4);
            GrpContact.Controls.Add(textBox3);
            GrpContact.Location = new Point(551, 219);
            GrpContact.Name = "GrpContact";
            GrpContact.Size = new Size(502, 250);
            GrpContact.TabIndex = 32;
            GrpContact.TabStop = false;
            GrpContact.Text = "KONTAKTDATEN";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(210, 52);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(240, 29);
            comboBox1.TabIndex = 30;
            // 
            // label1
            // 
            label1.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 53);
            label1.Name = "label1";
            label1.Size = new Size(170, 35);
            label1.TabIndex = 26;
            label1.Text = "Anrede";
            // 
            // label2
            // 
            label2.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 206);
            label2.Name = "label2";
            label2.Size = new Size(170, 35);
            label2.TabIndex = 24;
            label2.Text = "Ort";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(211, 203);
            textBox1.Margin = new Padding(5, 4, 5, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 32);
            textBox1.TabIndex = 25;
            textBox1.Text = "...";
            // 
            // label3
            // 
            label3.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(34, 104);
            label3.Name = "label3";
            label3.Size = new Size(170, 35);
            label3.TabIndex = 17;
            label3.Text = "Strasse und Nr.";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(211, 101);
            textBox2.Margin = new Padding(5, 4, 5, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(240, 32);
            textBox2.TabIndex = 19;
            textBox2.Text = "...";
            // 
            // label4
            // 
            label4.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(34, 155);
            label4.Name = "label4";
            label4.Size = new Size(170, 35);
            label4.TabIndex = 22;
            label4.Text = "Postleitzahl";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(210, 152);
            textBox3.Margin = new Padding(5, 4, 5, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(240, 32);
            textBox3.TabIndex = 23;
            textBox3.Text = "...";
            // 
            // GrpBusinessAddress
            // 
            GrpBusinessAddress.Controls.Add(LblBusinessCity);
            GrpBusinessAddress.Controls.Add(TxtbBusinessCity);
            GrpBusinessAddress.Controls.Add(LblBusinessStreet);
            GrpBusinessAddress.Controls.Add(TxtbBusinessStreet);
            GrpBusinessAddress.Controls.Add(LblBusinessPostalCode);
            GrpBusinessAddress.Controls.Add(TxtbBusinessPostalCode);
            GrpBusinessAddress.Location = new Point(1059, 515);
            GrpBusinessAddress.Name = "GrpBusinessAddress";
            GrpBusinessAddress.Size = new Size(502, 250);
            GrpBusinessAddress.TabIndex = 32;
            GrpBusinessAddress.TabStop = false;
            GrpBusinessAddress.Text = "GESCHÄFTSADRESSE";
            // 
            // LblBusinessCity
            // 
            LblBusinessCity.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblBusinessCity.Location = new Point(34, 155);
            LblBusinessCity.Name = "LblBusinessCity";
            LblBusinessCity.Size = new Size(170, 35);
            LblBusinessCity.TabIndex = 24;
            LblBusinessCity.Text = "Ort";
            // 
            // TxtbBusinessCity
            // 
            TxtbBusinessCity.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbBusinessCity.Location = new Point(211, 152);
            TxtbBusinessCity.Margin = new Padding(5, 4, 5, 4);
            TxtbBusinessCity.Name = "TxtbBusinessCity";
            TxtbBusinessCity.Size = new Size(240, 32);
            TxtbBusinessCity.TabIndex = 25;
            TxtbBusinessCity.Text = "...";
            // 
            // LblBusinessStreet
            // 
            LblBusinessStreet.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblBusinessStreet.Location = new Point(34, 53);
            LblBusinessStreet.Name = "LblBusinessStreet";
            LblBusinessStreet.Size = new Size(170, 35);
            LblBusinessStreet.TabIndex = 17;
            LblBusinessStreet.Text = "Strasse und Nr.";
            // 
            // TxtbBusinessStreet
            // 
            TxtbBusinessStreet.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbBusinessStreet.Location = new Point(211, 50);
            TxtbBusinessStreet.Margin = new Padding(5, 4, 5, 4);
            TxtbBusinessStreet.Name = "TxtbBusinessStreet";
            TxtbBusinessStreet.Size = new Size(240, 32);
            TxtbBusinessStreet.TabIndex = 19;
            TxtbBusinessStreet.Text = "...";
            // 
            // LblBusinessPostalCode
            // 
            LblBusinessPostalCode.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblBusinessPostalCode.Location = new Point(34, 104);
            LblBusinessPostalCode.Name = "LblBusinessPostalCode";
            LblBusinessPostalCode.Size = new Size(170, 35);
            LblBusinessPostalCode.TabIndex = 22;
            LblBusinessPostalCode.Text = "Postleitzahl";
            // 
            // TxtbBusinessPostalCode
            // 
            TxtbBusinessPostalCode.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbBusinessPostalCode.Location = new Point(210, 101);
            TxtbBusinessPostalCode.Margin = new Padding(5, 4, 5, 4);
            TxtbBusinessPostalCode.Name = "TxtbBusinessPostalCode";
            TxtbBusinessPostalCode.Size = new Size(240, 32);
            TxtbBusinessPostalCode.TabIndex = 23;
            TxtbBusinessPostalCode.Text = "...";
            // 
            // GrpApprenticeship
            // 
            GrpApprenticeship.Location = new Point(551, 515);
            GrpApprenticeship.Name = "GrpApprenticeship";
            GrpApprenticeship.Size = new Size(502, 250);
            GrpApprenticeship.TabIndex = 33;
            GrpApprenticeship.TabStop = false;
            GrpApprenticeship.Text = "AUSBILDUNG";
            // 
            // EmployeeDetailForm
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1615, 840);
            Controls.Add(GrpApprenticeship);
            Controls.Add(GrpBusinessAddress);
            Controls.Add(GrpContact);
            Controls.Add(GrpEmploymentInfo);
            Controls.Add(GrpPrivateAddress);
            Controls.Add(GrpPersonalData);
            Controls.Add(LblEmployeeNr);
            Controls.Add(TxtbEmployeeNr);
            Controls.Add(TxtbFirstName);
            Controls.Add(LblFirstName);
            Controls.Add(LblLastName);
            Controls.Add(TxtbLastName);
            Controls.Add(LblEmployeeInfos);
            Name = "EmployeeDetailForm";
            Text = "Mitarbeitende - Details";
            GrpPersonalData.ResumeLayout(false);
            GrpPersonalData.PerformLayout();
            GrpPrivateAddress.ResumeLayout(false);
            GrpPrivateAddress.PerformLayout();
            GrpEmploymentInfo.ResumeLayout(false);
            GrpEmploymentInfo.PerformLayout();
            GrpContact.ResumeLayout(false);
            GrpContact.PerformLayout();
            GrpBusinessAddress.ResumeLayout(false);
            GrpBusinessAddress.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblEmployeeInfos;
        private TextBox TxtbDateOfBirth;
        private TextBox TxtbFirstName;
        private Label LblDateOfBirth;
        private Label LblFirstName;
        private Label LblLastName;
        private TextBox TxtbLastName;
        private Label LblGender;
        private ComboBox CombGender;
        private TextBox TxtbSocialSecNr;
        private Label LblSocialSecNr;
        private Label LblEmployeeNr;
        private TextBox TxtbEmployeeNr;
        private ComboBox CombNationality;
        private Label LblNationality;
        private GroupBox GrpPersonalData;
        private GroupBox GrpPrivateAddress;
        private Label LblPrivateStreet;
        private TextBox TxtbPrivateStreet;
        private Label LblPrivatePostalCode;
        private TextBox TxtbPrivatePostalCode;
        private Label LblPrivateCity;
        private TextBox TxtbPrivateCity;
        private GroupBox GrpEmploymentInfo;
        private Label LblManagementLevel;
        private Label LblDepartment;
        private Label LblJobTitle;
        private TextBox TxtbJobTitle;
        private Label LblSalutation;
        private ComboBox CombSalutation;
        private ComboBox CombDepartment;
        private ComboBox CombManagementLevel;
        private DateTimePicker DtpHireDate;
        private Label LblHireDate;
        private DateTimePicker DtpDateOfBirth;
        private DateTimePicker DtpTerminationDate;
        private Label LblTerminationDate;
        private GroupBox GrpContact;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private GroupBox GrpBusinessAddress;
        private Label LblBusinessCity;
        private TextBox TxtbBusinessCity;
        private Label LblBusinessStreet;
        private TextBox TxtbBusinessStreet;
        private Label LblBusinessPostalCode;
        private TextBox TxtbBusinessPostalCode;
        private GroupBox GrpApprenticeship;
    }
}