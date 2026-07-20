using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ContactManager.UI.WinForms.Base
{
    // Zentrale Farbpalette der Anwendung, basierend auf der im Projekt definierten Farbwelt
    public static class AppColors
    {
        // Haupt-Akzentfarbe, z. B. für Header und Buttons - haupt-Lila
        public static readonly Color Primary = Color.FromArgb(0x5C, 0x2D, 0x91);

        // Sekundäre Akzentfarbe, etwas heller als Primary - helleres Lila
        public static readonly Color Accent = Color.FromArgb(0x8A, 0x4F, 0xB8);

        // Heller Hintergrundton für Formulare und Flächen - sehr helles Lila
        public static readonly Color Background = Color.FromArgb(0xF4, 0xEF, 0xFA);

        // Standard-Textfarbe auf hellem Hintergrund - dunkler Text
        public static readonly Color TextDark = Color.FromArgb(0x1A, 0x1A, 0x1A);

        // Textfarbe für dunkle/farbige Flächen (z. B. auf Primary) - weisser Text
        public static readonly Color TextOnPrimary = Color.White;
    }
}
