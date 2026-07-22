using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Model.Enums;

namespace ContactManager.Model
{
    /// <summary>
    /// Abstrakte Basisklasse für jede Person im System. Bündelt die Eigenschaften,
    /// die sich <see cref="Customer"/> und <see cref="Employee"/> teilen. Kann nicht
    /// direkt instanziiert werden; nur die abgeleiteten Typen stellen reale Kontakte dar.
    /// </summary>
    public abstract class Person
    {
        /// <summary>Eindeutiger Bezeichner, wird einmalig bei der Erstellung erzeugt und nie geändert.</summary>
        public Guid Id { get; init; } = Guid.NewGuid();

        /// <summary>Anrede (z. B. Herr/Frau); optional.</summary>
        public Salutation? Salutation { get; set; }

        /// <summary>Vorname der Person. Pflichtfeld.</summary>
        public required string FirstName { get; set; }

        /// <summary>Nachname der Person. Pflichtfeld.</summary>
        public required string LastName { get; set; }

        /// <summary>Geburtsdatum (ohne Uhrzeit); optional.</summary>
        public DateOnly? DateOfBirth { get; set; }

        /// <summary>Geschlecht der Person; optional.</summary>
        public Gender? Gender { get; set; }

        /// <summary>Mobiltelefonnummer als Freitext (behält führende Nullen und "+41"); optional.</summary>
        public string? MobilePhone { get; set; }

        /// <summary>Geschäftliche Telefonnummer als Freitext; optional.</summary>
        public string? BusinessPhone { get; set; }

        /// <summary>E-Mail-Adresse; optional.</summary>
        public string? Email { get; set; }

        /// <summary>Gibt an, ob die Person (Kunde oder Mitarbeiter) aktuell aktiv oder passiv ist. Pflichtfeld.</summary>
        public required Status PersonStatus { get; set; }
    }
}
