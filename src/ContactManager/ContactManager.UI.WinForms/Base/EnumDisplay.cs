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
            _ => salutation.ToString()
        };
    }
}
