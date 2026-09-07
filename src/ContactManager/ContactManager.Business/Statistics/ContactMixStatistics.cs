using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Statistics
{
    /// <summary>
    /// Mengenverhältnis von Mitarbeitenden, Lernenden und Kundschaft für das
    /// gemeinsame Ringdiagramm des Dashboards.
    /// </summary>
    public sealed record ContactMixStatistics
    {
        /// <summary>Anzahl Mitarbeitende ohne Lernende.</summary>
        public required int EmployeeCount { get; init; }

        /// <summary>Anzahl Lernende.</summary>
        public required int ApprenticeCount { get; init; }

        /// <summary>Anzahl Kundschaft.</summary>
        public required int CustomerCount { get; init; }

        /// <summary>Gesamtzahl aller Kontakte (Mitarbeitende, Lernende und Kundschaft zusammen).</summary>
        public required int TotalCount { get; init; }
    }
}
