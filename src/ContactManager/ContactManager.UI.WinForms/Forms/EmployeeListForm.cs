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
    /// Zeigt die Übersicht aller Mitarbeitenden an. Bewusst als eigenständiges Formular
    /// umgesetzt statt gemeinsam mit <see cref="CustomerListForm"/>, da sich die
    /// Datentiefe von Customer und Employee deutlich unterscheidet.
    /// </summary>
    public partial class EmployeeListForm : BaseForm
    {
        public EmployeeListForm()
        {
            InitializeComponent();
        }

        private void TxtbLastNameSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
