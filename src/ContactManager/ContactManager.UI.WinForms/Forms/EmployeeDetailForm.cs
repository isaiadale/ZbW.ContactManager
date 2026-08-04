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
            SetTabOrder();
            SetGroupTabOrder();
            // Formular startet eingeklappt, da "Lernende" standardmässig nicht aktiviert ist.
            this.ClientSize = new Size(this.ClientSize.Width, 825);
            TxtbLastName.Focus();
            TxtbEmployeeNr.ReadOnly = true;
        }

        // Blendet die Ausbildungs-Angaben nur ein, wenn Checkbox "IsApprentice" aktiviert ist.
        private void ChkbIsApprentice_CheckedChanged(object sender, EventArgs e)
        {
            GrpApprentice.Visible = ChkbIsApprentice.Checked;
            // Formularhöhe anpassen, damit Platz für die Ausbildungs-Box entsteht
            this.ClientSize = new Size(this.ClientSize.Width, ChkbIsApprentice.Checked ? 990 : 825);
        }

        // Setzt die Tab-Reihenfolge für bessere Bearbeitung der Felder mittels Tapstop.
        private void SetTabOrder()
        {
            Control[] orderedControls =
            {
                // Grunddaten
                TxtbLastName, TxtbFirstName, DtpDateOfBirth, CombGender, CombSalutation,
                TxtbSocialSecNr, CombNationality,

                // Kontaktdaten
                TxtbBusinessPhone, TxtbMobilePhone, TxtbEmail,

                // Anstellung
                CombDepartment, TxtbJobTitle, CombManagementLevel, DtpHireDate, DtpTerminationDate,

                // Privatadresse
                TxtbPrivateStreet, TxtbPrivatePostalCode, TxtbPrivateCity,

                // Geschäftsadresse
                TxtbBusinessStreet, TxtbBusinessPostalCode, TxtbBusinessCity,

                // Ausbildung
                ChkbIsApprentice, TxtbApprenticeshipYears, TxtbCurrAppYear
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
                GrpPersonalData, GrpContactData, GrpEmployeeInfo,
                GrpPrivateAddress, GrpBusinessAddress, ChkbIsApprentice, GrpApprentice
            };

            // Weist jeder GroupBox die Tab-Reihenfolge entsprechend ihrer Position zu.
            for (int i = 0; i < orderedGroups.Length; i++)
            {
                orderedGroups[i].TabIndex = i;
            }
        }
    }
}
