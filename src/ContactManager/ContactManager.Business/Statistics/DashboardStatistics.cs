using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Statistics
{
    /// <summary>
    /// Momentaufnahme aller Kennzahlen für das Dashboard, berechnet zu einem
    /// bestimmten Stichtag in einem einzigen, in sich stimmigen Durchgang über den
    /// Datenstamm.
    /// </summary>
    public sealed record DashboardStatistics
    {
        /// <summary>Mengenverhältnis Mitarbeitende / Lernende / Kundschaft für das gemeinsame Ringdiagramm.</summary>
        public required ContactMixStatistics Mix { get; init; }

        /// <summary>
        /// Kennzahlen aller Mitarbeitenden – Lernende sind darin eingeschlossen
        /// (im Unterschied zu <see cref="Mix"/>, wo sie separat gezählt werden).
        /// </summary>
        public required GroupStatistics Employees { get; init; }

        /// <summary>Kennzahlen der Lernenden als Teilmenge der Mitarbeitenden.</summary>
        public required GroupStatistics Apprentices { get; init; }

        /// <summary>Kennzahlen der Kundschaft.</summary>
        public required GroupStatistics Customers { get; init; }

        /// <summary>Kompakte Überblickskennzahlen.</summary>
        public required CompactStatistics Compact { get; init; }

        /// <summary>Kennzahlen mit zeitlichem Verlauf.</summary>
        public required TimelineStatistics Timeline { get; init; }

        /// <summary>Personalbezogene Detailkennzahlen.</summary>
        public required StaffStatistics Staff { get; init; }

        /// <summary>Kennzahlen zur Datenqualität und zu den Standorten der Kundschaft.</summary>
        public required DataQualityStatistics Quality { get; init; }
    }
}
