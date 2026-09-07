using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Statistics
{
    /// <summary>
    /// Personalbezogene Detailkennzahlen der Mitarbeitenden und Lernenden.
    /// </summary>
    public sealed record StaffStatistics
    {
        /// <summary>Anzahl Mitarbeitende je Kaderstufe (0–5), absteigend nach Anzahl.</summary>
        public required IReadOnlyList<ValueCount> ManagementLevels { get; init; }

        /// <summary>Anzahl Lernende je aktuellem Lehrjahr, absteigend nach Anzahl.</summary>
        public required IReadOnlyList<ValueCount> ApprenticesPerYear { get; init; }

        /// <summary>Die häufigsten Nationalitäten der Mitarbeitenden, absteigend nach Anzahl.</summary>
        public required IReadOnlyList<LabelCount> TopNationalities { get; init; }

        /// <summary>Mitarbeitende mit erfasstem Beschäftigungsgrad unter 100 Prozent.</summary>
        public required int PartTimeCount { get; init; }

        /// <summary>Mitarbeitende mit gesetztem Austrittsdatum (nicht mehr im Betrieb).</summary>
        public required int LeftCount { get; init; }
    }
}
