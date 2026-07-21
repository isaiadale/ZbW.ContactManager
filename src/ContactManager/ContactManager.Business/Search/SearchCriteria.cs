using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Search
{
    /// <summary>
    /// Bündelt die Filterkriterien für eine Personensuche. Jedes Kriterium ist optional:
    /// Ein auf <c>null</c> gesetztes Feld wird bei der Suche ignoriert. Sind alle Felder
    /// <c>null</c>, treffen die Kriterien auf jede Person zu.
    /// </summary>
    public class SearchCriteria
    {
        /// <summary>Filter auf den Vornamen (Teiltreffer); <c>null</c> = Kriterium ignorieren.</summary>
        public string? FirstName { get; set; }

        /// <summary>Filter auf den Nachnamen (Teiltreffer); <c>null</c> = Kriterium ignorieren.</summary>
        public string? LastName { get; set; }

        /// <summary>Filter auf das exakte Geburtsdatum; <c>null</c> = Kriterium ignorieren.</summary>
        public DateOnly? DateOfBirth { get; set; }

        /// <summary>Filter auf die Art des Kontakts (Kunde, Mitarbeiter, Lernender); <c>null</c> = Kriterium ignorieren.</summary>
        public ContactType? Type { get; set; }

        /// <summary>
        /// Filter auf die laufende Nummer; wird je nach <see cref="Type"/> gegen die
        /// Kunden- oder Mitarbeiternummer geprüft. <c>null</c> = Kriterium ignorieren.
        /// </summary>
        public int? Number { get; set; }
    }
}
