namespace ContactManager.UI.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LblHomeTitle = new Label();
            PnlCustomerTile = new Panel();
            LblCustomerTile = new Label();
            PnlEmployeeTile = new Panel();
            LblEmployeeTile = new Label();
            PnlCustomerTile.SuspendLayout();
            PnlEmployeeTile.SuspendLayout();
            SuspendLayout();
            // 
            // LblHomeTitle
            // 
            LblHomeTitle.Dock = DockStyle.Top;
            LblHomeTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblHomeTitle.Location = new Point(0, 0);
            LblHomeTitle.Name = "LblHomeTitle";
            LblHomeTitle.Size = new Size(688, 70);
            LblHomeTitle.TabIndex = 0;
            LblHomeTitle.Text = "Kontaktübersicht";
            LblHomeTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // PnlCustomerTile
            // 
            PnlCustomerTile.Controls.Add(LblCustomerTile);
            PnlCustomerTile.Location = new Point(135, 150);
            PnlCustomerTile.Name = "PnlCustomerTile";
            PnlCustomerTile.Size = new Size(200, 150);
            PnlCustomerTile.TabIndex = 1;
            // 
            // LblCustomerTile
            // 
            LblCustomerTile.Dock = DockStyle.Fill;
            LblCustomerTile.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblCustomerTile.Location = new Point(0, 0);
            LblCustomerTile.Name = "LblCustomerTile";
            LblCustomerTile.Size = new Size(200, 150);
            LblCustomerTile.TabIndex = 0;
            LblCustomerTile.Text = "Kundschaft";
            LblCustomerTile.TextAlign = ContentAlignment.MiddleCenter;
            LblCustomerTile.Click += LblCustomerTile_Click;
            // 
            // PnlEmployeeTile
            // 
            PnlEmployeeTile.Controls.Add(LblEmployeeTile);
            PnlEmployeeTile.Location = new Point(375, 150);
            PnlEmployeeTile.Name = "PnlEmployeeTile";
            PnlEmployeeTile.Size = new Size(200, 150);
            PnlEmployeeTile.TabIndex = 2;
            // 
            // LblEmployeeTile
            // 
            LblEmployeeTile.Dock = DockStyle.Fill;
            LblEmployeeTile.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblEmployeeTile.Location = new Point(0, 0);
            LblEmployeeTile.Name = "LblEmployeeTile";
            LblEmployeeTile.Size = new Size(200, 150);
            LblEmployeeTile.TabIndex = 0;
            LblEmployeeTile.Text = "Mitarbeitende";
            LblEmployeeTile.TextAlign = ContentAlignment.MiddleCenter;
            LblEmployeeTile.Click += LblEmployeeTile_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 414);
            Controls.Add(PnlEmployeeTile);
            Controls.Add(PnlCustomerTile);
            Controls.Add(LblHomeTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "ContactManager - Home";
            PnlCustomerTile.ResumeLayout(false);
            PnlEmployeeTile.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label LblHomeTitle;
        private Panel PnlCustomerTile;
        private Label LblCustomerTile;
        private Panel PnlEmployeeTile;
        private Label LblEmployeeTile;
    }
}
