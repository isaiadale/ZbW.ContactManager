using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using ContactManager.UI.WinForms.Base;

namespace ContactManager.UI.WinForms.Controls
{
    /// <summary>
    /// Gemeinsame Basis von <see cref="DonutChart"/> und <see cref="BarChart"/>: hält die
    /// Datenpunkte, sorgt für flackerfreies Zeichnen und zeigt einen Leerzustand, wenn
    /// keine oder ausschliesslich Nullwerte vorliegen. Die eigentliche Zeichnung eines
    /// konkreten Diagrammtyps übernimmt <see cref="DrawChart"/> in der abgeleiteten Klasse.
    /// </summary>
    public abstract class ChartControlBase : Control
    {
        private IReadOnlyList<ChartSlice> _slices = Array.Empty<ChartSlice>();

        /// <summary>
        /// Richtet flackerfreies, DPI-sauberes Zeichnen ein.
        /// </summary>
        protected ChartControlBase()
        {
            // Der Rahmen malt vollständig selbst und puffert in einen Zwischenspeicher,
            // statt direkt auf den Bildschirm zu zeichnen - ohne das würde das Diagramm
            // bei jeder Grössenänderung sichtbar flackern.
            SetStyle(
                ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw,
                true);

            BackColor = AppColors.Background;
            ForeColor = AppColors.TextDark;
        }

        /// <summary>Die aktuell dargestellten Datenpunkte; nie <c>null</c>, ggf. leer.</summary>
        protected IReadOnlyList<ChartSlice> Slices => _slices;

        /// <summary>Text, der anstelle des Diagramms erscheint, wenn keine Daten vorliegen.</summary>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string EmptyText { get; set; } = "Keine Daten vorhanden";

        /// <summary>
        /// Übergibt die darzustellenden Werte und zeichnet das Diagramm neu.
        /// </summary>
        /// <param name="slices">Die Datenpunkte. Einträge mit negativem Wert werden verworfen.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="slices"/> <c>null</c> ist.</exception>
        public void SetData(IEnumerable<ChartSlice> slices)
        {
            ArgumentNullException.ThrowIfNull(slices);

            _slices = slices.Where(s => s.Value >= 0).ToList();
            Invalidate();
        }

        /// <summary>
        /// Liefert die Farbe eines Datenpunkts: die am Datenpunkt gesetzte Farbe, oder,
        /// falls keine gesetzt ist, die nächste Farbe aus <see cref="ChartPalette"/>.
        /// </summary>
        /// <param name="index">Die Position des Datenpunkts innerhalb von <see cref="Slices"/>.</param>
        protected Color ColorOf(int index)
        {
            Color fixedColor = Slices[index].Color;
            return fixedColor.IsEmpty ? ChartPalette.ColorAt(index) : fixedColor;
        }

        /// <inheritdoc />
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Zu kleine Zeichenfläche (z. B. während des Layouts eines TableLayoutPanel):
            // gar nicht erst versuchen zu zeichnen, sonst drohen negative Radien/Breiten.
            if (Width < 20 || Height < 20)
                return;

            if (_slices.Count == 0 || _slices.Sum(s => s.Value) == 0)
            {
                DrawEmptyState(e.Graphics);
                return;
            }

            DrawChart(e.Graphics);
        }

        /// <summary>
        /// Zeichnet das eigentliche Diagramm anhand von <see cref="Slices"/>. Wird nur
        /// aufgerufen, wenn mindestens ein Datenpunkt mit positivem Wert vorliegt.
        /// </summary>
        /// <param name="graphics">Die vorbereitete Zeichenfläche.</param>
        protected abstract void DrawChart(Graphics graphics);

        private void DrawEmptyState(Graphics graphics) =>
            TextRenderer.DrawText(
                graphics,
                EmptyText,
                Font,
                ClientRectangle,
                Color.Gray,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
    }
}
