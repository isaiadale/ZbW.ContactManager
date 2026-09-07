using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ContactManager.UI.WinForms.Base;

namespace ContactManager.UI.WinForms.Controls
{
    /// <summary>
    /// Gerundete, farbige Kennzahlen-Kachel für das Dashboard: eine grosse Zahl mit
    /// kleiner Beschriftung darüber, wie im Vorbild-Screenshot des CRM-Dashboards.
    /// </summary>
    public class KpiTile : Control
    {
        // Untergrenze, bis zu der die Beschriftung verkleinert wird, damit sie in die
        // Kachel passt. Darunter wäre sie nicht mehr lesbar.
        private const float MinimumCaptionSize = 6.5f;

        private string _caption = string.Empty;
        private string _value = string.Empty;
        private Color _tileColor = AppColors.Primary;

        /// <summary>
        /// Richtet flackerfreies Zeichnen ein und setzt die Standardfarben.
        /// </summary>
        public KpiTile()
        {
            SetStyle(
                ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw,
                true);

            ForeColor = AppColors.TextOnPrimary;
        }

        /// <summary>Die kleine Beschriftung über der Zahl (z. B. „Mitarbeitende").</summary>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string Caption
        {
            get => _caption;
            set { _caption = value ?? string.Empty; Invalidate(); }
        }

        /// <summary>Die gross dargestellte Kennzahl (bereits als Text formatiert).</summary>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string Value
        {
            get => _value;
            set { _value = value ?? string.Empty; Invalidate(); }
        }

        /// <summary>Die Hintergrundfarbe der Kachel.</summary>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public Color TileColor
        {
            get => _tileColor;
            set { _tileColor = value; Invalidate(); }
        }

        /// <inheritdoc />
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Der Hintergrund des Elternteils blitzt an den abgerundeten Ecken durch,
            // da GraphicsPath (im Unterschied zu Region) auch die Kante weich zeichnet.
            using (SolidBrush parentBrush = new SolidBrush(Parent?.BackColor ?? AppColors.Background))
            {
                graphics.FillRectangle(parentBrush, ClientRectangle);
            }

            int radius = LogicalToDeviceUnits(14);
            Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = RoundedRectangle(bounds, radius))
            using (SolidBrush tileBrush = new SolidBrush(_tileColor))
            {
                graphics.FillPath(tileBrush, path);
            }

            int padding = LogicalToDeviceUnits(14);
            Rectangle captionArea = new Rectangle(padding, padding, Width - 2 * padding, LogicalToDeviceUnits(34));
            DrawCaption(graphics, captionArea);

            using Font valueFont = new Font(Font.FontFamily, Font.Size * 2.1f, FontStyle.Bold);
            Rectangle valueArea = new Rectangle(padding, captionArea.Bottom, Width - 2 * padding, Height - captionArea.Bottom - padding);
            TextRenderer.DrawText(
                graphics, _value, valueFont, valueArea, ForeColor,
                TextFormatFlags.Left | TextFormatFlags.Bottom | TextFormatFlags.EndEllipsis);
        }

        // Ein langes Einzelwort ("Beschäftigungsgrad") lässt sich nicht umbrechen und würde
        // deshalb unabhängig von der Zeilenzahl mit "..." abgeschnitten. Statt zu kürzen
        // wird die Beschriftung so weit verkleinert, bis sie in die Kachel passt.
        private void DrawCaption(Graphics graphics, Rectangle area)
        {
            const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordBreak;

            for (float size = Font.Size; size >= MinimumCaptionSize; size -= 0.5f)
            {
                using Font candidate = new Font(Font.FontFamily, size, Font.Style);
                Size required = TextRenderer.MeasureText(graphics, _caption, candidate, area.Size, flags);

                if (required.Width <= area.Width && required.Height <= area.Height)
                {
                    TextRenderer.DrawText(graphics, _caption, candidate, area, ForeColor, flags);
                    return;
                }
            }

            // Selbst in der kleinsten Stufe zu lang: dann doch kürzen, statt zu überlaufen.
            using Font smallestFont = new Font(Font.FontFamily, MinimumCaptionSize, Font.Style);
            TextRenderer.DrawText(
                graphics, _caption, smallestFont, area, ForeColor, flags | TextFormatFlags.EndEllipsis);
        }

        private static GraphicsPath RoundedRectangle(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
