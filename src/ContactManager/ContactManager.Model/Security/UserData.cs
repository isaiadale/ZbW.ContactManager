using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model.Security
{
    /// <summary>
    /// Kompletter Bestand der Benutzerkonten – die Einheit, die in der Benutzerdatei
    /// persistiert wird. Bewusst eine eigene Wurzel neben <see cref="ContactData"/>
    /// und in einer eigenen Datei: Zugangsdaten und Kontaktdaten haben fachlich nichts
    /// miteinander zu tun, und eine Passwortänderung soll nicht den gesamten
    /// Kontaktstamm neu schreiben.
    /// </summary>
    public class UserData
    {
        /// <summary>Alle erfassten Benutzerkonten.</summary>
        public List<User> Users { get; init; } = new();
    }
}
