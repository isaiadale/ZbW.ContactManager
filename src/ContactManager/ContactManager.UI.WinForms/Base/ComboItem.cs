using System;

namespace ContactManager.UI.WinForms.Base
{
    /// <summary>
    /// Eintrag einer ComboBox, der einen typisierten Wert an eine Beschriftung koppelt.
    /// Ohne diesen Umweg müsste die Oberfläche den Wert aus dem angezeigten Text
    /// zurückübersetzen — mit dem Eintrag liest man ihn über <see cref="Value"/> direkt aus.
    /// </summary>
    /// <typeparam name="TValue">Typ des hinterlegten Wertes, in der Regel ein Enum des Models.</typeparam>
    public sealed class ComboItem<TValue>
    {
        /// <summary>
        /// Erzeugt einen Eintrag aus Wert und Beschriftung.
        /// </summary>
        /// <param name="value">Der Wert, den dieser Eintrag repräsentiert.</param>
        /// <param name="text">Die in der ComboBox angezeigte Beschriftung.</param>
        public ComboItem(TValue value, string text)
        {
            Value = value;
            Text = text;
        }

        /// <summary>Der hinterlegte Wert.</summary>
        public TValue Value { get; }

        /// <summary>Die angezeigte Beschriftung.</summary>
        public string Text { get; }

        /// <summary>
        /// Liefert die Beschriftung. Die ComboBox zeigt genau diesen Text an, solange
        /// kein <c>DisplayMember</c> gesetzt ist.
        /// </summary>
        /// <returns>Die Beschriftung des Eintrags.</returns>
        public override string ToString() => Text;
    }
}
