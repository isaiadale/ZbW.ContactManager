using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Statistics
{
    /// <summary>
    /// Anzahl der Personen zu einem frei erfassten Textmerkmal (z. B. Abteilung,
    /// Nationalität, Ort). Das Label ist der unveränderte Rohwert aus dem Datenstamm;
    /// eine allfällige Übersetzung ist Sache der Oberfläche.
    /// </summary>
    public sealed record LabelCount
    {
        /// <summary>Der Rohwert des Merkmals.</summary>
        public required string Label { get; init; }

        /// <summary>Anzahl Personen mit diesem Wert.</summary>
        public required int Count { get; init; }
    }
}
