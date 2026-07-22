using ContactManager.Business.Helpers;
using ContactManager.Model;
using ContactManager.Model.Enums;
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
        /// Gibt alle erfassten Kunden zurück.
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
        /// Sucht einen Kunden anhand seiner Kundennummer.
        /// </summary>
        /// <param name="customerNumber">Die Kundennummer des gesuchten Kunden.</param>
        /// <returns>Der gefundene Kunde oder <c>null</c>, wenn kein Kunde mit dieser Kundennummer existiert.</returns>
        public Customer? GetByNumber(int customerNumber)
        {
            return _data.Customers.Find(c => c.CustomerNumber == customerNumber);
        }

        /// <summary>
        /// Fügt einen neuen Kunden zum Datenstamm hinzu und speichert die Änderung.
        /// </summary>
        /// <param name="customer">Der neu zu erfassende Kunde.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="customer"/> <c>null</c> ist.</exception>
        /// <exception cref="InvalidOperationException">
        /// Wird geworfen, wenn bereits ein Kunde mit derselben Id erfasst ist oder wenn dem
        /// übergebenen Kunden bereits eine Kundennummer zugewiesen wurde.
        /// </exception>
        public void Add(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            if (_data.Customers.Exists(c => c.Id == customer.Id))
               throw new InvalidOperationException($"Ein Kunde mit der Id: {customer.Id} ist bereits erfasst.");

            ContactValidator.Validate(customer);

            customer.AssignCustomerNumber(NumberGenerator.NextCustomerNumber(_data));

            _data.Customers.Add(customer);

            SaveChanges();
        }

        /// <summary>
        /// Überträgt die geänderten Daten auf den bestehenden Kunden mit derselben Id und speichert die Änderung.
        /// </summary>
        /// <param name="customer">Der Kunde mit aktualisierten Daten; wird über seine Id zugeordnet.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="customer"/> <c>null</c> ist.</exception>
        /// <exception cref="KeyNotFoundException">Wird geworfen, wenn kein Kunde mit dieser Id erfasst ist.</exception>
        public void Update(Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            ContactValidator.Validate(customer);

            Customer existing = GetRequired(customer.Id);

            // Id und CustomerNumber werden bewusst nicht übernommen: Beide bilden die
            // Identität des Kunden und bleiben unverändert. Das Model erzwingt das
            // bereits (Id ist "init", CustomerNumber hat "private set").
            existing.Salutation = customer.Salutation;
            existing.FirstName = customer.FirstName;
            existing.LastName = customer.LastName;
            existing.DateOfBirth = customer.DateOfBirth;
            existing.Gender = customer.Gender;
            existing.MobilePhone = customer.MobilePhone;
            existing.BusinessPhone = customer.BusinessPhone;
            existing.Email = customer.Email;
            existing.PersonStatus = customer.PersonStatus;

            existing.Title = customer.Title;
            existing.Address = customer.Address;

            SaveChanges();
        }

        /// <summary>
        /// Entfernt den Kunden mit der angegebenen Id aus dem Datenstamm und speichert die Änderung.
        /// </summary>
        /// <param name="id">Die Id des zu löschenden Kunden.</param>
        /// <exception cref="KeyNotFoundException">Wird geworfen, wenn kein Kunde mit dieser Id erfasst ist.</exception>
        public void Delete(Guid id)
        {
            Customer existing = GetRequired(id);

            _data.Customers.Remove(existing);

            SaveChanges();
        }

        /// <summary>
        /// Setzt den Status des Kunden mit der angegebenen Id auf aktiv
        /// (<see cref="Person.PersonStatus"/> = <c>Active</c>) und speichert die Änderung.
        /// </summary>
        /// <param name="id">Die Id des zu aktivierenden Kunden.</param>
        /// <exception cref="KeyNotFoundException">Wird geworfen, wenn kein Kunde mit dieser Id erfasst ist.</exception>
        public void Activate(Guid id)
        {
            GetRequired(id).PersonStatus = Status.Active;

            SaveChanges();
        }

        /// <summary>
        /// Setzt den Status des Kunden mit der angegebenen Id auf passiv
        /// (<see cref="Person.PersonStatus"/> = <c>Passive</c>) und speichert die Änderung.
        /// </summary>
        /// <param name="id">Die Id des zu deaktivierenden Kunden.</param>
        /// <exception cref="KeyNotFoundException">Wird geworfen, wenn kein Kunde mit dieser Id erfasst ist.</exception>
        public void Deactivate(Guid id)
        {
            GetRequired(id).PersonStatus = Status.Passive;

            SaveChanges();
        }

        /// <summary>
        /// Sucht den Kunden mit der angegebenen Id im Datenstamm und wirft, wenn es ihn
        /// nicht gibt. Gemeinsame Grundlage aller Methoden, die einen bestehenden Kunden
        /// voraussetzen — im Gegensatz zu <see cref="GetById"/>, das <c>null</c> zurückgibt.
        /// </summary>
        /// <param name="id">Die Id des gesuchten Kunden.</param>
        /// <returns>Der gefundene Kunde; nie <c>null</c>.</returns>
        /// <exception cref="KeyNotFoundException">Wird geworfen, wenn kein Kunde mit dieser Id erfasst ist.</exception>
        private Customer GetRequired(Guid id)
        {
            Customer? customer = GetById(id);

            if (customer is null)
                throw new KeyNotFoundException($"Es ist kein Kunde mit der Id: {id} erfasst.");

            return customer;
        }

        private void SaveChanges()
        {
            _repo.Save(_data);
        }
    }
}
