using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model.Security
{
    /// <summary>
    /// Ein Benutzerkonto für die Anmeldung an der Anwendung. Enthält bewusst
    /// <b>kein</b> Klartextpasswort, sondern nur den daraus abgeleiteten Hash samt
    /// aller Parameter, die zu seiner Reproduktion nötig sind (Salt und Iterationen).
    /// Reiner Datenträger ohne Logik – das Ableiten und Prüfen übernimmt die
    /// Business-Schicht.
    /// </summary>
    public class User
    {
        /// <summary>Der Anmeldename; dient zugleich als eindeutiger Schlüssel.</summary>
        public required string UserName { get; set; }

        /// <summary>
        /// Der pro Benutzer einmalig erzeugte Zufallswert, der vor dem Ableiten unter das
        /// Passwort gemischt wird (Base64). Er ist kein Geheimnis: Seine Aufgabe ist nicht,
        /// unbekannt zu sein, sondern pro Benutzer <i>verschieden</i> zu sein. Dadurch
        /// ergeben gleiche Passwörter verschiedene Hashes und vorberechnete Tabellen
        /// werden wirkungslos.
        /// </summary>
        public required string Salt { get; set; }

        /// <summary>
        /// Der aus Passwort und <see cref="Salt"/> abgeleitete Hash (Base64).
        /// </summary>
        public required string PasswordHash { get; set; }

        /// <summary>
        /// Die Anzahl Iterationen, mit der <see cref="PasswordHash"/> abgeleitet wurde.
        /// Wird pro Benutzer mitgespeichert, damit der empfohlene Wert später erhöht
        /// werden kann, ohne bestehende Konten ungültig zu machen: Jeder Hash trägt die
        /// Parameter mit, mit denen er entstanden ist.
        /// </summary>
        public required int Iterations { get; set; }
    }
}
