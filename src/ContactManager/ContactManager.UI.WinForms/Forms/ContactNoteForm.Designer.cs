namespace ContactManager.UI.WinForms.Forms
{
    partial class ContactNoteForm
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
            LblCreatedAt = new Label();
            DtpCreatedAt = new DateTimePicker();
            LblNoteText = new Label();
            TxtbNoteText = new TextBox();
            BtnSaveNote = new Button();
            BtnCancel = new Button();
            SuspendLayout();
            // 
            // LblCreatedAt
            // 
            LblCreatedAt.AutoSize = true;
            LblCreatedAt.Location = new Point(24, 24);
            LblCreatedAt.Name = "LblCreatedAt";
            LblCreatedAt.Size = new Size(88, 21);
            LblCreatedAt.TabIndex = 0;
            LblCreatedAt.Text = "Zeitpunkt";
            // 
            // DtpCreatedAt
            // 
            DtpCreatedAt.Format = DateTimePickerFormat.Custom;
            DtpCreatedAt.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            DtpCreatedAt.ShowUpDown = true;
            DtpCreatedAt.Location = new Point(24, 55);
            DtpCreatedAt.Margin = new Padding(5, 4, 5, 4);
            DtpCreatedAt.Name = "DtpCreatedAt";
            DtpCreatedAt.Size = new Size(280, 32);
            DtpCreatedAt.TabIndex = 1;
            // 
            // LblNoteText
            // 
            LblNoteText.AutoSize = true;
            LblNoteText.Location = new Point(24, 105);
            LblNoteText.Name = "LblNoteText";
            LblNoteText.Size = new Size(52, 21);
            LblNoteText.TabIndex = 2;
            LblNoteText.Text = "Notiz";
            // 
            // TxtbNoteText
            // 
            TxtbNoteText.Location = new Point(24, 136);
            TxtbNoteText.Margin = new Padding(5, 4, 5, 4);
            TxtbNoteText.Multiline = true;
            TxtbNoteText.Name = "TxtbNoteText";
            TxtbNoteText.ScrollBars = ScrollBars.Vertical;
            TxtbNoteText.Size = new Size(650, 210);
            TxtbNoteText.TabIndex = 3;
            // 
            // BtnSaveNote
            // 
            BtnSaveNote.Location = new Point(438, 366);
            BtnSaveNote.Name = "BtnSaveNote";
            BtnSaveNote.Size = new Size(112, 34);
            BtnSaveNote.TabIndex = 4;
            BtnSaveNote.Text = "Speichern";
            BtnSaveNote.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(562, 366);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(112, 34);
            BtnCancel.TabIndex = 5;
            BtnCancel.Text = "Abbrechen";
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // ContactNoteForm
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 424);
            Controls.Add(BtnCancel);
            Controls.Add(BtnSaveNote);
            Controls.Add(TxtbNoteText);
            Controls.Add(LblNoteText);
            Controls.Add(DtpCreatedAt);
            Controls.Add(LblCreatedAt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ContactNoteForm";
            Text = "Notiz";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private Label LblCreatedAt;
        private DateTimePicker DtpCreatedAt;
        private Label LblNoteText;
        private TextBox TxtbNoteText;
        private Button BtnSaveNote;
        private Button BtnCancel;
    }
}
