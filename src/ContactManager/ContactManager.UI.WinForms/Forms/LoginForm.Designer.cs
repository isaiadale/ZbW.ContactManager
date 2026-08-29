namespace ContactManager.UI.WinForms.Forms
{
    partial class LoginForm
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
            LblUserName = new Label();
            TxtbUserName = new TextBox();
            LblPassword = new Label();
            TxtbPassword = new TextBox();
            LblFirstStartHint = new Label();
            BtnLogin = new Button();
            BtnCancel = new Button();
            SuspendLayout();
            // 
            // LblUserName
            // 
            LblUserName.AutoSize = true;
            LblUserName.Location = new Point(24, 24);
            LblUserName.Name = "LblUserName";
            LblUserName.Size = new Size(110, 21);
            LblUserName.TabIndex = 0;
            LblUserName.Text = "Benutzername";
            // 
            // TxtbUserName
            // 
            TxtbUserName.Location = new Point(24, 55);
            TxtbUserName.Margin = new Padding(5, 4, 5, 4);
            TxtbUserName.Name = "TxtbUserName";
            TxtbUserName.Size = new Size(300, 32);
            TxtbUserName.TabIndex = 1;
            // 
            // LblPassword
            // 
            LblPassword.AutoSize = true;
            LblPassword.Location = new Point(24, 105);
            LblPassword.Name = "LblPassword";
            LblPassword.Size = new Size(75, 21);
            LblPassword.TabIndex = 2;
            LblPassword.Text = "Passwort";
            // 
            // TxtbPassword
            // 
            TxtbPassword.Location = new Point(24, 136);
            TxtbPassword.Margin = new Padding(5, 4, 5, 4);
            TxtbPassword.Name = "TxtbPassword";
            TxtbPassword.Size = new Size(300, 32);
            TxtbPassword.TabIndex = 3;
            TxtbPassword.UseSystemPasswordChar = true;
            // 
            // LblFirstStartHint
            // 
            LblFirstStartHint.Location = new Point(24, 180);
            LblFirstStartHint.Name = "LblFirstStartHint";
            LblFirstStartHint.Size = new Size(300, 50);
            LblFirstStartHint.TabIndex = 4;
            LblFirstStartHint.Visible = false;
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(24, 240);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(140, 34);
            BtnLogin.TabIndex = 5;
            BtnLogin.Text = "Anmelden";
            BtnLogin.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(184, 240);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(140, 34);
            BtnCancel.TabIndex = 6;
            BtnCancel.Text = "Abbrechen";
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 300);
            Controls.Add(BtnCancel);
            Controls.Add(BtnLogin);
            Controls.Add(LblFirstStartHint);
            Controls.Add(TxtbPassword);
            Controls.Add(LblPassword);
            Controls.Add(TxtbUserName);
            Controls.Add(LblUserName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            Text = "Anmeldung";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private Label LblUserName;
        private TextBox TxtbUserName;
        private Label LblPassword;
        private TextBox TxtbPassword;
        private Label LblFirstStartHint;
        private Button BtnLogin;
        private Button BtnCancel;
    }
}
