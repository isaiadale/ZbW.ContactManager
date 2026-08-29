using System;
using ContactManager.Business.Helpers;
using ContactManager.Model.Security;
using ContactManager.Persistence.Json;

namespace ContactManager.Business.Services
{
    /// <summary>
    /// Prüft Anmeldedaten gegen den Benutzerbestand. Steht bewusst <b>ausserhalb</b> der
    /// <see cref="ContactManagerFacade"/>: Der Login muss laufen, bevor der Kontaktstamm
    /// geladen wird, und bricht der Login ab, wird <c>contacts.json</c> nie angefasst.
    /// Läge Auth in der Fassade, müsste dafür bereits der komplette Kontaktstamm geladen
    /// sein - genau verkehrt herum.
    /// </summary>
    /// <remarks>
    /// Der Konstruktor ist bewusst <c>public</c> statt wie bei den übrigen Services
    /// <c>internal</c>: Die anderen Services werden ausschliesslich über die Fassade
    /// erzeugt, dieser Service hat aber keine Fassade über sich - der Composition Root
    /// (<c>Program.cs</c>, ein anderes Assembly) muss ihn direkt bauen können.
    /// </remarks>
    public class AuthenticationService
    {
        /// <summary>Anzahl Iterationen, mit der neue Passwort-Hashes abgeleitet werden.</summary>
        private const int DefaultIterations = 210_000;

        private const string DefaultUserName = "admin";
        private const string DefaultPassword = "admin";

        private readonly IUserRepository _repo;

        private readonly UserData _data;

        /// <summary>
        /// Erzeugt den Service und lädt den Benutzerbestand. Ist noch kein einziger
        /// Benutzer erfasst (typischerweise beim allerersten Start, weil die Datei
        /// fehlt), wird automatisch ein Standardbenutzer angelegt und gespeichert -
        /// analog dazu, dass <see cref="JsonContactRepository"/> bei fehlender Datei
        /// einen leeren Datenstamm liefert statt zu werfen.
        /// </summary>
        /// <param name="repository">Repository zum Laden und Speichern des Benutzerbestands.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="repository"/> <c>null</c> ist.</exception>
        public AuthenticationService(IUserRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);

            _repo = repository;
            _data = _repo.Load();

            EnsureDefaultUser();
        }

        /// <summary>
        /// <c>true</c>, wenn beim Erzeugen dieses Services soeben der Standardbenutzer
        /// angelegt wurde. Die UI nutzt das, um beim allerersten Start einen Hinweis auf
        /// die Zugangsdaten des angelegten Kontos anzuzeigen.
        /// </summary>
        public bool DefaultUserCreated { get; private set; }

        /// <summary>
        /// Prüft, ob Benutzername und Passwort zu einem erfassten Konto passen.
        /// Ein unbekannter Benutzername und ein falsches Passwort liefern absichtlich
        /// beide <c>false</c>: Die Oberfläche darf nicht verraten, welcher der beiden
        /// Fälle vorliegt. Der Benutzername wird ohne Rücksicht auf Gross-/Kleinschreibung
        /// verglichen.
        /// </summary>
        /// <param name="userName">Der eingegebene Benutzername.</param>
        /// <param name="password">Das eingegebene Klartextpasswort.</param>
        /// <returns><c>true</c>, wenn die Anmeldedaten gültig sind.</returns>
        public bool ValidateCredentials(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrEmpty(password))
                return false;

            User? user = FindUser(userName);

            if (user is null)
                return false;

            return PasswordHasher.Verify(password, user.Salt, user.PasswordHash, user.Iterations);
        }

        private User? FindUser(string userName)
        {
            return _data.Users.Find(u =>
                string.Equals(u.UserName, userName, StringComparison.OrdinalIgnoreCase));
        }

        private void EnsureDefaultUser()
        {
            if (_data.Users.Count > 0)
            {
                DefaultUserCreated = false;
                return;
            }

            byte[] salt = PasswordHasher.CreateSalt();
            string hash = PasswordHasher.ComputeHash(DefaultPassword, salt, DefaultIterations);

            _data.Users.Add(new User
            {
                UserName = DefaultUserName,
                Salt = Convert.ToBase64String(salt),
                PasswordHash = hash,
                Iterations = DefaultIterations
            });

            _repo.Save(_data);

            DefaultUserCreated = true;
        }
    }
}
