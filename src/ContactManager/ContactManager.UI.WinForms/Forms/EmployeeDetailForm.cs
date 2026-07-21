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
    /// Zeigt die Detaildaten einer einzelnen Mitarbeitenden-Person an bzw. dient der
    /// Erfassung neuer Mitarbeitende. Wird von <see cref="EmployeeListForm"/> aus
    /// geöffnet (Button "Neue Mitarbeitende" oder Doppelklick auf einen bestehenden Eintrag).
    /// </summary>
    public partial class EmployeeDetailForm : BaseForm
    {
        public EmployeeDetailForm()
        {
            InitializeComponent();
        }
    }
}
