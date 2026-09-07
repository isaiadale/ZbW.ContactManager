using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Statistics
{
    /// <summary>
    /// Kennzahlen mit zeitlichem Verlauf über die letzten zwölf Monate.
    /// </summary>
    public sealed record TimelineStatistics
    {
        /// <summary>
        /// Eintritte je Kalenderjahr (chronologisch), über alle Mitarbeitenden mit
        /// erfasstem Eintrittsdatum. Bewusst jahresweise statt monatlich: Ein
        /// monatliches Raster wäre bei den üblichen Datenmengen dieses Projekts fast
        /// durchgehend leer.
        /// </summary>
        public required IReadOnlyList<YearCount> HiresPerYear { get; init; }

        /// <summary>
        /// Erfasste Notizen je Monat der letzten zwölf Monate (chronologisch, bis und mit
        /// dem laufenden Monat). Monate ohne Notiz stehen mit Anzahl 0 in der Liste.
        /// </summary>
        public required IReadOnlyList<MonthCount> NotesPerMonth { get; init; }

        /// <summary>Anzahl Personen, deren Geburtstag in den laufenden Kalendermonat fällt.</summary>
        public required int BirthdaysThisMonth { get; init; }

        /// <summary>
        /// Durchschnittliche Betriebszugehörigkeit aller Mitarbeitenden mit erfasstem
        /// Eintrittsdatum, in Jahren; <c>null</c>, wenn kein Eintrittsdatum erfasst ist.
        /// Bereits ausgetretene Mitarbeitende zählen bis zu ihrem Austrittsdatum.
        /// </summary>
        public required double? AverageTenureYears { get; init; }
    }
}
