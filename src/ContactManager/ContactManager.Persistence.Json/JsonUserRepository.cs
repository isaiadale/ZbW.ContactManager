using System;
using System.IO;
using System.Text.Json;
using ContactManager.Model.Security;

namespace ContactManager.Persistence.Json
{
    /// <summary>
    /// Speichert und lädt den Benutzerbestand als JSON-Datei. Strukturell das
    /// Gegenstück zu <see cref="JsonContactRepository"/>, nur für eine eigene Datei
    /// (<c>users.json</c>) statt für den Kontaktstamm – Zugangsdaten und Kontaktdaten
    /// haben nichts miteinander zu tun und teilen sich deshalb keine Datei.
    /// </summary>
    public class JsonUserRepository : IUserRepository
    {
        private readonly string _filePath;

        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true
        };

        /// <summary>
        /// Erstellt das Repository. Ohne Angabe wird die Datei neben der Exe abgelegt
        /// (<c>users.json</c>); ein abweichender Pfad ist optional, z. B. für Tests.
        /// </summary>
        /// <param name="filePath">Abweichender Dateipfad, oder <c>null</c> für den Standardpfad.</param>
        public JsonUserRepository(string? filePath = null)
        {
            _filePath = filePath ?? Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "users.json");
        }

        /// <inheritdoc/>
        public UserData Load()
        {
            if (!File.Exists(_filePath))
                return new UserData();

            try
            {
                var json = File.ReadAllText(_filePath);
                var data = JsonSerializer.Deserialize<UserData>(json, Options);
                return data ?? new UserData();
            }
            catch (Exception ex)
            {
                var backup = _filePath + $".backup_{DateTime.Now:yyyyMMdd_HHmmss}";
                File.Move(_filePath, backup);

                // Kein MessageBox hier — stattdessen Exception weitergeben.
                // Die UI-Schicht (WinForms) ist zuständig für die Anzeige.
                throw new InvalidDataException(
                    $"Benutzerdatei konnte leider nicht geladen werden. " +
                    $"Sicherungskopie wurde erstellt: {backup}", ex);
            }
        }

        /// <inheritdoc/>
        public void Save(UserData data)
        {
            var json = JsonSerializer.Serialize(data, Options);
            File.WriteAllText(_filePath, json);
        }
    }
}
