using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ContactManager.Business;
using ContactManager.Business.Statistics;
using ContactManager.UI.WinForms.Base;
using ContactManager.UI.WinForms.Controls;

namespace ContactManager.UI.WinForms.Forms
{
    /// <summary>
    /// Zeigt eine Übersicht über den gesamten Datenstamm: Mengenverhältnis von
    /// Mitarbeitenden, Lernenden und Kundschaft, getrennte Kennzahlen je Gruppe sowie
    /// weiterführende Auswertungen zu Personal, Zeitverlauf und Datenqualität. Rein
    /// lesend — es lassen sich von hier aus keine Daten ändern.
    /// </summary>
    public partial class DashboardForm : BaseForm
    {
        // Zugang zur Business-Schicht. Wird von MainForm durchgereicht, damit alle
        // Fenster auf demselben, einmalig geladenen Datenstamm arbeiten.
        private readonly ContactManagerFacade _contacts;

        /// <summary>
        /// Erzeugt das Dashboard.
        /// </summary>
        /// <param name="contacts">Die Fassade der Business-Schicht, über die alle Daten laufen.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="contacts"/> <c>null</c> ist.</exception>
        public DashboardForm(ContactManagerFacade contacts)
        {
            ArgumentNullException.ThrowIfNull(contacts);

            InitializeComponent();
            _contacts = contacts;

            // Bewusst hier statt im Designer verdrahtet: Der Designer gehört den
            // Kolleg*innen, jede Änderung daran erzeugt unnötige Merge-Konflikte.
            BtnReturnToHome.Click += BtnReturnToHome_Click;
            TabDashboard.DrawItem += TabDashboard_DrawItem;
        }

        /// <summary>
        /// Berechnet die Kennzahlen und füllt alle Kacheln und Diagramme. Bewusst hier
        /// statt im Konstruktor: Zu diesem Zeitpunkt sind alle Controls erzeugt, und ein
        /// Fehler beim Laden träfe ein bereits sichtbares Fenster statt eines halb
        /// aufgebauten.
        /// </summary>
        /// <param name="e">Die Ereignisdaten des Load-Ereignisses.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ConfigureTabHeaders();
            LoadStatistics();
        }

        // Legt die Grösse der Reiter-Köpfe fest. Bewusst hier und nicht im Designer:
        // Das Umschalten von SizeMode verwirft eine zuvor gesetzte ItemSize wieder, und
        // die automatische Skalierung des Formulars (AutoScaleMode.Font) läuft erst beim
        // Laden - vorher gesetzte Werte würden ein zweites Mal skaliert.
        private void ConfigureTabHeaders()
        {
            // Nach der Breite des längsten Titels bemessen, damit kein Reiter abgeschnitten
            // wird. Gemessen wird fett, weil der ausgewählte Reiter fett gezeichnet wird.
            using Font boldFont = new Font(TabDashboard.Font, FontStyle.Bold);

            Size longest = Size.Empty;
            foreach (TabPage page in TabDashboard.TabPages)
            {
                Size caption = TextRenderer.MeasureText(page.Text, boldFont);
                longest = new Size(
                    Math.Max(longest.Width, caption.Width),
                    Math.Max(longest.Height, caption.Height));
            }

            TabDashboard.SizeMode = TabSizeMode.Fixed;
            TabDashboard.ItemSize = new Size(longest.Width + 40, longest.Height + 20);
        }

        /// <summary>
        /// Baut die gesamte Anzeige aus einer frischen Momentaufnahme der Kennzahlen neu
        /// auf. Einzige Stelle, die die Business-Schicht befragt - danach nur noch reines
        /// Übertragen in die Controls.
        /// </summary>
        private void LoadStatistics()
        {
            DashboardStatistics statistics = _contacts.Statistics.GetSnapshot();

            ShowOverviewTiles(statistics);
            ShowMixChart(statistics.Mix);
            ShowEmployeeSummary(statistics.Employees, statistics.Apprentices.Total);
            ShowCustomerSummary(statistics.Customers);

            ShowEmployeeTiles(statistics);
            ShowDepartmentChart(statistics.Compact);
            ShowStaffCharts(statistics.Staff);
            ShowHiresChart(statistics.Timeline);

            ShowQualityTiles(statistics);
            ShowNotesChart(statistics.Timeline);
            ShowGenderChart(statistics.Compact);
            ShowLocationCharts(statistics.Quality);
        }

        private void ShowOverviewTiles(DashboardStatistics statistics)
        {
            TleTotalContacts.Value = statistics.Mix.TotalCount.ToString();
            TleEmployees.Value = statistics.Employees.Total.ToString();
            TleApprentices.Value = statistics.Apprentices.Total.ToString();
            TleCustomers.Value = statistics.Customers.Total.ToString();
            TleAverageAge.Value = FormatYears(statistics.Compact.AverageAge);
            TleNoteCount.Value = statistics.Compact.NoteCount.ToString();
        }

        private void ShowMixChart(ContactMixStatistics mix)
        {
            ChtContactShare.CenterCaption = mix.TotalCount.ToString();
            ChtContactShare.SetData(new[]
            {
                new ChartSlice("Mitarbeitende", mix.EmployeeCount, ChartPalette.Employees),
                new ChartSlice("Lernende", mix.ApprenticeCount, ChartPalette.Apprentices),
                new ChartSlice("Kundschaft", mix.CustomerCount, ChartPalette.Customers)
            });
        }

        private void ShowEmployeeSummary(GroupStatistics employees, int apprenticeCount)
        {
            LblEmployeeSummaryTotalValue.Text = employees.Total.ToString();
            LblEmployeeSummaryActiveValue.Text = employees.ActiveCount.ToString();
            LblEmployeeSummaryPassiveValue.Text = employees.PassiveCount.ToString();
            LblEmployeeSummaryApprenticesValue.Text = apprenticeCount.ToString();
        }

        private void ShowCustomerSummary(GroupStatistics customers)
        {
            LblCustomerSummaryTotalValue.Text = customers.Total.ToString();
            LblCustomerSummaryActiveValue.Text = customers.ActiveCount.ToString();
            LblCustomerSummaryPassiveValue.Text = customers.PassiveCount.ToString();
        }

        private void ShowEmployeeTiles(DashboardStatistics statistics)
        {
            TleAverageEmploymentLevel.Value = statistics.Compact.AverageEmploymentLevel is double level
                ? level.ToString("0.0") + " %"
                : "–";
            TlePartTimeCount.Value = statistics.Staff.PartTimeCount.ToString();
            TleLeftCount.Value = statistics.Staff.LeftCount.ToString();
            TleAverageTenure.Value = FormatYears(statistics.Timeline.AverageTenureYears);
        }

        private void ShowDepartmentChart(CompactStatistics compact)
        {
            ChtDepartments.SetData(ToSlices(compact.EmployeesPerDepartment, l => l.Label, l => l.Count));
        }

        private void ShowStaffCharts(StaffStatistics staff)
        {
            ChtManagementLevels.SetData(ToSlices(staff.ManagementLevels, FormatManagementLevel, v => v.Count));
            ChtApprenticeYears.SetData(ToSlices(staff.ApprenticesPerYear, FormatApprenticeshipYear, v => v.Count));
            ChtNationalities.SetData(ToSlices(staff.TopNationalities, l => l.Label, l => l.Count));
        }

        private void ShowHiresChart(TimelineStatistics timeline)
        {
            ChtHiresPerYear.SetData(timeline.HiresPerYear.Select(y => new ChartSlice(y.Year.ToString(), y.Count)));
        }

        private void ShowQualityTiles(DashboardStatistics statistics)
        {
            TleWithoutEmail.Value = statistics.Quality.WithoutEmail.ToString();
            TleWithoutPhone.Value = statistics.Quality.WithoutPhone.ToString();
            TleWithoutAddress.Value = statistics.Quality.WithoutAddress.ToString();
            TleCustomersWithoutNote.Value = statistics.Quality.CustomersWithoutNote.ToString();
            TleBirthdaysThisMonth.Value = statistics.Timeline.BirthdaysThisMonth.ToString();
        }

        private void ShowNotesChart(TimelineStatistics timeline)
        {
            ChtNotesPerMonth.SetData(timeline.NotesPerMonth.Select(m => new ChartSlice(FormatMonth(m), m.Count)));
        }

        private void ShowGenderChart(CompactStatistics compact)
        {
            List<ChartSlice> slices = compact.GenderDistribution
                .Select((g, index) => new ChartSlice(
                    g.Gender is null ? "Nicht erfasst" : EnumDisplay.ToText(g.Gender.Value),
                    g.Count,
                    g.Gender is null ? ChartPalette.Unknown : ChartPalette.ColorAt(index)))
                .ToList();

            ChtGenderShare.CenterCaption = slices.Sum(s => s.Value).ToString();
            ChtGenderShare.SetData(slices);
        }

        private void ShowLocationCharts(DataQualityStatistics quality)
        {
            ChtTopCities.SetData(ToSlices(quality.TopCustomerCities, l => l.Label, l => l.Count));
            ChtTopPostalCodes.SetData(ToSlices(quality.TopCustomerPostalCodes, l => l.Label, l => l.Count));
        }

        // Übersetzt eine Liste von Auswertungswerten in Diagramm-Datenpunkte. Bündelt die
        // sonst überall wiederkehrende Select(...)-Zeile an einer Stelle.
        private static IEnumerable<ChartSlice> ToSlices<T>(
            IEnumerable<T> values, Func<T, string> label, Func<T, int> value) =>
            values.Select(v => new ChartSlice(label(v), value(v)));

        private static string FormatManagementLevel(ValueCount value) =>
            value.Value is int level ? $"Stufe {level}" : "Nicht erfasst";

        private static string FormatApprenticeshipYear(ValueCount value) =>
            value.Value is int year ? $"{year}. Lehrjahr" : "Nicht erfasst";

        private static string FormatMonth(MonthCount month) =>
            new DateOnly(month.Year, month.Month, 1).ToString("MM.yy");

        private static string FormatYears(double? years) =>
            years is double value ? value.ToString("0.0") : "–";

        // Schliesst dieses Fenster; MainForm erscheint automatisch wieder (FormClosed-Event)
        private void BtnReturnToHome_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        // Malt die Reiter-Köpfe selbst (TabDrawMode.OwnerDrawFixed im Designer gesetzt),
        // damit der ausgewählte Reiter farblich hervorsticht - native TabControls lassen
        // sich sonst nicht einfärben.
        private void TabDashboard_DrawItem(object? sender, DrawItemEventArgs e)
        {
            TabPage page = TabDashboard.TabPages[e.Index];
            bool isSelected = e.State.HasFlag(DrawItemState.Selected);

            Color background = isSelected ? AppColors.Primary : Color.FromArgb(0xE0, 0xD4, 0xF0);
            Color foreground = isSelected ? AppColors.TextOnPrimary : AppColors.TextDark;

            using (SolidBrush backBrush = new SolidBrush(background))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            // Die fette Schrift des ausgewählten Reiters wird eigens erzeugt und wieder
            // freigegeben. Die Schrift des TabControls darf dabei nie in ein using
            // geraten - sie gehört dem Control und wird sonst mitten im Zeichnen
            // freigegeben, was die Anwendung beim nächsten Zugriff hart beendet.
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

            if (isSelected)
            {
                using Font boldFont = new Font(TabDashboard.Font, FontStyle.Bold);
                TextRenderer.DrawText(e.Graphics, page.Text, boldFont, e.Bounds, foreground, flags);
            }
            else
            {
                TextRenderer.DrawText(e.Graphics, page.Text, TabDashboard.Font, e.Bounds, foreground, flags);
            }
        }
    }
}
