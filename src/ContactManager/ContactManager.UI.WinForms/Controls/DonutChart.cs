using System;
using System.Drawing;
using System.Windows.Forms;

namespace ContactManager.UI.WinForms.Controls
{
    /// <summary>
    /// Ringdiagramm (Donut) mit Legende: zeigt den prozentualen Anteil jedes
    /// Datenpunkts als Kreissegment und listet rechts daneben Farbe, Beschriftung,
    /// Anzahl und Prozentsatz auf.
    /// </summary>
    public class DonutChart : ChartControlBase
    {
        /// <summary>Text in der Mitte des Rings, üblicherweise die Gesamtzahl.</summary>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string CenterCaption { get; set; } = string.Empty;

        /// <summary>Ob rechts neben dem Ring eine Legende gezeichnet wird.</summary>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public bool ShowLegend { get; set; } = true;

        /// <inheritdoc />
        protected override void DrawChart(Graphics graphics)
        {
            int padding = LogicalToDeviceUnits(12);
            int legendWidth = ShowLegend ? (int)(Width * 0.42) : 0;

            Rectangle ringArea = new Rectangle(padding, padding, Width - legendWidth - 2 * padding, Height - 2 * padding);
            int diameter = Math.Min(ringArea.Width, ringArea.Height);
            Rectangle bounds = new Rectangle(
                ringArea.X + (ringArea.Width - diameter) / 2,
                ringArea.Y + (ringArea.Height - diameter) / 2,
                diameter,
                diameter);

            int total = 0;
            for (int i = 0; i < Slices.Count; i++)
                total += Slices[i].Value;

            // Segmente ab 12 Uhr (-90°) im Uhrzeigersinn zeichnen.
            float startAngle = -90f;
            for (int i = 0; i < Slices.Count; i++)
            {
                if (Slices[i].Value == 0)
                    continue;

                float sweep = 360f * Slices[i].Value / total;

                using Brush brush = new SolidBrush(ColorOf(i));
                graphics.FillPie(brush, bounds, startAngle, sweep);

                startAngle += sweep;
            }

            // Loch in die Mitte -> aus der Kreisfläche wird ein Ring.
            int holeInset = diameter / 4;
            Rectangle hole = Rectangle.Inflate(bounds, -holeInset, -holeInset);
            using (Brush holeBrush = new SolidBrush(BackColor))
            {
                graphics.FillEllipse(holeBrush, hole);
            }

            if (!string.IsNullOrEmpty(CenterCaption))
            {
                using Font centerFont = new Font(Font.FontFamily, Font.Size * 1.3f, FontStyle.Bold);
                TextRenderer.DrawText(
                    graphics,
                    CenterCaption,
                    centerFont,
                    hole,
                    ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

            if (ShowLegend)
                DrawLegend(graphics, bounds, legendWidth, padding, total);
        }

        // Zentriert den Legendenblock vertikal auf die Mitte des Rings, statt ihn oben
        // anzuheften - sonst wirkt die Komposition unzentriert, sobald der Ring (z. B. in
        // einer hohen, schmalen Kachel) deutlich weniger Höhe braucht als der Ring-Bereich.
        private void DrawLegend(Graphics graphics, Rectangle ringBounds, int legendWidth, int padding, int total)
        {
            int legendX = Width - legendWidth + padding;
            int swatchSize = LogicalToDeviceUnits(12);
            int rowHeight = LogicalToDeviceUnits(22);
            int contentHeight = Slices.Count * rowHeight;
            int y = Math.Max(padding, ringBounds.Y + (ringBounds.Height - contentHeight) / 2);

            for (int i = 0; i < Slices.Count; i++)
            {
                using Brush swatchBrush = new SolidBrush(ColorOf(i));
                graphics.FillRectangle(swatchBrush, legendX, y + 2, swatchSize, swatchSize);

                double percentage = total == 0 ? 0 : 100.0 * Slices[i].Value / total;
                string text = $"{Slices[i].Label}  {Slices[i].Value} ({percentage:0.0} %)";

                Rectangle textArea = new Rectangle(
                    legendX + swatchSize + LogicalToDeviceUnits(6),
                    y,
                    legendWidth - swatchSize - LogicalToDeviceUnits(6) - padding,
                    rowHeight);

                TextRenderer.DrawText(graphics, text, Font, textArea, ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

                y += rowHeight;
            }
        }
    }
}
