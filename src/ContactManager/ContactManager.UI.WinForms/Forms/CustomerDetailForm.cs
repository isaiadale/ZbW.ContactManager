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
            btnNewNote.Click += BtnNewNote_Click;
            DgvProtocolNotes.CellDoubleClick += DgvProtocolNotes_CellDoubleClick;
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
            ConfigureNotesGrid();

            if (_customer is null)
            {
                LblCustomerInfos.Text = "Neuen Kunden erfassen";

                // Vorschau auf die Nummer, die beim Speichern vergeben wird. Peek erhöht
                // den Zähler nicht - wird die Erfassung abgebrochen, entsteht also keine
                // Lücke in der Nummerierung. Der Zusatz im Text ist Absicht: Solange nicht
                // gespeichert ist, gehört die Nummer noch niemandem.
                TxtbCustomerNr.Text = $"{_contacts.Customers.PeekNextCustomerNumber()} (wird beim Speichern vergeben)";

                // AddNote braucht eine Kunden-Id, die es vor dem ersten Speichern noch
                // nicht gibt. Der Bereich wird deshalb gesperrt statt beim Klick mit einer
                // Fehlermeldung zu antworten - so ist schon vor dem Klick sichtbar, dass
                // hier zuerst der Kunde gespeichert werden muss.
                GrpProtocolNotes.Text = "PROTOKOLLIERUNG (erst nach dem Speichern)";
                DgvProtocolNotes.Enabled = false;
                btnNewNote.Enabled = false;
            }
            else
            {
                LoadFromModel(_customer);
                LoadNotes();
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
            ControlBinding.WriteDate(DtpDateOfBirth, customer.DateOfBirth);
            ControlBinding.SelectEnum(CombGender, customer.Gender);
            ControlBinding.SelectEnum(CombSalutation, customer.Salutation);
            TxtbTitle.Text = customer.Title ?? string.Empty;
            ControlBinding.SelectEnum<Status>(CombStatus, customer.PersonStatus);

            // Kontaktdaten
            TxtbBusinessPhone.Text = customer.BusinessPhone ?? string.Empty;
            TxtbMobilePhone.Text = customer.MobilePhone ?? string.Empty;
            TxtbEmail.Text = customer.Email ?? string.Empty;

            // Adresse
            ControlBinding.WriteAddress(customer.Address, TxtbStreet, TxtbPostalCode, TxtbCity);
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

            // Der Status ist Pflichtfeld. CombStatus ist eine DropDownList und wird beim
            // Öffnen vorbelegt, hat also immer eine Auswahl; die beiden Rückfallwerte
            // greifen nur, falls das je nicht mehr gilt. Der bestehende Status geht dabei
            // vor Status.Active — sonst würde ein Fehlgriff einen deaktivierten Kunden
            // stillschweigend wieder aktivieren.
            Status status = ControlBinding.ReadEnum<Status>(CombStatus)
                ?? _customer?.PersonStatus
                ?? Status.Active;

            var customer = new Customer
            {
                Id = id,
                LastName = TxtbLastName.Text.Trim(),
                FirstName = TxtbFirstName.Text.Trim(),
                PersonStatus = status
            };

            // Grunddaten
            customer.DateOfBirth = ControlBinding.ReadDate(DtpDateOfBirth);
            customer.Gender = ControlBinding.ReadEnum<Gender>(CombGender);
            customer.Salutation = ControlBinding.ReadEnum<Salutation>(CombSalutation);
            customer.Title = ControlBinding.ReadOptionalText(TxtbTitle);

            // Kontaktdaten
            customer.BusinessPhone = ControlBinding.ReadOptionalText(TxtbBusinessPhone);
            customer.MobilePhone = ControlBinding.ReadOptionalText(TxtbMobilePhone);
            customer.Email = ControlBinding.ReadOptionalText(TxtbEmail);

            // Adresse
            customer.Address = ControlBinding.ReadAddress(TxtbStreet, TxtbPostalCode, TxtbCity);

            return customer;
        }

        /// <summary>
        /// Verbindet die im Designer angelegten Spalten der Notiz-Historie mit den
        /// Properties von <see cref="ContactNote"/>. Wird genau einmal beim Öffnen des
        /// Fensters aufgerufen.
        /// </summary>
        private void ConfigureNotesGrid()
        {
            // Ohne diese Zeile hängt WinForms zusätzlich zu den Designer-Spalten für jede
            // Property des gebundenen Objekts eine automatisch erzeugte Spalte an.
            DgvProtocolNotes.AutoGenerateColumns = false;

            // nameof statt Zeichenkette: Ein Tippfehler wäre sonst kein Fehler, sondern
            // bloss eine stumm leer bleibende Spalte zur Laufzeit.
            ColDateTime.DataPropertyName = nameof(ContactNote.CreatedAt);
            ColText.DataPropertyName = nameof(ContactNote.Text);

            // CreatedAt ist ein DateTime und wird - anders als ein DateOnly - von der
            // DataGridView von selbst angezeigt; nötig ist hier nur das Format. Die im
            // Designer gesetzte Breite von 120 Pixeln reicht für Datum und Uhrzeit nicht,
            // deshalb die Korrektur im Code.
            ColDateTime.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
            ColDateTime.Width = 200;

            // Die Historie ist reine Anzeige: Notizen sind nach dem Erfassen unveränderlich
            // und werden weder hier noch anderswo bearbeitet oder gelöscht.
            foreach (DataGridViewColumn column in DgvProtocolNotes.Columns)
            {
                column.ReadOnly = true;
            }

            DgvProtocolNotes.AllowUserToAddRows = false;
            DgvProtocolNotes.AllowUserToDeleteRows = false;
            DgvProtocolNotes.MultiSelect = false;
            DgvProtocolNotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvProtocolNotes.RowHeadersVisible = false;
        }

        /// <summary>
        /// Baut die Notiz-Historie aus dem aktuellen Datenstamm neu auf. Einziger Ort, an
        /// dem die Tabelle befüllt wird - nach jeder neuen Notiz genügt ein erneuter Aufruf.
        /// Die Sortierung (neueste zuerst) liefert bereits die Business-Schicht.
        /// </summary>
        private void LoadNotes()
        {
            // Im Erfassungsmodus gibt es noch keinen Kunden, dessen Notizen anzuzeigen wären.
            if (_customer is null)
            {
                return;
            }

            // Als DataSource taugt nur eine echte Liste, daher ToList().
            DgvProtocolNotes.DataSource = _contacts.Notes.GetNotes(_customer.Id).ToList();
        }

        // Öffnet das Notizformular im Erfassungsmodus.
        private void BtnNewNote_Click(object? sender, EventArgs e)
        {
            // Im Erfassungsmodus ist der Button deaktiviert; die Prüfung hält den Zustand
            // auch dann konsistent, wenn das einmal nicht mehr gilt.
            if (_customer is null)
            {
                return;
            }

            // ShowDialog gibt das Fenster - anders als Show/Close - nicht selbst frei;
            // ohne using bliebe bei jedem Öffnen ein Formular im Speicher zurück.
            using (ContactNoteForm note = new ContactNoteForm(_contacts, _customer.Id))
            {
                if (note.ShowDialog(this) == DialogResult.OK)
                {
                    LoadNotes();
                }
            }
        }

        // Öffnet die doppelt angeklickte Notiz in der reinen Ansicht.
        private void DgvProtocolNotes_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Ein Doppelklick auf die Spaltenüberschrift meldet RowIndex -1; ohne diese
            // Prüfung würde der Zugriff auf Rows[-1] die Anwendung beenden.
            if (e.RowIndex < 0 || _customer is null)
            {
                return;
            }

            if (DgvProtocolNotes.Rows[e.RowIndex].DataBoundItem is not ContactNote note)
            {
                return;
            }

            // Bewusst ohne LoadNotes() danach: In der reinen Ansicht kann sich nichts
            // geändert haben - Notizen sind nach dem Erfassen unveränderlich.
            using (ContactNoteForm view = new ContactNoteForm(_contacts, _customer.Id, note))
            {
                view.ShowDialog(this);
            }
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
            ControlBinding.FillEnumCombo<Gender>(CombGender, EnumDisplay.ToText);
            ControlBinding.FillEnumCombo<Salutation>(CombSalutation, EnumDisplay.ToText);
            ControlBinding.FillEnumCombo<Status>(CombStatus, EnumDisplay.ToText);
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

            // Anders als Geschlecht und Anrede ist der Status kein optionales Feld: Ein
            // neuer Kunde ist per Voreinstellung aktiv. Leer lassen ginge nicht, die
            // DropDownList kennt keine Eingabe von Hand.
            ControlBinding.SelectEnum<Status>(CombStatus, Status.Active);

            DtpDateOfBirth.Checked = false;
        }

        // Setzt die Tab-Reihenfolge für bessere Bearbeitung der Felder mittels Tapstop.
        private void SetTabOrder()
        {
            Control[] orderedControls =
            {
                // Grunddaten
                TxtbLastName, TxtbFirstName, DtpDateOfBirth, CombGender, CombSalutation, TxtbTitle,
                CombStatus,

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
                GrpPersonalData, GrpContactData, GrpAddress, GrpProtocolNotes
            };

            // Weist jeder GroupBox die Tab-Reihenfolge entsprechend ihrer Position zu.
            for (int i = 0; i < orderedGroups.Length; i++)
            {
                orderedGroups[i].TabIndex = i;
            }
        }
    }
}