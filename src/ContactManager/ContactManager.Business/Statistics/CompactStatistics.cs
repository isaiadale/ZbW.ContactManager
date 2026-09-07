using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Statistics
{
    /// <summary>
    /// Kompakte Überblickskennzahlen über alle Personen des Datenstamms.
    /// </summary>
    public sealed record CompactStatistics
    {
        /// <summary>
        /// Durchschnittsalter in Jahren aller Personen mit erfasstem Geburtsdatum;
        /// <c>null</c>, wenn kein Geburtsdatum erfasst ist.
        /// </summary>
        public required double? AverageAge { get; init; }

        /// <summary>Verteilung aller Personen nach Geschlecht, absteigend nach Anzahl.</summary>
        public required IReadOnlyList<GenderCount> GenderDistribution { get; init; }

        /// <summary>Anzahl Mitarbeitende (inkl. Lernende) je Abteilung, absteigend nach Anzahl.</summary>
        public required IReadOnlyList<LabelCount> EmployeesPerDepartment { get; init; }

        /// <summary>
        /// Durchschnittlicher Beschäftigungsgrad in Prozent aller Mitarbeitenden mit
        /// erfasstem Wert; <c>null</c>, wenn kein Beschäftigungsgrad erfasst ist.
        /// </summary>
        public required double? AverageEmploymentLevel { get; init; }

        /// <summary>Gesamtzahl aller protokollierten Notizen über alle Kunden hinweg.</summary>
        public required int NoteCount { get; init; }
    }
}
