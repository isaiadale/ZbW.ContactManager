using System;
using System.Drawing;

namespace ContactManager.UI.WinForms.Base
{
    /// <summary>
    /// Farbreihe für Diagramme. Bewusst getrennt von <see cref="AppColors"/>: Dort stehen
    /// die fünf Bedeutungsfarben der Anwendung, hier eine daraus abgeleitete Abstufung
    /// derselben Lila-Familie, die auch für mehrreihige Diagramme (z. B. Abteilungen,
    /// Nationalitäten) ausreicht.
    /// </summary>
    public static class ChartPalette
    {
        private static readonly Color[] Series =
        {
            Color.FromArgb(0x5C, 0x2D, 0x91), // Primary
            Color.FromArgb(0x8A, 0x4F, 0xB8), // Accent
            Color.FromArgb(0xB0, 0x84, 0xD4), // helles Lila
            Color.FromArgb(0x6E, 0x5A, 0xC8), // Blaulila
            Color.FromArgb(0xC9, 0xA7, 0xE8), // Flieder
            Color.FromArgb(0x3D, 0x1C, 0x63), // sehr dunkles Lila
            Color.FromArgb(0xD9, 0x7B, 0xC4), // Magenta-Akzent
            Color.FromArgb(0x9B, 0xB0, 0xE0), // gedämpftes Blau als Kontrast
        };

        /// <summary>Feste Farbe der Mitarbeitenden in allen Diagrammen und Kacheln.</summary>
        public static Color Employees => Series[0];

        /// <summary>Feste Farbe der Kundschaft in allen Diagrammen und Kacheln.</summary>
        public static Color Customers => Series[1];

        /// <summary>Feste Farbe der Lernenden in allen Diagrammen und Kacheln.</summary>
        public static Color Apprentices => Series[3];

        /// <summary>Neutrale Farbe für „nicht erfasst"-Anteile.</summary>
        public static Color Unknown => Color.FromArgb(0xBD, 0xB5, 0xC8);

        /// <summary>
        /// Liefert die Reihenfarbe an der angegebenen Position. Der Index läuft zyklisch
        /// um, damit auch eine Auswertung mit mehr Einträgen als Farben nie ohne Farbe
        /// dasteht.
        /// </summary>
        /// <param name="index">Die Position innerhalb der Datenreihe (ab 0).</param>
        /// <returns>Die zugehörige Farbe.</returns>
        public static Color ColorAt(int index) => Series[Math.Abs(index) % Series.Length];
    }
}
