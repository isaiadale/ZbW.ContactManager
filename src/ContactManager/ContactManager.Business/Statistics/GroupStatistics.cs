using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Statistics
{
    /// <summary>
    /// Kennzahlen einer Personengruppe (z. B. Mitarbeitende oder Kundschaft):
    /// Gesamtzahl sowie Aufteilung nach Status.
    /// </summary>
    public sealed record GroupStatistics
    {
        /// <summary>Gesamtzahl der Personen dieser Gruppe.</summary>
        public required int Total { get; init; }

        /// <summary>Anzahl der Personen dieser Gruppe mit Status Aktiv.</summary>
        public required int ActiveCount { get; init; }

        /// <summary>Anzahl der Personen dieser Gruppe mit Status Passiv.</summary>
        public required int PassiveCount { get; init; }
    }
}
