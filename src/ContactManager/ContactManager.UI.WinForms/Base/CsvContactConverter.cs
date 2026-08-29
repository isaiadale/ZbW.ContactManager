using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ContactManager.Model;
using ContactManager.Model.Enums;

namespace ContactManager.UI.WinForms.Base
{
    /// <summary>
    /// Wandelt Mitarbeitende (inkl. Lernende) und Kundschaft in CSV-Zeilen um und zurück.
    /// Bewusst in der UI-Schicht angesiedelt statt in der Business-Schicht, aus demselben
    /// Grund wie <see cref="EnumDisplay"/>: Die deutschen Spaltennamen und Beschriftungen
    /// sind reine Darstellung, das Model bleibt sprachneutral. Eine CSV-Datei ist wie ein
    /// Formular für Menschen lesbar (z. B. in Excel) und gehört darum hierher - analog zu
    /// <see cref="ControlBinding"/>, nur für Dateien statt für Controls.
    /// </summary>
    /// <remarks>
    /// Reine Zuordnung CSV ↔ Model, ohne Wissen über die Business-Schicht: Diese Klasse
    /// erfasst keine Personen und speichert nichts. Aufrufende Formulare übergeben die hier
    /// erzeugten Objekte selbst an <c>contacts.Employees.Add</c> bzw.
    /// <c>contacts.Customers.Add</c> - dieselbe Validierung und Nummernvergabe wie bei einer
    /// manuellen Erfassung greift so auch beim Import.
    /// </remarks>
    public static class CsvContactConverter
    {
        // Semikolon statt Komma: In der Schweiz/DE öffnet Excel eine so gespeicherte Datei
        // direkt in Spalten, ohne dass man den Trenner erst manuell umstellen muss.
        private const char Delimiter = ';';

        // Dieselben Muster wie ControlBinding: Datum schweizerisch, mit und ohne führende Null.
        private static readonly string[] DateFormats = { "dd.MM.yyyy", "d.M.yyyy" };

        // Grenzen für importierte Daten. Sie spiegeln die MinDate-Werte der DateTimePicker
        // im EmployeeDetailForm wider und sind kein blosser Plausibilitäts-Check: Ein Datum
        // ausserhalb dieser Grenzen liesse sich zwar speichern, aber das Detailformular
        // stürzte beim Öffnen dieser Person ab, weil ein DateTimePicker einen Wert
        // ausserhalb seines Bereichs mit einer ArgumentOutOfRangeException quittiert.
        // Werden die Grenzen im Designer geändert, gehören sie hier nachgeführt.
        private static readonly DateOnly MinBirthDate = new(1900, 1, 1);
        private static readonly DateOnly MinEmploymentDate = new(1950, 1, 1);

        // Eintritt und Austritt haben im Designer keine Obergrenze, es gilt also die des
        // Controls selbst (DateTimePicker.MaximumDateTime). DateOnly reicht ein Jahr weiter
        // als der Picker - ohne diese Grenze liesse sich genau dieses eine Jahr importieren
        // und brächte das Detailformular später zum Absturz.
        private static readonly DateOnly MaxPickerDate = new(9998, 12, 31);

        // Obergrenze für das Geburtsdatum. Als Property statt als Feld, damit sie auch dann
        // stimmt, wenn die Anwendung über Mitternacht hinaus läuft.
        private static DateOnly Today => DateOnly.FromDateTime(DateTime.Today);

        private static readonly string[] EmployeeHeader =
        {
            "Typ", "MitarbeiterNr", "Anrede", "Nachname", "Vorname", "Geburtsdatum", "Geschlecht",
            "AhvNummer", "Nationalitaet", "GeschaeftsTelefon", "Mobile", "Email",
            "Abteilung", "Rolle", "Kaderstufe", "Stellenprozent", "Eintritt", "Austritt", "Status",
            "PrivatStrasse", "PrivatPlz", "PrivatOrt",
            "GeschaeftsStrasse", "GeschaeftsPlz", "GeschaeftsOrt",
            "Lehrjahre", "AktuellesLehrjahr"
        };

        private static readonly string[] CustomerHeader =
        {
            "KundenNr", "Anrede", "Titel", "Nachname", "Vorname", "Geburtsdatum", "Geschlecht",
            "Telefon", "Mobile", "Email", "Status", "Strasse", "Plz", "Ort"
        };

        // ------------------------------------------------------------------
        // Export
        // ------------------------------------------------------------------

        /// <summary>
        /// Schreibt alle übergebenen Mitarbeitenden (inkl. Lernende) als CSV-Datei.
        /// </summary>
        /// <param name="employees">Die zu exportierenden Mitarbeitenden.</param>
        /// <param name="filePath">Zielpfad der CSV-Datei; eine bestehende Datei wird überschrieben.</param>
        public static void ExportEmployees(IEnumerable<Employee> employees, string filePath)
        {
            using StreamWriter writer = CreateWriter(filePath);

            writer.WriteLine(BuildRow(EmployeeHeader));

            foreach (Employee employee in employees)
            {
                writer.WriteLine(BuildRow(ToFields(employee)));
            }
        }

        /// <summary>
        /// Schreibt alle übergebenen Kunden als CSV-Datei.
        /// </summary>
        /// <param name="customers">Die zu exportierenden Kunden.</param>
        /// <param name="filePath">Zielpfad der CSV-Datei; eine bestehende Datei wird überschrieben.</param>
        public static void ExportCustomers(IEnumerable<Customer> customers, string filePath)
        {
            using StreamWriter writer = CreateWriter(filePath);

            writer.WriteLine(BuildRow(CustomerHeader));

            foreach (Customer customer in customers)
            {
                writer.WriteLine(BuildRow(ToFields(customer)));
            }
        }

        private static StreamWriter CreateWriter(string filePath) =>
            // UTF-8 mit BOM, damit Excel unter Windows Umlaute (ä, ö, ü) automatisch richtig liest,
            // ohne dass man die Kodierung beim Öffnen von Hand auswählen muss.
            new StreamWriter(filePath, false, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));

        private static string[] ToFields(Employee employee)
        {
            Apprentice? apprentice = employee as Apprentice;

            return new[]
            {
                apprentice is null ? "Mitarbeiter" : "Lernender",
                employee.EmployeeNumber.ToString(),
                Format(employee.Salutation),
                employee.LastName,
                employee.FirstName,
                Format(employee.DateOfBirth),
                Format(employee.Gender),
                employee.SocialSecurityNumber ?? "",
                employee.Nationality ?? "",
                employee.BusinessPhone ?? "",
                employee.MobilePhone ?? "",
                employee.Email ?? "",
                employee.Department ?? "",
                employee.JobTitle ?? "",
                employee.ManagementLevel?.ToString() ?? "",
                employee.EmploymentLevel?.ToString() ?? "",
                Format(employee.HireDate),
                Format(employee.TerminationDate),
                Format(employee.PersonStatus),
                employee.HomeAddress?.Street ?? "",
                employee.HomeAddress?.PostalCode ?? "",
                employee.HomeAddress?.City ?? "",
                employee.BusinessAddress?.Street ?? "",
                employee.BusinessAddress?.PostalCode ?? "",
                employee.BusinessAddress?.City ?? "",
                apprentice is null ? "" : apprentice.ApprenticeshipYears.ToString(),
                apprentice?.CurrentApprenticeshipYear?.ToString() ?? ""
            };
        }

        private static string[] ToFields(Customer customer) => new[]
        {
            customer.CustomerNumber.ToString(),
            Format(customer.Salutation),
            customer.Title ?? "",
            customer.LastName,
            customer.FirstName,
            Format(customer.DateOfBirth),
            Format(customer.Gender),
            customer.BusinessPhone ?? "",
            customer.MobilePhone ?? "",
            customer.Email ?? "",
            Format(customer.PersonStatus),
            customer.Address?.Street ?? "",
            customer.Address?.PostalCode ?? "",
            customer.Address?.City ?? ""
        };

        // ------------------------------------------------------------------
        // Import
        // ------------------------------------------------------------------

        /// <summary>
        /// Liest Mitarbeitende (inkl. Lernende) aus einer CSV-Datei. Fehlerhafte Zeilen
        /// werden übersprungen und gesammelt gemeldet statt den ganzen Import abzubrechen -
        /// die übrigen, gültigen Zeilen werden trotzdem zurückgegeben.
        /// </summary>
        /// <param name="filePath">Pfad der einzulesenden CSV-Datei.</param>
        /// <returns>Erfolgreich gelesene, aber noch nicht gespeicherte Mitarbeitende sowie die Fehler der übersprungenen Zeilen.</returns>
        /// <exception cref="CsvFormatException">
        /// Wird geworfen, wenn die Datei leer ist oder der Kopfzeile eine Pflichtspalte fehlt.
        /// </exception>
        public static CsvImportResult<Employee> ImportEmployees(string filePath)
        {
            CsvImportResult<Employee> result = new();

            string[] lines = ReadLines(filePath);

            // string.Split liefert immer mindestens einen Eintrag, eine leere Datei also
            // eine einzelne leere Zeile - deshalb wird hier auf den Inhalt geprüft und
            // nicht auf die Anzahl.
            if (lines.Length == 0 || string.IsNullOrWhiteSpace(lines[0]))
            {
                throw new CsvFormatException("Die Datei ist leer.");
            }

            // "Typ" ist hier zwingend, obwohl eine leere Zelle als "Mitarbeiter" durchginge:
            // Die Spalte ist das Erkennungsmerkmal einer Mitarbeitenden-Datei. Ohne sie
            // würde eine Kunden-CSV - die ebenfalls Nachname und Vorname hat - klaglos als
            // Mitarbeitende eingelesen.
            Dictionary<string, int> columns = MapColumns(lines[0], new[] { "Typ", "Nachname", "Vorname" });
            int fieldCount = SplitLine(lines[0]).Length;

            for (int i = 1; i < lines.Length; i++)
            {
                int lineNumber = i + 1;

                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                try
                {
                    string[] fields = SplitRow(lines[i], fieldCount);
                    result.Imported.Add(new CsvImportRow<Employee>(lineNumber, ToEmployee(fields, columns)));
                }
                catch (CsvRowException ex)
                {
                    result.Errors.Add(new CsvRowError(lineNumber, ex.Message));
                }
            }

            return result;
        }

        /// <summary>
        /// Liest Kunden aus einer CSV-Datei. Fehlerhafte Zeilen werden übersprungen und
        /// gesammelt gemeldet statt den ganzen Import abzubrechen.
        /// </summary>
        /// <param name="filePath">Pfad der einzulesenden CSV-Datei.</param>
        /// <returns>Erfolgreich gelesene, aber noch nicht gespeicherte Kunden sowie die Fehler der übersprungenen Zeilen.</returns>
        /// <exception cref="CsvFormatException">
        /// Wird geworfen, wenn die Datei leer ist oder der Kopfzeile eine Pflichtspalte fehlt.
        /// </exception>
        public static CsvImportResult<Customer> ImportCustomers(string filePath)
        {
            CsvImportResult<Customer> result = new();

            string[] lines = ReadLines(filePath);

            // string.Split liefert immer mindestens einen Eintrag, eine leere Datei also
            // eine einzelne leere Zeile - deshalb wird hier auf den Inhalt geprüft und
            // nicht auf die Anzahl.
            if (lines.Length == 0 || string.IsNullOrWhiteSpace(lines[0]))
            {
                throw new CsvFormatException("Die Datei ist leer.");
            }

            Dictionary<string, int> columns = MapColumns(lines[0], new[] { "Nachname", "Vorname" });
            int fieldCount = SplitLine(lines[0]).Length;

            // Nachname und Vorname allein genügen als Erkennungsmerkmal nicht: Die
            // Mitarbeitenden-CSV führt dieselben beiden Spalten und liesse sich hier sonst
            // klaglos einlesen - mit dem Ergebnis, dass jede Mitarbeitende Person als Kunde
            // mit leerer Adresse und leerem Telefon im Datenstamm landet. Die Spalte "Typ"
            // kommt nur in der Mitarbeitenden-Datei vor und verrät sie eindeutig.
            if (columns.ContainsKey("Typ"))
            {
                throw new CsvFormatException(
                    "Diese Datei enthält eine Spalte \"Typ\" und ist damit ein Export von " +
                    "Mitarbeitenden. Kunden werden in der Kundenliste importiert.");
            }

            for (int i = 1; i < lines.Length; i++)
            {
                int lineNumber = i + 1;

                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                try
                {
                    string[] fields = SplitRow(lines[i], fieldCount);
                    result.Imported.Add(new CsvImportRow<Customer>(lineNumber, ToCustomer(fields, columns)));
                }
                catch (CsvRowException ex)
                {
                    result.Errors.Add(new CsvRowError(lineNumber, ex.Message));
                }
            }

            return result;
        }

        /// <summary>
        /// Baut die abschliessende Meldung für die Oberfläche. Steht hier statt in den
        /// beiden Listenformularen, weil sie dort Wort für Wort doppelt stünde - dieselbe
        /// Überlegung, die schon <see cref="ControlBinding"/> aus den Detailformularen
        /// herausgelöst hat.
        /// </summary>
        /// <param name="imported">Anzahl erfolgreich gespeicherter Datensätze.</param>
        /// <param name="singular">Bezeichnung für genau einen Datensatz, z. B. "Kunde/in".</param>
        /// <param name="plural">Bezeichnung für mehrere Datensätze, z. B. "Kunden".</param>
        /// <param name="errors">Die übersprungenen Zeilen mit Begründung.</param>
        /// <param name="aborted">Meldung des Schreibfehlers, der den Import abgebrochen hat, sonst <c>null</c>.</param>
        /// <returns>Der anzuzeigende Meldungstext.</returns>
        public static string BuildImportSummary(int imported, string singular, string plural,
            IReadOnlyList<CsvRowError> errors, string? aborted)
        {
            // Die Liste der übersprungenen Zeilen wird gekappt: Bei einer durchgehend
            // unpassenden Datei stünden sonst Hunderte Zeilen in einer MessageBox, die sich
            // nicht scrollen lässt.
            const int MaxShownErrors = 15;

            string summary = imported == 1
                ? $"1 {singular} wurde importiert."
                : $"{imported} {plural} wurden importiert.";

            if (aborted is not null)
            {
                summary += "\n\nDer Import wurde abgebrochen, weil die Daten nicht " +
                    $"gespeichert werden konnten:\n{aborted}";
            }

            if (errors.Count > 0)
            {
                summary += $"\n\n{errors.Count} Zeile(n) übersprungen:\n" +
                    string.Join("\n", errors.Take(MaxShownErrors)
                        .Select(error => $"Zeile {error.LineNumber}: {error.Message}"));

                if (errors.Count > MaxShownErrors)
                {
                    summary += $"\n… und {errors.Count - MaxShownErrors} weitere.";
                }
            }

            return summary;
        }

        private static Employee ToEmployee(string[] fields, Dictionary<string, int> columns)
        {
            string type = Get(fields, columns, "Typ");
            bool isApprentice = type.Equals("Lernender", StringComparison.OrdinalIgnoreCase);
            bool isEmployee = type.Equals("Mitarbeiter", StringComparison.OrdinalIgnoreCase);

            // Auch eine leere Zelle ist ein Fehler und nicht stillschweigend "Mitarbeiter":
            // Sonst verlöre eine lernende Person, bei der die Spalte versehentlich geleert
            // wurde, mit dem Typ auch ihre Lehrjahre - ohne jede Meldung.
            if (!isApprentice && !isEmployee)
            {
                throw new CsvRowException(type.Length == 0
                    ? "Die Spalte \"Typ\" ist leer (erwartet: \"Mitarbeiter\" oder \"Lernender\")."
                    : $"Unbekannter Typ \"{type}\" (erwartet: \"Mitarbeiter\" oder \"Lernender\").");
            }

            Employee employee = isApprentice
                ? new Apprentice
                {
                    FirstName = Get(fields, columns, "Vorname"),
                    LastName = Get(fields, columns, "Nachname"),
                    PersonStatus = ParseStatus(Get(fields, columns, "Status")),
                    // Nicht-nullable int: Ein leeres Feld ergibt 0, worauf der Validator beim
                    // Add() mit einer verständlichen Meldung reagiert - genau wie im Detailformular.
                    ApprenticeshipYears = ParseOptionalInt(fields, columns, "Lehrjahre") ?? 0,
                    CurrentApprenticeshipYear = ParseOptionalInt(fields, columns, "AktuellesLehrjahr")
                }
                : new Employee
                {
                    FirstName = Get(fields, columns, "Vorname"),
                    LastName = Get(fields, columns, "Nachname"),
                    PersonStatus = ParseStatus(Get(fields, columns, "Status"))
                };

            employee.Salutation = ParseSalutation(Get(fields, columns, "Anrede"));
            employee.DateOfBirth = ParseOptionalDate(fields, columns, "Geburtsdatum", MinBirthDate, Today);
            employee.Gender = ParseGender(Get(fields, columns, "Geschlecht"));
            employee.SocialSecurityNumber = Empty(Get(fields, columns, "AhvNummer"));
            employee.Nationality = Empty(Get(fields, columns, "Nationalitaet"));
            employee.BusinessPhone = Empty(Get(fields, columns, "GeschaeftsTelefon"));
            employee.MobilePhone = Empty(Get(fields, columns, "Mobile"));
            employee.Email = Empty(Get(fields, columns, "Email"));
            employee.Department = Empty(Get(fields, columns, "Abteilung"));
            employee.JobTitle = Empty(Get(fields, columns, "Rolle"));
            employee.ManagementLevel = ParseOptionalInt(fields, columns, "Kaderstufe");
            employee.EmploymentLevel = ParseOptionalInt(fields, columns, "Stellenprozent");
            employee.HireDate = ParseOptionalDate(fields, columns, "Eintritt", MinEmploymentDate, MaxPickerDate);
            employee.TerminationDate = ParseOptionalDate(fields, columns, "Austritt", MinEmploymentDate, MaxPickerDate);
            employee.HomeAddress = ParseAddress(fields, columns, "PrivatStrasse", "PrivatPlz", "PrivatOrt");
            employee.BusinessAddress = ParseAddress(fields, columns, "GeschaeftsStrasse", "GeschaeftsPlz", "GeschaeftsOrt");

            // MitarbeiterNr bewusst nicht gelesen: Die Nummer vergibt Add() automatisch
            // (siehe Business-README), ein CSV-Wert würde ignoriert und wäre irreführend.
            return employee;
        }

        private static Customer ToCustomer(string[] fields, Dictionary<string, int> columns) => new Customer
        {
            FirstName = Get(fields, columns, "Vorname"),
            LastName = Get(fields, columns, "Nachname"),
            PersonStatus = ParseStatus(Get(fields, columns, "Status")),
            Salutation = ParseSalutation(Get(fields, columns, "Anrede")),
            Title = Empty(Get(fields, columns, "Titel")),
            DateOfBirth = ParseOptionalDate(fields, columns, "Geburtsdatum", MinBirthDate, Today),
            Gender = ParseGender(Get(fields, columns, "Geschlecht")),
            BusinessPhone = Empty(Get(fields, columns, "Telefon")),
            MobilePhone = Empty(Get(fields, columns, "Mobile")),
            Email = Empty(Get(fields, columns, "Email")),
            Address = ParseAddress(fields, columns, "Strasse", "Plz", "Ort")
        };

        // ------------------------------------------------------------------
        // Feld-Umrechnung (parallel zu ControlBinding, aber CSV-Text statt Controls)
        // ------------------------------------------------------------------

        private static string Format(DateOnly? date) => date?.ToString("dd.MM.yyyy") ?? "";
        private static string Format(Status status) => EnumDisplay.ToText(status);
        private static string Format(Gender? gender) => gender is Gender g ? EnumDisplay.ToText(g) : "";
        private static string Format(Salutation? salutation) => salutation is Salutation s ? EnumDisplay.ToText(s) : "";

        private static string? Empty(string text) => string.IsNullOrWhiteSpace(text) ? null : text.Trim();

        private static Status ParseStatus(string text)
        {
            if (text.Length == 0)
            {
                // Wie bei der manuellen Erfassung (EmployeeDetailForm.ClearInputs): ohne
                // Angabe gilt eine neue Person als aktiv.
                return Status.Active;
            }

            if (EnumDisplay.TryParseStatus(text, out Status status))
            {
                return status;
            }

            throw new CsvRowException($"Unbekannter Status \"{text}\" (erwartet: \"Aktiv\" oder \"Passiv\").");
        }

        private static Salutation? ParseSalutation(string text)
        {
            if (text.Length == 0)
            {
                return null;
            }

            if (EnumDisplay.TryParseSalutation(text, out Salutation salutation))
            {
                return salutation;
            }

            throw new CsvRowException($"Unbekannte Anrede \"{text}\".");
        }

        private static Gender? ParseGender(string text)
        {
            if (text.Length == 0)
            {
                return null;
            }

            if (EnumDisplay.TryParseGender(text, out Gender gender))
            {
                return gender;
            }

            throw new CsvRowException($"Unbekanntes Geschlecht \"{text}\".");
        }

        private static DateOnly? ParseOptionalDate(string[] fields, Dictionary<string, int> columns,
            string column, DateOnly minimum, DateOnly maximum)
        {
            string text = Get(fields, columns, column);

            if (text.Length == 0)
            {
                return null;
            }

            if (!DateOnly.TryParseExact(text, DateFormats, out DateOnly date))
            {
                throw new CsvRowException($"Spalte \"{column}\": \"{text}\" ist kein gültiges Datum (TT.MM.JJJJ).");
            }

            if (date < minimum || date > maximum)
            {
                throw new CsvRowException(
                    $"Spalte \"{column}\": \"{text}\" liegt ausserhalb des zulässigen Bereichs " +
                    $"({minimum:dd.MM.yyyy} bis {maximum:dd.MM.yyyy}).");
            }

            return date;
        }

        private static int? ParseOptionalInt(string[] fields, Dictionary<string, int> columns, string column)
        {
            string text = Get(fields, columns, column);

            if (text.Length == 0)
            {
                return null;
            }

            if (int.TryParse(text, out int value))
            {
                return value;
            }

            throw new CsvRowException($"Spalte \"{column}\": \"{text}\" ist keine gültige Zahl.");
        }

        private static Address? ParseAddress(string[] fields, Dictionary<string, int> columns,
            string streetColumn, string postalCodeColumn, string cityColumn)
        {
            string street = Get(fields, columns, streetColumn);
            string postalCode = Get(fields, columns, postalCodeColumn);
            string city = Get(fields, columns, cityColumn);

            // Gleiche Regel wie ControlBinding.ReadAddress: Sind alle drei leer, gilt die
            // Adresse als nicht erfasst; ist nur ein Teil ausgefüllt, entsteht die Adresse
            // trotzdem, und der Validator meldet beim Add(), was fehlt.
            if (street.Length == 0 && postalCode.Length == 0 && city.Length == 0)
            {
                return null;
            }

            return new Address { Street = street, PostalCode = postalCode, City = city };
        }

        // Liest ein Feld anhand des Spaltennamens. Fehlt die Spalte in dieser Datei, weil
        // eine optionale Spalte weggelassen wurde, gilt das Feld als leer - die Datei muss
        // also nicht alle Spalten führen. Zu kurze Datenzeilen fängt dagegen bereits
        // SplitRow ab; die Längenprüfung hier ist nur noch die zweite Absicherung.
        private static string Get(string[] fields, Dictionary<string, int> columns, string column)
        {
            if (!columns.TryGetValue(column, out int index) || index >= fields.Length)
            {
                return "";
            }

            return fields[index].Trim();
        }

        /// <summary>
        /// Liest die Datei zeilenweise ein und erkennt dabei die Kodierung. Ein eigener
        /// Leser statt <c>File.ReadAllLines</c>, weil Excel beim Speichern zwei Formate
        /// anbietet: "CSV UTF-8" schreibt UTF-8, das schlichte "CSV (Trennzeichen-getrennt)"
        /// dagegen ANSI. Ohne diese Unterscheidung käme "Müller" aus einer in Excel
        /// bearbeiteten Datei als "M?ller" zurück - und zwar stillschweigend.
        /// </summary>
        private static string[] ReadLines(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);

            // Ein von uns geschriebenes Byte-Order-Mark gehört nicht zum Inhalt; bliebe es
            // stehen, hiesse die erste Spalte der Kopfzeile nicht "Typ", sondern "﻿Typ".
            int start = HasUtf8Bom(bytes) ? 3 : 0;

            string text;

            try
            {
                // throwOnInvalidBytes: Nur so meldet der Decoder ungültige Bytes, statt
                // stillschweigend Ersatzzeichen einzusetzen.
                text = new UTF8Encoding(false, throwOnInvalidBytes: true)
                    .GetString(bytes, start, bytes.Length - start);
            }
            catch (DecoderFallbackException)
            {
                // Kein gültiges UTF-8, also die westeuropäische Einzelbyte-Kodierung. Latin1
                // ist in .NET fest eingebaut - anders als Windows-1252, das erst registriert
                // werden müsste - und deckt alle Umlaute sowie ß und die Akzentbuchstaben
                // identisch ab. Nur die Sonderzeichen, die Windows-1252 zusätzlich im
                // Bereich 0x80-0x9F führt (typografische Anführungszeichen, Gedankenstrich,
                // Eurozeichen), kommen anders heraus; in Namen und Adressen ist das kein Thema.
                text = Encoding.Latin1.GetString(bytes, start, bytes.Length - start);
            }

            return text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
        }

        private static bool HasUtf8Bom(byte[] bytes) =>
            bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF;

        // Baut aus der Kopfzeile eine Namen-zu-Index-Zuordnung. Wirft, wenn eine der
        // zwingend benötigten Spalten fehlt, damit ein Import mit der falschen Datei sofort
        // eine verständliche Meldung ergibt statt lauter einzelner Zeilenfehler.
        private static Dictionary<string, int> MapColumns(string headerLine, string[] required)
        {
            string[] headers = SplitLine(headerLine);
            Dictionary<string, int> columns = new(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < headers.Length; i++)
            {
                columns[headers[i].Trim()] = i;
            }

            string[] missing = required.Where(name => !columns.ContainsKey(name)).ToArray();

            if (missing.Length > 0)
            {
                throw new CsvFormatException(
                    $"Der Kopfzeile fehlen die Spalte(n): {string.Join(", ", missing)}. " +
                    "Ist das wirklich eine mit \"CSV Export\" erzeugte Datei?");
            }

            return columns;
        }

        // ------------------------------------------------------------------
        // CSV-Low-Level: Zusammenbauen und Trennen einer Zeile
        // ------------------------------------------------------------------

        // Baut eine CSV-Zeile aus einzelnen Feldern zusammen und escaped dabei jedes Feld,
        // das den Trenner, ein Anführungszeichen oder einen Zeilenumbruch enthält.
        private static string BuildRow(IEnumerable<string> fields) =>
            string.Join(Delimiter, fields.Select(Escape));

        private static string Escape(string field)
        {
            bool needsQuotes = field.Contains(Delimiter) || field.Contains('"') ||
                field.Contains('\n') || field.Contains('\r');

            if (!needsQuotes)
            {
                return field;
            }

            return "\"" + field.Replace("\"", "\"\"") + "\"";
        }

        // Trennt eine Datenzeile auf und stellt sicher, dass sie so viele Felder hat wie die
        // Kopfzeile. Ohne diese Prüfung würde eine abgeschnittene Zeile klaglos eingelesen:
        // Get() meldet für jedes fehlende Feld eine leere Zeichenkette, die Person entstünde
        // also mit lauter leeren Angaben, ohne dass jemand etwas davon merkt. Mehr Felder
        // als die Kopfzeile sind unschädlich - sie werden schlicht nicht zugeordnet.
        private static string[] SplitRow(string line, int expectedFieldCount)
        {
            string[] fields = SplitLine(line);

            if (fields.Length < expectedFieldCount)
            {
                throw new CsvRowException(
                    $"Die Zeile hat nur {fields.Length} statt {expectedFieldCount} Felder.");
            }

            return fields;
        }

        // Trennt eine einzelne Zeile in ihre Felder auf und berücksichtigt dabei
        // Anführungszeichen: Ein in Anführungszeichen stehender Trenner gehört zum Feld,
        // ein doppeltes Anführungszeichen darin steht für ein einzelnes, wörtliches
        // Anführungszeichen. Bewusst zeilenweise statt zeichenweise über die ganze Datei:
        // Für unsere Daten genügt das, weil sie ausnahmslos aus einzeiligen Textfeldern
        // stammen. Ein Feld mit echtem Zeilenumbruch wird deshalb nicht unterstützt - Escape
        // setzt es zwar korrekt in Anführungszeichen, gelesen würde es aber als zwei Zeilen.
        private static string[] SplitLine(string line)
        {
            List<string> fields = new();
            StringBuilder current = new();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (inQuotes)
                {
                    if (c == '"' && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current.Append('"');
                        i++;
                    }
                    else if (c == '"')
                    {
                        inQuotes = false;
                    }
                    else
                    {
                        current.Append(c);
                    }
                }
                else if (c == '"')
                {
                    inQuotes = true;
                }
                else if (c == Delimiter)
                {
                    fields.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(c);
                }
            }

            fields.Add(current.ToString());

            return fields.ToArray();
        }

        // Interner Zeilenfehler beim Parsen; wird von den Import-Methoden abgefangen und in
        // einen CsvRowError umgewandelt. Bleibt privat, weil er nach aussen nie sichtbar
        // werden soll - Aufrufer sehen ausschliesslich CsvImportResult.Errors.
        private sealed class CsvRowException : Exception
        {
            public CsvRowException(string message) : base(message)
            {
            }
        }
    }

    /// <summary>Ergebnis eines CSV-Imports: erfolgreich gelesene Objekte plus übersprungene Zeilen mit Grund.</summary>
    /// <typeparam name="T">Der importierte Model-Typ (<see cref="Employee"/> oder <see cref="Customer"/>).</typeparam>
    public class CsvImportResult<T>
    {
        /// <summary>
        /// Erfolgreich gelesene, aber noch nicht gespeicherte Objekte, jeweils mit der
        /// Zeile, aus der sie stammen.
        /// </summary>
        public List<CsvImportRow<T>> Imported { get; } = new();

        /// <summary>Zeilen, die wegen eines Formatfehlers übersprungen wurden.</summary>
        public List<CsvRowError> Errors { get; } = new();
    }

    /// <summary>
    /// Ein gelesenes Objekt samt der Zeile, aus der es stammt. Die Zeilennummer wird
    /// mitgeführt, weil ein Datensatz auch später noch scheitern kann - beim Speichern
    /// über die Business-Schicht - und die Meldung dann trotzdem auf die Zeile in der
    /// Datei zeigen soll statt nur auf einen Namen.
    /// </summary>
    /// <typeparam name="T">Der importierte Model-Typ.</typeparam>
    /// <param name="LineNumber">Zeilennummer in der Datei (Kopfzeile = Zeile 1).</param>
    /// <param name="Item">Das gelesene, noch nicht gespeicherte Objekt.</param>
    public record CsvImportRow<T>(int LineNumber, T Item);

    /// <summary>Beschreibt eine beim Import übersprungene CSV-Zeile.</summary>
    /// <param name="LineNumber">Zeilennummer in der Datei (Kopfzeile = Zeile 1).</param>
    /// <param name="Message">Deutschsprachige, anzeigbare Begründung.</param>
    public record CsvRowError(int LineNumber, string Message);

    /// <summary>
    /// Wird geworfen, wenn die CSV-Datei als Ganzes nicht lesbar ist (leer, oder der
    /// Kopfzeile fehlt eine zwingend benötigte Spalte) - im Unterschied zu einer einzelnen
    /// fehlerhaften Zeile, die stattdessen als <see cref="CsvRowError"/> gesammelt wird.
    /// </summary>
    public class CsvFormatException : Exception
    {
        /// <summary>Erzeugt die Ausnahme mit einer beschreibenden, anzeigbaren Meldung.</summary>
        /// <param name="message">Die deutschsprachige, anzeigbare Fehlermeldung.</param>
        public CsvFormatException(string message) : base(message)
        {
        }
    }
}
