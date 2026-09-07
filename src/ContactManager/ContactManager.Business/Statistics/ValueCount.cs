using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Statistics
{
    /// <summary>
    /// Anzahl der Personen zu einem ganzzahligen Merkmal (z. B. Kaderstufe, Lehrjahr).
    /// <c>null</c> steht für „nicht erfasst".
    /// </summary>
    public sealed record ValueCount
    {
        /// <summary>Der Merkmalswert, oder <c>null</c>, wenn er nicht erfasst ist.</summary>
        public required int? Value { get; init; }

        /// <summary>Anzahl Personen mit diesem Wert.</summary>
        public required int Count { get; init; }
    }
}
