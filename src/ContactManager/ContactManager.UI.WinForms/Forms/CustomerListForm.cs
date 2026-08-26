using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContactManager.Business;
using ContactManager.Business.Search;
using ContactManager.Model;
using ContactManager.Model.Enums;
using ContactManager.UI.WinForms.Base;

namespace ContactManager.UI.WinForms.Forms
{
    /// <summary>
    /// Zeigt die Übersicht aller Kundschaft an. Bewusst als eigenständiges Formular
    /// umgesetzt statt gemeinsam mit <see cref="EmployeeListForm"/>, da sich die
    /// Datentiefe von Customer und Employee deutlich unterscheidet.
    /// </summary>
    public partial class CustomerListForm : BaseForm
    {
        // Zugang zur Business-Schicht. Wird von der MainForm durchgereicht, damit alle
        // Fenster auf demselben, einmalig geladenen Datenstamm arbeiten.
        private readonly ContactManagerFacade _contacts;

        // Verwaltet die Häkchen der Spalte ColSelect. Wird erst in ConfigureGrid erzeugt,
        // weil die Spalte davor noch nicht fertig eingerichtet ist.
        private GridSelection? _selection;

        /// <summary>
        /// Erzeugt die Kundenübersicht.
        /// </summary>
        /// <param name="contacts">Die Fassade der Business-Schicht, über die alle Daten laufen.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="contacts"/> <c>null</c> ist.</exception>
        public CustomerListForm(ContactManagerFacade contacts)
        {
            ArgumentNullException.ThrowIfNull(contacts);

            InitializeComponent();
            _contacts = contacts;

            // Bewusst hier statt im Designer verdrahtet: Der Designer gehört den
            // Kolleg*innen, jede Änderung daran erzeugt unnötige Merge-Konflikte.
            BtnAddCustomer.Click += BtnAddCustomer_Click;
            DgvCustomerList.CellDoubleClick += DgvCustomerList_CellDoubleClick;
            BtnDeleteCustomer.Click += BtnDeleteCustomer_Click;
            BtnFilterReset.Click += BtnFilterReset_Click;

            SetTabOrder();
        }

        // Setzt die Tab-Reihenfolge für bessere Bedienung mittels Tabstop.
        private void SetTabOrder()
        {
            Control[] orderedControls =
            {
                TxtbCustomerNrSearch, TxtbLastNameSearch, TxtbFirstNameSearch, TxtbDateOfBirthSearch,
                BtnAddCustomer, DgvCustomerList, BtnDeleteCustomer, BtnReturnToHome
            };

            for (int i = 0; i < orderedControls.Length; i++)
            {
                orderedControls[i].TabIndex = i;
            }
        }

        /// <summary>
        /// Richtet Tabelle und Suchfelder ein und lädt die Kundschaft, sobald das Fenster
        /// erscheint.
        /// Bewusst hier statt im Konstruktor: Zu diesem Zeitpunkt sind alle Controls
        /// erzeugt, und ein Fehler beim Laden trifft ein bereits sichtbares Fenster.
        /// </summary>
        /// <param name="e">Die Ereignisdaten des Load-Ereignisses.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ConfigureGrid();
            PrepareSearchInputs();
            LoadCustomers();
        }

        /// <summary>
        /// Verbindet die im Designer angelegten Spalten mit den Properties von
        /// <see cref="Customer"/>. Wird genau einmal beim Öffnen des Fensters aufgerufen.
        /// </summary>
        private void ConfigureGrid()
        {
            // Ohne diese Zeile hängt WinForms zusätzlich zu den Designer-Spalten für jede
            // Property des gebundenen Objekts eine automatisch erzeugte Spalte an.
            DgvCustomerList.AutoGenerateColumns = false;

            // nameof statt Zeichenkette: Ein Tippfehler wäre sonst kein Fehler, sondern
            // bloss eine stumm leer bleibende Spalte zur Laufzeit.
            ColCustomerNumber.DataPropertyName = nameof(Customer.CustomerNumber);
            ColLastname.DataPropertyName = nameof(Customer.LastName);
            ColFirstName.DataPropertyName = nameof(Customer.FirstName);
            ColTitle.DataPropertyName = nameof(Customer.Title);
            ColDateOfBirth.DataPropertyName = nameof(Customer.DateOfBirth);
            // Die Spalte ist mit "Telefon" beschriftet und zeigt deshalb die
            // Geschäftsnummer; die Mobilnummer steht im Detailformular.
            ColPhone.DataPropertyName = nameof(Customer.BusinessPhone);
            ColEmail.DataPropertyName = nameof(Customer.Email);
            ColStatus.DataPropertyName = nameof(Customer.PersonStatus);

            // Die Datenspalten sind reine Anzeige; geändert wird im Detailformular. Ohne
            // ReadOnly liessen sich Zellen direkt bearbeiten - die Änderung landete im
            // Model, aber nie auf der Platte, weil dabei kein Service aufgerufen wird.
            //
            // Gesperrt wird bewusst Spalte für Spalte statt über DgvCustomerList.ReadOnly:
            // Steht das ganze Grid auf ReadOnly, zeichnet WinForms auch die Checkbox-Zellen
            // von ColSelect deaktiviert - die Spalte sieht dann leer aus und die
            // Mehrfachauswahl ist nicht bedienbar. ColSelect nimmt GridSelection wieder aus
            // der Sperre heraus.
            foreach (DataGridViewColumn column in DgvCustomerList.Columns)
            {
                column.ReadOnly = true;
            }

            DgvCustomerList.AllowUserToAddRows = false;
            DgvCustomerList.AllowUserToDeleteRows = false;
            DgvCustomerList.MultiSelect = false;
            DgvCustomerList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DgvCustomerList.CellFormatting += DgvCustomerList_CellFormatting;

            _selection = new GridSelection(DgvCustomerList, ColSelect);
        }

        /// <summary>
        /// Leert die Suchfelder und beschriftet sie mit einem Platzhalter. Nötig, weil im
        /// Designer wörtlich "..." als Text hinterlegt ist - ungeleert würde die Liste beim
        /// Öffnen nach dem Vornamen "..." suchen und leer bleiben. Der Platzhalter des
        /// Datumsfelds nennt zugleich das erwartete Format.
        /// </summary>
        private void PrepareSearchInputs()
        {
            TxtbCustomerNrSearch.Text = string.Empty;
            TxtbLastNameSearch.Text = string.Empty;
            TxtbFirstNameSearch.Text = string.Empty;
            TxtbDateOfBirthSearch.Text = string.Empty;

            TxtbCustomerNrSearch.PlaceholderText = "z. B. 1001";
            TxtbLastNameSearch.PlaceholderText = "z. B. Muster";
            TxtbFirstNameSearch.PlaceholderText = "z. B. Anna";
            TxtbDateOfBirthSearch.PlaceholderText = "TT.MM.JJJJ";

            // Erst jetzt verdrahtet und nicht im Konstruktor: Das Leeren oben löst selbst
            // ein TextChanged aus - die Liste würde sonst viermal aufgebaut, noch bevor sie
            // das erste Mal gebraucht wird.
            TxtbCustomerNrSearch.TextChanged += SearchInput_TextChanged;
            TxtbLastNameSearch.TextChanged += SearchInput_TextChanged;
            TxtbFirstNameSearch.TextChanged += SearchInput_TextChanged;
            TxtbDateOfBirthSearch.TextChanged += SearchInput_TextChanged;
        }

        // Wertet die Suchkriterien laufend aus: Jede Änderung an einem Suchfeld baut die
        // Liste sofort neu auf. Kommt später ein Such-Button dazu, wandert derselbe Aufruf
        // auf dessen Click-Ereignis und diese vier Verdrahtungen entfallen.
        private void SearchInput_TextChanged(object? sender, EventArgs e)
        {
            LoadCustomers();
        }

        /// <summary>
        /// Baut die Anzeige aus dem aktuellen Datenstamm neu auf und wendet dabei die
        /// eingegebenen Suchkriterien an. Einziger Ort, an dem die Tabelle befüllt wird -
        /// nach jeder Änderung genügt ein erneuter Aufruf. Sind keine Kriterien erfasst,
        /// liefert die Suche alle Personen; ein Sonderfall "ohne Filter" ist deshalb unnötig.
        /// </summary>
        private void LoadCustomers()
        {
            IReadOnlyList<Person> matches = _contacts.Search.Search(BuildSearchCriteria());

            // Search() durchsucht Kunden und Mitarbeitende gemeinsam und liefert deshalb
            // Person; die Spalten dieser Liste sind aber an Customer-Properties gebunden.
            // Ausserdem taugt als DataSource nur eine echte Liste, daher ToList().
            DgvCustomerList.DataSource = matches.OfType<Customer>().ToList();

            // Die Checkbox-Spalte ist ungebunden: Ihre Werte überleben das Setzen der
            // DataSource nicht. Ohne diesen Aufruf wäre die Auswahl nach jedem Tastendruck
            // im Suchfeld still verschwunden - und die Zellen stünden auf null statt false,
            // womit WinForms gar keine Checkbox zeichnet.
            _selection?.Refresh();
        }

        /// <summary>
        /// Liest die Suchfelder aus und baut daraus die Kriterien für die Business-Schicht.
        /// Leere und unvollständige Eingaben ergeben <c>null</c> und werden von der Suche
        /// ignoriert - während des Tippens ist jede Eingabe zwischenzeitlich unvollständig,
        /// eine Fehlermeldung pro Tastendruck wäre unbrauchbar.
        /// </summary>
        /// <returns>Die aktuell im Formular erfassten Suchkriterien.</returns>
        private SearchCriteria BuildSearchCriteria() => new SearchCriteria
        {
            FirstName = ControlBinding.ReadOptionalText(TxtbFirstNameSearch),
            LastName = ControlBinding.ReadOptionalText(TxtbLastNameSearch),
            DateOfBirth = ControlBinding.ReadOptionalDate(TxtbDateOfBirthSearch),
            Number = ControlBinding.ReadOptionalInt(TxtbCustomerNrSearch),

            // Type bleibt null, genau wie in der Mitarbeiterliste - dort ist es zwingend
            // (ContactType.Employee würde Lernende ausschliessen), hier wäre
            // ContactType.Customer zwar unschädlich, aber überflüssig: Das OfType<Customer>
            // in LoadCustomers() wird für die DataSource ohnehin gebraucht und filtert
            // bereits. Beide Listen bleiben so Zeile für Zeile gleich lesbar.
            Type = null
        };

        private void DgvCustomerList_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Der Status ist im Model ein englisches Enum (Active/Passive). Für die Anzeige
            // wird er hier übersetzt, ohne dafür das Model anfassen zu müssen.
            if (DgvCustomerList.Columns[e.ColumnIndex] == ColStatus && e.Value is Status status)
            {
                e.Value = EnumDisplay.ToText(status);
                e.FormattingApplied = true;
            }
        }

        // Öffnet das Detailformular im Erfassungsmodus.
        private void BtnAddCustomer_Click(object? sender, EventArgs e)
        {
            ShowDetail(null);
        }

        // Öffnet die doppelt angeklickte Zeile im Bearbeitungsmodus.
        private void DgvCustomerList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Ein Doppelklick auf die Spaltenüberschrift meldet RowIndex -1; ohne diese
            // Prüfung würde der Zugriff auf Rows[-1] die Anwendung beenden.
            if (e.RowIndex < 0)
            {
                return;
            }

            // DataBoundItem ist genau das Objekt aus dem Datenstamm, an das gebunden wurde -
            // inklusive Id. Genau deshalb ist die Liste an Customer gebunden und nicht an
            // eine eigene Anzeigeklasse.
            if (DgvCustomerList.Rows[e.RowIndex].DataBoundItem is not Customer customer)
            {
                return;
            }

            ShowDetail(customer);
        }

        /// <summary>
        /// Zeigt das Detailformular modal an und baut die Liste danach neu auf.
        /// </summary>
        /// <param name="customer">Der zu bearbeitende Kunde, oder <c>null</c> für eine Neuerfassung.</param>
        private void ShowDetail(Customer? customer)
        {
            // ShowDialog gibt das Fenster - anders als Show/Close - nicht selbst frei;
            // ohne using bliebe bei jedem Öffnen ein Formular im Speicher zurück.
            using (CustomerDetailForm detail = new CustomerDetailForm(_contacts, customer))
            {
                // Owner setzen, damit das Detailfenster nicht hinter der Liste verschwindet.
                detail.ShowDialog(this);
            }

            // Bewusst ohne Prüfung auf DialogResult.OK: Das Detailformular schliesst auch
            // dann, wenn der Datensatz zwischenzeitlich gelöscht wurde (DialogResult.Cancel) -
            // gerade dann muss die Liste neu geladen werden.
            LoadCustomers();
        }

        private void BtnReturnToHome_Click(object sender, EventArgs e)
        {
            // Schliesst dieses Fenster; MainForm erscheint automatisch wieder (FormClosed-Event)
            this.Close();
        }

        // Leert alle Suchfelder für eine neue Suche. Das Leeren jedes Felds löst über
        // SearchInput_TextChanged bereits einen Reload aus - ein zusätzlicher Aufruf von
        // LoadCustomers() ist deshalb hier nicht nötig, genau wie in PrepareSearchInputs.
        private void BtnFilterReset_Click(object? sender, EventArgs e)
        {
            TxtbCustomerNrSearch.Text = string.Empty;
            TxtbLastNameSearch.Text = string.Empty;
            TxtbFirstNameSearch.Text = string.Empty;
            TxtbDateOfBirthSearch.Text = string.Empty;
        }

        // Das Umschalten der Checkbox erledigt seit der Einführung von GridSelection
        // WinForms selbst: ColSelect ist eine editierbare Spalte, ein Klick genügt, und
        // CommitEdit schreibt den Wert sofort fest. Das frühere programmatische Umschalten
        // an dieser Stelle würde den Klick ein zweites Mal umdrehen und sich damit selbst
        // aufheben. Die Methode bleibt leer stehen, weil das CellClick-Ereignis im Designer
        // verdrahtet ist - und der gehört den Kolleg*innen.
        private void DgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // Löscht alle über die Checkbox ausgewählten Kunden, nach Sicherheitsabfrage.
        private void BtnDeleteCustomer_Click(object? sender, EventArgs e)
        {
            // Bewusst nur die sichtbaren Zeilen: Bei aktiver Suche soll genau das gelöscht
            // werden, was man auch sieht.
            IReadOnlyList<Customer> selected = _selection?.GetSelected<Customer>() ?? new List<Customer>();

            // Ohne Auswahl gibt es nichts zu löschen.
            if (selected.Count == 0)
            {
                MessageBox.Show("Bitte mindestens eine Person auswählen.",
                    "Keine Auswahl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Meldung je nach Anzahl im Singular oder Plural formulieren.
            string message = selected.Count == 1
                ? "Soll der ausgewählte Datensatz wirklich gelöscht werden?"
                : $"Sollen die ausgewählten {selected.Count} Datensätze wirklich gelöscht werden?";

            DialogResult confirm = MessageBox.Show(message, "Löschen bestätigen",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Ohne Bestätigung bleibt alles unverändert.
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            // Delete speichert pro Aufruf automatisch - kein zusätzlicher Speicherschritt nötig.
            // Der Fehlerfall wird gezählt statt sofort gemeldet: Bei mehreren Ausgewählten
            // sollen die übrigen trotzdem gelöscht werden, statt beim ersten Fehler stehen
            // zu bleiben.
            int notFound = 0;

            foreach (Customer customer in selected)
            {
                try
                {
                    _contacts.Customers.Delete(customer.Id);
                }
                catch (KeyNotFoundException)
                {
                    notFound++;
                }

                // In beiden Fällen ist der Eintrag weg - das Häkchen darf nicht als
                // gemerkte Auswahl liegen bleiben.
                _selection?.Forget(customer.Id);
            }

            if (notFound > 0)
            {
                MessageBox.Show(
                    $"{notFound} der ausgewählten Datensätze waren nicht mehr erfasst und wurden übersprungen.",
                    "Datensatz nicht gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Liste neu aufbauen, damit die gelöschten Personen sofort verschwinden.
            LoadCustomers();
        }
    }
}
