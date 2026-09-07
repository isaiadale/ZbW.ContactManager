using System;
using System.Drawing;
using System.Windows.Forms;

namespace ContactManager.UI.WinForms.Controls
{
    /// <summary>
    /// Balkendiagramm ohne Achsengerüst: ein Balken pro Datenpunkt, skaliert auf den
    /// grössten vorkommenden Wert. Unterstützt waagrechte Balken (für lange
    /// Beschriftungen wie Abteilungen oder Nationalitäten) und senkrechte Balken
    /// (für kurze, gleich lange Beschriftungen wie Monate).
    /// </summary>
    public class BarChart : ChartControlBase
    {
        /// <summary>
        /// Ob die Balken waagrecht statt senkrecht gezeichnet werden. Waagrecht eignet
        /// sich für lange Textbeschriftungen, die unter senkrechten Balken überlappen
        /// würden.
        /// </summary>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public bool Horizontal { get; set; }

        /// <summary>Titel über der Zeichenfläche; ein leerer Text blendet ihn aus.</summary>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string Title { get; set; } = string.Empty;

        /// <inheritdoc />
        protected override void DrawChart(Graphics graphics)
        {
            int padding = LogicalToDeviceUnits(8);
            int titleHeight = string.IsNullOrEmpty(Title) ? 0 : LogicalToDeviceUnits(20);

            Rectangle plotArea = new Rectangle(
                padding,
                padding + titleHeight,
                Width - 2 * padding,
                Height - 2 * padding - titleHeight);

            if (!string.IsNullOrEmpty(Title))
            {
                using Font titleFont = new Font(Font, FontStyle.Bold);
                TextRenderer.DrawText(
                    graphics,
                    Title,
                    titleFont,
                    new Rectangle(padding, padding, Width - 2 * padding, titleHeight),
                    ForeColor,
                    TextFormatFlags.Left);
            }

            int max = 0;
            for (int i = 0; i < Slices.Count; i++)
                max = Math.Max(max, Slices[i].Value);

            if (max == 0 || plotArea.Width <= 0 || plotArea.Height <= 0)
                return;

            if (Horizontal)
                DrawHorizontal(graphics, plotArea, max);
            else
                DrawVertical(graphics, plotArea, max);
        }

        private void DrawHorizontal(Graphics graphics, Rectangle plotArea, int max)
        {
            int count = Slices.Count;
            float rowHeight = plotArea.Height / (float)count;
            float barHeight = rowHeight * 0.6f;
            int labelWidth = (int)(plotArea.Width * 0.35f);
            int valueWidth = LogicalToDeviceUnits(36);
            int barAreaWidth = Math.Max(0, plotArea.Width - labelWidth - valueWidth);

            for (int i = 0; i < count; i++)
            {
                float rowTop = plotArea.Top + i * rowHeight;
                float barTop = rowTop + (rowHeight - barHeight) / 2f;

                Rectangle labelArea = new Rectangle(plotArea.Left, (int)rowTop, labelWidth, (int)rowHeight);
                TextRenderer.DrawText(
                    graphics, Slices[i].Label, Font, labelArea, ForeColor,
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

                float barLength = Slices[i].Value / (float)max * barAreaWidth;
                RectangleF barRect = new RectangleF(plotArea.Left + labelWidth + LogicalToDeviceUnits(4), barTop, barLength, barHeight);

                using Brush brush = new SolidBrush(ColorOf(i));
                graphics.FillRectangle(brush, barRect);

                Rectangle valueArea = new Rectangle(
                    plotArea.Left + labelWidth + LogicalToDeviceUnits(4) + (int)barLength + LogicalToDeviceUnits(4),
                    (int)rowTop, valueWidth, (int)rowHeight);
                TextRenderer.DrawText(
                    graphics, Slices[i].Value.ToString(), Font, valueArea, ForeColor,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }

        private void DrawVertical(Graphics graphics, Rectangle plotArea, int max)
        {
            int count = Slices.Count;
            float columnWidth = plotArea.Width / (float)count;
            float barWidth = columnWidth * 0.6f;
            int labelHeight = LogicalToDeviceUnits(16);
            int valueHeight = LogicalToDeviceUnits(16);
            int barAreaHeight = Math.Max(0, plotArea.Height - labelHeight - valueHeight);

            for (int i = 0; i < count; i++)
            {
                float columnLeft = plotArea.Left + i * columnWidth;
                float barLeft = columnLeft + (columnWidth - barWidth) / 2f;

                float barLength = Slices[i].Value / (float)max * barAreaHeight;
                float barTop = plotArea.Top + valueHeight + (barAreaHeight - barLength);

                RectangleF barRect = new RectangleF(barLeft, barTop, barWidth, barLength);

                using Brush brush = new SolidBrush(ColorOf(i));
                graphics.FillRectangle(brush, barRect);

                Rectangle valueArea = new Rectangle((int)columnLeft, plotArea.Top, (int)columnWidth, valueHeight);
                TextRenderer.DrawText(
                    graphics, Slices[i].Value.ToString(), Font, valueArea, ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.Top);

                Rectangle labelArea = new Rectangle((int)columnLeft, plotArea.Bottom - labelHeight, (int)columnWidth, labelHeight);
                TextRenderer.DrawText(
                    graphics, Slices[i].Label, Font, labelArea, ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.Bottom | TextFormatFlags.EndEllipsis);
            }
        }
    }
}
