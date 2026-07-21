using ContactManager.Business.Search;
using ContactManager.Model;

namespace ContactManager.Business.Services
{
    /// <summary>
    /// Geschäftslogik für die Personensuche. Rein lesend: filtert die geladenen Kunden
    /// und Mitarbeiter (inkl. Lernende) anhand der übergebenen <see cref="SearchCriteria"/>,
    /// ohne den Datenstamm zu verändern oder zu persistieren.
    /// </summary>
    public class SearchService
    {
        private readonly List<Customer> _customers;

        private readonly List<Employee> _employees;

        /// <summary>
        /// Erzeugt den Service auf Basis der bereits geladenen Listen.
        /// Wird von der Fassade aufgebaut, nicht direkt von der UI.
        /// </summary>
        /// <param name="customers">Alle erfassten Kunden des Datenstamms.</param>
        /// <param name="employees">Alle erfassten Mitarbeiter (inkl. Lernende) des Datenstamms.</param>
        internal SearchService(List<Customer> customers, List<Employee> employees)
        {
            ArgumentNullException.ThrowIfNull(customers);
            ArgumentNullException.ThrowIfNull(employees);

            _customers = customers;
            _employees = employees;
        }

        /// <summary>
        /// Sucht über alle Personen (Kunden und Mitarbeiter) anhand der angegebenen Kriterien.
        /// Jedes gesetzte Kriterium verengt die Treffermenge; nicht gesetzte (<c>null</c>)
        /// Kriterien werden ignoriert. Sind alle Kriterien <c>null</c>, werden alle Personen
        /// zurückgegeben. Namensfelder treffen bei Teilübereinstimmung (Gross-/Kleinschreibung
        /// wird ignoriert), das Geburtsdatum muss exakt übereinstimmen.
        /// </summary>
        /// <param name="criteria">Die anzuwendenden Suchkriterien.</param>
        /// <returns>Alle Personen, die auf sämtliche gesetzten Kriterien passen; ggf. leer.</returns>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="criteria"/> <c>null</c> ist.</exception>
        public IReadOnlyList<Person> Search(SearchCriteria criteria)
        {
            ArgumentNullException.ThrowIfNull(criteria);

            // Kunden und Mitarbeiter (inkl. Lernende) zu einer gemeinsamen Personen-Sequenz vereinen.
            IEnumerable<Person> results = _customers.Cast<Person>().Concat(_employees);

            if (!string.IsNullOrWhiteSpace(criteria.FirstName))
                results = results.Where(p => p.FirstName.Contains(criteria.FirstName, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(criteria.LastName))
                results = results.Where(p => p.LastName.Contains(criteria.LastName, StringComparison.OrdinalIgnoreCase));

            if (criteria.DateOfBirth is not null)
                results = results.Where(p => p.DateOfBirth == criteria.DateOfBirth);

            if (criteria.Type is not null)
                results = results.Where(p => MatchesType(p, criteria.Type.Value));

            if (criteria.Number is not null)
                results = results.Where(p => MatchesNumber(p, criteria.Number.Value));

            return results.ToList();
        }

        /// <summary>
        /// Prüft, ob eine Person zum gesuchten <see cref="ContactType"/> passt.
        /// <see cref="ContactType.Employee"/> schliesst Lernende bewusst aus – diese sind
        /// nur über <see cref="ContactType.Apprentice"/> auffindbar.
        /// </summary>
        /// <param name="person">Die zu prüfende Person.</param>
        /// <param name="type">Der gesuchte Kontakttyp.</param>
        /// <returns><c>true</c>, wenn die Person dem Typ entspricht; sonst <c>false</c>.</returns>
        private static bool MatchesType(Person person, ContactType type) => type switch
        {
            ContactType.Customer => person is Customer,
            ContactType.Employee => person is Employee and not Apprentice,
            ContactType.Apprentice => person is Apprentice,
            _ => false
        };

        /// <summary>
        /// Prüft, ob die laufende Nummer einer Person mit der gesuchten Nummer übereinstimmt.
        /// Kunden werden über die Kundennummer, Mitarbeiter (inkl. Lernende) über die
        /// Mitarbeiternummer geprüft.
        /// </summary>
        /// <param name="person">Die zu prüfende Person.</param>
        /// <param name="number">Die gesuchte laufende Nummer.</param>
        /// <returns><c>true</c>, wenn die Nummer der Person übereinstimmt; sonst <c>false</c>.</returns>
        private static bool MatchesNumber(Person person, int number) => person switch
        {
            Customer customer => customer.CustomerNumber == number,
            Employee employee => employee.EmployeeNumber == number,
            _ => false
        };
    }
}