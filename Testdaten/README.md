# Testdaten

Beispieldateien für den **CSV-Import** des ContactManagers — bewusst mit gültigen *und*
fehlerhaften Datensätzen, damit sich Validierung und Fehlerbehandlung vorführen lassen.

## Import und Export ausführen

1. Anwendung starten und anmelden (`admin` / `admin`, siehe [Root-README](../README.md)).
2. **Mitarbeiterliste** bzw. **Kundenliste** öffnen.
3. Schaltfläche **CSV Import** — Datei auswählen. Nach dem Import erscheint ein Bericht mit
   der Anzahl übernommener Zeilen und allen abgewiesenen Zeilen inklusive Zeilennummer.
4. Schaltfläche **CSV Export** schreibt den aktuellen Bestand im selben Format zurück.

## Dateiformat

| | |
|---|---|
| Trennzeichen | Semikolon `;` |
| Kodierung | UTF-8 mit BOM (Import erkennt zusätzlich ANSI/Latin-1) |
| Datumsformat | `TT.MM.JJJJ`, z. B. `01.08.2024` |
| Enum-Werte | `Aktiv`/`Passiv`, `Herr`/`Frau`/`Keine Anrede`, `Männlich`/`Weiblich`/`Divers` |
| Zeilenende | eine Zeile pro Person, keine mehrzeiligen Felder |

**Kopfzeile Mitarbeitende (27 Spalten)**

```
Typ;MitarbeiterNr;Anrede;Nachname;Vorname;Geburtsdatum;Geschlecht;AhvNummer;Nationalitaet;GeschaeftsTelefon;Mobile;Email;Abteilung;Rolle;Kaderstufe;Stellenprozent;Eintritt;Austritt;Status;PrivatStrasse;PrivatPlz;PrivatOrt;GeschaeftsStrasse;GeschaeftsPlz;GeschaeftsOrt;Lehrjahre;AktuellesLehrjahr
```

**Kopfzeile Kundschaft (14 Spalten)**

```
KundenNr;Anrede;Titel;Nachname;Vorname;Geburtsdatum;Geschlecht;Telefon;Mobile;Email;Status;Strasse;Plz;Ort
```

Hinweise:

- Die Spalte **`Typ`** unterscheidet `Mitarbeiter` und `Lernender` und verhindert zugleich,
  dass eine Mitarbeitenden-Datei versehentlich in der Kundenliste importiert wird.
- **`MitarbeiterNr` / `KundenNr` werden beim Import nicht gelesen** — die laufenden Nummern
  vergibt die Business-Schicht selbst. Die Spalten sind nur befüllt, damit die Dateien wie
  echte Exporte aussehen.
- Pflichtspalten in der Kopfzeile: `Typ`, `Nachname`, `Vorname` (Mitarbeitende) bzw.
  `Nachname`, `Vorname` (Kundschaft). Optionale Spalten dürfen fehlen, die Reihenfolge ist frei.

## Übersicht der Dateien

| Datei | Inhalt |
|---|---|
| `Mitarbeitende_gueltig.csv` | 8 fehlerfreie Mitarbeitende und Lernende |
| `Kundschaft_gueltig.csv` | 8 fehlerfreie Kundinnen und Kunden |
| `Mitarbeitende_fehlerhaft.csv` | 20 Zeilen mit je **einem** gezielten Fehler |
| `Kundschaft_fehlerhaft.csv` | 11 Zeilen mit je **einem** gezielten Fehler |
| `Mitarbeitende_KopfzeileUnvollstaendig.csv` | Kopfzeile ohne `Nachname`/`Vorname` |
| `Leer.csv` | leere Datei |

Die gültigen Dateien lassen sich mehrfach importieren — es entstehen dann Duplikate mit
neuen laufenden Nummern, was gewollt ist (der Import prüft nicht auf Doubletten).

## Erwartete Fehlermeldungen

Die Validierung ist **fail-fast**: pro Zeile wird nur der erste Verstoss gemeldet. Deshalb
enthält jede Zeile der Fehlerdateien genau einen Defekt. Fehlerhafte Zeilen brechen den
Import **nicht** ab — die übrigen Zeilen werden übernommen und die Fehler am Schluss
gesammelt angezeigt.

### `Mitarbeitende_fehlerhaft.csv`

| Zeile | Nachname | Fehler | Erwartete Meldung |
|---|---|---|---|
| 2 | Typleer | `Typ` ist leer | Die Spalte „Typ" ist leer … |
| 3 | Typfalsch | `Typ` = `Praktikant` | Unbekannter Typ „Praktikant" (erwartet: „Mitarbeiter" oder „Lernender") |
| 4 | Datumsformat | Geburtsdatum `32.13.1990` | … ist kein gültiges Datum (TT.MM.JJJJ). |
| 5 | Datumsbereich | Geburtsdatum `01.01.1899` | … liegt ausserhalb des zulässigen Bereichs … |
| 6 | Zahlformat | Stellenprozent `achtzig` | … ist keine gültige Zahl. |
| 7 | Statusfalsch | Status `halbaktiv` | Unbekannter Status „halbaktiv" (erwartet: „Aktiv" oder „Passiv"). |
| 8 | Anredefalsch | Anrede `Fräulein` | Unbekannte Anrede „Fräulein". |
| 9 | Geschlechtfalsch | Geschlecht `unbekannt` | Unbekanntes Geschlecht „unbekannt". |
| 10 | Feldzahl | nur 10 statt 27 Felder | Die Zeile hat nur 10 statt 27 Felder. |
| 11 | Vornameleer | Vorname leer | Der Vorname darf nicht leer sein. |
| 12 | *(leer)* | Nachname leer | Der Nachname darf nicht leer sein. |
| 13 | Mailfalsch | E-Mail ohne `@` | Die E-Mail-Adresse „…" hat kein gültiges Format. |
| 14 | Zukunft | Geburtsdatum `01.01.2090` | Das Geburtsdatum darf nicht in der Zukunft liegen. |
| 15 | Pensumzuhoch | Stellenprozent `150` | Der Beschäftigungsgrad muss zwischen 0 und 100 Prozent liegen. |
| 16 | Kaderstufezuhoch | Kaderstufe `9` | Die Kaderstufe muss zwischen 0 und 5 liegen. |
| 17 | Austrittzufrueh | Austritt vor Eintritt | Das Austrittsdatum darf nicht vor dem Eintrittsdatum liegen. |
| 18 | Plzfalsch | PLZ `900` | Die Postleitzahl „900" ist keine gültige Schweizer PLZ (4-stellig). |
| 19 | Strasseleer | Strasse leer, PLZ/Ort gesetzt | Die Strasse darf nicht leer sein. |
| 20 | Lehrjahrenull | Lernender mit `Lehrjahre` = 0 | Die Anzahl Lehrjahre muss grösser als 0 sein. |
| 21 | Lehrjahrzuhoch | Lehrjahr 5 von 3 | Das aktuelle Lehrjahr muss zwischen 1 und der Anzahl Lehrjahre liegen. |

Die Zeilen 2–10 werden bereits beim **Einlesen der Datei** abgewiesen, die Zeilen 11–21
erst von der **Validierung der Business-Schicht** (`ValidationException`) — beide Wege
landen im selben Fehlerbericht.

### `Kundschaft_fehlerhaft.csv`

| Zeile | Nachname | Fehler | Erwartete Meldung |
|---|---|---|---|
| 2 | Vornameleer | Vorname leer | Der Vorname darf nicht leer sein. |
| 3 | *(leer)* | Nachname leer | Der Nachname darf nicht leer sein. |
| 4 | Mailfalsch | E-Mail ohne `@` | Die E-Mail-Adresse „…" hat kein gültiges Format. |
| 5 | Zukunft | Geburtsdatum `01.01.2090` | Das Geburtsdatum darf nicht in der Zukunft liegen. |
| 6 | Datumsformat | Geburtsdatum `12.13.1990` | … ist kein gültiges Datum (TT.MM.JJJJ). |
| 7 | Statusfalsch | Status `halbaktiv` | Unbekannter Status „halbaktiv" … |
| 8 | Anredefalsch | Anrede `Fräulein` | Unbekannte Anrede „Fräulein". |
| 9 | Geschlechtfalsch | Geschlecht `unbekannt` | Unbekanntes Geschlecht „unbekannt". |
| 10 | Plzfalsch | PLZ `12345` | Die Postleitzahl „12345" ist keine gültige Schweizer PLZ (4-stellig). |
| 11 | Ortleer | Ort leer, Strasse/PLZ gesetzt | Der Ort darf nicht leer sein. |
| 12 | Feldzahl | nur 7 statt 14 Felder | Die Zeile hat nur 7 statt 14 Felder. |

### Dateien, die komplett abgewiesen werden

| Datei | Erwartetes Verhalten |
|---|---|
| `Leer.csv` | Meldung „Die Datei ist leer." — keine Zeile wird importiert |
| `Mitarbeitende_KopfzeileUnvollstaendig.csv` | Meldung „Der Kopfzeile fehlen die Spalte(n): Nachname, Vorname" |
| `Mitarbeitende_gueltig.csv` **in der Kundenliste** | Abweisung, weil die Datei die Spalte `Typ` enthält und damit ein Export von Mitarbeitenden ist |
