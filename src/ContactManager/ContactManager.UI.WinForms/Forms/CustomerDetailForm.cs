using ContactManager.UI.WinForms.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ContactManager.UI.WinForms.Forms
{
    /// <summary>
    /// Zeigt die Detaildaten eines einzelnen Kundenkontakts an bzw. dient der
    /// Erfassung neuer Kunden. Wird von <see cref="CustomerListForm"/> aus
    /// geöffnet (Button "Neuer Kunde" oder Doppelklick auf einen bestehenden Eintrag).
    /// </summary>
    public partial class CustomerDetailForm : BaseForm
    {
        public CustomerDetailForm()
        {
            InitializeComponent();
            SetTabOrder();
            SetGroupTabOrder();
            TxtbLastName.Focus();
            TxtbCustomerNr.ReadOnly = true;
        }

        // Setzt die Tab-Reihenfolge für bessere Bearbeitung der Felder mittels Tapstop.
        private void SetTabOrder()
        {
            Control[] orderedControls =
            {
                // Grunddaten
                TxtbLastName, TxtbFirstName, DtpDateOfBirth, CombGender, CombSalutation, TxtbTitle,

                // Kontaktdaten
                TxtbBusinessPhone, TxtbMobilePhone, TxtbEmail,

                // Adresse
                TxtbStreet, TxtbPostalCode, TxtbCity
            };

            // Weist jedem Control im Array die Tab-Reihenfolge entsprechend seiner Position zu.
            for (int i = 0; i < orderedControls.Length; i++)
            {
                orderedControls[i].TabIndex = i;
            }
        }
        // Setzt die Reihenfolge der GroupBoxen selbst (Tab-Ebene des Formulars)
        private void SetGroupTabOrder()
        {
            Control[] orderedGroups =
            {
                GrpPersonalData, GrpContactData, GrpAddress
            };

            // Weist jeder GroupBox die Tab-Reihenfolge entsprechend ihrer Position zu.
            for (int i = 0; i < orderedGroups.Length; i++)
            {
                orderedGroups[i].TabIndex = i;
            }
        }
    }
}
