using ContactManager.Model;

namespace ContactManager.Business.Helpers
{
    /// <summary>
    /// Vergibt die laufenden Nummern für Kunden und Mitarbeiter (Auto-Increment).
    /// Kapselt die Regel „nächste Nummer = zuletzt vergebene + 1" an einer Stelle
    /// und hält dabei die persistierten Zähler im <see cref="ContactData"/> aktuell,
    /// damit die Vergabe nach einem Neustart lückenlos weiterläuft.
    /// </summary>
    internal static class NumberGenerator
    {
        /// <summary>
        /// Ermittelt die nächste freie Kundennummer, erhöht den persistierten Zähler
        /// (<see cref="ContactData.LastCustomerNumber"/>) und gibt die neue Nummer zurück.
        /// </summary>
        /// <param name="data">Der Datenstamm, dessen Kundenzähler fortgeschrieben wird.</param>
        /// <returns>Die neu vergebene, eindeutige Kundennummer.</returns>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="data"/> <c>null</c> ist.</exception>
        public static int NextCustomerNumber(ContactData data)
        {
            ArgumentNullException.ThrowIfNull(data);

            data.LastCustomerNumber++;
            return data.LastCustomerNumber;
        }

        /// <summary>
        /// Ermittelt die nächste freie Mitarbeiternummer, erhöht den persistierten Zähler
        /// (<see cref="ContactData.LastEmployeeNumber"/>) und gibt die neue Nummer zurück.
        /// </summary>
        /// <param name="data">Der Datenstamm, dessen Mitarbeiterzähler fortgeschrieben wird.</param>
        /// <returns>Die neu vergebene, eindeutige Mitarbeiternummer.</returns>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="data"/> <c>null</c> ist.</exception>
        public static int NextEmployeeNumber(ContactData data)
        {
            ArgumentNullException.ThrowIfNull(data);

            data.LastEmployeeNumber++;
            return data.LastEmployeeNumber;
        }
    }
}
