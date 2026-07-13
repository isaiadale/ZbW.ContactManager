namespace ContactManager.Model
{
    /// <summary>Kompletter Datenstamm der Anwendung – die Einheit, die persistiert wird.</summary>
    public class ContactData
    {
        /// <summary>Alle erfassten Kunden.</summary>
        public List<Customer> Customers { get; init; } = new();

        /// <summary>Alle erfassten Mitarbeiter inkl. Lernende.</summary>
        public List<Employee> Employees { get; init; } = new();

        /// <summary>Zuletzt vergebene Mitarbeiternummer, damit der Zähler nach Neustart weiterläuft.</summary>
        public int LastEmployeeNumber { get; set; }
    }
}
