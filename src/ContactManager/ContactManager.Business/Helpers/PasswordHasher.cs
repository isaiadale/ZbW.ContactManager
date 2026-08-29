using System;
using System.Security.Cryptography;

namespace ContactManager.Business.Helpers
{
    /// <summary>
    /// Kapselt das Ableiten und Prüfen von Passwort-Hashes nach PBKDF2. Kennt nur
    /// primitive Werte (Passwort, Salt, Iterationen) – das Zusammensetzen zu einem
    /// <see cref="ContactManager.Model.Security.User"/> übernimmt der aufrufende Service.
    /// </summary>
    internal static class PasswordHasher
    {
        /// <summary>Länge des Hashes in Bytes (256 Bit, passend zu SHA-256).</summary>
        private const int HashSizeInBytes = 32;

        /// <summary>Länge des Salts in Bytes.</summary>
        private const int SaltSizeInBytes = 16;

        /// <summary>
        /// Erzeugt einen kryptografisch zufälligen Salt. Bewusst <see cref="RandomNumberGenerator"/>
        /// statt <see cref="Random"/>: Ein gewöhnlicher Zufallsgenerator ist vorhersagbar
        /// und für Salts ungeeignet.
        /// </summary>
        /// <returns>Ein neuer, zufälliger Salt fester Länge.</returns>
        internal static byte[] CreateSalt()
        {
            return RandomNumberGenerator.GetBytes(SaltSizeInBytes);
        }

        /// <summary>
        /// Leitet aus Passwort, Salt und Iterationszahl einen Hash ab (PBKDF2/SHA-256)
        /// und liefert ihn Base64-kodiert – so lässt er sich unmittelbar in JSON ablegen.
        /// </summary>
        /// <param name="password">Das Klartextpasswort.</param>
        /// <param name="salt">Der zugehörige Salt.</param>
        /// <param name="iterations">Die Anzahl Ableitungs-Iterationen.</param>
        /// <returns>Der abgeleitete Hash, Base64-kodiert.</returns>
        internal static string ComputeHash(string password, byte[] salt, int iterations)
        {
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, iterations, HashAlgorithmName.SHA256, HashSizeInBytes);

            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Prüft ein eingegebenes Passwort gegen einen gespeicherten Hash. Ein unlesbarer
        /// Salt/Hash (z. B. nach manueller Bearbeitung der Datei) oder eine ungültige
        /// Iterationszahl gelten als "nicht authentifiziert" statt die Anwendung abstürzen
        /// zu lassen.
        /// </summary>
        /// <param name="password">Das eingegebene Klartextpasswort.</param>
        /// <param name="saltBase64">Der gespeicherte Salt, Base64-kodiert.</param>
        /// <param name="hashBase64">Der gespeicherte Hash, Base64-kodiert.</param>
        /// <param name="iterations">Die Anzahl Iterationen, mit der der Hash entstand.</param>
        /// <returns><c>true</c>, wenn das Passwort zum gespeicherten Hash passt.</returns>
        internal static bool Verify(string password, string saltBase64, string hashBase64, int iterations)
        {
            if (iterations <= 0)
                return false;

            byte[] expected;
            byte[] salt;

            try
            {
                expected = Convert.FromBase64String(hashBase64);
                salt = Convert.FromBase64String(saltBase64);
            }
            catch (FormatException)
            {
                // Salt oder Hash sind kein gültiges Base64 - fachlich "nicht authentifiziert",
                // kein technischer Fehler, der die Anwendung beenden müsste.
                return false;
            }

            byte[] actual = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, iterations, HashAlgorithmName.SHA256, expected.Length);

            // Zeitkonstanter Vergleich: Ein gewöhnlicher Vergleich bricht beim ersten
            // abweichenden Byte ab, wodurch die Laufzeit vom Inhalt abhängt (Timing-Angriff).
            // FixedTimeEquals braucht unabhängig vom Inhalt immer gleich lang.
            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
    }
}
