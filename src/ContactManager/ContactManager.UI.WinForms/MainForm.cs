using ContactManager.UI.WinForms.Base;
using ContactManager.UI.WinForms.Forms;

namespace ContactManager.UI.WinForms

{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
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
                _customerListForm = new CustomerListForm();

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
                _employeeListForm = new EmployeeListForm();

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
