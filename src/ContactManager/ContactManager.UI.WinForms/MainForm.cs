using ContactManager.UI.WinForms.Base;

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
    }
}
