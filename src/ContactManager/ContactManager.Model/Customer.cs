using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Model.Enums;

namespace ContactManager.Model
{
    /// <summary>
    /// Ein Kundenkontakt. Erbt die gemeinsamen Personendaten von <see cref="Person"/>
    /// und ergänzt sie um kundenspezifische Informationen.
    /// </summary>
    public class Customer : Person
    {
        /// <summary>
        /// Automatisch hochgezählte Kundennummer, die von der Business-Schicht vergeben wird.
        /// Von ausserhalb des Models nur lesbar.
        /// </summary>
        public int CustomerNumber { get; private set; }

        /// <summary>Akademischer oder beruflicher Titel (z. B. "Dr."); optional.</summary>
        public string? Title { get; set; }

        /// <summary>Postanschrift des Kunden; optional.</summary>
        public Address? Address { get; set; }

        /// <summary>
        /// Chronologische Historie der Kontaktnotizen zu diesem Kunden. Notizen werden
        /// ausschliesslich angehängt und nie geändert oder entfernt. Die Verwaltung läuft
        /// über den <c>ContactNoteService</c> der Business-Schicht.
        /// </summary>
        public List<ContactNote> Notes { get; init; } = new();

        /// <summary>
        /// Vergibt die Kundennummer einmalig. Die Berechnung der nächsten freien Nummer
        /// liegt in der Business-Schicht; das Model stellt hier nur sicher, dass eine
        /// einmal vergebene Nummer nicht mehr überschrieben werden kann.
        /// </summary>
        /// <param name="number">Die zu vergebende Kundennummer; muss grösser als 0 sein.</param>
        /// <exception cref="ArgumentOutOfRangeException">Wird geworfen, wenn <paramref name="number"/> kleiner oder gleich 0 ist.</exception>
        /// <exception cref="InvalidOperationException">Wird geworfen, wenn diesem Kunden bereits eine Nummer zugewiesen wurde.</exception>
        public void AssignCustomerNumber(int number)
        {
            if (number <= 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Kundennummer muss positiv sein.");

            if (CustomerNumber != 0)
                throw new InvalidOperationException("Kundennummer wurde bereits vergeben.");

            CustomerNumber = number;
        }
    }
}
