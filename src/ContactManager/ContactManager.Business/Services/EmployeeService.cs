using ContactManager.Model;
using ContactManager.Model.Enums;
using ContactManager.Persistence.Json;


namespace ContactManager.Business.Services
{
    /// <summary>
    /// Geschäftslogik für Mitarbeiter: Lesen, Erfassen, Mutieren, Löschen sowie
    /// Aktivieren und Deaktivieren. Arbeitet auf dem geladenen Datenstamm
    /// (<see cref="ContactData"/>) und persistiert Änderungen über das
    /// <see cref="IContactRepository"/>.
    /// </summary>
    public class EmployeeService
    {
        private readonly IContactRepository _repo;

        private readonly ContactData _data;

        /// <summary>
        /// Erzeugt den Service auf Basis des bereits geladenen Datenstamms.
        /// Wird von der Fassade aufgebaut, nicht direkt von der UI.
        /// </summary>
        /// <param name="repo">Repository zum Persistieren des Datenstamms.</param>
        /// <param name="data">Der vollständige, bereits geladene Datenstamm.</param>
        internal EmployeeService(IContactRepository repo, ContactData data)
        {
            ArgumentNullException.ThrowIfNull(repo);
            ArgumentNullException.ThrowIfNull(data);

            _repo = repo;
            _data = data;
        }

        /// <summary>
        /// Gibt alle erfassten Mitarbeiter zurück.
        /// Änderungen laufen ausschliesslich über die Methoden dieses Service.
        /// </summary>
        /// <returns>Alle Mitarbeiter des Datenstamms.</returns>
        public IReadOnlyList<Employee> GetAll()
        {
            return _data.Employees;
        }

        /// <summary>
        /// Sucht einen Mitarbeiter anhand seiner eindeutigen Id.
        /// </summary>
        /// <param name="id">Die Id des gesuchten Mitarbeiters.</param>
        /// <returns>Der gefundene Mitarbeiter oder <c>null</c>, wenn kein Mitarbeiter mit dieser Id existiert.</returns>
        public Employee? GetById(Guid id)
        {
            return _data.Employees.Find(c => c.Id == id);
        }

        /// <summary>
        /// Sucht einen Mitarbeiter anhand seiner Mitarbeiternummer.
        /// </summary>
        /// <param name="employeeNumber">Die Mitarbeiternummer des gesuchten Mitarbeiters.</param>
        /// <returns>Der gefundene Mitarbeiter oder <c>null</c>, wenn kein Mitarbeiter mit dieser Mitarbeiternummer existiert.</returns>
        public Employee? GetByNumber(int employeeNumber)
        {
            return _data.Employees.Find(c => c.EmployeeNumber == employeeNumber);
        }

        /// <summary>
        /// Fügt einen neuen Mitarbeiter zum Datenstamm hinzu und speichert die Änderung.
        /// </summary>
        /// <param name="employee">Der neu zu erfassende Mitarbeiter.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="employee"/> <c>null</c> ist.</exception>
        /// <exception cref="InvalidOperationException">
        /// Wird geworfen, wenn bereits ein Mitarbeiter mit derselben Id erfasst ist oder wenn dem
        /// übergebenen Mitarbeiter bereits eine Mitarbeiternummer zugewiesen wurde.
        /// </exception>
        public void Add(Employee employee)
        {
            ArgumentNullException.ThrowIfNull(employee);

            if (_data.Employees.Exists(c => c.Id == employee.Id))
                throw new InvalidOperationException($"Ein Mitarbeiter mit der Id: {employee.Id} ist bereits erfasst.");

            int nextNumber = _data.LastEmployeeNumber + 1;
            employee.AssignEmployeeNumber(nextNumber);
            _data.LastEmployeeNumber = nextNumber;

            _data.Employees.Add(employee);

            SaveChanges();
        }

        /// <summary>
        /// Überträgt die geänderten Daten auf den bestehenden Mitarbeiter mit derselben Id und speichert die Änderung.
        /// </summary>
        /// <param name="employee">Der Mitarbeiter mit aktualisierten Daten; wird über seine Id zugeordnet.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="employee"/> <c>null</c> ist.</exception>
        /// <exception cref="KeyNotFoundException">Wird geworfen, wenn kein Mitarbeiter mit dieser Id erfasst ist.</exception>
        public void Update(Employee employee)
        {
            ArgumentNullException.ThrowIfNull(employee);

            Employee existing = GetRequired(employee.Id);

            // Id und EmployeeNumber werden bewusst nicht übernommen: Beide bilden die
            // Identität des Mitarbeiters und bleiben unverändert. Das Model erzwingt das
            // bereits (Id ist "init", EmployeeNumber hat "private set").
            existing.Salutation = employee.Salutation;
            existing.FirstName = employee.FirstName;
            existing.LastName = employee.LastName;
            existing.DateOfBirth = employee.DateOfBirth;
            existing.Gender = employee.Gender;
            existing.MobilePhone = employee.MobilePhone;
            existing.BusinessPhone = employee.BusinessPhone;
            existing.Email = employee.Email;
            existing.PersonStatus = employee.PersonStatus;

            existing.Department = employee.Department;
            existing.SocialSecurityNumber = employee.SocialSecurityNumber;
            existing.Nationality = employee.Nationality;
            existing.HireDate = employee.HireDate;
            existing.TerminationDate = employee.TerminationDate;
            existing.EmploymentLevel = employee.EmploymentLevel;
            existing.JobTitle = employee.JobTitle;
            existing.ManagementLevel = employee.ManagementLevel;
            existing.BusinessAddress = employee.BusinessAddress;
            existing.HomeAddress = employee.HomeAddress;

            // Ist der Datensatz ein Lernender, werden zusätzlich dessen lehrspezifische
            // Felder übernommen. Nur wenn beide Instanzen Lernende sind – ein Wechsel des
            // Typs (Mitarbeiter <-> Lernender) wird über Update bewusst nicht unterstützt.
            if (existing is Apprentice existingApprentice && employee is Apprentice updatedApprentice)
            {
                existingApprentice.ApprenticeshipYears = updatedApprentice.ApprenticeshipYears;
                existingApprentice.CurrentApprenticeshipYear = updatedApprentice.CurrentApprenticeshipYear;
            }

            SaveChanges();
        }

        /// <summary>
        /// Entfernt den Mitarbeiter mit der angegebenen Id aus dem Datenstamm und speichert die Änderung.
        /// </summary>
        /// <param name="id">Die Id des zu löschenden Mitarbeiters.</param>
        /// <exception cref="KeyNotFoundException">Wird geworfen, wenn kein Mitarbeiter mit dieser Id erfasst ist.</exception>
        public void Delete(Guid id)
        {
            Employee existing = GetRequired(id);

            _data.Employees.Remove(existing);

            SaveChanges();
        }

        /// <summary>
        /// Setzt den Status des Mitarbeiters mit der angegebenen Id auf aktiv
        /// (<see cref="Person.PersonStatus"/> = <c>Active</c>) und speichert die Änderung.
        /// </summary>
        /// <param name="id">Die Id des zu aktivierenden Mitarbeiters.</param>
        /// <exception cref="KeyNotFoundException">Wird geworfen, wenn kein Mitarbeiter mit dieser Id erfasst ist.</exception>
        public void Activate(Guid id)
        {
            GetRequired(id).PersonStatus = Status.Active;

            SaveChanges();
        }

        /// <summary>
        /// Setzt den Status des Mitarbeiters mit der angegebenen Id auf passiv
        /// (<see cref="Person.PersonStatus"/> = <c>Passive</c>) und speichert die Änderung.
        /// </summary>
        /// <param name="id">Die Id des zu deaktivierenden Mitarbeiters.</param>
        /// <exception cref="KeyNotFoundException">Wird geworfen, wenn kein Mitarbeiter mit dieser Id erfasst ist.</exception>
        public void Deactivate(Guid id)
        {
            GetRequired(id).PersonStatus = Status.Passive;

            SaveChanges();
        }

        /// <summary>
        /// Sucht den Mitarbeiter mit der angegebenen Id im Datenstamm und wirft, wenn es ihn
        /// nicht gibt. Gemeinsame Grundlage aller Methoden, die einen bestehenden Mitarbeiter
        /// voraussetzen — im Gegensatz zu <see cref="GetById"/>, das <c>null</c> zurückgibt.
        /// </summary>
        /// <param name="id">Die Id des gesuchten Mitarbeiters.</param>
        /// <returns>Der gefundene Mitarbeiter; nie <c>null</c>.</returns>
        /// <exception cref="KeyNotFoundException">Wird geworfen, wenn kein Mitarbeiter mit dieser Id erfasst ist.</exception>
        private Employee GetRequired(Guid id)
        {
            Employee? employee = GetById(id);

            if (employee is null)
                throw new KeyNotFoundException($"Es ist kein Mitarbeiter mit der Id: {id} erfasst.");

            return employee;
        }

        private void SaveChanges()
        {
            _repo.Save(_data);
        }
    }
}
