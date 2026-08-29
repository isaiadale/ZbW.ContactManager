using ContactManager.Model.Security;

namespace ContactManager.Persistence.Json
{
    /// <summary>
    /// Die Business-Schicht kennt nur diesen Vertrag, nicht die konkrete JSON-Implementierung.
    /// Analog zu <see cref="IContactRepository"/>, aber für den Benutzerbestand.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Lädt den kompletten Benutzerbestand. Liefert einen leeren Bestand,
        /// wenn noch nichts gespeichert wurde (Datei fehlt) – wirft dann NICHT.
        /// </summary>
        UserData Load();

        /// <summary>
        /// Speichert den kompletten Benutzerbestand auf die Festplatte.
        /// </summary>
        void Save(UserData data);
    }
}
