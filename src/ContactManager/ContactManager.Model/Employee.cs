using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ContactManager.Model
{
    /// <summary>
    /// Ein Mitarbeiterkontakt. Erbt die gemeinsamen Personendaten von <see cref="Person"/>
    /// und ergänzt sie um beschäftigungsspezifische Informationen.
    /// </summary>
    /// <remarks>
    /// Lernende liegen in <see cref="ContactData.Employees"/> als <see cref="Employee"/>.
    /// System.Text.Json schreibt aber standardmässig nur die Eigenschaften des
    /// <i>deklarierten</i> Typs - ohne die Registrierung unten gingen beim Speichern die
    /// Lehrjahre und die Typinformation verloren, und eine lernende Person wäre nach dem
    /// nächsten Programmstart ein gewöhnlicher Mitarbeiter.
    /// <para>
    /// Der Diskriminator erscheint als <c>"$type": "Apprentice"</c> in der JSON-Datei, und
    /// zwar nur bei Lernenden. Bestehende Datensätze ohne dieses Feld werden unverändert
    /// als <see cref="Employee"/> gelesen; die Datei muss also nicht neu aufgebaut werden.
    /// </para>
    /// <para>
    /// <b>Jede weitere Klasse, die von <see cref="Employee"/> erbt, gehört hier ebenfalls
    /// eingetragen.</b> Ein nicht registrierter Untertyp wird beim Speichern nicht mehr
    /// stillschweigend als <see cref="Employee"/> geschrieben, sondern quittiert mit einer
    /// <see cref="System.NotSupportedException"/>.
    /// </para>
    /// </remarks>
    [JsonDerivedType(typeof(Apprentice), typeDiscriminator: "Apprentice")]
    public class Employee : Person
    {
        /// <summary>
        /// Automatisch hochgezählte Mitarbeiternummer, die von der Business-Schicht vergeben wird.
        /// Von ausserhalb des Models nur lesbar; beim Laden aus der JSON-Datei setzt der
        /// Serializer den nicht-öffentlichen Setter direkt (siehe <see cref="JsonIncludeAttribute"/>).
        /// </summary>
        [JsonInclude]
        public int EmployeeNumber { get; private set; }

        /// <summary>Abteilung, der der Mitarbeiter angehört; optional.</summary>
        public string? Department { get; set; }

        /// <summary>Schweizer Sozialversicherungsnummer (AHV) als Freitext; optional.</summary>
        public string? SocialSecurityNumber { get; set; }

        /// <summary>Nationalität des Mitarbeiters; optional.</summary>
        public string? Nationality { get; set; }

        /// <summary>Datum des Beschäftigungsbeginns (Eintrittsdatum); optional.</summary>
        public DateOnly? HireDate { get; set; }

        /// <summary>Datum des Beschäftigungsendes (Austrittsdatum); null, solange noch angestellt.</summary>
        public DateOnly? TerminationDate { get; set; }

        /// <summary>Beschäftigungsgrad in Prozent (0–100); optional.</summary>
        public int? EmploymentLevel { get; set; }

        /// <summary>Tätigkeitsbezeichnung / Rolle; optional.</summary>
        public string? JobTitle { get; set; }

        /// <summary>Kaderstufe von 0 (keine) bis 5 (höchste); optional.</summary>
        public int? ManagementLevel { get; set; }

        /// <summary>Geschäftsadresse des Mitarbeiters; optional.</summary>
        public Address? BusinessAddress { get; set; }

        /// <summary>Wohnadresse des Mitarbeiters; optional.</summary>
        public Address? HomeAddress { get; set; }

        /// <summary>
        /// Vergibt die Mitarbeiternummer einmalig. Die Berechnung der nächsten freien Nummer
        /// liegt in der Business-Schicht; das Model stellt hier nur sicher, dass eine
        /// einmal vergebene Nummer nicht mehr überschrieben werden kann.
        /// </summary>
        /// <param name="number">Die zu vergebende Mitarbeiternummer; muss grösser als 0 sein.</param>
        /// <exception cref="ArgumentOutOfRangeException">Wird geworfen, wenn <paramref name="number"/> kleiner oder gleich 0 ist.</exception>
        /// <exception cref="InvalidOperationException">Wird geworfen, wenn diesem Mitarbeiter bereits eine Nummer zugewiesen wurde.</exception>
        public void AssignEmployeeNumber(int number)
        {
            if (number <= 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Mitarbeiternummer muss positiv sein.");

            if (EmployeeNumber != 0)
                throw new InvalidOperationException("Mitarbeiternummer wurde bereits vergeben.");

            EmployeeNumber = number;
        }
    }
}