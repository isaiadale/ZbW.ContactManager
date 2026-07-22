using ContactManager.Business.Services;
using ContactManager.Model;
using ContactManager.Persistence.Json;

namespace ContactManager.Business
{
    /// <summary>
    /// Zentrale Eingangstür der Business-Schicht für die UI. Lädt den Datenstamm genau
    /// einmal über das <see cref="IContactRepository"/> und baut darauf alle fachlichen
    /// Services auf, die sich denselben <see cref="ContactData"/> teilen. Die UI kennt
    /// ausschliesslich diese Fassade und ihre Service-Properties, nie die einzelnen
    /// Service-Konstruktoren (diese sind bewusst <c>internal</c>).
    /// </summary>
    public class ContactManagerFacade
    {
        /// <summary>
        /// Erzeugt die Fassade, lädt den gesamten Datenstamm einmalig und verdrahtet
        /// alle Services darauf. Das übergebene Repository bestimmt, woher die Daten
        /// stammen (z. B. JSON-Datei oder ein In-Memory-Fake im Test).
        /// </summary>
        /// <param name="repository">Die Ablage, aus der geladen und in die gespeichert wird.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="repository"/> <c>null</c> ist.</exception>
        public ContactManagerFacade(IContactRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);

            // Genau ein Ladevorgang: Alle Services arbeiten anschliessend auf denselben
            // Listen dieses Datenstamms. Dadurch sieht z. B. die Suche sofort einen Kunden,
            // der über den CustomerService erfasst wurde – ohne erneutes Laden.
            ContactData data = repository.Load();

            Customers = new CustomerService(repository, data);
            Employees = new EmployeeService(repository, data);
            Notes = new ContactNoteService(repository, data);
            Search = new SearchService(data.Customers, data.Employees);
        }

        /// <summary>Geschäftslogik für Kunden: Lesen, Erfassen, Mutieren, Löschen, Aktivieren/Deaktivieren.</summary>
        public CustomerService Customers { get; }

        /// <summary>Geschäftslogik für Mitarbeiter und Lernende: Lesen, Erfassen, Mutieren, Löschen, Aktivieren/Deaktivieren.</summary>
        public EmployeeService Employees { get; }

        /// <summary>Verwaltung der Kontaktnotizen zu Kunden (anhängen und lesen, inkl. Historie).</summary>
        public ContactNoteService Notes { get; }

        /// <summary>Lesende Suche über alle Kunden und Mitarbeiter/Lernende.</summary>
        public SearchService Search { get; }
    }
}
