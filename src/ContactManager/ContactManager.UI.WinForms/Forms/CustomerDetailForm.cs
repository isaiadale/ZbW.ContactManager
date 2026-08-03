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
    /// Zeigt die Detaildaten einer einzelnen Kundin an bzw. dient der Erfassung
    /// neuer Kontakte. Wird von <see cref="CustomerListForm"/> aus geöffnet
    /// (Button "Neuer Kontakt" oder Doppelklick auf einen bestehenden Eintrag).
    /// </summary>
    public partial class CustomerDetailForm : BaseForm
    {
        public CustomerDetailForm()
        {
            InitializeComponent();
        }
    }
}
