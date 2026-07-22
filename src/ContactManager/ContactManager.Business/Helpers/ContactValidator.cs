using System.Net.Mail;
using ContactManager.Business.Exceptions;
using ContactManager.Model;

namespace ContactManager.Business.Helpers
{
    /// <summary>
    /// Zentrale Eingabevalidierung der Business-Schicht. Prüft Geschäftsregeln, die das
    /// Model bewusst nicht kennt (z. B. leere Pflichtfelder, E-Mail-Format, Wertebereiche
    /// und feldübergreifende Bedingungen) und wirft bei Verstoss eine
    /// <see cref="ValidationException"/> mit anzeigbarer Meldung. Wird von den Services
    /// vor dem Erfassen und Mutieren aufgerufen, damit ungültige Daten nie persistiert werden.
    /// </summary>
    internal static class ContactValidator
    {
        /// <summary>
        /// Validiert eine Person passend zu ihrem konkreten Typ. Verzweigt über
        /// Pattern-Matching auf <see cref="Customer"/>, <see cref="Apprentice"/> bzw.
        /// <see cref="Employee"/>, sodass für Lernende automatisch auch die
        /// Mitarbeiter- und Personenregeln greifen.
        /// </summary>
        /// <param name="person">Der zu prüfende Kontakt.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="person"/> <c>null</c> ist.</exception>
        /// <exception cref="ValidationException">Wird geworfen, wenn eine Geschäftsregel verletzt ist.</exception>
        public static void Validate(Person person)
        {
            ArgumentNullException.ThrowIfNull(person);

            switch (person)
            {
                case Customer customer:
                    ValidateCustomer(customer);
                    break;
                case Apprentice apprentice:
                    ValidateApprentice(apprentice);
                    break;
                case Employee employee:
                    ValidateEmployee(employee);
                    break;
                default:
                    ValidatePerson(person);
                    break;
            }
        }

        /// <summary>Prüft die allen Personen gemeinsamen Felder (Name, E-Mail, Geburtsdatum).</summary>
        private static void ValidatePerson(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
                throw new ValidationException("Der Vorname darf nicht leer sein.");

            if (string.IsNullOrWhiteSpace(person.LastName))
                throw new ValidationException("Der Nachname darf nicht leer sein.");

            if (!string.IsNullOrWhiteSpace(person.Email) && !IsValidEmail(person.Email))
                throw new ValidationException($"Die E-Mail-Adresse \"{person.Email}\" hat kein gültiges Format.");

            if (person.DateOfBirth is DateOnly birth && birth > DateOnly.FromDateTime(DateTime.Today))
                throw new ValidationException("Das Geburtsdatum darf nicht in der Zukunft liegen.");
        }

        /// <summary>Prüft die Personendaten und – falls vorhanden – die Adresse eines Kunden.</summary>
        private static void ValidateCustomer(Customer customer)
        {
            ValidatePerson(customer);

            if (customer.Address is not null)
                ValidateAddress(customer.Address);
        }

        /// <summary>
        /// Prüft die Personendaten sowie die mitarbeiterspezifischen Wertebereiche
        /// (Beschäftigungsgrad, Kaderstufe), die Datumsreihenfolge und die Adressen.
        /// </summary>
        private static void ValidateEmployee(Employee employee)
        {
            ValidatePerson(employee);

            if (employee.EmploymentLevel is int level && (level < 0 || level > 100))
                throw new ValidationException("Der Beschäftigungsgrad muss zwischen 0 und 100 Prozent liegen.");

            if (employee.ManagementLevel is int management && (management < 0 || management > 5))
                throw new ValidationException("Die Kaderstufe muss zwischen 0 und 5 liegen.");

            if (employee.HireDate is DateOnly hire &&
                employee.TerminationDate is DateOnly termination &&
                termination < hire)
                throw new ValidationException("Das Austrittsdatum darf nicht vor dem Eintrittsdatum liegen.");

            if (employee.BusinessAddress is not null)
                ValidateAddress(employee.BusinessAddress);

            if (employee.HomeAddress is not null)
                ValidateAddress(employee.HomeAddress);
        }

        /// <summary>
        /// Prüft die Mitarbeiterdaten sowie die lehrspezifischen Regeln: Die Lehrdauer muss
        /// positiv sein und das aktuelle Lehrjahr darf sie nicht überschreiten.
        /// </summary>
        private static void ValidateApprentice(Apprentice apprentice)
        {
            ValidateEmployee(apprentice);

            if (apprentice.ApprenticeshipYears <= 0)
                throw new ValidationException("Die Anzahl Lehrjahre muss grösser als 0 sein.");

            if (apprentice.CurrentApprenticeshipYear is int current &&
                (current < 1 || current > apprentice.ApprenticeshipYears))
                throw new ValidationException("Das aktuelle Lehrjahr muss zwischen 1 und der Anzahl Lehrjahre liegen.");
        }

        /// <summary>Prüft eine Adresse auf gefüllte Pflichtfelder und eine gültige Schweizer PLZ.</summary>
        private static void ValidateAddress(Address address)
        {
            if (string.IsNullOrWhiteSpace(address.Street))
                throw new ValidationException("Die Strasse darf nicht leer sein.");

            if (string.IsNullOrWhiteSpace(address.City))
                throw new ValidationException("Der Ort darf nicht leer sein.");

            if (!IsValidSwissPostalCode(address.PostalCode))
                throw new ValidationException($"Die Postleitzahl \"{address.PostalCode}\" ist keine gültige Schweizer PLZ (4-stellig).");
        }

        /// <summary>Prüft, ob eine Zeichenkette dem Format einer Schweizer PLZ entspricht (genau 4 Ziffern).</summary>
        private static bool IsValidSwissPostalCode(string postalCode)
        {
            return postalCode.Length == 4 && postalCode.All(char.IsDigit);
        }

        /// <summary>Prüft, ob eine Zeichenkette als E-Mail-Adresse parsbar ist.</summary>
        private static bool IsValidEmail(string email)
        {
            return MailAddress.TryCreate(email, out _);
        }
    }
}
