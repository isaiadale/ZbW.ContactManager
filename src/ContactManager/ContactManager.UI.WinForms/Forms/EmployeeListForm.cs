using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContactManager.Business;
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
        }

        /// <summary>
        /// Richtet die Tabelle ein und lädt die Mitarbeitenden, sobald das Fenster erscheint.
        /// Bewusst hier statt im Konstruktor: Zu diesem Zeitpunkt sind alle Controls
        /// erzeugt, und ein Fehler beim Laden trifft ein bereits sichtbares Fenster.
        /// </summary>
        /// <param name="e">Die Ereignisdaten des Load-Ereignisses.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ConfigureGrid();
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
        /// Baut die Anzeige aus dem aktuellen Datenstamm neu auf. Einziger Ort, an dem die
        /// Tabelle befüllt wird - nach jeder Änderung genügt ein erneuter Aufruf.
        /// </summary>
        private void LoadEmployees()
        {
            // GetAll() liefert IReadOnlyList (und enthält Lernende gleich mit);
            // als DataSource taugt nur eine echte Liste.
            DgvEmployeeList.DataSource = _contacts.Employees.GetAll().ToList();
        }

        private void BtnReturnToHome_Click(object sender, EventArgs e)
        {
            // Schliesst dieses Fenster; MainForm erscheint automatisch wieder (FormClosed-Event)
            this.Close();
        }
    }
}
