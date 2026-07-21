using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ContactManager.UI.WinForms.Base;

namespace ContactManager.UI.WinForms.Forms
{
    /// <summary>
    /// Zeigt die Übersicht aller Kundschaft an. Bewusst als eigenständiges Formular
    /// umgesetzt statt gemeinsam mit <see cref="EmployeeListForm"/>, da sich die
    /// Datentiefe von Customer und Employee deutlich unterscheidet.
    /// </summary>
    public partial class CustomerListForm : BaseForm
    {
        public CustomerListForm()
        {
            InitializeComponent();
        }
                      
        private void BtnReturnToHome_Click(object sender, EventArgs e)
        {
            // Schliesst dieses Fenster; MainForm erscheint automatisch wieder (FormClosed-Event)
            this.Close();
        }
    }
}
