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
            SuspendLayout();
            // 
            // LblCustomerInfos
            // 
            LblCustomerInfos.Dock = DockStyle.Top;
            LblCustomerInfos.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCustomerInfos.Location = new Point(0, 0);
            LblCustomerInfos.Name = "LblCustomerInfos";
            LblCustomerInfos.Size = new Size(800, 70);
            LblCustomerInfos.TabIndex = 10;
            LblCustomerInfos.Text = "KD-Nr. Name Vorname";
            LblCustomerInfos.TextAlign = ContentAlignment.BottomCenter;
            // 
            // CustomerDetailForm
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 654);
            Controls.Add(LblCustomerInfos);
            Name = "CustomerDetailForm";
            Text = "Kundschaft - Details";
            ResumeLayout(false);
        }

        #endregion

        private Label LblCustomerInfos;
    }
}