using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactManager.Model;

namespace ContactManager.UI.WinForms.Base
{
    /// <summary>
    /// Rechnet zwischen den Werten der WinForms-Controls und den Typen des Models um.
    /// Bewusst als eigene Klasse und nicht je Formular: Detail- und Listenformulare
    /// brauchen dieselben Umrechnungen, und beide Detailformulare hatten sie bis hierhin
    /// Wort für Wort doppelt stehen.
    /// </summary>
    /// <remarks>
    /// Alle Methoden sind statisch und arbeiten ausschliesslich mit ihren Parametern —
    /// die Klasse kennt weder ein Formular noch die Business-Schicht.
    /// </remarks>
    public static class ControlBinding
    {
        // Im Formular wird das Datum schweizerisch geschrieben - mit und ohne führende Null.
        private static readonly string[] DateFormats = { "dd.MM.yyyy", "d.M.yyyy" };

        /// <summary>
        /// Liest ein optionales Textfeld. Leere oder nur aus Leerzeichen bestehende Eingaben
        /// werden zu <c>null</c> — das Model unterscheidet "nicht erfasst" von "leerer Text".
        /// </summary>
        /// <param name="box">Das auszulesende Textfeld.</param>
        /// <returns>Der bereinigte Text oder <c>null</c>.</returns>
        public static string? ReadOptionalText(TextBox box) => ReadOptionalText(box.Text);

        /// <summary>
        /// Bereinigt einen Eingabetext; leere Eingaben werden zu <c>null</c>.
        /// </summary>
        /// <param name="text">Der zu bereinigende Text.</param>
        /// <returns>Der getrimmte Text oder <c>null</c>.</returns>
        public static string? ReadOptionalText(string? text) =>
            string.IsNullOrWhiteSpace(text) ? null : text.Trim();

        /// <summary>
        /// Liest eine ganze Zahl aus einem Textfeld, ohne bei Buchstaben abzustürzen.
        /// Bewusst <c>TryParse</c> statt <c>Parse</c>: Eine Fehleingabe darf die Anwendung
        /// nicht beenden.
        /// </summary>
        /// <param name="box">Das auszulesende Textfeld.</param>
        /// <returns>Die eingegebene Zahl oder <c>null</c>, wenn das Feld leer oder keine Zahl ist.</returns>
        public static int? ReadOptionalInt(TextBox box) =>
            int.TryParse(box.Text.Trim(), out int value) ? value : null;

        /// <summary>
        /// Liest ein Datum aus einem Textfeld. Die Muster sind fest vorgegeben, damit die
        /// Eingabe unabhängig davon funktioniert, welche Kultur Windows meldet —
        /// <c>TryParse</c> ohne Angabe würde "31.12.1990" auf einem englischen System nicht
        /// erkennen. Eine (noch) unvollständige Eingabe ergibt <c>null</c> statt eines Fehlers.
        /// </summary>
        /// <param name="box">Das auszulesende Textfeld.</param>
        /// <returns>Das eingegebene Datum oder <c>null</c>, wenn die Eingabe keinem Muster entspricht.</returns>
        public static DateOnly? ReadOptionalDate(TextBox box) =>
            DateOnly.TryParseExact(box.Text.Trim(), DateFormats, out DateOnly value) ? value : null;

        /// <summary>
        /// Liest ein Datum aus einem DateTimePicker; ist dessen Checkbox nicht gesetzt,
        /// gilt das Datum als nicht erfasst.
        /// </summary>
        /// <param name="picker">Das auszulesende Datumsfeld.</param>
        /// <returns>Das gewählte Datum oder <c>null</c>.</returns>
        public static DateOnly? ReadDate(DateTimePicker picker) =>
            picker.Checked ? DateOnly.FromDateTime(picker.Value) : null;

        /// <summary>
        /// Zeigt ein Datum im DateTimePicker an; <c>null</c> erscheint als leerer,
        /// nicht angehakter Wert.
        /// </summary>
        /// <param name="picker">Das zu setzende Datumsfeld.</param>
        /// <param name="value">Das anzuzeigende Datum oder <c>null</c>.</param>
        public static void WriteDate(DateTimePicker picker, DateOnly? value)
        {
            if (value is DateOnly date)
            {
                picker.Value = date.ToDateTime(TimeOnly.MinValue);
                picker.Checked = true;
            }
            else
            {
                picker.Checked = false;
            }
        }

        /// <summary>
        /// Baut aus drei Eingabefeldern eine Adresse. Sind alle drei leer, gilt die Adresse
        /// als nicht erfasst; ist nur ein Teil ausgefüllt, entsteht die Adresse trotzdem und
        /// der Validator der Business-Schicht meldet, was fehlt.
        /// </summary>
        /// <param name="street">Feld für Strasse und Nummer.</param>
        /// <param name="postalCode">Feld für die Postleitzahl.</param>
        /// <param name="city">Feld für den Ort.</param>
        /// <returns>Die erfasste Adresse oder <c>null</c>.</returns>
        public static Address? ReadAddress(TextBox street, TextBox postalCode, TextBox city)
        {
            string streetValue = street.Text.Trim();
            string postalCodeValue = postalCode.Text.Trim();
            string cityValue = city.Text.Trim();

            if (streetValue.Length == 0 && postalCodeValue.Length == 0 && cityValue.Length == 0)
            {
                return null;
            }

            return new Address
            {
                Street = streetValue,
                PostalCode = postalCodeValue,
                City = cityValue
            };
        }

        /// <summary>
        /// Verteilt eine Adresse auf die drei zugehörigen Eingabefelder.
        /// </summary>
        /// <param name="address">Die anzuzeigende Adresse oder <c>null</c>.</param>
        /// <param name="street">Feld für Strasse und Nummer.</param>
        /// <param name="postalCode">Feld für die Postleitzahl.</param>
        /// <param name="city">Feld für den Ort.</param>
        public static void WriteAddress(Address? address, TextBox street, TextBox postalCode, TextBox city)
        {
            street.Text = address?.Street ?? string.Empty;
            postalCode.Text = address?.PostalCode ?? string.Empty;
            city.Text = address?.City ?? string.Empty;
        }

        /// <summary>
        /// Füllt eine ComboBox mit allen Werten eines Enums und deren deutscher Beschriftung.
        /// Bewusst über <c>Items</c> statt über <c>DataSource</c>: Nur so bleibt der Zustand
        /// "nichts ausgewählt" möglich, den die optionalen Felder des Models brauchen.
        /// </summary>
        /// <typeparam name="TEnum">Das anzuzeigende Enum.</typeparam>
        /// <param name="box">Die zu füllende ComboBox.</param>
        /// <param name="toText">Übersetzt einen Enum-Wert in seine Beschriftung.</param>
        public static void FillEnumCombo<TEnum>(ComboBox box, Func<TEnum, string> toText)
            where TEnum : struct, Enum
        {
            box.Items.Clear();

            foreach (TEnum value in Enum.GetValues<TEnum>())
            {
                box.Items.Add(new ComboItem<TEnum>(value, toText(value)));
            }

            box.SelectedIndex = -1;
        }

        /// <summary>
        /// Liest den ausgewählten Enum-Wert einer ComboBox.
        /// </summary>
        /// <typeparam name="TEnum">Das erwartete Enum.</typeparam>
        /// <param name="box">Die auszulesende ComboBox.</param>
        /// <returns>Der gewählte Wert oder <c>null</c>, wenn nichts ausgewählt ist.</returns>
        public static TEnum? ReadEnum<TEnum>(ComboBox box)
            where TEnum : struct, Enum =>
            (box.SelectedItem as ComboItem<TEnum>)?.Value;

        /// <summary>
        /// Wählt den zum Wert passenden Eintrag einer ComboBox aus; <c>null</c> lässt die
        /// Auswahl leer.
        /// </summary>
        /// <typeparam name="TEnum">Das angezeigte Enum.</typeparam>
        /// <param name="box">Die zu setzende ComboBox.</param>
        /// <param name="value">Der auszuwählende Wert oder <c>null</c>.</param>
        public static void SelectEnum<TEnum>(ComboBox box, TEnum? value)
            where TEnum : struct, Enum
        {
            box.SelectedIndex = -1;

            if (value is null)
            {
                return;
            }

            foreach (object? item in box.Items)
            {
                if (item is ComboItem<TEnum> comboItem &&
                    EqualityComparer<TEnum>.Default.Equals(comboItem.Value, value.Value))
                {
                    box.SelectedItem = item;
                    return;
                }
            }
        }

        /// <summary>
        /// Wählt einen Text in einer ComboBox aus und nimmt ihn vorher in die Liste auf,
        /// falls er dort fehlt. Ohne das ginge ein gespeicherter Wert beim nächsten
        /// Speichern verloren, nur weil er nicht zur Auswahl steht.
        /// </summary>
        /// <param name="box">Die zu setzende ComboBox.</param>
        /// <param name="value">Der auszuwählende Text oder <c>null</c>.</param>
        public static void SelectOrAdd(ComboBox box, string? value)
        {
            box.SelectedIndex = -1;

            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            if (!box.Items.Contains(value))
            {
                box.Items.Add(value);
            }

            box.SelectedItem = value;
        }
    }
}
