using ContactManager.UI.WinForms.Controls;

namespace ContactManager.UI.WinForms.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PnlHeader = new Panel();
            BtnReturnToHome = new Button();
            LblDashboardTitle = new Label();
            TabDashboard = new TabControl();
            TabOverview = new TabPage();
            TlpOverviewBody = new TableLayoutPanel();
            TlpOverviewSummaries = new TableLayoutPanel();
            GrpEmployeeSummary = new GroupBox();
            LblEmployeeSummaryApprenticesValue = new Label();
            LblEmployeeSummaryApprenticesCaption = new Label();
            LblEmployeeSummaryPassiveValue = new Label();
            LblEmployeeSummaryPassiveCaption = new Label();
            LblEmployeeSummaryActiveValue = new Label();
            LblEmployeeSummaryActiveCaption = new Label();
            LblEmployeeSummaryTotalValue = new Label();
            LblEmployeeSummaryTotalCaption = new Label();
            GrpCustomerSummary = new GroupBox();
            LblCustomerSummaryPassiveValue = new Label();
            LblCustomerSummaryPassiveCaption = new Label();
            LblCustomerSummaryActiveValue = new Label();
            LblCustomerSummaryActiveCaption = new Label();
            LblCustomerSummaryTotalValue = new Label();
            LblCustomerSummaryTotalCaption = new Label();
            ChtContactShare = new DonutChart();
            FlpOverviewTiles = new FlowLayoutPanel();
            TleTotalContacts = new KpiTile();
            TleEmployees = new KpiTile();
            TleApprentices = new KpiTile();
            TleCustomers = new KpiTile();
            TleAverageAge = new KpiTile();
            TleNoteCount = new KpiTile();
            TabEmployees = new TabPage();
            TlpEmployeeCharts = new TableLayoutPanel();
            ChtDepartments = new BarChart();
            ChtNationalities = new BarChart();
            ChtManagementLevels = new BarChart();
            ChtApprenticeYears = new BarChart();
            ChtHiresPerYear = new BarChart();
            FlpEmployeeTiles = new FlowLayoutPanel();
            TleAverageEmploymentLevel = new KpiTile();
            TlePartTimeCount = new KpiTile();
            TleLeftCount = new KpiTile();
            TleAverageTenure = new KpiTile();
            TabQuality = new TabPage();
            TlpQualityCharts = new TableLayoutPanel();
            ChtNotesPerMonth = new BarChart();
            ChtGenderShare = new DonutChart();
            ChtTopCities = new BarChart();
            ChtTopPostalCodes = new BarChart();
            FlpQualityTiles = new FlowLayoutPanel();
            TleWithoutEmail = new KpiTile();
            TleWithoutPhone = new KpiTile();
            TleWithoutAddress = new KpiTile();
            TleCustomersWithoutNote = new KpiTile();
            TleBirthdaysThisMonth = new KpiTile();
            PnlHeader.SuspendLayout();
            TabDashboard.SuspendLayout();
            TabOverview.SuspendLayout();
            TlpOverviewBody.SuspendLayout();
            TlpOverviewSummaries.SuspendLayout();
            GrpEmployeeSummary.SuspendLayout();
            GrpCustomerSummary.SuspendLayout();
            FlpOverviewTiles.SuspendLayout();
            TabEmployees.SuspendLayout();
            TlpEmployeeCharts.SuspendLayout();
            FlpEmployeeTiles.SuspendLayout();
            TabQuality.SuspendLayout();
            TlpQualityCharts.SuspendLayout();
            FlpQualityTiles.SuspendLayout();
            SuspendLayout();
            //
            // PnlHeader
            //
            PnlHeader.Controls.Add(BtnReturnToHome);
            PnlHeader.Controls.Add(LblDashboardTitle);
            PnlHeader.Dock = DockStyle.Top;
            PnlHeader.Location = new Point(0, 0);
            PnlHeader.Name = "PnlHeader";
            PnlHeader.Size = new Size(1180, 56);
            PnlHeader.TabIndex = 0;
            //
            // BtnReturnToHome
            //
            BtnReturnToHome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnReturnToHome.Location = new Point(1016, 12);
            BtnReturnToHome.Name = "BtnReturnToHome";
            BtnReturnToHome.Size = new Size(140, 32);
            BtnReturnToHome.TabIndex = 1;
            BtnReturnToHome.Text = "Zurück";
            BtnReturnToHome.UseVisualStyleBackColor = true;
            //
            // LblDashboardTitle
            //
            LblDashboardTitle.Font = new Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblDashboardTitle.Location = new Point(24, 12);
            LblDashboardTitle.Name = "LblDashboardTitle";
            LblDashboardTitle.Size = new Size(400, 32);
            LblDashboardTitle.TabIndex = 0;
            LblDashboardTitle.Text = "Dashboard";
            LblDashboardTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // TabDashboard
            //
            TabDashboard.Controls.Add(TabOverview);
            TabDashboard.Controls.Add(TabEmployees);
            TabDashboard.Controls.Add(TabQuality);
            TabDashboard.Dock = DockStyle.Fill;
            TabDashboard.DrawMode = TabDrawMode.OwnerDrawFixed;
            TabDashboard.Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TabDashboard.Location = new Point(0, 56);
            TabDashboard.Name = "TabDashboard";
            TabDashboard.SelectedIndex = 0;
            TabDashboard.Size = new Size(1180, 704);
            TabDashboard.TabIndex = 1;
            //
            // TabOverview
            //
            TabOverview.Controls.Add(TlpOverviewBody);
            TabOverview.Controls.Add(FlpOverviewTiles);
            TabOverview.Location = new Point(4, 24);
            TabOverview.Name = "TabOverview";
            TabOverview.Padding = new Padding(12);
            TabOverview.Size = new Size(1172, 676);
            TabOverview.TabIndex = 0;
            TabOverview.Text = "Übersicht";
            TabOverview.UseVisualStyleBackColor = true;
            //
            // TlpOverviewBody
            //
            TlpOverviewBody.ColumnCount = 2;
            TlpOverviewBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            TlpOverviewBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            TlpOverviewBody.Controls.Add(TlpOverviewSummaries, 0, 0);
            TlpOverviewBody.Controls.Add(ChtContactShare, 1, 0);
            TlpOverviewBody.Dock = DockStyle.Fill;
            TlpOverviewBody.Location = new Point(12, 302);
            TlpOverviewBody.Name = "TlpOverviewBody";
            TlpOverviewBody.RowCount = 1;
            TlpOverviewBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TlpOverviewBody.Size = new Size(1148, 362);
            TlpOverviewBody.TabIndex = 1;
            //
            // TlpOverviewSummaries
            //
            TlpOverviewSummaries.ColumnCount = 1;
            TlpOverviewSummaries.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TlpOverviewSummaries.Controls.Add(GrpEmployeeSummary, 0, 0);
            TlpOverviewSummaries.Controls.Add(GrpCustomerSummary, 0, 1);
            TlpOverviewSummaries.Dock = DockStyle.Fill;
            TlpOverviewSummaries.Location = new Point(3, 3);
            TlpOverviewSummaries.Name = "TlpOverviewSummaries";
            TlpOverviewSummaries.Padding = new Padding(0, 0, 12, 0);
            TlpOverviewSummaries.RowCount = 2;
            TlpOverviewSummaries.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            TlpOverviewSummaries.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            TlpOverviewSummaries.Size = new Size(659, 536);
            TlpOverviewSummaries.TabIndex = 0;
            //
            // GrpEmployeeSummary
            //
            GrpEmployeeSummary.Controls.Add(LblEmployeeSummaryApprenticesValue);
            GrpEmployeeSummary.Controls.Add(LblEmployeeSummaryApprenticesCaption);
            GrpEmployeeSummary.Controls.Add(LblEmployeeSummaryPassiveValue);
            GrpEmployeeSummary.Controls.Add(LblEmployeeSummaryPassiveCaption);
            GrpEmployeeSummary.Controls.Add(LblEmployeeSummaryActiveValue);
            GrpEmployeeSummary.Controls.Add(LblEmployeeSummaryActiveCaption);
            GrpEmployeeSummary.Controls.Add(LblEmployeeSummaryTotalValue);
            GrpEmployeeSummary.Controls.Add(LblEmployeeSummaryTotalCaption);
            GrpEmployeeSummary.Dock = DockStyle.Fill;
            GrpEmployeeSummary.Location = new Point(3, 3);
            GrpEmployeeSummary.Name = "GrpEmployeeSummary";
            GrpEmployeeSummary.Size = new Size(641, 288);
            GrpEmployeeSummary.TabIndex = 0;
            GrpEmployeeSummary.TabStop = false;
            GrpEmployeeSummary.Text = "Mitarbeitende";
            //
            // LblEmployeeSummaryTotalCaption
            //
            LblEmployeeSummaryTotalCaption.Location = new Point(20, 32);
            LblEmployeeSummaryTotalCaption.Name = "LblEmployeeSummaryTotalCaption";
            LblEmployeeSummaryTotalCaption.Size = new Size(200, 24);
            LblEmployeeSummaryTotalCaption.TabIndex = 0;
            LblEmployeeSummaryTotalCaption.Text = "Total";
            //
            // LblEmployeeSummaryTotalValue
            //
            LblEmployeeSummaryTotalValue.Font = new Font("Century Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblEmployeeSummaryTotalValue.Location = new Point(380, 32);
            LblEmployeeSummaryTotalValue.Name = "LblEmployeeSummaryTotalValue";
            LblEmployeeSummaryTotalValue.Size = new Size(220, 24);
            LblEmployeeSummaryTotalValue.TabIndex = 1;
            LblEmployeeSummaryTotalValue.TextAlign = ContentAlignment.MiddleRight;
            //
            // LblEmployeeSummaryActiveCaption
            //
            LblEmployeeSummaryActiveCaption.Location = new Point(20, 76);
            LblEmployeeSummaryActiveCaption.Name = "LblEmployeeSummaryActiveCaption";
            LblEmployeeSummaryActiveCaption.Size = new Size(200, 24);
            LblEmployeeSummaryActiveCaption.TabIndex = 2;
            LblEmployeeSummaryActiveCaption.Text = "Aktiv";
            //
            // LblEmployeeSummaryActiveValue
            //
            LblEmployeeSummaryActiveValue.Font = new Font("Century Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblEmployeeSummaryActiveValue.Location = new Point(380, 76);
            LblEmployeeSummaryActiveValue.Name = "LblEmployeeSummaryActiveValue";
            LblEmployeeSummaryActiveValue.Size = new Size(220, 24);
            LblEmployeeSummaryActiveValue.TabIndex = 3;
            LblEmployeeSummaryActiveValue.TextAlign = ContentAlignment.MiddleRight;
            //
            // LblEmployeeSummaryPassiveCaption
            //
            LblEmployeeSummaryPassiveCaption.Location = new Point(20, 120);
            LblEmployeeSummaryPassiveCaption.Name = "LblEmployeeSummaryPassiveCaption";
            LblEmployeeSummaryPassiveCaption.Size = new Size(200, 24);
            LblEmployeeSummaryPassiveCaption.TabIndex = 4;
            LblEmployeeSummaryPassiveCaption.Text = "Passiv";
            //
            // LblEmployeeSummaryPassiveValue
            //
            LblEmployeeSummaryPassiveValue.Font = new Font("Century Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblEmployeeSummaryPassiveValue.Location = new Point(380, 120);
            LblEmployeeSummaryPassiveValue.Name = "LblEmployeeSummaryPassiveValue";
            LblEmployeeSummaryPassiveValue.Size = new Size(220, 24);
            LblEmployeeSummaryPassiveValue.TabIndex = 5;
            LblEmployeeSummaryPassiveValue.TextAlign = ContentAlignment.MiddleRight;
            //
            // LblEmployeeSummaryApprenticesCaption
            //
            LblEmployeeSummaryApprenticesCaption.Location = new Point(20, 164);
            LblEmployeeSummaryApprenticesCaption.Name = "LblEmployeeSummaryApprenticesCaption";
            LblEmployeeSummaryApprenticesCaption.Size = new Size(200, 24);
            LblEmployeeSummaryApprenticesCaption.TabIndex = 6;
            LblEmployeeSummaryApprenticesCaption.Text = "davon Lernende";
            //
            // LblEmployeeSummaryApprenticesValue
            //
            LblEmployeeSummaryApprenticesValue.Font = new Font("Century Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblEmployeeSummaryApprenticesValue.Location = new Point(380, 164);
            LblEmployeeSummaryApprenticesValue.Name = "LblEmployeeSummaryApprenticesValue";
            LblEmployeeSummaryApprenticesValue.Size = new Size(220, 24);
            LblEmployeeSummaryApprenticesValue.TabIndex = 7;
            LblEmployeeSummaryApprenticesValue.TextAlign = ContentAlignment.MiddleRight;
            //
            // GrpCustomerSummary
            //
            GrpCustomerSummary.Controls.Add(LblCustomerSummaryPassiveValue);
            GrpCustomerSummary.Controls.Add(LblCustomerSummaryPassiveCaption);
            GrpCustomerSummary.Controls.Add(LblCustomerSummaryActiveValue);
            GrpCustomerSummary.Controls.Add(LblCustomerSummaryActiveCaption);
            GrpCustomerSummary.Controls.Add(LblCustomerSummaryTotalValue);
            GrpCustomerSummary.Controls.Add(LblCustomerSummaryTotalCaption);
            GrpCustomerSummary.Dock = DockStyle.Fill;
            GrpCustomerSummary.Location = new Point(3, 297);
            GrpCustomerSummary.Name = "GrpCustomerSummary";
            GrpCustomerSummary.Size = new Size(641, 236);
            GrpCustomerSummary.TabIndex = 1;
            GrpCustomerSummary.TabStop = false;
            GrpCustomerSummary.Text = "Kundschaft";
            //
            // LblCustomerSummaryTotalCaption
            //
            LblCustomerSummaryTotalCaption.Location = new Point(20, 32);
            LblCustomerSummaryTotalCaption.Name = "LblCustomerSummaryTotalCaption";
            LblCustomerSummaryTotalCaption.Size = new Size(200, 24);
            LblCustomerSummaryTotalCaption.TabIndex = 0;
            LblCustomerSummaryTotalCaption.Text = "Total";
            //
            // LblCustomerSummaryTotalValue
            //
            LblCustomerSummaryTotalValue.Font = new Font("Century Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCustomerSummaryTotalValue.Location = new Point(380, 32);
            LblCustomerSummaryTotalValue.Name = "LblCustomerSummaryTotalValue";
            LblCustomerSummaryTotalValue.Size = new Size(220, 24);
            LblCustomerSummaryTotalValue.TabIndex = 1;
            LblCustomerSummaryTotalValue.TextAlign = ContentAlignment.MiddleRight;
            //
            // LblCustomerSummaryActiveCaption
            //
            LblCustomerSummaryActiveCaption.Location = new Point(20, 76);
            LblCustomerSummaryActiveCaption.Name = "LblCustomerSummaryActiveCaption";
            LblCustomerSummaryActiveCaption.Size = new Size(200, 24);
            LblCustomerSummaryActiveCaption.TabIndex = 2;
            LblCustomerSummaryActiveCaption.Text = "Aktiv";
            //
            // LblCustomerSummaryActiveValue
            //
            LblCustomerSummaryActiveValue.Font = new Font("Century Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCustomerSummaryActiveValue.Location = new Point(380, 76);
            LblCustomerSummaryActiveValue.Name = "LblCustomerSummaryActiveValue";
            LblCustomerSummaryActiveValue.Size = new Size(220, 24);
            LblCustomerSummaryActiveValue.TabIndex = 3;
            LblCustomerSummaryActiveValue.TextAlign = ContentAlignment.MiddleRight;
            //
            // LblCustomerSummaryPassiveCaption
            //
            LblCustomerSummaryPassiveCaption.Location = new Point(20, 120);
            LblCustomerSummaryPassiveCaption.Name = "LblCustomerSummaryPassiveCaption";
            LblCustomerSummaryPassiveCaption.Size = new Size(200, 24);
            LblCustomerSummaryPassiveCaption.TabIndex = 4;
            LblCustomerSummaryPassiveCaption.Text = "Passiv";
            //
            // LblCustomerSummaryPassiveValue
            //
            LblCustomerSummaryPassiveValue.Font = new Font("Century Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCustomerSummaryPassiveValue.Location = new Point(380, 120);
            LblCustomerSummaryPassiveValue.Name = "LblCustomerSummaryPassiveValue";
            LblCustomerSummaryPassiveValue.Size = new Size(220, 24);
            LblCustomerSummaryPassiveValue.TabIndex = 5;
            LblCustomerSummaryPassiveValue.TextAlign = ContentAlignment.MiddleRight;
            //
            // ChtContactShare
            //
            ChtContactShare.Dock = DockStyle.Fill;
            ChtContactShare.Location = new Point(668, 3);
            ChtContactShare.Name = "ChtContactShare";
            ChtContactShare.ShowLegend = true;
            ChtContactShare.Size = new Size(477, 536);
            ChtContactShare.TabIndex = 1;
            //
            // FlpOverviewTiles
            //
            FlpOverviewTiles.Controls.Add(TleTotalContacts);
            FlpOverviewTiles.Controls.Add(TleEmployees);
            FlpOverviewTiles.Controls.Add(TleApprentices);
            FlpOverviewTiles.Controls.Add(TleCustomers);
            FlpOverviewTiles.Controls.Add(TleAverageAge);
            FlpOverviewTiles.Controls.Add(TleNoteCount);
            FlpOverviewTiles.Dock = DockStyle.Top;
            FlpOverviewTiles.Location = new Point(12, 12);
            FlpOverviewTiles.Name = "FlpOverviewTiles";
            FlpOverviewTiles.Size = new Size(1148, 290);
            FlpOverviewTiles.TabIndex = 0;
            FlpOverviewTiles.WrapContents = true;
            //
            // TleTotalContacts
            //
            TleTotalContacts.Caption = "Kontakte gesamt";
            TleTotalContacts.Margin = new Padding(0, 0, 12, 12);
            TleTotalContacts.Name = "TleTotalContacts";
            TleTotalContacts.Size = new Size(370, 130);
            TleTotalContacts.TabIndex = 0;
            TleTotalContacts.TileColor = Color.FromArgb(0x5C, 0x2D, 0x91);
            TleTotalContacts.Value = "0";
            //
            // TleEmployees
            //
            TleEmployees.Caption = "Mitarbeitende";
            TleEmployees.Margin = new Padding(0, 0, 12, 12);
            TleEmployees.Name = "TleEmployees";
            TleEmployees.Size = new Size(370, 130);
            TleEmployees.TabIndex = 1;
            TleEmployees.TileColor = Color.FromArgb(0x5C, 0x2D, 0x91);
            TleEmployees.Value = "0";
            //
            // TleApprentices
            //
            TleApprentices.Caption = "Lernende";
            TleApprentices.Margin = new Padding(0, 0, 12, 12);
            TleApprentices.Name = "TleApprentices";
            TleApprentices.Size = new Size(370, 130);
            TleApprentices.TabIndex = 2;
            TleApprentices.TileColor = Color.FromArgb(0x6E, 0x5A, 0xC8);
            TleApprentices.Value = "0";
            //
            // TleCustomers
            //
            TleCustomers.Caption = "Kundschaft";
            TleCustomers.Margin = new Padding(0, 0, 12, 12);
            TleCustomers.Name = "TleCustomers";
            TleCustomers.Size = new Size(370, 130);
            TleCustomers.TabIndex = 3;
            TleCustomers.TileColor = Color.FromArgb(0x8A, 0x4F, 0xB8);
            TleCustomers.Value = "0";
            //
            // TleAverageAge
            //
            TleAverageAge.Caption = "Ø Alter";
            TleAverageAge.Margin = new Padding(0, 0, 12, 12);
            TleAverageAge.Name = "TleAverageAge";
            TleAverageAge.Size = new Size(370, 130);
            TleAverageAge.TabIndex = 4;
            TleAverageAge.TileColor = Color.FromArgb(0xB0, 0x84, 0xD4);
            TleAverageAge.Value = "–";
            //
            // TleNoteCount
            //
            TleNoteCount.Caption = "Notizen gesamt";
            TleNoteCount.Margin = new Padding(0, 0, 12, 12);
            TleNoteCount.Name = "TleNoteCount";
            TleNoteCount.Size = new Size(370, 130);
            TleNoteCount.TabIndex = 5;
            TleNoteCount.TileColor = Color.FromArgb(0xB0, 0x84, 0xD4);
            TleNoteCount.Value = "0";
            //
            // TabEmployees
            //
            TabEmployees.Controls.Add(TlpEmployeeCharts);
            TabEmployees.Controls.Add(FlpEmployeeTiles);
            TabEmployees.Location = new Point(4, 24);
            TabEmployees.Name = "TabEmployees";
            TabEmployees.Padding = new Padding(12);
            TabEmployees.Size = new Size(1172, 676);
            TabEmployees.TabIndex = 1;
            TabEmployees.Text = "Mitarbeitende";
            TabEmployees.UseVisualStyleBackColor = true;
            //
            // TlpEmployeeCharts
            //
            TlpEmployeeCharts.ColumnCount = 2;
            TlpEmployeeCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TlpEmployeeCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TlpEmployeeCharts.Controls.Add(ChtDepartments, 0, 0);
            TlpEmployeeCharts.Controls.Add(ChtNationalities, 1, 0);
            TlpEmployeeCharts.Controls.Add(ChtManagementLevels, 0, 1);
            TlpEmployeeCharts.Controls.Add(ChtApprenticeYears, 1, 1);
            TlpEmployeeCharts.Controls.Add(ChtHiresPerYear, 0, 2);
            TlpEmployeeCharts.Dock = DockStyle.Fill;
            TlpEmployeeCharts.Location = new Point(12, 162);
            TlpEmployeeCharts.Name = "TlpEmployeeCharts";
            TlpEmployeeCharts.RowCount = 3;
            TlpEmployeeCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            TlpEmployeeCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            TlpEmployeeCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
            TlpEmployeeCharts.SetColumnSpan(ChtHiresPerYear, 2);
            TlpEmployeeCharts.Size = new Size(1148, 502);
            TlpEmployeeCharts.TabIndex = 1;
            //
            // ChtDepartments
            //
            ChtDepartments.Dock = DockStyle.Fill;
            ChtDepartments.Horizontal = true;
            ChtDepartments.Location = new Point(3, 3);
            ChtDepartments.Name = "ChtDepartments";
            ChtDepartments.Size = new Size(568, 173);
            ChtDepartments.TabIndex = 0;
            ChtDepartments.Title = "Mitarbeitende pro Abteilung";
            //
            // ChtNationalities
            //
            ChtNationalities.Dock = DockStyle.Fill;
            ChtNationalities.Horizontal = true;
            ChtNationalities.Location = new Point(577, 3);
            ChtNationalities.Name = "ChtNationalities";
            ChtNationalities.Size = new Size(568, 173);
            ChtNationalities.TabIndex = 1;
            ChtNationalities.Title = "Top Nationalitäten";
            //
            // ChtManagementLevels
            //
            ChtManagementLevels.Dock = DockStyle.Fill;
            ChtManagementLevels.Horizontal = true;
            ChtManagementLevels.Location = new Point(3, 182);
            ChtManagementLevels.Name = "ChtManagementLevels";
            ChtManagementLevels.Size = new Size(568, 173);
            ChtManagementLevels.TabIndex = 2;
            ChtManagementLevels.Title = "Kaderstufen";
            //
            // ChtApprenticeYears
            //
            ChtApprenticeYears.Dock = DockStyle.Fill;
            ChtApprenticeYears.Horizontal = true;
            ChtApprenticeYears.Location = new Point(577, 182);
            ChtApprenticeYears.Name = "ChtApprenticeYears";
            ChtApprenticeYears.Size = new Size(568, 173);
            ChtApprenticeYears.TabIndex = 3;
            ChtApprenticeYears.Title = "Lernende nach Lehrjahr";
            //
            // ChtHiresPerYear
            //
            ChtHiresPerYear.Dock = DockStyle.Fill;
            ChtHiresPerYear.Location = new Point(3, 361);
            ChtHiresPerYear.Name = "ChtHiresPerYear";
            ChtHiresPerYear.Size = new Size(1142, 178);
            ChtHiresPerYear.TabIndex = 4;
            ChtHiresPerYear.Title = "Eintritte pro Jahr";
            //
            // FlpEmployeeTiles
            //
            FlpEmployeeTiles.Controls.Add(TleAverageEmploymentLevel);
            FlpEmployeeTiles.Controls.Add(TlePartTimeCount);
            FlpEmployeeTiles.Controls.Add(TleLeftCount);
            FlpEmployeeTiles.Controls.Add(TleAverageTenure);
            FlpEmployeeTiles.Dock = DockStyle.Top;
            FlpEmployeeTiles.Location = new Point(12, 12);
            FlpEmployeeTiles.Name = "FlpEmployeeTiles";
            FlpEmployeeTiles.Size = new Size(1148, 150);
            FlpEmployeeTiles.TabIndex = 0;
            FlpEmployeeTiles.WrapContents = true;
            //
            // TleAverageEmploymentLevel
            //
            TleAverageEmploymentLevel.Caption = "Ø Beschäftigungsgrad";
            TleAverageEmploymentLevel.Margin = new Padding(0, 0, 12, 12);
            TleAverageEmploymentLevel.Name = "TleAverageEmploymentLevel";
            TleAverageEmploymentLevel.Size = new Size(275, 130);
            TleAverageEmploymentLevel.TabIndex = 0;
            TleAverageEmploymentLevel.TileColor = Color.FromArgb(0x5C, 0x2D, 0x91);
            TleAverageEmploymentLevel.Value = "–";
            //
            // TlePartTimeCount
            //
            TlePartTimeCount.Caption = "Teilzeit (< 100 %)";
            TlePartTimeCount.Margin = new Padding(0, 0, 12, 12);
            TlePartTimeCount.Name = "TlePartTimeCount";
            TlePartTimeCount.Size = new Size(275, 130);
            TlePartTimeCount.TabIndex = 1;
            TlePartTimeCount.TileColor = Color.FromArgb(0x8A, 0x4F, 0xB8);
            TlePartTimeCount.Value = "0";
            //
            // TleLeftCount
            //
            TleLeftCount.Caption = "Ausgetretene";
            TleLeftCount.Margin = new Padding(0, 0, 12, 12);
            TleLeftCount.Name = "TleLeftCount";
            TleLeftCount.Size = new Size(275, 130);
            TleLeftCount.TabIndex = 2;
            TleLeftCount.TileColor = Color.FromArgb(0xB0, 0x84, 0xD4);
            TleLeftCount.Value = "0";
            //
            // TleAverageTenure
            //
            TleAverageTenure.Caption = "Ø Betriebszugehörigkeit (Jahre)";
            TleAverageTenure.Margin = new Padding(0, 0, 12, 12);
            TleAverageTenure.Name = "TleAverageTenure";
            TleAverageTenure.Size = new Size(275, 130);
            TleAverageTenure.TabIndex = 3;
            TleAverageTenure.TileColor = Color.FromArgb(0x6E, 0x5A, 0xC8);
            TleAverageTenure.Value = "–";
            //
            // TabQuality
            //
            TabQuality.Controls.Add(TlpQualityCharts);
            TabQuality.Controls.Add(FlpQualityTiles);
            TabQuality.Location = new Point(4, 24);
            TabQuality.Name = "TabQuality";
            TabQuality.Padding = new Padding(12);
            TabQuality.Size = new Size(1172, 676);
            TabQuality.TabIndex = 2;
            TabQuality.Text = "Kundschaft && Datenqualität";
            TabQuality.UseVisualStyleBackColor = true;
            //
            // TlpQualityCharts
            //
            TlpQualityCharts.ColumnCount = 2;
            TlpQualityCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TlpQualityCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TlpQualityCharts.Controls.Add(ChtNotesPerMonth, 0, 0);
            TlpQualityCharts.Controls.Add(ChtGenderShare, 1, 0);
            TlpQualityCharts.Controls.Add(ChtTopCities, 0, 1);
            TlpQualityCharts.Controls.Add(ChtTopPostalCodes, 1, 1);
            TlpQualityCharts.Dock = DockStyle.Fill;
            TlpQualityCharts.Location = new Point(12, 162);
            TlpQualityCharts.Name = "TlpQualityCharts";
            TlpQualityCharts.RowCount = 2;
            TlpQualityCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TlpQualityCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TlpQualityCharts.Size = new Size(1148, 502);
            TlpQualityCharts.TabIndex = 1;
            //
            // ChtNotesPerMonth
            //
            ChtNotesPerMonth.Dock = DockStyle.Fill;
            ChtNotesPerMonth.Location = new Point(3, 3);
            ChtNotesPerMonth.Name = "ChtNotesPerMonth";
            ChtNotesPerMonth.Size = new Size(568, 265);
            ChtNotesPerMonth.TabIndex = 0;
            ChtNotesPerMonth.Title = "Notizen pro Monat";
            //
            // ChtGenderShare
            //
            ChtGenderShare.Dock = DockStyle.Fill;
            ChtGenderShare.Location = new Point(577, 3);
            ChtGenderShare.Name = "ChtGenderShare";
            ChtGenderShare.ShowLegend = true;
            ChtGenderShare.Size = new Size(568, 265);
            ChtGenderShare.TabIndex = 1;
            //
            // ChtTopCities
            //
            ChtTopCities.Dock = DockStyle.Fill;
            ChtTopCities.Horizontal = true;
            ChtTopCities.Location = new Point(3, 274);
            ChtTopCities.Name = "ChtTopCities";
            ChtTopCities.Size = new Size(568, 265);
            ChtTopCities.TabIndex = 2;
            ChtTopCities.Title = "Top Orte der Kundschaft";
            //
            // ChtTopPostalCodes
            //
            ChtTopPostalCodes.Dock = DockStyle.Fill;
            ChtTopPostalCodes.Horizontal = true;
            ChtTopPostalCodes.Location = new Point(577, 274);
            ChtTopPostalCodes.Name = "ChtTopPostalCodes";
            ChtTopPostalCodes.Size = new Size(568, 265);
            ChtTopPostalCodes.TabIndex = 3;
            ChtTopPostalCodes.Title = "Top Postleitzahlen der Kundschaft";
            //
            // FlpQualityTiles
            //
            FlpQualityTiles.Controls.Add(TleWithoutEmail);
            FlpQualityTiles.Controls.Add(TleWithoutPhone);
            FlpQualityTiles.Controls.Add(TleWithoutAddress);
            FlpQualityTiles.Controls.Add(TleCustomersWithoutNote);
            FlpQualityTiles.Controls.Add(TleBirthdaysThisMonth);
            FlpQualityTiles.Dock = DockStyle.Top;
            FlpQualityTiles.Location = new Point(12, 12);
            FlpQualityTiles.Name = "FlpQualityTiles";
            FlpQualityTiles.Size = new Size(1148, 150);
            FlpQualityTiles.TabIndex = 0;
            FlpQualityTiles.WrapContents = true;
            //
            // TleWithoutEmail
            //
            TleWithoutEmail.Caption = "Ohne E-Mail";
            TleWithoutEmail.Margin = new Padding(0, 0, 12, 12);
            TleWithoutEmail.Name = "TleWithoutEmail";
            TleWithoutEmail.Size = new Size(217, 130);
            TleWithoutEmail.TabIndex = 0;
            TleWithoutEmail.TileColor = Color.FromArgb(0xBD, 0xB5, 0xC8);
            TleWithoutEmail.Value = "0";
            //
            // TleWithoutPhone
            //
            TleWithoutPhone.Caption = "Ohne Telefon";
            TleWithoutPhone.Margin = new Padding(0, 0, 12, 12);
            TleWithoutPhone.Name = "TleWithoutPhone";
            TleWithoutPhone.Size = new Size(217, 130);
            TleWithoutPhone.TabIndex = 1;
            TleWithoutPhone.TileColor = Color.FromArgb(0xBD, 0xB5, 0xC8);
            TleWithoutPhone.Value = "0";
            //
            // TleWithoutAddress
            //
            TleWithoutAddress.Caption = "Kundschaft ohne Adresse";
            TleWithoutAddress.Margin = new Padding(0, 0, 12, 12);
            TleWithoutAddress.Name = "TleWithoutAddress";
            TleWithoutAddress.Size = new Size(217, 130);
            TleWithoutAddress.TabIndex = 2;
            TleWithoutAddress.TileColor = Color.FromArgb(0xBD, 0xB5, 0xC8);
            TleWithoutAddress.Value = "0";
            //
            // TleCustomersWithoutNote
            //
            TleCustomersWithoutNote.Caption = "Kundschaft ohne Notiz";
            TleCustomersWithoutNote.Margin = new Padding(0, 0, 12, 12);
            TleCustomersWithoutNote.Name = "TleCustomersWithoutNote";
            TleCustomersWithoutNote.Size = new Size(217, 130);
            TleCustomersWithoutNote.TabIndex = 3;
            TleCustomersWithoutNote.TileColor = Color.FromArgb(0x8A, 0x4F, 0xB8);
            TleCustomersWithoutNote.Value = "0";
            //
            // TleBirthdaysThisMonth
            //
            TleBirthdaysThisMonth.Caption = "Geburtstage diesen Monat";
            TleBirthdaysThisMonth.Margin = new Padding(0, 0, 12, 12);
            TleBirthdaysThisMonth.Name = "TleBirthdaysThisMonth";
            TleBirthdaysThisMonth.Size = new Size(217, 130);
            TleBirthdaysThisMonth.TabIndex = 4;
            TleBirthdaysThisMonth.TileColor = Color.FromArgb(0xB0, 0x84, 0xD4);
            TleBirthdaysThisMonth.Value = "0";
            //
            // DashboardForm
            //
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 760);
            Controls.Add(TabDashboard);
            Controls.Add(PnlHeader);
            MinimumSize = new Size(960, 680);
            Name = "DashboardForm";
            Text = "ContactManager - Dashboard";
            PnlHeader.ResumeLayout(false);
            TabDashboard.ResumeLayout(false);
            TabOverview.ResumeLayout(false);
            TlpOverviewBody.ResumeLayout(false);
            TlpOverviewSummaries.ResumeLayout(false);
            GrpEmployeeSummary.ResumeLayout(false);
            GrpCustomerSummary.ResumeLayout(false);
            FlpOverviewTiles.ResumeLayout(false);
            TabEmployees.ResumeLayout(false);
            TlpEmployeeCharts.ResumeLayout(false);
            FlpEmployeeTiles.ResumeLayout(false);
            TabQuality.ResumeLayout(false);
            TlpQualityCharts.ResumeLayout(false);
            FlpQualityTiles.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private Panel PnlHeader;
        private Label LblDashboardTitle;
        private Button BtnReturnToHome;
        private TabControl TabDashboard;
        private TabPage TabOverview;
        private FlowLayoutPanel FlpOverviewTiles;
        private KpiTile TleTotalContacts;
        private KpiTile TleEmployees;
        private KpiTile TleApprentices;
        private KpiTile TleCustomers;
        private KpiTile TleAverageAge;
        private KpiTile TleNoteCount;
        private TableLayoutPanel TlpOverviewBody;
        private TableLayoutPanel TlpOverviewSummaries;
        private GroupBox GrpEmployeeSummary;
        private Label LblEmployeeSummaryTotalCaption;
        private Label LblEmployeeSummaryTotalValue;
        private Label LblEmployeeSummaryActiveCaption;
        private Label LblEmployeeSummaryActiveValue;
        private Label LblEmployeeSummaryPassiveCaption;
        private Label LblEmployeeSummaryPassiveValue;
        private Label LblEmployeeSummaryApprenticesCaption;
        private Label LblEmployeeSummaryApprenticesValue;
        private GroupBox GrpCustomerSummary;
        private Label LblCustomerSummaryTotalCaption;
        private Label LblCustomerSummaryTotalValue;
        private Label LblCustomerSummaryActiveCaption;
        private Label LblCustomerSummaryActiveValue;
        private Label LblCustomerSummaryPassiveCaption;
        private Label LblCustomerSummaryPassiveValue;
        private DonutChart ChtContactShare;
        private TabPage TabEmployees;
        private FlowLayoutPanel FlpEmployeeTiles;
        private KpiTile TleAverageEmploymentLevel;
        private KpiTile TlePartTimeCount;
        private KpiTile TleLeftCount;
        private KpiTile TleAverageTenure;
        private TableLayoutPanel TlpEmployeeCharts;
        private BarChart ChtDepartments;
        private BarChart ChtNationalities;
        private BarChart ChtManagementLevels;
        private BarChart ChtApprenticeYears;
        private BarChart ChtHiresPerYear;
        private TabPage TabQuality;
        private FlowLayoutPanel FlpQualityTiles;
        private KpiTile TleWithoutEmail;
        private KpiTile TleWithoutPhone;
        private KpiTile TleWithoutAddress;
        private KpiTile TleCustomersWithoutNote;
        private KpiTile TleBirthdaysThisMonth;
        private TableLayoutPanel TlpQualityCharts;
        private BarChart ChtNotesPerMonth;
        private DonutChart ChtGenderShare;
        private BarChart ChtTopCities;
        private BarChart ChtTopPostalCodes;
    }
}
