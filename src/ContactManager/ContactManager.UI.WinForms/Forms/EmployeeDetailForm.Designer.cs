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
            CombSalutation = new ComboBox();
            LblSalutation = new Label();
            DtpDateOfBirth = new DateTimePicker();
            GrpPrivateAddress = new GroupBox();
            LblPrivateCity = new Label();
            TxtbPrivateCity = new TextBox();
            LblPrivateStreet = new Label();
            TxtbPrivateStreet = new TextBox();
            LblPrivatePostalCode = new Label();
            TxtbPrivatePostalCode = new TextBox();
            GrpEmployeeInfo = new GroupBox();
            DtpTerminationDate = new DateTimePicker();
            LblTerminationDate = new Label();
            DtpHireDate = new DateTimePicker();
            LblHireDate = new Label();
            CombManagementLevel = new ComboBox();
            CombDepartment = new ComboBox();
            LblManagementLevel = new Label();
            LblDepartment = new Label();
            LblJobTitle = new Label();
            TxtbJobTitle = new TextBox();
            GrpContactData = new GroupBox();
            TxtbBusinessPhone = new TextBox();
            LblBusinessPhone = new Label();
            LblMobilePhone = new Label();
            TxtbMobilePhone = new TextBox();
            LblEmail = new Label();
            TxtbEmail = new TextBox();
            GrpBusinessAddress = new GroupBox();
            LblBusinessCity = new Label();
            TxtbBusinessCity = new TextBox();
            LblBusinessStreet = new Label();
            TxtbBusinessStreet = new TextBox();
            LblBusinessPostalCode = new Label();
            TxtbBusinessPostalCode = new TextBox();
            GrpApprentice = new GroupBox();
            LblApprenticeshipYears = new Label();
            TxtbApprenticeshipYears = new TextBox();
            LblCurrAppYear = new Label();
            TxtbCurrAppYear = new TextBox();
            ChkbIsApprentice = new CheckBox();
            BtnSave = new Button();
            GrpPersonalData.SuspendLayout();
            GrpPrivateAddress.SuspendLayout();
            GrpEmployeeInfo.SuspendLayout();
            GrpContactData.SuspendLayout();
            GrpBusinessAddress.SuspendLayout();
            GrpApprentice.SuspendLayout();
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
            LblEmployeeInfos.Text = "MA-Nr. Name Vorname (mittels Code)";
            LblEmployeeInfos.TextAlign = ContentAlignment.BottomCenter;
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
            LblGender.Location = new Point(541, 53);
            LblGender.Name = "LblGender";
            LblGender.Size = new Size(170, 35);
            LblGender.TabIndex = 20;
            LblGender.Text = "Geschlecht";
            // 
            // CombGender
            // 
            CombGender.DropDownStyle = ComboBoxStyle.DropDownList;
            CombGender.FormattingEnabled = true;
            CombGender.Location = new Point(717, 52);
            CombGender.Name = "CombGender";
            CombGender.Size = new Size(240, 29);
            CombGender.TabIndex = 21;
            // 
            // TxtbSocialSecNr
            // 
            TxtbSocialSecNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbSocialSecNr.Location = new Point(717, 152);
            TxtbSocialSecNr.Margin = new Padding(5, 4, 5, 4);
            TxtbSocialSecNr.Name = "TxtbSocialSecNr";
            TxtbSocialSecNr.Size = new Size(240, 32);
            TxtbSocialSecNr.TabIndex = 23;
            TxtbSocialSecNr.Text = "...";
            // 
            // LblSocialSecNr
            // 
            LblSocialSecNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblSocialSecNr.Location = new Point(541, 155);
            LblSocialSecNr.Name = "LblSocialSecNr";
            LblSocialSecNr.Size = new Size(170, 35);
            LblSocialSecNr.TabIndex = 22;
            LblSocialSecNr.Text = "AHV-Nummer";
            // 
            // LblEmployeeNr
            // 
            LblEmployeeNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblEmployeeNr.Location = new Point(28, 53);
            LblEmployeeNr.Name = "LblEmployeeNr";
            LblEmployeeNr.Size = new Size(170, 32);
            LblEmployeeNr.TabIndex = 27;
            LblEmployeeNr.Text = "MA-Nummer";
            // 
            // TxtbEmployeeNr
            // 
            TxtbEmployeeNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbEmployeeNr.Location = new Point(203, 50);
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
            CombNationality.Location = new Point(716, 209);
            CombNationality.Name = "CombNationality";
            CombNationality.Size = new Size(240, 29);
            CombNationality.TabIndex = 29;
            // 
            // LblNationality
            // 
            LblNationality.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblNationality.Location = new Point(541, 211);
            LblNationality.Name = "LblNationality";
            LblNationality.Size = new Size(170, 35);
            LblNationality.TabIndex = 28;
            LblNationality.Text = "Nationalität";
            // 
            // GrpPersonalData
            // 
            GrpPersonalData.Controls.Add(CombSalutation);
            GrpPersonalData.Controls.Add(LblSalutation);
            GrpPersonalData.Controls.Add(DtpDateOfBirth);
            GrpPersonalData.Controls.Add(LblDateOfBirth);
            GrpPersonalData.Controls.Add(CombNationality);
            GrpPersonalData.Controls.Add(LblNationality);
            GrpPersonalData.Controls.Add(TxtbFirstName);
            GrpPersonalData.Controls.Add(LblEmployeeNr);
            GrpPersonalData.Controls.Add(LblFirstName);
            GrpPersonalData.Controls.Add(TxtbEmployeeNr);
            GrpPersonalData.Controls.Add(TxtbLastName);
            GrpPersonalData.Controls.Add(LblLastName);
            GrpPersonalData.Controls.Add(LblGender);
            GrpPersonalData.Controls.Add(CombGender);
            GrpPersonalData.Controls.Add(LblSocialSecNr);
            GrpPersonalData.Controls.Add(TxtbSocialSecNr);
            GrpPersonalData.Location = new Point(43, 122);
            GrpPersonalData.Name = "GrpPersonalData";
            GrpPersonalData.Size = new Size(1010, 260);
            GrpPersonalData.TabIndex = 30;
            GrpPersonalData.TabStop = false;
            GrpPersonalData.Text = "GRUNDDATEN";
            // 
            // CombSalutation
            // 
            CombSalutation.DropDownStyle = ComboBoxStyle.DropDownList;
            CombSalutation.FormattingEnabled = true;
            CombSalutation.Location = new Point(717, 103);
            CombSalutation.Name = "CombSalutation";
            CombSalutation.Size = new Size(240, 29);
            CombSalutation.TabIndex = 30;
            // 
            // LblSalutation
            // 
            LblSalutation.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblSalutation.Location = new Point(541, 104);
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
            // GrpPrivateAddress
            // 
            GrpPrivateAddress.Controls.Add(LblPrivateCity);
            GrpPrivateAddress.Controls.Add(TxtbPrivateCity);
            GrpPrivateAddress.Controls.Add(LblPrivateStreet);
            GrpPrivateAddress.Controls.Add(TxtbPrivateStreet);
            GrpPrivateAddress.Controls.Add(LblPrivatePostalCode);
            GrpPrivateAddress.Controls.Add(TxtbPrivatePostalCode);
            GrpPrivateAddress.Location = new Point(551, 411);
            GrpPrivateAddress.Name = "GrpPrivateAddress";
            GrpPrivateAddress.Size = new Size(502, 198);
            GrpPrivateAddress.TabIndex = 31;
            GrpPrivateAddress.TabStop = false;
            GrpPrivateAddress.Text = "PRIVATADRESSE";
            // 
            // LblPrivateCity
            // 
            LblPrivateCity.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPrivateCity.Location = new Point(34, 155);
            LblPrivateCity.Name = "LblPrivateCity";
            LblPrivateCity.Size = new Size(170, 35);
            LblPrivateCity.TabIndex = 24;
            LblPrivateCity.Text = "Ort";
            // 
            // TxtbPrivateCity
            // 
            TxtbPrivateCity.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbPrivateCity.Location = new Point(211, 152);
            TxtbPrivateCity.Margin = new Padding(5, 4, 5, 4);
            TxtbPrivateCity.Name = "TxtbPrivateCity";
            TxtbPrivateCity.Size = new Size(240, 32);
            TxtbPrivateCity.TabIndex = 25;
            TxtbPrivateCity.Text = "...";
            // 
            // LblPrivateStreet
            // 
            LblPrivateStreet.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPrivateStreet.Location = new Point(34, 53);
            LblPrivateStreet.Name = "LblPrivateStreet";
            LblPrivateStreet.Size = new Size(170, 35);
            LblPrivateStreet.TabIndex = 17;
            LblPrivateStreet.Text = "Strasse und Nr.";
            // 
            // TxtbPrivateStreet
            // 
            TxtbPrivateStreet.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbPrivateStreet.Location = new Point(211, 50);
            TxtbPrivateStreet.Margin = new Padding(5, 4, 5, 4);
            TxtbPrivateStreet.Name = "TxtbPrivateStreet";
            TxtbPrivateStreet.Size = new Size(240, 32);
            TxtbPrivateStreet.TabIndex = 19;
            TxtbPrivateStreet.Text = "...";
            // 
            // LblPrivatePostalCode
            // 
            LblPrivatePostalCode.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPrivatePostalCode.Location = new Point(34, 104);
            LblPrivatePostalCode.Name = "LblPrivatePostalCode";
            LblPrivatePostalCode.Size = new Size(170, 35);
            LblPrivatePostalCode.TabIndex = 22;
            LblPrivatePostalCode.Text = "Postleitzahl";
            // 
            // TxtbPrivatePostalCode
            // 
            TxtbPrivatePostalCode.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbPrivatePostalCode.Location = new Point(210, 101);
            TxtbPrivatePostalCode.Margin = new Padding(5, 4, 5, 4);
            TxtbPrivatePostalCode.Name = "TxtbPrivatePostalCode";
            TxtbPrivatePostalCode.Size = new Size(240, 32);
            TxtbPrivatePostalCode.TabIndex = 23;
            TxtbPrivatePostalCode.Text = "...";
            // 
            // GrpEmployeeInfo
            // 
            GrpEmployeeInfo.Controls.Add(DtpTerminationDate);
            GrpEmployeeInfo.Controls.Add(LblTerminationDate);
            GrpEmployeeInfo.Controls.Add(DtpHireDate);
            GrpEmployeeInfo.Controls.Add(LblHireDate);
            GrpEmployeeInfo.Controls.Add(CombManagementLevel);
            GrpEmployeeInfo.Controls.Add(CombDepartment);
            GrpEmployeeInfo.Controls.Add(LblManagementLevel);
            GrpEmployeeInfo.Controls.Add(LblDepartment);
            GrpEmployeeInfo.Controls.Add(LblJobTitle);
            GrpEmployeeInfo.Controls.Add(TxtbJobTitle);
            GrpEmployeeInfo.Location = new Point(43, 411);
            GrpEmployeeInfo.Name = "GrpEmployeeInfo";
            GrpEmployeeInfo.Size = new Size(502, 301);
            GrpEmployeeInfo.TabIndex = 32;
            GrpEmployeeInfo.TabStop = false;
            GrpEmployeeInfo.Text = "ANSTELLUNG";
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
            // DtpHireDate
            // 
            DtpHireDate.Format = DateTimePickerFormat.Short;
            DtpHireDate.Location = new Point(203, 203);
            DtpHireDate.Name = "DtpHireDate";
            DtpHireDate.Size = new Size(240, 30);
            DtpHireDate.TabIndex = 34;
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
            // CombManagementLevel
            // 
            CombManagementLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            CombManagementLevel.FormattingEnabled = true;
            CombManagementLevel.Location = new Point(205, 154);
            CombManagementLevel.Name = "CombManagementLevel";
            CombManagementLevel.Size = new Size(240, 29);
            CombManagementLevel.TabIndex = 32;
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
            // GrpBusinessAddress
            // 
            GrpBusinessAddress.Controls.Add(LblBusinessCity);
            GrpBusinessAddress.Controls.Add(TxtbBusinessCity);
            GrpBusinessAddress.Controls.Add(LblBusinessStreet);
            GrpBusinessAddress.Controls.Add(TxtbBusinessStreet);
            GrpBusinessAddress.Controls.Add(LblBusinessPostalCode);
            GrpBusinessAddress.Controls.Add(TxtbBusinessPostalCode);
            GrpBusinessAddress.Location = new Point(1059, 411);
            GrpBusinessAddress.Name = "GrpBusinessAddress";
            GrpBusinessAddress.Size = new Size(502, 198);
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
            // GrpApprentice
            // 
            GrpApprentice.Controls.Add(LblApprenticeshipYears);
            GrpApprentice.Controls.Add(TxtbApprenticeshipYears);
            GrpApprentice.Controls.Add(LblCurrAppYear);
            GrpApprentice.Controls.Add(TxtbCurrAppYear);
            GrpApprentice.Location = new Point(43, 773);
            GrpApprentice.Name = "GrpApprentice";
            GrpApprentice.Size = new Size(502, 150);
            GrpApprentice.TabIndex = 33;
            GrpApprentice.TabStop = false;
            GrpApprentice.Text = "AUSBILDUNG";
            GrpApprentice.Visible = false;
            // 
            // LblApprenticeshipYears
            // 
            LblApprenticeshipYears.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblApprenticeshipYears.Location = new Point(27, 49);
            LblApprenticeshipYears.Name = "LblApprenticeshipYears";
            LblApprenticeshipYears.Size = new Size(170, 35);
            LblApprenticeshipYears.TabIndex = 24;
            LblApprenticeshipYears.Text = "Total Lehrjahre";
            // 
            // TxtbApprenticeshipYears
            // 
            TxtbApprenticeshipYears.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbApprenticeshipYears.Location = new Point(204, 46);
            TxtbApprenticeshipYears.Margin = new Padding(5, 4, 5, 4);
            TxtbApprenticeshipYears.Name = "TxtbApprenticeshipYears";
            TxtbApprenticeshipYears.Size = new Size(240, 32);
            TxtbApprenticeshipYears.TabIndex = 25;
            TxtbApprenticeshipYears.Text = "...";
            // 
            // LblCurrAppYear
            // 
            LblCurrAppYear.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblCurrAppYear.Location = new Point(27, 100);
            LblCurrAppYear.Name = "LblCurrAppYear";
            LblCurrAppYear.Size = new Size(170, 35);
            LblCurrAppYear.TabIndex = 26;
            LblCurrAppYear.Text = "Aktuelles Jahr";
            // 
            // TxtbCurrAppYear
            // 
            TxtbCurrAppYear.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbCurrAppYear.Location = new Point(203, 97);
            TxtbCurrAppYear.Margin = new Padding(5, 4, 5, 4);
            TxtbCurrAppYear.Name = "TxtbCurrAppYear";
            TxtbCurrAppYear.Size = new Size(240, 32);
            TxtbCurrAppYear.TabIndex = 27;
            TxtbCurrAppYear.Text = "...";
            // 
            // ChkbIsApprentice
            // 
            ChkbIsApprentice.AutoSize = true;
            ChkbIsApprentice.Location = new Point(43, 731);
            ChkbIsApprentice.Name = "ChkbIsApprentice";
            ChkbIsApprentice.Size = new Size(124, 25);
            ChkbIsApprentice.TabIndex = 0;
            ChkbIsApprentice.Text = "LERNENDE";
            ChkbIsApprentice.UseVisualStyleBackColor = true;
            ChkbIsApprentice.CheckedChanged += ChkbIsApprentice_CheckedChanged;
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
            // EmployeeDetailForm
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1615, 769);
            Controls.Add(BtnSave);
            Controls.Add(ChkbIsApprentice);
            Controls.Add(GrpApprentice);
            Controls.Add(GrpBusinessAddress);
            Controls.Add(GrpContactData);
            Controls.Add(GrpEmployeeInfo);
            Controls.Add(GrpPrivateAddress);
            Controls.Add(GrpPersonalData);
            Controls.Add(LblEmployeeInfos);
            Name = "EmployeeDetailForm";
            Text = "Mitarbeitende - Details";
            GrpPersonalData.ResumeLayout(false);
            GrpPersonalData.PerformLayout();
            GrpPrivateAddress.ResumeLayout(false);
            GrpPrivateAddress.PerformLayout();
            GrpEmployeeInfo.ResumeLayout(false);
            GrpEmployeeInfo.PerformLayout();
            GrpContactData.ResumeLayout(false);
            GrpContactData.PerformLayout();
            GrpBusinessAddress.ResumeLayout(false);
            GrpBusinessAddress.PerformLayout();
            GrpApprentice.ResumeLayout(false);
            GrpApprentice.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblEmployeeInfos;
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
        private GroupBox GrpEmployeeInfo;
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
        private GroupBox GrpContactData;
        private Label LblBusinessPhone;
        private Label LblMobilePhone;
        private TextBox TxtbMobilePhone;
        private Label LblEmail;
        private TextBox TxtbEmail;
        private GroupBox GrpBusinessAddress;
        private Label LblBusinessCity;
        private TextBox TxtbBusinessCity;
        private Label LblBusinessStreet;
        private TextBox TxtbBusinessStreet;
        private Label LblBusinessPostalCode;
        private TextBox TxtbBusinessPostalCode;
        private GroupBox GrpApprentice;
        private TextBox TxtbBusinessPhone;
        private CheckBox ChkbIsApprentice;
        private Label LblApprenticeshipYears;
        private TextBox TxtbApprenticeshipYears;
        private Label LblCurrAppYear;
        private TextBox TxtbCurrAppYear;
        private Button BtnSave;
    }
}