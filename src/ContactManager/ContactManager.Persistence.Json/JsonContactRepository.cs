using System.Text.Json;
using System.Text.Json.Serialization;
using ContactManager.Model;

namespace ContactManager.Persistence.Json;

/// <summary>
/// Speichert und lädt den kompletten Datenstamm als JSON-Datei auf der Festplatte.
/// </summary>
public class JsonContactRepository : IContactRepository
{
    private readonly string _filePath;

    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public JsonContactRepository(string? filePath = null)
    {
        _filePath = filePath ?? Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "contacts.json");
    }

    /// <summary>
    /// Lädt den kompletten Datenstamm. 
    /// Liefert einen leeren Stamm,
    /// wenn noch nichts gespeichert wurde (Datei fehlt) – wird kein Fehler geworfen!
    /// </summary>
    public ContactData Load()
    {
        if (!File.Exists(_filePath))
            return new ContactData();

        try
        {
            var json = File.ReadAllText(_filePath);
            var data = JsonSerializer.Deserialize<ContactData>(json, Options);
            return data ?? new ContactData();
        }
        catch (Exception ex)
        {
            var backup = _filePath +
                $".backup_{DateTime.Now:yyyyMMdd_HHmmss}";
            File.Move(_filePath, backup);

            // Kein MessageBox hier — stattdessen Exception weitergeben.
            // Die UI-Schicht (WinForms) ist zuständig für die Anzeige.
            throw new InvalidDataException(
                $"Datendatei konnte leider nicht geladen werden. " +
                $"Sicherungskopie wurde erstellt: {backup}", ex);
        }
    }

    /// <summary>
    /// Speichert den kompletten Datenstamm auf die Festplatte.
    /// </summary>
    public void Save(ContactData data)
    {
        var json = JsonSerializer.Serialize(data, Options);
        File.WriteAllText(_filePath, json);
    }
}