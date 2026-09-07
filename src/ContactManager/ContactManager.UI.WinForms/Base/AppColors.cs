using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ContactManager.UI.WinForms.Base
{
    /// <summary>
    /// Zentrale Farbpalette der Anwendung, basierend auf der im Projekt definierten
    /// Farbwelt. Farben werden ausschliesslich hier bezogen und nie im Formular
    /// hart codiert, damit die Oberfläche an einer Stelle anpassbar bleibt.
    /// </summary>
    public static class AppColors
    {
        /// <summary>Haupt-Akzentfarbe für Header und Schaltflächen (dunkles Lila).</summary>
        public static readonly Color Primary = Color.FromArgb(0x5C, 0x2D, 0x91);

        /// <summary>Sekundäre Akzentfarbe, etwas heller als <see cref="Primary"/> (helleres Lila).</summary>
        public static readonly Color Accent = Color.FromArgb(0x8A, 0x4F, 0xB8);

        /// <summary>Heller Hintergrundton für Formulare und Flächen (sehr helles Lila).</summary>
        public static readonly Color Background = Color.FromArgb(0xF4, 0xEF, 0xFA);

        /// <summary>Standard-Textfarbe auf hellem Hintergrund (nahezu schwarz).</summary>
        public static readonly Color TextDark = Color.FromArgb(0x1A, 0x1A, 0x1A);

        /// <summary>Textfarbe für dunkle bzw. farbige Flächen, etwa auf <see cref="Primary"/> (weiss).</summary>
        public static readonly Color TextOnPrimary = Color.White;
    }
}
