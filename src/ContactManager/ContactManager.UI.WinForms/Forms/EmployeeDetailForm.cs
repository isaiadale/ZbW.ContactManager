using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ContactManager.Business;
using ContactManager.Business.Exceptions;
using ContactManager.Model;
using ContactManager.Model.Enums;
using ContactManager.UI.WinForms.Base;
using System.Linq;

namespace ContactManager.UI.WinForms.Forms
{
    /// <summary>
    /// Zeigt die Detaildaten einer einzelnen Mitarbeitenden-Person an bzw. dient der
    /// Erfassung neuer Mitarbeitende. Wird von <see cref="EmployeeListForm"/> aus
    /// geöffnet (Button "Neue Mitarbeitende" oder Doppelklick auf einen bestehenden Eintrag).
    /// Deckt <see cref="Employee"/> und <see cref="Apprentice"/> gemeinsam ab — die
    /// Checkbox "LERNENDE" entscheidet, welcher der beiden Typen erfasst wird.
    /// </summary>
    public partial class EmployeeDetailForm : BaseForm
    {
        // Zugang zur Business-Schicht. Wird von der Liste durchgereicht, damit alle
        // Fenster auf demselben, einmalig geladenen Datenstamm arbeiten.
        private readonly ContactManagerFacade _contacts;

        // Die zu bearbeitende Person, oder null im Erfassungsmodus. Dieses eine Feld
        // unterscheidet die beiden Modi des Formulars.
        private readonly Employee? _employee;

        /// <summary>
        /// Öffnet das Formular im <b>Erfassungsmodus</b>: Alle Felder sind leer, beim
        /// Speichern entsteht eine neue Person.
        /// </summary>
        /// <param name="contacts">Die Fassade der Business-Schicht, über die alle Daten laufen.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="contacts"/> <c>null</c> ist.</exception>
        public EmployeeDetailForm(ContactManagerFacade contacts)
            : this(contacts, null)
        {
        }

        /// <summary>
        /// Öffnet das Formular im <b>Bearbeitungsmodus</b>, wenn eine Person übergeben wird,
        /// sonst im Erfassungsmodus.
        /// </summary>
        /// <param name="contacts">Die Fassade der Business-Schicht, über die alle Daten laufen.</param>
        /// <param name="employee">Die zu bearbeitende Person, oder <c>null</c> für eine Neuerfassung.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="contacts"/> <c>null</c> ist.</exception>
        public EmployeeDetailForm(ContactManagerFacade contacts, Employee? employee)
        {
            ArgumentNullException.ThrowIfNull(contacts);

            InitializeComponent();

            _contacts = contacts;
            _employee = employee;

            SetTabOrder();
            SetGroupTabOrder();

            // Formular startet eingeklappt, da "Lernende" standardmässig nicht aktiviert ist.
            this.ClientSize = new Size(this.ClientSize.Width, 840);
            TxtbEmployeeNr.ReadOnly = true;

            // Bewusst hier statt im Designer verdrahtet: Der Designer gehört den
            // Kolleg*innen, jede Änderung daran erzeugt unnötige Merge-Konflikte.
            BtnSave.Click += BtnSave_Click;
        }

        /// <summary>
        /// Bereitet die Eingabefelder vor und füllt sie im Bearbeitungsmodus mit den Daten
        /// der übergebenen Person. Bewusst hier statt im Konstruktor: Zu diesem Zeitpunkt
        /// sind alle Controls erzeugt und das Fenster ist bereit für den Fokus.
        /// </summary>
        /// <param name="e">Die Ereignisdaten des Load-Ereignisses.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            FillComboBoxes();
            ClearInputs();

            if (_employee is null)
            {
                LblEmployeeInfos.Text = "Neue Mitarbeitende erfassen";

                // Vorschau auf die Nummer, die beim Speichern vergeben wird. Peek erhöht
                // den Zähler nicht - wird die Erfassung abgebrochen, entsteht also keine
                // Lücke in der Nummerierung. Der Zusatz im Text ist Absicht: Solange nicht
                // gespeichert ist, gehört die Nummer noch niemandem.
                TxtbEmployeeNr.Text = $"{_contacts.Employees.PeekNextEmployeeNumber()} (wird beim Speichern vergeben)";
            }
            else
            {
                LoadFromModel(_employee);
            }

            TxtbLastName.Focus();
        }

        /// <summary>
        /// Überträgt die Werte der übergebenen Person in die Eingabefelder (Model → Controls).
        /// </summary>
        /// <param name="employee">Die anzuzeigende Person.</param>
        private void LoadFromModel(Employee employee)
        {
            LblEmployeeInfos.Text = $"{employee.EmployeeNumber} {employee.LastName} {employee.FirstName}";
            TxtbEmployeeNr.Text = employee.EmployeeNumber.ToString();

            // Grunddaten
            TxtbLastName.Text = employee.LastName;
            TxtbFirstName.Text = employee.FirstName;
            ControlBinding.WriteDate(DtpDateOfBirth, employee.DateOfBirth);
            ControlBinding.SelectEnum(CombGender, employee.Gender);
            ControlBinding.SelectEnum(CombSalutation, employee.Salutation);
            TxtbSocialSecNr.Text = employee.SocialSecurityNumber ?? string.Empty;
            CombNationality.Text = employee.Nationality ?? string.Empty;

            // Kontaktdaten
            TxtbBusinessPhone.Text = employee.BusinessPhone ?? string.Empty;
            TxtbMobilePhone.Text = employee.MobilePhone ?? string.Empty;
            TxtbEmail.Text = employee.Email ?? string.Empty;

            // Anstellung
            ControlBinding.SelectOrAdd(CombDepartment, employee.Department);
            TxtbJobTitle.Text = employee.JobTitle ?? string.Empty;
            TxtbEmploymentLevel.Text = employee.EmploymentLevel?.ToString() ?? string.Empty;
            CombManagementLevel.SelectedItem = employee.ManagementLevel;
            ControlBinding.WriteDate(DtpHireDate, employee.HireDate);
            ControlBinding.WriteDate(DtpTerminationDate, employee.TerminationDate);

            ControlBinding.WriteAddress(employee.HomeAddress, TxtbPrivateStreet, TxtbPrivatePostalCode, TxtbPrivateCity);
            ControlBinding.WriteAddress(employee.BusinessAddress, TxtbBusinessStreet, TxtbBusinessPostalCode, TxtbBusinessCity);

            // Ausbildung: Ein bestehender Mitarbeiter kann nachträglich nicht zum Lernenden
            // werden (und umgekehrt) — das wäre ein Typwechsel, den die Business-Schicht
            // bewusst nicht unterstützt. Die Checkbox zeigt hier also nur noch an.
            if (employee is Apprentice apprentice)
            {
                ChkbIsApprentice.Checked = true;
                TxtbApprenticeshipYears.Text = apprentice.ApprenticeshipYears.ToString();
                TxtbCurrAppYear.Text = apprentice.CurrentApprenticeshipYear?.ToString() ?? string.Empty;
            }

            ChkbIsApprentice.Enabled = false;
        }

        /// <summary>
        /// Baut aus den Eingabefeldern eine Person (Controls → Model). Im Bearbeitungsmodus
        /// übernimmt das Ergebnis die <see cref="Person.Id"/> des Originals, damit
        /// <c>Update</c> den bestehenden Datensatz findet.
        /// </summary>
        /// <returns>Ein <see cref="Apprentice"/>, wenn "LERNENDE" angehakt ist, sonst ein <see cref="Employee"/>.</returns>
        private Employee CollectFromControls()
        {
            // Die Id bleibt im Bearbeitungsmodus erhalten; sie ist "init" und lässt sich
            // deshalb nur hier, in der Objekterzeugung, setzen.
            Guid id = _employee?.Id ?? Guid.NewGuid();
            string lastName = TxtbLastName.Text.Trim();
            string firstName = TxtbFirstName.Text.Trim();

            // Der Status ist Pflichtfeld, hat aber noch kein Control (Lücke 3 in PLAN.md).
            // Beim Bearbeiten wird der bestehende Status beibehalten — sonst würde jedes
            // Speichern eine deaktivierte Person stillschweigend wieder aktivieren.
            // TODO: an Status-Control binden, sobald vorhanden.
            Status status = _employee?.PersonStatus ?? Status.Active;

            Employee employee = ChkbIsApprentice.Checked
                ? new Apprentice
                {
                    Id = id,
                    LastName = lastName,
                    FirstName = firstName,
                    PersonStatus = status,
                    // Nicht-nullable int: Ein leeres Feld ergibt 0, worauf der Validator mit
                    // einer verständlichen deutschen Meldung reagiert.
                    ApprenticeshipYears = ControlBinding.ReadOptionalInt(TxtbApprenticeshipYears) ?? 0,
                    CurrentApprenticeshipYear = ControlBinding.ReadOptionalInt(TxtbCurrAppYear)
                }
                : new Employee
                {
                    Id = id,
                    LastName = lastName,
                    FirstName = firstName,
                    PersonStatus = status
                };

            // Grunddaten
            employee.DateOfBirth = ControlBinding.ReadDate(DtpDateOfBirth);
            employee.Gender = ControlBinding.ReadEnum<Gender>(CombGender);
            employee.Salutation = ControlBinding.ReadEnum<Salutation>(CombSalutation);
            employee.SocialSecurityNumber = ControlBinding.ReadOptionalText(TxtbSocialSecNr);
            employee.Nationality = ControlBinding.ReadOptionalText(CombNationality.Text);

            // Kontaktdaten
            employee.BusinessPhone = ControlBinding.ReadOptionalText(TxtbBusinessPhone);
            employee.MobilePhone = ControlBinding.ReadOptionalText(TxtbMobilePhone);
            employee.Email = ControlBinding.ReadOptionalText(TxtbEmail);

            // Anstellung
            employee.Department = ControlBinding.ReadOptionalText(CombDepartment.SelectedItem?.ToString());
            employee.JobTitle = ControlBinding.ReadOptionalText(TxtbJobTitle);
            employee.ManagementLevel = CombManagementLevel.SelectedItem is int level ? level : null;
            employee.HireDate = ControlBinding.ReadDate(DtpHireDate);
            employee.TerminationDate = ControlBinding.ReadDate(DtpTerminationDate);
            employee.EmploymentLevel = ControlBinding.ReadOptionalInt(TxtbEmploymentLevel);

            // Adressen
            employee.HomeAddress = ControlBinding.ReadAddress(TxtbPrivateStreet, TxtbPrivatePostalCode, TxtbPrivateCity);
            employee.BusinessAddress = ControlBinding.ReadAddress(TxtbBusinessStreet, TxtbBusinessPostalCode, TxtbBusinessCity);

            return employee;
        }

        // Speichert die Eingaben über die Business-Schicht. Ein Extra-Schritt "auf die
        // Platte schreiben" entfällt: Add und Update persistieren selbst.
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                Employee employee = CollectFromControls();

                if (_employee is null)
                {
                    _contacts.Employees.Add(employee);
                }
                else
                {
                    _contacts.Employees.Update(employee);
                }

                // Schliesst das modal geöffnete Fenster; die Liste lädt danach neu.
                DialogResult = DialogResult.OK;
            }
            catch (ValidationException ex)
            {
                // Die Meldung ist bereits deutsch und für Endanwender formuliert.
                MessageBox.Show(ex.Message, "Ungültige Eingabe",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (KeyNotFoundException)
            {
                // Der Datensatz wurde zwischenzeitlich gelöscht — weiterarbeiten wäre sinnlos.
                MessageBox.Show("Diese Person ist nicht mehr erfasst und kann nicht gespeichert werden.",
                    "Datensatz nicht gefunden", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                DialogResult = DialogResult.Cancel;
            }
        }

        // Blendet die Ausbildungs-Angaben nur ein, wenn Checkbox "IsApprentice" aktiviert ist.
        private void ChkbIsApprentice_CheckedChanged(object sender, EventArgs e)
        {
            GrpApprentice.Visible = ChkbIsApprentice.Checked;
            // Formularhöhe anpassen, damit Platz für die Ausbildungs-Box entsteht
            this.ClientSize = new Size(this.ClientSize.Width, ChkbIsApprentice.Checked ? 1000 : 840);
        }

        /// <summary>
        /// Füllt die Auswahlfelder mit ihren möglichen Werten. Die Enum-Werte des Models sind
        /// englisch benannt und werden für die Anzeige über <see cref="EnumDisplay"/> übersetzt.
        /// </summary>
        private void FillComboBoxes()
        {
            // Der Typ steht hier explizit, weil EnumDisplay.ToText mehrfach überladen ist
            // und der Compiler sonst nicht weiss, welche der Überladungen gemeint ist.
            ControlBinding.FillEnumCombo<Gender>(CombGender, EnumDisplay.ToText);
            ControlBinding.FillEnumCombo<Salutation>(CombSalutation, EnumDisplay.ToText);

            // Die Kaderstufe reicht laut Business-Regel von 0 bis 5. Die ComboBox ist im
            // Designer leer angelegt, deshalb werden die Werte hier gesetzt.
            CombManagementLevel.Items.Clear();
            for (int level = 0; level <= 5; level++)
            {
                CombManagementLevel.Items.Add(level);
            }
            CombManagementLevel.SelectedIndex = -1;

            // Feste Abteilungsliste, analog zur Kaderstufe direkt hier definiert.
            CombDepartment.Items.Clear();
            CombDepartment.Items.AddRange(new object[]
            {
                "IT", "Verkauf", "Finanzen", "HR", "Produktion", "Marketing", "Geschäftsleitung"
            });
            CombDepartment.SelectedIndex = -1;

            // Länderliste für die Nationalität. .NET kennt bereits alle Länder über CultureInfo
            // (eine Sprachregion pro Land, z. B. "de-CH" für Schweiz) - deshalb keine eigene,
            // manuell gepflegte Liste nötig. RegionInfo liefert daraus den ausgeschriebenen
            // Ländernamen in der aktuellen Sprache (bei uns Deutsch, dank Windows-Spracheinstellung).
            string[] nationalities = System.Globalization.CultureInfo
                .GetCultures(System.Globalization.CultureTypes.SpecificCultures)
                .Select(culture => new System.Globalization.RegionInfo(culture.Name).DisplayName)
                .Distinct()
                .OrderBy(name => name)
                .ToArray();

            // Vorschlagsliste für die Autovervollständigung; freie Eingabe bleibt weiterhin möglich.
            CombNationality.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CombNationality.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            CombNationality.AutoCompleteCustomSource.AddRange(nationalities);
            CombNationality.Validating += CombNationality_Validating;
        }

        // Verhindert erfundene Länder: Eingabe muss exakt einem Listeneintrag entsprechen.
        private void CombNationality_Validating(object sender, CancelEventArgs e)
        {
            if (CombNationality.Text.Length > 0 &&
                !CombNationality.AutoCompleteCustomSource.Cast<string>().Contains(CombNationality.Text))
            {
                MessageBox.Show("Bitte ein gültiges Land aus der Liste auswählen.",
                    "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CombNationality.Text = string.Empty;
            }
        }

        /// <summary>
        /// Leert alle Eingabefelder. Nötig, weil im Designer als Platzhalter wörtlich "..."
        /// in den Textfeldern steht — ohne Leeren würde das als erfasster Wert gespeichert.
        /// </summary>
        private void ClearInputs()
        {
            TextBox[] inputs =
            {
                TxtbLastName, TxtbFirstName, TxtbSocialSecNr,
                TxtbBusinessPhone, TxtbMobilePhone, TxtbEmail,
                TxtbJobTitle,
                TxtbPrivateStreet, TxtbPrivatePostalCode, TxtbPrivateCity,
                TxtbBusinessStreet, TxtbBusinessPostalCode, TxtbBusinessCity,
                TxtbApprenticeshipYears, TxtbCurrAppYear,TxtbEmploymentLevel
            };

            foreach (TextBox input in inputs)
            {
                input.Text = string.Empty;
            }

            // AHV-Nummer beginnt immer mit dem Schweizer Ländercode 756
            TxtbSocialSecNr.Text = "756";

            CombGender.SelectedIndex = -1;
            CombSalutation.SelectedIndex = -1;
            CombDepartment.SelectedIndex = -1;
            CombManagementLevel.SelectedIndex = -1;
            CombNationality.Text = string.Empty;

            DtpDateOfBirth.Checked = false;
            DtpHireDate.Checked = false;
            DtpTerminationDate.Checked = false;
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
                CombDepartment, TxtbJobTitle, CombManagementLevel,TxtbEmploymentLevel, DtpHireDate, DtpTerminationDate,

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

        // Erlaubt nur Ziffern und Steuerzeichen (z. B. Rücktaste) in der AHV-Nummer.
        private void TxtbSocialSecNr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Cursor ans Ende setzen, damit "756" nicht überschrieben wird, sondern man direkt weitertippt.
        private void TxtbSocialSecNr_Enter(object sender, EventArgs e)
        {
            TxtbSocialSecNr.SelectionStart = TxtbSocialSecNr.Text.Length;
            TxtbSocialSecNr.SelectionLength = 0;
        }

       
    }
}
