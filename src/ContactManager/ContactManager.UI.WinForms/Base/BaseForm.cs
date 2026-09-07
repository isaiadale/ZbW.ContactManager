using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ContactManager.UI.WinForms.Base
{
    /// <summary>
    /// Gemeinsame Basisklasse aller Formulare der Anwendung. Sie vereinheitlicht das
    /// Erscheinungsbild, damit einzelne Formulare Position und Hintergrund nicht
    /// jeweils selbst setzen müssen.
    /// </summary>
    public class BaseForm : Form
    {
        /// <summary>
        /// Erstellt das Formular, positioniert es mittig auf dem Bildschirm und setzt
        /// den Hintergrund auf <see cref="AppColors.Background"/>.
        /// </summary>
        public BaseForm()
        {
            // Fenster beim Öffnen immer mittig auf dem Bildschirm positionieren
            this.StartPosition = FormStartPosition.CenterScreen;

            // Einheitliche Hintergrundfarbe gemäss Farbpalette (statt Standard-Grau)
            this.BackColor = AppColors.Background;
        }
    }
}
