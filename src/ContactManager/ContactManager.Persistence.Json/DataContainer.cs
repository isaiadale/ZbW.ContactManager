using ContactManager.Model;

namespace ContactManager.Persistence.Json;

/// <summary>
/// Internes Hüllobjekt für die JSON-Serialisierung.
/// Fasst Kunden und Mitarbeiter zusammen, damit alles
/// in einer einzigen Datei gespeichert wird.
/// </summary>
internal class DataContainer
{
    public List<Customer> Customers { get; set; } = new();
    public List<Employee> Employees { get; set; } = new();
}