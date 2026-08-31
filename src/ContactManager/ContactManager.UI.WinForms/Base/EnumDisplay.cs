using System;
using ContactManager.Model.Enums;

namespace ContactManager.UI.WinForms.Base
{
    /// <summary>
    /// Übersetzt die Enum-Werte des Models in deutsche Beschriftungen für die Oberfläche.
    /// Bewusst in der UI-Schicht angesiedelt: Das Model bleibt sprachneutral (englische
    /// Bezeichner), die Übersetzung ist reine Darstellung und geht nur die Anzeige an.
    /// </summary>
    public static class EnumDisplay
    {
        /// <summary>
        /// Liefert die deutsche Beschriftung eines <see cref="Status"/>-Wertes.
        /// </summary>
        /// <param name="status">Der anzuzeigende Status.</param>
        /// <returns>„Aktiv" bzw. „Passiv"; bei unbekanntem Wert dessen Name.</returns>
        public static string ToText(Status status) => status switch
        {
            Status.Active => "Aktiv",
            Status.Passive => "Passiv",
            _ => status.ToString()
        };

        /// <summary>
        /// Liefert die deutsche Beschriftung eines <see cref="Gender"/>-Wertes.
        /// </summary>
        /// <param name="gender">Das anzuzeigende Geschlecht.</param>
        /// <returns>Die deutsche Bezeichnung; bei unbekanntem Wert dessen Name.</returns>
        public static string ToText(Gender gender) => gender switch
        {
            Gender.Male => "Männlich",
            Gender.Female => "Weiblich",
            Gender.Diverse => "Divers",
            _ => gender.ToString()
        };

        /// <summary>
        /// Liefert die deutsche Beschriftung einer <see cref="Salutation"/>.
        /// </summary>
        /// <param name="salutation">Die anzuzeigende Anrede.</param>
        /// <returns>Die deutsche Anrede; bei unbekanntem Wert deren Name.</returns>
        public static string ToText(Salutation salutation) => salutation switch
        {
            Salutation.Mr => "Herr",
            Salutation.Mrs => "Frau",
            Salutation.None => "Keine Anrede",
            _ => salutation.ToString()
        };

        // Die folgenden drei Methoden sind die Umkehrung von ToText: Sie werden vom
        // CSV-Import gebraucht, der die deutschen Beschriftungen aus der Datei wieder in
        // Enum-Werte zurückübersetzen muss. Akzeptiert wird sowohl die deutsche
        // Beschriftung als auch der rohe Enum-Name (z. B. "Active" statt "Aktiv") - so
        // liest der Import auch eine Datei ein, die nicht mit "CSV Export" erzeugt wurde.
        //
        // Das Enum.IsDefined hinter jedem Enum.TryParse ist kein Zierrat: TryParse allein
        // akzeptiert auch Zahlen und meldet für "9" brav Erfolg, obwohl (Gender)9 gar
        // nicht existiert. Ohne die Prüfung landete so ein Wert unbemerkt im Datenstamm
        // und würde in der Liste als nackte Zahl angezeigt.

        /// <summary>Versucht, eine Beschriftung (deutsch oder Enum-Name) in einen <see cref="Status"/> zu übersetzen.</summary>
        /// <param name="text">Die zu übersetzende Beschriftung.</param>
        /// <param name="status">Der erkannte Wert, falls die Methode <c>true</c> zurückgibt.</param>
        /// <returns><c>true</c>, wenn <paramref name="text"/> erkannt wurde.</returns>
        public static bool TryParseStatus(string? text, out Status status)
        {
            switch (text?.Trim().ToLowerInvariant())
            {
                case "aktiv":
                    status = Status.Active;
                    return true;
                case "passiv":
                    status = Status.Passive;
                    return true;
                default:
                    return Enum.TryParse(text, ignoreCase: true, out status) && Enum.IsDefined(status);
            }
        }

        /// <summary>Versucht, eine Beschriftung (deutsch oder Enum-Name) in ein <see cref="Gender"/> zu übersetzen.</summary>
        /// <param name="text">Die zu übersetzende Beschriftung.</param>
        /// <param name="gender">Der erkannte Wert, falls die Methode <c>true</c> zurückgibt.</param>
        /// <returns><c>true</c>, wenn <paramref name="text"/> erkannt wurde.</returns>
        public static bool TryParseGender(string? text, out Gender gender)
        {
            switch (text?.Trim().ToLowerInvariant())
            {
                case "männlich":
                    gender = Gender.Male;
                    return true;
                case "weiblich":
                    gender = Gender.Female;
                    return true;
                case "divers":
                    gender = Gender.Diverse;
                    return true;
                default:
                    return Enum.TryParse(text, ignoreCase: true, out gender) && Enum.IsDefined(gender);
            }
        }

        /// <summary>Versucht, eine Beschriftung (deutsch oder Enum-Name) in eine <see cref="Salutation"/> zu übersetzen.</summary>
        /// <param name="text">Die zu übersetzende Beschriftung.</param>
        /// <param name="salutation">Der erkannte Wert, falls die Methode <c>true</c> zurückgibt.</param>
        /// <returns><c>true</c>, wenn <paramref name="text"/> erkannt wurde.</returns>
        public static bool TryParseSalutation(string? text, out Salutation salutation)
        {
            switch (text?.Trim().ToLowerInvariant())
            {
                case "herr":
                    salutation = Salutation.Mr;
                    return true;
                case "frau":
                    salutation = Salutation.Mrs;
                    return true;
                case "keine anrede":
                    salutation = Salutation.None;
                    return true;
                default:
                    return Enum.TryParse(text, ignoreCase: true, out salutation) && Enum.IsDefined(salutation);
            }
        }
    }
}
