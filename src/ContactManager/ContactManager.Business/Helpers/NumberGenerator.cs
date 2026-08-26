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

            // Bewusst über Peek: So steht die Regel "zuletzt vergebene + 1" nur an einer
            // Stelle und Vorschau und tatsächliche Vergabe können nicht auseinanderlaufen.
            data.LastCustomerNumber = PeekNextCustomerNumber(data);
            return data.LastCustomerNumber;
        }

        /// <summary>
        /// Meldet, welche Kundennummer der nächste <see cref="NextCustomerNumber"/>-Aufruf
        /// vergeben würde, <b>ohne</b> den Zähler zu erhöhen. Gedacht für eine Vorschau in
        /// der Oberfläche; verbindlich vergeben wird die Nummer erst beim Speichern.
        /// </summary>
        /// <param name="data">Der Datenstamm, dessen Kundenzähler gelesen wird.</param>
        /// <returns>Die Nummer, die als nächste vergeben würde.</returns>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="data"/> <c>null</c> ist.</exception>
        public static int PeekNextCustomerNumber(ContactData data)
        {
            ArgumentNullException.ThrowIfNull(data);

            return data.LastCustomerNumber + 1;
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

            // Bewusst über Peek: So steht die Regel "zuletzt vergebene + 1" nur an einer
            // Stelle und Vorschau und tatsächliche Vergabe können nicht auseinanderlaufen.
            data.LastEmployeeNumber = PeekNextEmployeeNumber(data);
            return data.LastEmployeeNumber;
        }

        /// <summary>
        /// Meldet, welche Mitarbeiternummer der nächste <see cref="NextEmployeeNumber"/>-Aufruf
        /// vergeben würde, <b>ohne</b> den Zähler zu erhöhen. Gedacht für eine Vorschau in
        /// der Oberfläche; verbindlich vergeben wird die Nummer erst beim Speichern.
        /// </summary>
        /// <param name="data">Der Datenstamm, dessen Mitarbeiterzähler gelesen wird.</param>
        /// <returns>Die Nummer, die als nächste vergeben würde.</returns>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="data"/> <c>null</c> ist.</exception>
        public static int PeekNextEmployeeNumber(ContactData data)
        {
            ArgumentNullException.ThrowIfNull(data);

            return data.LastEmployeeNumber + 1;
        }
    }
}
