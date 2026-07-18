using ContactManager.Model;
using ContactManager.Persistence.Json;

namespace ContactManager.Business.Services
{
    /// <summary>
    /// Geschäftslogik für Kunden: Lesen, Erfassen, Mutieren, Löschen sowie
    /// Aktivieren und Deaktivieren. Arbeitet auf dem geladenen Datenstamm
    /// (<see cref="ContactData"/>) und persistiert Änderungen über das
    /// <see cref="IContactRepository"/>.
    /// </summary>
    public class CustomerService
    {
        private readonly IContactRepository _repo;

        private readonly ContactData _data;

        /// <summary>
        /// Erzeugt den Service auf Basis des bereits geladenen Datenstamms.
        /// Wird von der Fassade aufgebaut, nicht direkt von der UI.
        /// </summary>
        /// <param name="repo">Repository zum Persistieren des Datenstamms.</param>
        /// <param name="data">Der vollständige, bereits geladene Datenstamm.</param>
        internal CustomerService(IContactRepository repo, ContactData data)
        {
            ArgumentNullException.ThrowIfNull(repo);
            ArgumentNullException.ThrowIfNull(data);

            _repo = repo;
            _data = data;
        }

        /// <summary>
        /// Gibt alle erfassten Kunden zurück. Die Liste ist schreibgeschützt;
        /// Änderungen laufen ausschliesslich über die Methoden dieses Service.
        /// </summary>
        /// <returns>Alle Kunden des Datenstamms.</returns>
        public IReadOnlyList<Customer> GetAll()
        {
            return _data.Customers;
        }

        /// <summary>
        /// Sucht einen Kunden anhand seiner eindeutigen Id.
        /// </summary>
        /// <param name="id">Die Id des gesuchten Kunden.</param>
        /// <returns>Der gefundene Kunde oder <c>null</c>, wenn kein Kunde mit dieser Id existiert.</returns>
        public Customer? GetById(Guid id)
        {
            return _data.Customers.Find(c => c.Id == id);
        }

        /// <summary>
        /// Fügt einen neuen Kunden zum Datenstamm hinzu und speichert die Änderung.
        /// </summary>
        /// <param name="customer">Der neu zu erfassende Kunde.</param>
        public void Add(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            if (_data.Customers.Exists(c => c.Id == customer.Id))
               throw new InvalidOperationException($"Ein Kunde mit der Id: {customer.Id} ist bereits erfasst.");

            int nextNummer = _data.LastCustomerNumber + 1;
            customer.AssignCustomerNumber(nextNummer);
            _data.LastCustomerNumber = nextNummer;

            _data.Customers.Add(customer);

            SaveChanges();
        }

        /// <summary>
        /// Ersetzt einen bestehenden Kunden anhand seiner Id durch die übergebene
        /// Version und speichert die Änderung.
        /// </summary>
        /// <param name="customer">Der Kunde mit aktualisierten Daten; wird über seine Id zugeordnet.</param>
        public void Update(Customer customer)
        {

        }

        /// <summary>
        /// Entfernt den Kunden mit der angegebenen Id aus dem Datenstamm und speichert die Änderung.
        /// </summary>
        /// <param name="id">Die Id des zu löschenden Kunden.</param>
        public void Delete(Guid id)
        {

        }

        /// <summary>
        /// Setzt den Status des Kunden mit der angegebenen Id auf aktiv
        /// (<see cref="Customer.CustomerStatus"/> = <c>Active</c>) und speichert die Änderung.
        /// </summary>
        /// <param name="id">Die Id des zu aktivierenden Kunden.</param>
        public void Activate(Guid id)
        {

        }

        /// <summary>
        /// Setzt den Status des Kunden mit der angegebenen Id auf passiv
        /// (<see cref="Customer.CustomerStatus"/> = <c>Passive</c>) und speichert die Änderung.
        /// </summary>
        /// <param name="id">Die Id des zu deaktivierenden Kunden.</param>
        public void Deactivate(Guid id)
        {

        }

        private void SaveChanges()
        {
            _repo.Save(_data);
        }
    }
}
