using ContactManager.Business;
using ContactManager.Persistence.Json;
using ContactManager.UI.WinForms.Forms;

namespace ContactManager.UI.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // Bewusst als Erstes: Schlägt das Laden unten fehl, hat die Fehlermeldung
            // bereits die konfigurierte Schrift und DPI-Einstellung.
            ApplicationConfiguration.Initialize();

            // Composition Root: die einzige Stelle der Anwendung, an der die konkrete
            // Ablage bekannt ist. Alle Formulare kennen ab hier nur noch die Fassade.
            ContactManagerFacade contacts;

            try
            {
                IContactRepository repository = new JsonContactRepository();
                contacts = new ContactManagerFacade(repository);
            }
            catch (InvalidDataException ex)
            {
                // Die Datendatei ist beschädigt. Das Repository hat vorher bereits eine
                // Sicherungskopie angelegt; die Meldung nennt deren Pfad. Geordnet beenden,
                // statt die Anwendung mit einem unbehandelten Fehler starten zu lassen.
                MessageBox.Show(
                    ex.Message,
                    "Daten konnten nicht geladen werden",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Rückkehr aus Main beendet den Prozess sauber – Application.Run läuft noch nicht.
                return;
            }

            Application.Run(new MainForm(contacts));
            // Application.Run(new EmployeeDetailForm()); // Nur zum Testen einkommentieren
        }
    }
}
