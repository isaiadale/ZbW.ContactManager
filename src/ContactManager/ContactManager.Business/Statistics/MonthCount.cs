using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Statistics
{
    /// <summary>
    /// Anzahl Ereignisse in einem Kalendermonat. Wird für Verläufe über die letzten
    /// zwölf Monate verwendet; Monate ohne Ereignis erscheinen mit <see cref="Count"/> 0,
    /// damit ein Balkendiagramm keine Lücken in der Zeitachse hat.
    /// </summary>
    public sealed record MonthCount
    {
        /// <summary>Jahr des Monats.</summary>
        public required int Year { get; init; }

        /// <summary>Monat (1–12).</summary>
        public required int Month { get; init; }

        /// <summary>Anzahl Ereignisse in diesem Monat.</summary>
        public required int Count { get; init; }
    }
}
