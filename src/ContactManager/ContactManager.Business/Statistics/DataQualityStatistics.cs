using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Statistics
{
    /// <summary>
    /// Kennzahlen zur Vollständigkeit der erfassten Daten sowie zu den Standorten
    /// der Kundschaft.
    /// </summary>
    public sealed record DataQualityStatistics
    {
        /// <summary>Anzahl Personen (Mitarbeitende und Kundschaft) ohne erfasste E-Mail-Adresse.</summary>
        public required int WithoutEmail { get; init; }

        /// <summary>
        /// Anzahl Personen ohne erfasste Telefonnummer (weder Mobile noch Geschäft).
        /// </summary>
        public required int WithoutPhone { get; init; }

        /// <summary>
        /// Anzahl Kundschaft ohne erfasste Adresse.
        /// </summary>
        public required int WithoutAddress { get; init; }

        /// <summary>Die häufigsten Orte der Kundschaft, absteigend nach Anzahl.</summary>
        public required IReadOnlyList<LabelCount> TopCustomerCities { get; init; }

        /// <summary>Die häufigsten Postleitzahlen der Kundschaft, absteigend nach Anzahl.</summary>
        public required IReadOnlyList<LabelCount> TopCustomerPostalCodes { get; init; }

        /// <summary>Kundschaft ohne eine einzige protokollierte Notiz.</summary>
        public required int CustomersWithoutNote { get; init; }
    }
}
