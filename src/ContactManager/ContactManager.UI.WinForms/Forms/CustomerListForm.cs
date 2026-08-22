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

            
        }

        /// <summary>
        /// Richtet die Tabelle ein und lädt die Kundschaft, sobald das Fenster erscheint.
        /// Bewusst hier statt im Konstruktor: Zu diesem Zeitpunkt sind alle Controls
        /// erzeugt, und ein Fehler beim Laden trifft ein bereits sichtbares Fenster.
        /// </summary>
        /// <param name="e">Die Ereignisdaten des Load-Ereignisses.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ConfigureGrid();
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
            // ColPhone ist mehrdeutig (Mobile oder Geschäft) - hier bewusst die Mobilnummer.
            ColPhone.DataPropertyName = nameof(Customer.MobilePhone);
            ColEmail.DataPropertyName = nameof(Customer.Email);
            ColStatus.DataPropertyName = nameof(Customer.PersonStatus);

            // Die Liste ist reine Anzeige; geändert wird im Detailformular. Ohne ReadOnly
            // liessen sich Zellen direkt bearbeiten - die Änderung landete im Model, aber
            // nie auf der Platte, weil dabei kein Service aufgerufen wird.
            DgvCustomerList.ReadOnly = true;
            DgvCustomerList.AllowUserToAddRows = false;
            DgvCustomerList.AllowUserToDeleteRows = false;
            DgvCustomerList.MultiSelect = false;
            DgvCustomerList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DgvCustomerList.CellFormatting += DgvCustomerList_CellFormatting;
        }

        /// <summary>
        /// Baut die Anzeige aus dem aktuellen Datenstamm neu auf. Einziger Ort, an dem die
        /// Tabelle befüllt wird - nach jeder Änderung genügt ein erneuter Aufruf.
        /// </summary>
        private void LoadCustomers()
        {
            // GetAll() liefert IReadOnlyList; als DataSource taugt nur eine echte Liste.
            DgvCustomerList.DataSource = _contacts.Customers.GetAll().ToList();
        }

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

        private void BtnReturnToHome_Click(object sender, EventArgs e)
        {
            // Schliesst dieses Fenster; MainForm erscheint automatisch wieder (FormClosed-Event)
            this.Close();
        }

        private void DgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ermöglicht das Umschalten der Checkbox mit nur einem Klick, statt zwei
            if (e.RowIndex >= 0 && DgvCustomerList.Columns[e.ColumnIndex].Name == "ColSelect")
            {
                DataGridViewCheckBoxCell checkboxCell =
                    (DataGridViewCheckBoxCell)DgvCustomerList.Rows[e.RowIndex].Cells["ColSelect"];

                checkboxCell.Value = !(bool)(checkboxCell.Value ?? false);

                // Zelle sofort verlassen, damit der neue Wert übernommen wird
                DgvCustomerList.EndEdit();
            }
        }
    }
}
