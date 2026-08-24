using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactManager.Business;
using ContactManager.Model;
using ContactManager.UI.WinForms.Base;

namespace ContactManager.UI.WinForms.Forms
{
    /// <summary>
    /// Erfasst eine neue Notiz zu einem Kundenkontakt oder zeigt eine bereits erfasste
    /// Notiz an. Wird modal aus <see cref="CustomerDetailForm"/> geöffnet — über den
    /// Button "neue Notitz" (Erfassung) oder per Doppelklick auf eine Zeile der Historie
    /// (reine Ansicht). Notizen sind laut Fachkonzept nur anhängbar: Einmal gespeichert,
    /// lassen sie sich weder ändern noch löschen.
    /// </summary>
    public partial class ContactNoteForm : BaseForm
    {
        // Zugang zur Business-Schicht. Wird vom Detailformular durchgereicht, damit alle
        // Fenster auf demselben, einmalig geladenen Datenstamm arbeiten.
        private readonly ContactManagerFacade _contacts;

        // Der Kunde, an dessen Historie die Notiz angehängt wird.
        private readonly Guid _customerId;

        // Die anzuzeigende Notiz, oder null im Erfassungsmodus. Dieses eine Feld
        // unterscheidet die beiden Modi des Formulars.
        private readonly ContactNote? _note;

        /// <summary>
        /// Öffnet das Formular im <b>Erfassungsmodus</b>: Der Zeitpunkt ist mit "jetzt"
        /// vorbelegt und änderbar, das Textfeld ist leer.
        /// </summary>
        /// <param name="contacts">Die Fassade der Business-Schicht, über die alle Daten laufen.</param>
        /// <param name="customerId">Die Id des Kunden, zu dem die Notiz gehört.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="contacts"/> <c>null</c> ist.</exception>
        public ContactNoteForm(ContactManagerFacade contacts, Guid customerId)
            : this(contacts, customerId, null)
        {
        }

        /// <summary>
        /// Öffnet das Formular in der <b>reinen Ansicht</b>, wenn eine Notiz übergeben wird,
        /// sonst im Erfassungsmodus.
        /// </summary>
        /// <param name="contacts">Die Fassade der Business-Schicht, über die alle Daten laufen.</param>
        /// <param name="customerId">Die Id des Kunden, zu dem die Notiz gehört.</param>
        /// <param name="note">Die anzuzeigende Notiz, oder <c>null</c> für eine Neuerfassung.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="contacts"/> <c>null</c> ist.</exception>
        public ContactNoteForm(ContactManagerFacade contacts, Guid customerId, ContactNote? note)
        {
            ArgumentNullException.ThrowIfNull(contacts);

            InitializeComponent();

            _contacts = contacts;
            _customerId = customerId;
            _note = note;

            // Bewusst hier statt im Designer verdrahtet: Der Designer gehört den
            // Kolleg*innen, jede Änderung daran erzeugt unnötige Merge-Konflikte.
            BtnSaveNote.Click += BtnSaveNote_Click;
            BtnCancel.Click += BtnCancel_Click;

            // Enter speichert, Escape schliesst. Beide Zuweisungen brauchen die fertig
            // erzeugten Controls, stehen deshalb nach InitializeComponent().
            AcceptButton = BtnSaveNote;
            CancelButton = BtnCancel;
        }

        /// <summary>
        /// Belegt die Eingabefelder vor bzw. füllt sie in der Ansicht mit den Werten der
        /// übergebenen Notiz. Bewusst hier statt im Konstruktor: Zu diesem Zeitpunkt sind
        /// alle Controls erzeugt und das Fenster ist bereit für den Fokus.
        /// </summary>
        /// <param name="e">Die Ereignisdaten des Load-Ereignisses.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_note is null)
            {
                Text = "Neue Notiz";

                // Der Picker kennt keinen leeren Zustand; hier ist das kein Problem, weil
                // der Zeitpunkt anders als ein Geburtsdatum ein Pflichtwert ist. Deshalb
                // auch kein ShowCheckBox wie bei DtpDateOfBirth.
                DtpCreatedAt.Value = DateTime.Now;
                TxtbNoteText.Text = string.Empty;

                TxtbNoteText.Focus();
            }
            else
            {
                LoadFromModel(_note);
            }
        }

        /// <summary>
        /// Zeigt die übergebene Notiz an und sperrt das Formular. Notizen sind nach dem
        /// Erfassen unveränderlich — es gibt deshalb bewusst kein Gegenstück, das die
        /// Controls wieder in ein Model zurückliest.
        /// </summary>
        /// <param name="note">Die anzuzeigende Notiz.</param>
        private void LoadFromModel(ContactNote note)
        {
            Text = "Notiz vom " + note.CreatedAt.ToString("dd.MM.yyyy HH:mm:ss");

            // Der Picker wirft, wenn der Wert ausserhalb seines Bereichs liegt (ab 1753).
            // Aus einer von Hand manipulierten contacts.json kann so ein Wert kommen - eine
            // unbrauchbare Anzeige ist hinnehmbar, ein Absturz nicht.
            if (note.CreatedAt >= DtpCreatedAt.MinDate && note.CreatedAt <= DtpCreatedAt.MaxDate)
            {
                DtpCreatedAt.Value = note.CreatedAt;
            }

            TxtbNoteText.Text = note.Text;

            DtpCreatedAt.Enabled = false;

            // ReadOnly statt Enabled = false: So bleibt langer Text markierbar und
            // scrollbar, wird aber nicht ausgegraut und unleserlich.
            TxtbNoteText.ReadOnly = true;

            BtnSaveNote.Visible = false;
            BtnCancel.Text = "Schliessen";

            // Ohne Speichern-Button darf Enter nicht ins Leere laufen.
            AcceptButton = BtnCancel;
        }

        // Hängt die Notiz über die Business-Schicht an die Historie an. Ein Extra-Schritt
        // "auf die Platte schreiben" entfällt: AddNote persistiert selbst.
        private void BtnSaveNote_Click(object? sender, EventArgs e)
        {
            string text = TxtbNoteText.Text.Trim();

            // Die Prüfung steht bewusst vor dem Serviceaufruf: AddNote würde zwar ebenfalls
            // ablehnen, aber mit einer englischen ArgumentException, die als Meldung für
            // Endanwender nicht taugt.
            if (text.Length == 0)
            {
                MessageBox.Show("Bitte einen Notiztext erfassen.", "Ungültige Eingabe",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                TxtbNoteText.Focus();
                return;
            }

            try
            {
                _contacts.Notes.AddNote(_customerId, text, DtpCreatedAt.Value);

                // Schliesst das modal geöffnete Fenster; die Historie lädt danach neu.
                DialogResult = DialogResult.OK;
            }
            catch (KeyNotFoundException)
            {
                // Der Kunde wurde zwischenzeitlich gelöscht — weiterarbeiten wäre sinnlos.
                MessageBox.Show("Dieser Kunde ist nicht mehr erfasst; die Notiz kann nicht gespeichert werden.",
                    "Datensatz nicht gefunden", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                DialogResult = DialogResult.Cancel;
            }
        }

        // Schliesst das Fenster, ohne etwas zu speichern.
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
