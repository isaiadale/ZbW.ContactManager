using System.Text.Json;
using System.Text.Json.Serialization;
using ContactManager.Model;

namespace ContactManager.Persistence.Json;

/// <summary>
/// Speichert und lädt alle Kontakte als JSON-Datei auf der Festplatte.
/// </summary>
public class JsonContactRepository
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
    /// Serialisiert alle Kunden und Mitarbeiter und schreibt
    /// sie als JSON auf die Festplatte.
    /// </summary>
    public void Save(IEnumerable<Customer> customers,
                     IEnumerable<Employee> employees)
    {
        var container = new DataContainer
        {
            Customers = customers.ToList(),
            Employees = employees.ToList()
        };

        var json = JsonSerializer.Serialize(container, Options);
        File.WriteAllText(_filePath, json);
    }

    /// <summary>
    /// Liest die JSON-Datei und gibt Kunden und Mitarbeiter zurück.
    /// Gibt leere Listen zurück wenn die Datei noch nicht existiert.
    /// Bei defekter Datei wird eine Sicherungskopie erstellt.
    /// </summary>
    public (List<Customer> Customers, List<Employee> Employees) Load()
    {
        var leer = (new List<Customer>(), new List<Employee>());

        if (!File.Exists(_filePath))
            return leer;

        try
        {
            var json = File.ReadAllText(_filePath);
            var container = JsonSerializer
                .Deserialize<DataContainer>(json, Options);

            return container is null
                ? leer
                : (container.Customers, container.Employees);
        }
        catch (Exception ex)
        {
            var backup = _filePath +
                $".backup_{DateTime.Now:yyyyMMdd_HHmmss}";
            File.Move(_filePath, backup);

            // Kein MessageBox hier — stattdessen Exception weitergeben.
            // Die UI-Schicht (WinForms) ist zuständig für die Anzeige.
            throw new InvalidDataException(
                $"Datendatei konnte nicht geladen werden. " +
                $"Sicherungskopie erstellt: {backup}", ex);
        }
    }
}