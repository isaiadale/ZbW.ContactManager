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
            TxtbDateOfBirth = new TextBox();
            TxtbFirstName = new TextBox();
            LblDateOfBirth = new Label();
            LblFirstName = new Label();
            LblLastName = new Label();
            TxtbLastName = new TextBox();
            LblGender = new Label();
            CombGender = new ComboBox();
            TxtbSocialSecNr = new TextBox();
            LblSocialSecNr = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            LblEmployeeNr = new Label();
            TxtbEmployeeNr = new TextBox();
            CombNationality = new ComboBox();
            LblNationality = new Label();
            SuspendLayout();
            // 
            // LblEmployeeInfos
            // 
            LblEmployeeInfos.Dock = DockStyle.Top;
            LblEmployeeInfos.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblEmployeeInfos.Location = new Point(0, 0);
            LblEmployeeInfos.Name = "LblEmployeeInfos";
            LblEmployeeInfos.Size = new Size(1388, 70);
            LblEmployeeInfos.TabIndex = 9;
            LblEmployeeInfos.Text = "MA-Nr. Name Vorname";
            LblEmployeeInfos.TextAlign = ContentAlignment.BottomCenter;
            // 
            // TxtbDateOfBirth
            // 
            TxtbDateOfBirth.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbDateOfBirth.Location = new Point(229, 278);
            TxtbDateOfBirth.Margin = new Padding(5, 4, 5, 4);
            TxtbDateOfBirth.Name = "TxtbDateOfBirth";
            TxtbDateOfBirth.Size = new Size(240, 32);
            TxtbDateOfBirth.TabIndex = 19;
            TxtbDateOfBirth.Text = "...";
            // 
            // TxtbFirstName
            // 
            TxtbFirstName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbFirstName.Location = new Point(229, 223);
            TxtbFirstName.Margin = new Padding(5, 4, 5, 4);
            TxtbFirstName.Name = "TxtbFirstName";
            TxtbFirstName.Size = new Size(240, 32);
            TxtbFirstName.TabIndex = 18;
            TxtbFirstName.Text = "...";
            // 
            // LblDateOfBirth
            // 
            LblDateOfBirth.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblDateOfBirth.Location = new Point(52, 280);
            LblDateOfBirth.Name = "LblDateOfBirth";
            LblDateOfBirth.Size = new Size(170, 35);
            LblDateOfBirth.TabIndex = 17;
            LblDateOfBirth.Text = "Geburtsdatum";
            // 
            // LblFirstName
            // 
            LblFirstName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblFirstName.Location = new Point(52, 227);
            LblFirstName.Name = "LblFirstName";
            LblFirstName.Size = new Size(170, 35);
            LblFirstName.TabIndex = 16;
            LblFirstName.Text = "Vorname";
            // 
            // LblLastName
            // 
            LblLastName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblLastName.Location = new Point(52, 174);
            LblLastName.Name = "LblLastName";
            LblLastName.Size = new Size(170, 35);
            LblLastName.TabIndex = 15;
            LblLastName.Text = "Nachname";
            // 
            // TxtbLastName
            // 
            TxtbLastName.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbLastName.Location = new Point(229, 171);
            TxtbLastName.Margin = new Padding(5, 4, 5, 4);
            TxtbLastName.Name = "TxtbLastName";
            TxtbLastName.Size = new Size(240, 32);
            TxtbLastName.TabIndex = 14;
            TxtbLastName.Text = "...";
            // 
            // LblGender
            // 
            LblGender.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblGender.Location = new Point(52, 344);
            LblGender.Name = "LblGender";
            LblGender.Size = new Size(170, 35);
            LblGender.TabIndex = 20;
            LblGender.Text = "Geschlecht";
            // 
            // CombGender
            // 
            CombGender.DropDownStyle = ComboBoxStyle.DropDownList;
            CombGender.FormattingEnabled = true;
            CombGender.Location = new Point(229, 343);
            CombGender.Name = "CombGender";
            CombGender.Size = new Size(240, 29);
            CombGender.TabIndex = 21;
            // 
            // TxtbSocialSecNr
            // 
            TxtbSocialSecNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtbSocialSecNr.Location = new Point(229, 395);
            TxtbSocialSecNr.Margin = new Padding(5, 4, 5, 4);
            TxtbSocialSecNr.Name = "TxtbSocialSecNr";
            TxtbSocialSecNr.Size = new Size(240, 32);
            TxtbSocialSecNr.TabIndex = 23;
            TxtbSocialSecNr.Text = "...";
            // 
            // LblSocialSecNr
            // 
            LblSocialSecNr.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblSocialSecNr.Location = new Point(52, 397);
            LblSocialSecNr.Name = "LblSocialSecNr";
            LblSocialSecNr.Size = new Size(170, 35);
            LblSocialSecNr.TabIndex = 22;
            LblSocialSecNr.Text = "Sozialversicherungsnummer";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(229, 448);
            textBox1.Margin = new Padding(5, 4, 5, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 32);
            textBox1.TabIndex = 25;
            textBox1.Text = "...";
            // 
            // label1
            // 
            label1.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 450);
            label1.Name = "label1";
            label1.Size = new Size(170, 35);
            label1.TabIndex = 24;
            label1.Text = "Geburtsdatum";
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
            TxtbEmployeeNr.Size = new Size(240, 32);
            TxtbEmployeeNr.TabIndex = 26;
            TxtbEmployeeNr.Text = "...";
            // 
            // CombNationality
            // 
            CombNationality.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CombNationality.FormattingEnabled = true;
            CombNationality.Location = new Point(229, 507);
            CombNationality.Name = "CombNationality";
            CombNationality.Size = new Size(240, 29);
            CombNationality.TabIndex = 29;
            // 
            // LblNationality
            // 
            LblNationality.Font = new Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblNationality.Location = new Point(52, 508);
            LblNationality.Name = "LblNationality";
            LblNationality.Size = new Size(170, 35);
            LblNationality.TabIndex = 28;
            LblNationality.Text = "Nationalität";
            // 
            // EmployeeDetailForm
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1388, 654);
            Controls.Add(CombNationality);
            Controls.Add(LblNationality);
            Controls.Add(LblEmployeeNr);
            Controls.Add(TxtbEmployeeNr);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(TxtbSocialSecNr);
            Controls.Add(LblSocialSecNr);
            Controls.Add(CombGender);
            Controls.Add(LblGender);
            Controls.Add(TxtbDateOfBirth);
            Controls.Add(TxtbFirstName);
            Controls.Add(LblDateOfBirth);
            Controls.Add(LblFirstName);
            Controls.Add(LblLastName);
            Controls.Add(TxtbLastName);
            Controls.Add(LblEmployeeInfos);
            Name = "EmployeeDetailForm";
            Text = "Mitarbeitende - Details";
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
        private TextBox textBox1;
        private Label label1;
        private Label LblEmployeeNr;
        private TextBox TxtbEmployeeNr;
        private ComboBox CombNationality;
        private Label LblNationality;
    }
}