using ContactManager.Model;

namespace ContactManager.Persistence.Json
{
    /// <summary>
    /// Die Business-Schicht kennt nur diesen Vertrag, nicht die konkrete JSON-Implementierung.
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>
        /// Lädt den kompletten Datenstamm. Liefert einen leeren Stamm,
        /// wenn noch nichts gespeichert wurde (Datei fehlt) – wirft dann NICHT.
        /// </summary>
        ContactData Load();

        /// <summary>
        /// Speichert den kompletten Datenstamm auf die Festplatte.
        /// </summary>
        /// <param name="data">Der vollständige Datenstamm, der die bestehende Ablage komplett ersetzt</param>
        void Save(ContactData data);
    }
}