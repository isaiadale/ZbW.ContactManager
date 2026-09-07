using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Statistics
{
    /// <summary>
    /// Anzahl Ereignisse in einem Kalenderjahr. Wird für mehrjährige Verläufe verwendet
    /// (z. B. Eintritte), bei denen ein monatliches Raster zu fein aufgelöst wäre.
    /// </summary>
    public sealed record YearCount
    {
        /// <summary>Das Kalenderjahr.</summary>
        public required int Year { get; init; }

        /// <summary>Anzahl Ereignisse in diesem Jahr.</summary>
        public required int Count { get; init; }
    }
}
