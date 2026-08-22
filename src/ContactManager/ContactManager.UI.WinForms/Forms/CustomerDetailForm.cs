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
    /// Zeigt die Detaildaten eines einzelnen Kundenkontakts an bzw. dient der
    /// Erfassung neuer Kunden. Wird von <see cref="CustomerListForm"/> aus
    /// geöffnet (Button "Neuer Kunde" oder Doppelklick auf einen bestehenden Eintrag).
    /// </summary>
    public partial class CustomerDetailForm : BaseForm
    {
        // Zugang zur Business-Schicht. Wird von der Liste durchgereicht, damit alle
        // Fenster auf demselben, einmalig geladenen Datenstamm arbeiten.
        private readonly ContactManagerFacade _contacts;

        // Der zu bearbeitende Kunde, oder null im Erfassungsmodus. Dieses eine Feld
        // unterscheidet die beiden Modi des Formulars.
        private readonly Customer? _customer;

        /// <summary>
        /// Öffnet das Formular im <b>Erfassungsmodus</b>: Alle Felder sind leer, beim
        /// Speichern entsteht ein neuer Kunde.
        /// </summary>
        /// <param name="contacts">Die Fassade der Business-Schicht, über die alle Daten laufen.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="contacts"/> <c>null</c> ist.</exception>
        public CustomerDetailForm(ContactManagerFacade contacts)
            : this(contacts, null)
        {
        }

        /// <summary>
        /// Öffnet das Formular im <b>Bearbeitungsmodus</b>, wenn ein Kunde übergeben wird,
        /// sonst im Erfassungsmodus.
        /// </summary>
        /// <param name="contacts">Die Fassade der Business-Schicht, über die alle Daten laufen.</param>
        /// <param name="customer">Der zu bearbeitende Kunde, oder <c>null</c> für eine Neuerfassung.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="contacts"/> <c>null</c> ist.</exception>
        public CustomerDetailForm(ContactManagerFacade contacts, Customer? customer)
        {
            ArgumentNullException.ThrowIfNull(contacts);

            InitializeComponent();

            _contacts = contacts;
            _customer = customer;

            SetTabOrder();
            SetGroupTabOrder();

            TxtbCustomerNr.ReadOnly = true;

            // Bewusst hier statt im Designer verdrahtet: Der Designer gehört den
            // Kolleg*innen, jede Änderung daran erzeugt unnötige Merge-Konflikte.
            BtnSave.Click += BtnSave_Click;
        }

        /// <summary>
        /// Bereitet die Eingabefelder vor und füllt sie im Bearbeitungsmodus mit den Daten
        /// des übergebenen Kunden. Bewusst hier statt im Konstruktor: Zu diesem Zeitpunkt
        /// sind alle Controls erzeugt und das Fenster ist bereit für den Fokus.
        /// </summary>
        /// <param name="e">Die Ereignisdaten des Load-Ereignisses.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            FillComboBoxes();
            ClearInputs();

            if (_customer is null)
            {
                LblCustomerInfos.Text = "Neuen Kunden erfassen";
                // Die Nummer vergibt die Business-Schicht erst beim Speichern.
                TxtbCustomerNr.Text = "(neu)";
            }
            else
            {
                LoadFromModel(_customer);
            }

            TxtbLastName.Focus();
        }

        /// <summary>
        /// Überträgt die Werte des übergebenen Kunden in die Eingabefelder (Model → Controls).
        /// </summary>
        /// <param name="customer">Der anzuzeigende Kunde.</param>
        private void LoadFromModel(Customer customer)
        {
            LblCustomerInfos.Text = $"{customer.CustomerNumber} {customer.LastName} {customer.FirstName}";
            TxtbCustomerNr.Text = customer.CustomerNumber.ToString();

            // Grunddaten
            TxtbLastName.Text = customer.LastName;
            TxtbFirstName.Text = customer.FirstName;
            WriteDate(DtpDateOfBirth, customer.DateOfBirth);
            SelectEnum(CombGender, customer.Gender);
            SelectEnum(CombSalutation, customer.Salutation);
            TxtbTitle.Text = customer.Title ?? string.Empty;

            // Kontaktdaten
            TxtbBusinessPhone.Text = customer.BusinessPhone ?? string.Empty;
            TxtbMobilePhone.Text = customer.MobilePhone ?? string.Empty;
            TxtbEmail.Text = customer.Email ?? string.Empty;

            // Adresse
            WriteAddress(customer.Address, TxtbStreet, TxtbPostalCode, TxtbCity);
        }

        /// <summary>
        /// Baut aus den Eingabefeldern einen Kunden (Controls → Model). Im Bearbeitungsmodus
        /// übernimmt das Ergebnis die <see cref="Person.Id"/> des Originals, damit
        /// <c>Update</c> den bestehenden Datensatz findet.
        /// </summary>
        /// <returns>Der aus den Eingaben zusammengesetzte Kunde.</returns>
        private Customer CollectFromControls()
        {
            // Die Id bleibt im Bearbeitungsmodus erhalten; sie ist "init" und lässt sich
            // deshalb nur hier, in der Objekterzeugung, setzen.
            Guid id = _customer?.Id ?? Guid.NewGuid();

            // Der Status ist Pflichtfeld, hat aber noch kein Control. Beim Bearbeiten wird
            // der bestehende Status beibehalten — sonst würde jedes Speichern einen
            // deaktivierten Kunden stillschweigend wieder aktivieren.
            // TODO: an Status-Control binden, sobald vorhanden.
            Status status = _customer?.PersonStatus ?? Status.Active;

            var customer = new Customer
            {
                Id = id,
                LastName = TxtbLastName.Text.Trim(),
                FirstName = TxtbFirstName.Text.Trim(),
                PersonStatus = status
            };

            // Grunddaten
            customer.DateOfBirth = ReadDate(DtpDateOfBirth);
            customer.Gender = ReadEnum<Gender>(CombGender);
            customer.Salutation = ReadEnum<Salutation>(CombSalutation);
            customer.Title = ReadOptionalText(TxtbTitle);

            // Kontaktdaten
            customer.BusinessPhone = ReadOptionalText(TxtbBusinessPhone);
            customer.MobilePhone = ReadOptionalText(TxtbMobilePhone);
            customer.Email = ReadOptionalText(TxtbEmail);

            // Adresse
            customer.Address = ReadAddress(TxtbStreet, TxtbPostalCode, TxtbCity);

            return customer;
        }

        // Speichert die Eingaben über die Business-Schicht. Ein Extra-Schritt "auf die
        // Platte schreiben" entfällt: Add und Update persistieren selbst.
        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                Customer customer = CollectFromControls();

                if (_customer is null)
                {
                    _contacts.Customers.Add(customer);
                }
                else
                {
                    _contacts.Customers.Update(customer);
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
                MessageBox.Show("Dieser Kunde ist nicht mehr erfasst und kann nicht gespeichert werden.",
                    "Datensatz nicht gefunden", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                DialogResult = DialogResult.Cancel;
            }
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
        }

        /// <summary>
        /// Leert alle Eingabefelder. Nötig, weil im Designer als Platzhalter wörtlich "..."
        /// in den Textfeldern steht — ohne Leeren würde das als erfasster Wert gespeichert.
        /// </summary>
        private void ClearInputs()
        {
            TextBox[] inputs =
            {
                TxtbLastName, TxtbFirstName, TxtbTitle,
                TxtbBusinessPhone, TxtbMobilePhone, TxtbEmail,
                TxtbStreet, TxtbPostalCode, TxtbCity
            };

            foreach (TextBox input in inputs)
            {
                input.Text = string.Empty;
            }

            CombGender.SelectedIndex = -1;
            CombSalutation.SelectedIndex = -1;

            DtpDateOfBirth.Checked = false;
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
    }
}