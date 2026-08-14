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
            this.ClientSize = new Size(this.ClientSize.Width, 825);
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
            PrepareDatePickers();
            ClearInputs();

            if (_employee is null)
            {
                LblEmployeeInfos.Text = "Neue Mitarbeitende erfassen";
                // Die Nummer vergibt die Business-Schicht erst beim Speichern.
                TxtbEmployeeNr.Text = "(neu)";
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
            WriteDate(DtpDateOfBirth, employee.DateOfBirth);
            SelectEnum(CombGender, employee.Gender);
            SelectEnum(CombSalutation, employee.Salutation);
            TxtbSocialSecNr.Text = employee.SocialSecurityNumber ?? string.Empty;
            CombNationality.Text = employee.Nationality ?? string.Empty;

            // Kontaktdaten
            TxtbBusinessPhone.Text = employee.BusinessPhone ?? string.Empty;
            TxtbMobilePhone.Text = employee.MobilePhone ?? string.Empty;
            TxtbEmail.Text = employee.Email ?? string.Empty;

            // Anstellung
            SelectOrAdd(CombDepartment, employee.Department);
            TxtbJobTitle.Text = employee.JobTitle ?? string.Empty;
            CombManagementLevel.SelectedItem = employee.ManagementLevel;
            WriteDate(DtpHireDate, employee.HireDate);
            WriteDate(DtpTerminationDate, employee.TerminationDate);

            WriteAddress(employee.HomeAddress, TxtbPrivateStreet, TxtbPrivatePostalCode, TxtbPrivateCity);
            WriteAddress(employee.BusinessAddress, TxtbBusinessStreet, TxtbBusinessPostalCode, TxtbBusinessCity);

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
                    ApprenticeshipYears = ReadOptionalInt(TxtbApprenticeshipYears) ?? 0,
                    CurrentApprenticeshipYear = ReadOptionalInt(TxtbCurrAppYear)
                }
                : new Employee
                {
                    Id = id,
                    LastName = lastName,
                    FirstName = firstName,
                    PersonStatus = status
                };

            // Grunddaten
            employee.DateOfBirth = ReadDate(DtpDateOfBirth);
            employee.Gender = ReadEnum<Gender>(CombGender);
            employee.Salutation = ReadEnum<Salutation>(CombSalutation);
            employee.SocialSecurityNumber = ReadOptionalText(TxtbSocialSecNr);
            employee.Nationality = ReadOptionalText(CombNationality.Text);

            // Kontaktdaten
            employee.BusinessPhone = ReadOptionalText(TxtbBusinessPhone);
            employee.MobilePhone = ReadOptionalText(TxtbMobilePhone);
            employee.Email = ReadOptionalText(TxtbEmail);

            // Anstellung
            employee.Department = ReadOptionalText(CombDepartment.SelectedItem?.ToString());
            employee.JobTitle = ReadOptionalText(TxtbJobTitle);
            employee.ManagementLevel = CombManagementLevel.SelectedItem is int level ? level : null;
            employee.HireDate = ReadDate(DtpHireDate);
            employee.TerminationDate = ReadDate(DtpTerminationDate);

            // TODO: EmploymentLevel binden, sobald das Control existiert (Lücke 2 in PLAN.md).
            employee.EmploymentLevel = _employee?.EmploymentLevel;

            employee.HomeAddress = ReadAddress(TxtbPrivateStreet, TxtbPrivatePostalCode, TxtbPrivateCity);
            employee.BusinessAddress = ReadAddress(TxtbBusinessStreet, TxtbBusinessPostalCode, TxtbBusinessCity);

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
            this.ClientSize = new Size(this.ClientSize.Width, ChkbIsApprentice.Checked ? 990 : 825);
        }

        /// <summary>
        /// Füllt die Auswahlfelder mit ihren möglichen Werten. Die Enum-Werte des Models sind
        /// englisch benannt und werden für die Anzeige über <see cref="EnumDisplay"/> übersetzt.
        /// </summary>
        private void FillComboBoxes()
        {
            // Der Typ steht hier explizit, weil EnumDisplay.ToText mehrfach überladen ist
            // und der Compiler sonst nicht weiss, welche der Überladungen gemeint ist.
            FillEnumCombo<Gender>(CombGender, EnumDisplay.ToText);
            FillEnumCombo<Salutation>(CombSalutation, EnumDisplay.ToText);

            // Die Kaderstufe reicht laut Business-Regel von 0 bis 5. Die ComboBox ist im
            // Designer leer angelegt, deshalb werden die Werte hier gesetzt.
            CombManagementLevel.Items.Clear();
            for (int level = 0; level <= 5; level++)
            {
                CombManagementLevel.Items.Add(level);
            }
            CombManagementLevel.SelectedIndex = -1;
        }

        /// <summary>
        /// Erlaubt den Datumsfeldern den Zustand "nicht gesetzt". Ein DateTimePicker hat
        /// sonst immer ein Datum — jede Person bekäme beim Erfassen ungefragt das heutige.
        /// Die Checkbox im Control bedeutet damit "Wert erfasst".
        /// </summary>
        private void PrepareDatePickers()
        {
            DtpDateOfBirth.ShowCheckBox = true;
            DtpHireDate.ShowCheckBox = true;
            DtpTerminationDate.ShowCheckBox = true;
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
                TxtbApprenticeshipYears, TxtbCurrAppYear
            };

            foreach (TextBox input in inputs)
            {
                input.Text = string.Empty;
            }

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

        // ---------------------------------------------------------------------------
        // Kleine Umrechnungshilfen zwischen Control-Werten und Model-Typen.
        // Statisch, weil sie nur mit ihren Parametern arbeiten und keinen Zustand kennen.
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Liest ein optionales Textfeld. Leere oder nur aus Leerzeichen bestehende Eingaben
        /// werden zu <c>null</c> — das Model unterscheidet "nicht erfasst" von "leerer Text".
        /// </summary>
        /// <param name="box">Das auszulesende Textfeld.</param>
        /// <returns>Der bereinigte Text oder <c>null</c>.</returns>
        private static string? ReadOptionalText(TextBox box) => ReadOptionalText(box.Text);

        /// <summary>
        /// Bereinigt einen Eingabetext; leere Eingaben werden zu <c>null</c>.
        /// </summary>
        /// <param name="text">Der zu bereinigende Text.</param>
        /// <returns>Der getrimmte Text oder <c>null</c>.</returns>
        private static string? ReadOptionalText(string? text) =>
            string.IsNullOrWhiteSpace(text) ? null : text.Trim();

        /// <summary>
        /// Liest eine ganze Zahl aus einem Textfeld, ohne bei Buchstaben abzustürzen.
        /// Bewusst <c>TryParse</c> statt <c>Parse</c>: Eine Fehleingabe darf die Anwendung
        /// nicht beenden.
        /// </summary>
        /// <param name="box">Das auszulesende Textfeld.</param>
        /// <returns>Die eingegebene Zahl oder <c>null</c>, wenn das Feld leer oder keine Zahl ist.</returns>
        private static int? ReadOptionalInt(TextBox box) =>
            int.TryParse(box.Text.Trim(), out int value) ? value : null;

        /// <summary>
        /// Liest ein Datum aus einem DateTimePicker; ist dessen Checkbox nicht gesetzt,
        /// gilt das Datum als nicht erfasst.
        /// </summary>
        /// <param name="picker">Das auszulesende Datumsfeld.</param>
        /// <returns>Das gewählte Datum oder <c>null</c>.</returns>
        private static DateOnly? ReadDate(DateTimePicker picker) =>
            picker.Checked ? DateOnly.FromDateTime(picker.Value) : null;

        /// <summary>
        /// Zeigt ein Datum im DateTimePicker an; <c>null</c> erscheint als leerer,
        /// nicht angehakter Wert.
        /// </summary>
        /// <param name="picker">Das zu setzende Datumsfeld.</param>
        /// <param name="value">Das anzuzeigende Datum oder <c>null</c>.</param>
        private static void WriteDate(DateTimePicker picker, DateOnly? value)
        {
            if (value is DateOnly date)
            {
                picker.Value = date.ToDateTime(TimeOnly.MinValue);
                picker.Checked = true;
            }
            else
            {
                picker.Checked = false;
            }
        }

        /// <summary>
        /// Baut aus drei Eingabefeldern eine Adresse. Sind alle drei leer, gilt die Adresse
        /// als nicht erfasst; ist nur ein Teil ausgefüllt, entsteht die Adresse trotzdem und
        /// der Validator der Business-Schicht meldet, was fehlt.
        /// </summary>
        /// <param name="street">Feld für Strasse und Nummer.</param>
        /// <param name="postalCode">Feld für die Postleitzahl.</param>
        /// <param name="city">Feld für den Ort.</param>
        /// <returns>Die erfasste Adresse oder <c>null</c>.</returns>
        private static Address? ReadAddress(TextBox street, TextBox postalCode, TextBox city)
        {
            string streetValue = street.Text.Trim();
            string postalCodeValue = postalCode.Text.Trim();
            string cityValue = city.Text.Trim();

            if (streetValue.Length == 0 && postalCodeValue.Length == 0 && cityValue.Length == 0)
            {
                return null;
            }

            return new Address
            {
                Street = streetValue,
                PostalCode = postalCodeValue,
                City = cityValue
            };
        }

        /// <summary>
        /// Verteilt eine Adresse auf die drei zugehörigen Eingabefelder.
        /// </summary>
        /// <param name="address">Die anzuzeigende Adresse oder <c>null</c>.</param>
        /// <param name="street">Feld für Strasse und Nummer.</param>
        /// <param name="postalCode">Feld für die Postleitzahl.</param>
        /// <param name="city">Feld für den Ort.</param>
        private static void WriteAddress(Address? address, TextBox street, TextBox postalCode, TextBox city)
        {
            street.Text = address?.Street ?? string.Empty;
            postalCode.Text = address?.PostalCode ?? string.Empty;
            city.Text = address?.City ?? string.Empty;
        }

        /// <summary>
        /// Füllt eine ComboBox mit allen Werten eines Enums und deren deutscher Beschriftung.
        /// Bewusst über <c>Items</c> statt über <c>DataSource</c>: Nur so bleibt der Zustand
        /// "nichts ausgewählt" möglich, den die optionalen Felder des Models brauchen.
        /// </summary>
        /// <typeparam name="TEnum">Das anzuzeigende Enum.</typeparam>
        /// <param name="box">Die zu füllende ComboBox.</param>
        /// <param name="toText">Übersetzt einen Enum-Wert in seine Beschriftung.</param>
        private static void FillEnumCombo<TEnum>(ComboBox box, Func<TEnum, string> toText)
            where TEnum : struct, Enum
        {
            box.Items.Clear();

            foreach (TEnum value in Enum.GetValues<TEnum>())
            {
                box.Items.Add(new ComboItem<TEnum>(value, toText(value)));
            }

            box.SelectedIndex = -1;
        }

        /// <summary>
        /// Liest den ausgewählten Enum-Wert einer ComboBox.
        /// </summary>
        /// <typeparam name="TEnum">Das erwartete Enum.</typeparam>
        /// <param name="box">Die auszulesende ComboBox.</param>
        /// <returns>Der gewählte Wert oder <c>null</c>, wenn nichts ausgewählt ist.</returns>
        private static TEnum? ReadEnum<TEnum>(ComboBox box)
            where TEnum : struct, Enum =>
            (box.SelectedItem as ComboItem<TEnum>)?.Value;

        /// <summary>
        /// Wählt den zum Wert passenden Eintrag einer ComboBox aus; <c>null</c> lässt die
        /// Auswahl leer.
        /// </summary>
        /// <typeparam name="TEnum">Das angezeigte Enum.</typeparam>
        /// <param name="box">Die zu setzende ComboBox.</param>
        /// <param name="value">Der auszuwählende Wert oder <c>null</c>.</param>
        private static void SelectEnum<TEnum>(ComboBox box, TEnum? value)
            where TEnum : struct, Enum
        {
            box.SelectedIndex = -1;

            if (value is null)
            {
                return;
            }

            foreach (object? item in box.Items)
            {
                if (item is ComboItem<TEnum> comboItem &&
                    EqualityComparer<TEnum>.Default.Equals(comboItem.Value, value.Value))
                {
                    box.SelectedItem = item;
                    return;
                }
            }
        }

        /// <summary>
        /// Wählt einen Text in einer ComboBox aus und nimmt ihn vorher in die Liste auf,
        /// falls er dort fehlt. Ohne das ginge ein gespeicherter Wert beim nächsten
        /// Speichern verloren, nur weil er nicht zur Auswahl steht.
        /// </summary>
        /// <param name="box">Die zu setzende ComboBox.</param>
        /// <param name="value">Der auszuwählende Text oder <c>null</c>.</param>
        private static void SelectOrAdd(ComboBox box, string? value)
        {
            box.SelectedIndex = -1;

            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            if (!box.Items.Contains(value))
            {
                box.Items.Add(value);
            }

            box.SelectedItem = value;
        }
    }
}
