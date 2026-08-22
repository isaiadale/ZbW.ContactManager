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
using ContactManager.UI.WinForms.Base;

namespace ContactManager.UI.WinForms.Forms
{
    /// <summary>
    /// Zeigt die Übersicht aller Mitarbeitenden an. Bewusst als eigenständiges Formular
    /// umgesetzt statt gemeinsam mit <see cref="CustomerListForm"/>, da sich die
    /// Datentiefe von Customer und Employee deutlich unterscheidet.
    /// </summary>
    public partial class EmployeeListForm : BaseForm
    {
        // Zugang zur Business-Schicht. Wird von der MainForm durchgereicht, damit alle
        // Fenster auf demselben, einmalig geladenen Datenstamm arbeiten.
        private readonly ContactManagerFacade _contacts;

        /// <summary>
        /// Erzeugt die Mitarbeiterübersicht.
        /// </summary>
        /// <param name="contacts">Die Fassade der Business-Schicht, über die alle Daten laufen.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="contacts"/> <c>null</c> ist.</exception>
        public EmployeeListForm(ContactManagerFacade contacts)
        {
            ArgumentNullException.ThrowIfNull(contacts);

            InitializeComponent();
            _contacts = contacts;

            // Bewusst hier statt im Designer verdrahtet: Der Designer gehört den
            // Kolleg*innen, jede Änderung daran erzeugt unnötige Merge-Konflikte.
            BtnAddEmployee.Click += BtnAddEmployee_Click;
            DgvEmployeeList.CellDoubleClick += DgvEmployeeList_CellDoubleClick;
            BtnDeleteEmployee.Click += BtnDeleteEmployee_Click;

            SetTabOrder();
        }

        // Setzt die Tab-Reihenfolge für bessere Bedienung mittels Tabstop.
        private void SetTabOrder()
        {
            Control[] orderedControls =
            {
                TxtbEmployeeNrSearch, TxtbLastNameSearch, TxtbFirstNameSearch, TxtbDateOfBirthSearch,
                BtnAddEmployee, DgvEmployeeList, BtnDeleteEmployee, BtnReturnToHome
    };

            for (int i = 0; i < orderedControls.Length; i++)
            {
                orderedControls[i].TabIndex = i;
            }
        }

        /// <summary>
        /// Richtet Tabelle und Suchfelder ein und lädt die Mitarbeitenden, sobald das Fenster
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
            LoadEmployees();
        }

        /// <summary>
        /// Verbindet die im Designer angelegten Spalten mit den Properties von
        /// <see cref="Employee"/>. Wird genau einmal beim Öffnen des Fensters aufgerufen.
        /// </summary>
        private void ConfigureGrid()
        {
            // Ohne diese Zeile hängt WinForms zusätzlich zu den Designer-Spalten für jede
            // Property des gebundenen Objekts eine automatisch erzeugte Spalte an.
            DgvEmployeeList.AutoGenerateColumns = false;

            // nameof statt Zeichenkette: Ein Tippfehler wäre sonst kein Fehler, sondern
            // bloss eine stumm leer bleibende Spalte zur Laufzeit.
            ColEmployeeNumber.DataPropertyName = nameof(Employee.EmployeeNumber);
            ColLastname.DataPropertyName = nameof(Employee.LastName);
            ColFirstName.DataPropertyName = nameof(Employee.FirstName);
            ColDateOfBirth.DataPropertyName = nameof(Employee.DateOfBirth);
            // ColPhone ist mehrdeutig (Mobile oder Geschäft) - hier bewusst die Mobilnummer.
            ColPhone.DataPropertyName = nameof(Employee.MobilePhone);
            ColEmail.DataPropertyName = nameof(Employee.Email);
            ColDepartment.DataPropertyName = nameof(Employee.Department);
            ColJobTitle.DataPropertyName = nameof(Employee.JobTitle);

            // Die Liste ist reine Anzeige; geändert wird im Detailformular. Ohne ReadOnly
            // liessen sich Zellen direkt bearbeiten - die Änderung landete im Model, aber
            // nie auf der Platte, weil dabei kein Service aufgerufen wird.
            DgvEmployeeList.ReadOnly = true;
            DgvEmployeeList.AllowUserToAddRows = false;
            DgvEmployeeList.AllowUserToDeleteRows = false;
            DgvEmployeeList.MultiSelect = false;
            DgvEmployeeList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Leert die Suchfelder und beschriftet sie mit einem Platzhalter. Nötig, weil im
        /// Designer wörtlich "..." als Text hinterlegt ist - ungeleert würde die Liste beim
        /// Öffnen nach dem Vornamen "..." suchen und leer bleiben. Der Platzhalter des
        /// Datumsfelds nennt zugleich das erwartete Format.
        /// </summary>
        private void PrepareSearchInputs()
        {
            TxtbEmployeeNrSearch.Text = string.Empty;
            TxtbLastNameSearch.Text = string.Empty;
            TxtbFirstNameSearch.Text = string.Empty;
            TxtbDateOfBirthSearch.Text = string.Empty;

            TxtbEmployeeNrSearch.PlaceholderText = "z. B. 1001";
            TxtbLastNameSearch.PlaceholderText = "z. B. Muster";
            TxtbFirstNameSearch.PlaceholderText = "z. B. Anna";
            TxtbDateOfBirthSearch.PlaceholderText = "TT.MM.JJJJ";

            // Erst jetzt verdrahtet und nicht im Konstruktor: Das Leeren oben löst selbst
            // ein TextChanged aus - die Liste würde sonst viermal aufgebaut, noch bevor sie
            // das erste Mal gebraucht wird.
            TxtbEmployeeNrSearch.TextChanged += SearchInput_TextChanged;
            TxtbLastNameSearch.TextChanged += SearchInput_TextChanged;
            TxtbFirstNameSearch.TextChanged += SearchInput_TextChanged;
            TxtbDateOfBirthSearch.TextChanged += SearchInput_TextChanged;
        }

        // Wertet die Suchkriterien laufend aus: Jede Änderung an einem Suchfeld baut die
        // Liste sofort neu auf. Kommt später ein Such-Button dazu, wandert derselbe Aufruf
        // auf dessen Click-Ereignis und diese vier Verdrahtungen entfallen.
        private void SearchInput_TextChanged(object? sender, EventArgs e)
        {
            LoadEmployees();
        }

        /// <summary>
        /// Baut die Anzeige aus dem aktuellen Datenstamm neu auf und wendet dabei die
        /// eingegebenen Suchkriterien an. Einziger Ort, an dem die Tabelle befüllt wird -
        /// nach jeder Änderung genügt ein erneuter Aufruf. Sind keine Kriterien erfasst,
        /// liefert die Suche alle Personen; ein Sonderfall "ohne Filter" ist deshalb unnötig.
        /// </summary>
        private void LoadEmployees()
        {
            IReadOnlyList<Person> matches = _contacts.Search.Search(BuildSearchCriteria());

            // Search() durchsucht Kunden und Mitarbeitende gemeinsam und liefert deshalb
            // Person; die Spalten dieser Liste sind aber an Employee-Properties gebunden.
            // OfType wirft die Kunden weg und behält Lernende (Apprentice erbt Employee).
            // Ausserdem taugt als DataSource nur eine echte Liste, daher ToList().
            DgvEmployeeList.DataSource = matches.OfType<Employee>().ToList();
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
            Number = ControlBinding.ReadOptionalInt(TxtbEmployeeNrSearch),

            // Type bleibt bewusst null: ContactType.Employee schliesst Lernende aus
            // (person is Employee and not Apprentice) - sie würden aus der Liste fallen,
            // sobald ein Suchfeld ausgefüllt ist. Die Eingrenzung auf Mitarbeitende
            // übernimmt stattdessen das OfType<Employee> in LoadEmployees().
            Type = null
        };

        // Öffnet das Detailformular im Erfassungsmodus.
        private void BtnAddEmployee_Click(object? sender, EventArgs e)
        {
            ShowDetail(null);
        }

        // Öffnet die doppelt angeklickte Zeile im Bearbeitungsmodus.
        private void DgvEmployeeList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Ein Doppelklick auf die Spaltenüberschrift meldet RowIndex -1; ohne diese
            // Prüfung würde der Zugriff auf Rows[-1] die Anwendung beenden.
            if (e.RowIndex < 0)
            {
                return;
            }

            // DataBoundItem ist genau das Objekt aus dem Datenstamm, an das gebunden wurde -
            // inklusive Id. Genau deshalb ist die Liste an Employee gebunden und nicht an
            // eine eigene Anzeigeklasse.
            if (DgvEmployeeList.Rows[e.RowIndex].DataBoundItem is not Employee employee)
            {
                return;
            }

            ShowDetail(employee);
        }

        /// <summary>
        /// Zeigt das Detailformular modal an und baut die Liste danach neu auf.
        /// </summary>
        /// <param name="employee">Die zu bearbeitende Person, oder <c>null</c> für eine Neuerfassung.</param>
        private void ShowDetail(Employee? employee)
        {
            // ShowDialog gibt das Fenster - anders als Show/Close - nicht selbst frei;
            // ohne using bliebe bei jedem Öffnen ein Formular im Speicher zurück.
            using (EmployeeDetailForm detail = new EmployeeDetailForm(_contacts, employee))
            {
                // Owner setzen, damit das Detailfenster nicht hinter der Liste verschwindet.
                detail.ShowDialog(this);
            }

            // Bewusst ohne Prüfung auf DialogResult.OK: Das Detailformular schliesst auch
            // dann, wenn der Datensatz zwischenzeitlich gelöscht wurde (DialogResult.Cancel) -
            // gerade dann muss die Liste neu geladen werden.
            LoadEmployees();
        }

        private void BtnReturnToHome_Click(object sender, EventArgs e)
        {
            // Schliesst dieses Fenster; MainForm erscheint automatisch wieder (FormClosed-Event)
            this.Close();
        }

        private void DgvEmployeeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ermöglicht das Umschalten der Checkbox mit nur einem Klick, statt zwei
            if (e.RowIndex >= 0 && DgvEmployeeList.Columns[e.ColumnIndex].Name == "ColSelect")
            {
                DataGridViewCheckBoxCell checkboxCell =
                    (DataGridViewCheckBoxCell)DgvEmployeeList.Rows[e.RowIndex].Cells["ColSelect"];

                checkboxCell.Value = !(bool)(checkboxCell.Value ?? false);

                // Zelle sofort verlassen, damit der neue Wert übernommen wird
                DgvEmployeeList.EndEdit();
            }

        }

        // Löscht alle über die Checkbox ausgewählten Personen, nach Sicherheitsabfrage.
        private void BtnDeleteEmployee_Click(object sender, EventArgs e)
        {
            // Alle Zeilen sammeln, deren Checkbox-Spalte angehakt ist.
            List<Employee> selected = new List<Employee>();

            foreach (DataGridViewRow row in DgvEmployeeList.Rows)
            {
                if (row.Cells["ColSelect"].Value is bool isChecked && isChecked &&
                    row.DataBoundItem is Employee employee)
                {
                    selected.Add(employee);
                }
            }

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

            foreach (Employee employee in selected)
            {
                try
                {
                    _contacts.Employees.Delete(employee.Id);
                }
                catch (KeyNotFoundException)
                {
                    notFound++;
                }
            }

            if (notFound > 0)
            {
                MessageBox.Show(
                    $"{notFound} der ausgewählten Datensätze waren nicht mehr erfasst und wurden übersprungen.",
                    "Datensatz nicht gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Liste neu aufbauen, damit die gelöschten Personen sofort verschwinden.
            LoadEmployees();
        }
    }
}
