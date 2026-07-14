using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ContactManager.UI.WinForms.Base
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            // Fenster beim Öffnen immer mittig auf dem Bildschirm positionieren
            this.StartPosition = FormStartPosition.CenterScreen;

            // Einheitliche Hintergrundfarbe gemäss Farbpalette (statt Standard-Grau)
            this.BackColor = AppColors.Background;
        }
    }
}
