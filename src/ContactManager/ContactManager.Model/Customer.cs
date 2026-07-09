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
        /// <summary>Akademischer oder beruflicher Titel (z. B. "Dr."); optional.</summary>
        public string? Title { get; set; }

        /// <summary>Gibt an, ob der Kunde aktuell aktiv oder passiv ist. Pflichtfeld.</summary>
        public required Status CustomerStatus { get; set; }

        /// <summary>Postanschrift des Kunden; optional.</summary>
        public Address? Address { get; set; }
    }
}
