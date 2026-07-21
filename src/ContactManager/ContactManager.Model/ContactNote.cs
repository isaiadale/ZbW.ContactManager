using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model
{
    /// <summary>
    /// Eine einzelne Notiz zu einem Kundenkontakt. Bildet zusammen mit den weiteren
    /// Notizen eines Kunden die laufende Dokumentation (Historie). Notizen werden nur
    /// angehängt und sind nach dem Erfassen unveränderlich.
    /// </summary>
    public class ContactNote
    {
        /// <summary>Eindeutiger Bezeichner, wird einmalig bei der Erstellung erzeugt und nie geändert.</summary>
        public Guid Id { get; init; } = Guid.NewGuid();

        /// <summary>Zeitpunkt (mit Uhrzeit), zu dem die Notiz erfasst wurde.</summary>
        public DateTime CreatedAt { get; init; } = DateTime.Now;

        /// <summary>Der eigentliche Notiztext. Pflichtfeld.</summary>
        public required string Text { get; init; }
    }
}
