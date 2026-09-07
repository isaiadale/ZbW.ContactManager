using System;
using System.Drawing;

namespace ContactManager.UI.WinForms.Controls
{
    /// <summary>
    /// Ein einzelner Datenpunkt für <see cref="DonutChart"/> und <see cref="BarChart"/>:
    /// eine bereits übersetzte Beschriftung, ein Wert und optional eine feste Farbe.
    /// Kennt weder die Business-Schicht noch ein bestimmtes Formular.
    /// </summary>
    public sealed class ChartSlice
    {
        /// <summary>
        /// Erzeugt einen Datenpunkt.
        /// </summary>
        /// <param name="label">Die anzuzeigende Beschriftung (bereits deutsch).</param>
        /// <param name="value">Der darzustellende Wert. Negative Werte werden von den Diagrammen verworfen.</param>
        /// <param name="color">
        /// Eine feste Farbe für diesen Datenpunkt, oder <c>Color.Empty</c>, damit das
        /// Diagramm die Farbe selbst aus <see cref="Base.ChartPalette"/> vergibt.
        /// </param>
        public ChartSlice(string label, int value, Color color = default)
        {
            ArgumentNullException.ThrowIfNull(label);

            Label = label;
            Value = value;
            Color = color;
        }

        /// <summary>Die anzuzeigende Beschriftung.</summary>
        public string Label { get; }

        /// <summary>Der darzustellende Wert.</summary>
        public int Value { get; }

        /// <summary>Die feste Farbe dieses Datenpunkts, oder <c>Color.Empty</c> für eine automatisch vergebene.</summary>
        public Color Color { get; }
    }
}
