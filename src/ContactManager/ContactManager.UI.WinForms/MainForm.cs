using ContactManager.Business;
using ContactManager.UI.WinForms.Base;
using ContactManager.UI.WinForms.Forms;

namespace ContactManager.UI.WinForms

{
    /// <summary>
    /// Startseite der Anwendung. Zeigt die Kachel-Navigation und öffnet von dort die
    /// beiden Listenformulare, an die sie die Fassade der Business-Schicht weiterreicht.
    /// </summary>
    public partial class MainForm : BaseForm
    {
        // Zugang zur Business-Schicht. Wird in Program.Main einmalig erzeugt und von hier
        // an alle Folgefenster weitergegeben, damit alle auf denselben Daten arbeiten.
        private readonly ContactManagerFacade _contacts;

        /// <summary>
        /// Erzeugt die Startseite.
        /// </summary>
        /// <param name="contacts">Die Fassade der Business-Schicht, über die alle Daten laufen.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="contacts"/> <c>null</c> ist.</exception>
        public MainForm(ContactManagerFacade contacts)
        {
            ArgumentNullException.ThrowIfNull(contacts);

            InitializeComponent();
            _contacts = contacts;

            // Kacheln gemäss der selbst erstellten Farbpalette
            PnlCustomerTile.BackColor = AppColors.Primary;
            PnlEmployeeTile.BackColor = AppColors.Primary;

            // Textfarbe anpassen, da der Background dunkel ist
            LblCustomerTile.ForeColor = AppColors.TextOnPrimary;
            LblEmployeeTile.ForeColor = AppColors.TextOnPrimary;

            // Cursor bei Hover auf Hand setzen, zeigt Klickbarkeit der Kacheln an
            PnlCustomerTile.Cursor = Cursors.Hand;
            PnlEmployeeTile.Cursor = Cursors.Hand;
        }

        // Merkt sich das aktuell offene Fenster oder null, falls keins offen ist
        private CustomerListForm? _customerListForm;
        private EmployeeListForm? _employeeListForm;


        private void LblCustomerTile_Click(object sender, EventArgs e)
        {
            // Fenster wird geöffnet - sofern noch nicht geöffnet oder bereits geschlossen
            if (_customerListForm == null || _customerListForm.IsDisposed)
            {
                _customerListForm = new CustomerListForm(_contacts);

                // Reagiert, sobald das Kundschaft-Fenster geschlossen wird
                _customerListForm.FormClosed += CustomerListForm_Closed;
                _customerListForm.Show();
            }

            // Fenster existiert bereits, deshalb nur in den Vordergrund holen
            else
            {
                _customerListForm.BringToFront();
            }

            // Startseite ausblenden, solange das Kundschaft-Fenster offen ist
            this.Hide();
        }

        private void LblEmployeeTile_Click(object sender, EventArgs e)
        {
            // Fenster wird geöffnet - sofern noch nicht geöffnet oder bereits geschlossen
            if (_employeeListForm == null || _employeeListForm.IsDisposed)
            {
                _employeeListForm = new EmployeeListForm(_contacts);

                // Reagiert, sobald das Kundschaft-Fenster geschlossen wird
                _employeeListForm.FormClosed += EmployeeListForm_Closed;
                _employeeListForm.Show();
            }

            // Fenster existiert bereits, deshalb nur in den Vordergrund holen
            else
            {
                _employeeListForm.BringToFront();
            }

            // Startseite ausblenden, solange das Kundschaft-Fenster offen ist
            this.Hide();
        }

        // Wird automatisch aufgerufen, wenn das Kundschaft-Fenster geschlossen wird
        private void CustomerListForm_Closed(object? sender, FormClosedEventArgs e)
        {
            // Startseite wieder anzeigen
            this.Show();
        }
        private void EmployeeListForm_Closed(object? sender, FormClosedEventArgs e)
        {
            // Startseite wieder anzeigen
            this.Show();
        }
    }
}
