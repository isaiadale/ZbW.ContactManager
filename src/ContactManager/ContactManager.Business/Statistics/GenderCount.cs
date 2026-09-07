using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Model.Enums;

namespace ContactManager.Business.Statistics
{
    /// <summary>
    /// Anzahl der Personen zu einem Geschlecht. <c>null</c> steht für „nicht erfasst".
    /// </summary>
    public sealed record GenderCount
    {
        /// <summary>Das Geschlecht, oder <c>null</c>, wenn es nicht erfasst ist.</summary>
        public required Gender? Gender { get; init; }

        /// <summary>Anzahl Personen mit diesem Geschlecht.</summary>
        public required int Count { get; init; }
    }
}
