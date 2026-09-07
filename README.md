# ZbW.ContactManager

Windows-Forms-Anwendung (C# / .NET 10) zur Verwaltung von **Mitarbeitenden und Kundschaft**
mit vollständigem CRUD, Notiz-Historie, Suche, Login und CSV-Import/-Export.

Semesterprojekt im Modul **Programming Foundation II** (ZbW, HF Informatik).

---

## Gruppenmitglieder

| Name                   |
| ---------------------- |
| Isaia D'Alessandro     |
| Tobi Rey               |
| Nia Schmid (teilweise) |

---

## 🔑 Zugangsdaten (Demo)

Die Anwendung startet mit einem Anmeldefenster.

| Benutzername | Passwort |
| ------------ | -------- |
| `admin`      | `admin`  |

- Dieses Konto wird beim **ersten Start automatisch angelegt** — das Anmeldefenster weist
  im unteren Bereich darauf hin.
- Die Benutzerdatei `users.json` liegt **neben der Exe** (`bin/Debug/net10.0-windows/`) und
  wird **nicht** ins Git-Repository eingecheckt.
- Passwörter werden **nie im Klartext** gespeichert: PBKDF2 mit SHA-256, 210 000 Iterationen
  und einem zufälligen Salt pro Benutzer (`ContactManager.Business/Helpers/PasswordHasher.cs`).
  Der Vergleich läuft zeitkonstant (`CryptographicOperations.FixedTimeEquals`).
- **Zurücksetzen:** `users.json` löschen — beim nächsten Start wird `admin` / `admin` neu erzeugt.

> Es handelt sich um ein bewusst dokumentiertes **Demo-Konto** für die Bewertung, nicht um
> ein produktives Geheimnis.

---

## Funktionsumfang

**Pflichtanforderungen**

- Erfassen, Mutieren, Aktivieren/Deaktivieren und Löschen von Mitarbeitenden und Kundschaft
- Lernende als eigene Klasse (`Apprentice`) im selben Formular wie Mitarbeitende
- Automatische Vergabe der Mitarbeiternummer (zusätzlich auch der Kundennummer)
- Notizen zu Kundenkontakten inklusive **Historie** (neuste zuerst, unveränderlich)
- Suche über Vorname, Nachname, Geburtsdatum und laufende Nummer
- **Speichern** des Datenstamms auf die Festplatte

**Umgesetzte optionale Anforderungen**

- **Login** mit dateibasierten Zugangsdaten (`users.json`, PBKDF2-Hash)
- **CSV-Import und -Export** für Mitarbeitende und Kundschaft, inklusive Beispieldateien
  (siehe [Testdaten](#testdaten))

---

## Architektur

Die Solution liegt unter `src/ContactManager/` und besteht aus vier Projekten:

| Projekt                           | Zweck                                       | Referenziert            |
| --------------------------------- | ------------------------------------------- | ----------------------- |
| `ContactManager.Model`            | Datenklassen und Vererbungshierarchie       | —                       |
| `ContactManager.Persistence.Json` | Laden/Speichern via `System.Text.Json`      | Model                   |
| `ContactManager.Business`         | Geschäftslogik, Validierung, CRUD-Regeln    | Model, Persistence.Json |
| `ContactManager.UI.WinForms`      | Windows-Forms-Oberfläche (**Startprojekt**) | Business, Model         |

Abhängigkeitsrichtung: **UI → Business → Persistence → Model**.
Die UI enthält keine Geschäftslogik, das Model kennt keine andere Schicht.

Die UI spricht ausschliesslich mit der **`ContactManagerFacade`** — dem einzigen
öffentlichen Einstiegspunkt der Business-Schicht. Sie lädt den Datenstamm einmalig und
stellt vier Services bereit:

| Property    | Aufgabe                                                                                 |
| ----------- | --------------------------------------------------------------------------------------- |
| `Customers` | `GetAll`, `GetById`, `GetByNumber`, `Add`, `Update`, `Delete`, `Activate`, `Deactivate` |
| `Employees` | dieselben Methoden für Mitarbeitende und Lernende                                       |
| `Notes`     | `AddNote`, `GetNotes` (Kundennotizen, nur anfügen)                                      |
| `Search`    | `Search(SearchCriteria)` über beide Personengruppen                                     |

Das Repository wird der Fassade per Konstruktor übergeben (Dependency Inversion) — die
Business-Schicht kennt nur das Interface `IContactRepository`, nie die JSON-Implementierung.
Zusammengebaut wird alles an genau einer Stelle, in `Program.Main()` (Composition Root).

### Vererbungshierarchie

```
            Person (abstrakt)
           /                \
     Customer              Employee
                              |
                          Apprentice

     Address  (eigenständige Klasse, keine Vererbung)
```

- `Customer` und `Employee` erben von `Person` (Anrede, Name, Geburtsdatum, Geschlecht,
  Kontaktangaben, Status aktiv/passiv).
- `Apprentice` erbt von `Employee` und ergänzt Lehrjahre und aktuelles Lehrjahr.
- `Address` ist eine eigenständige Klasse und wird als Property verwendet
  (Privat- und Geschäftsadresse).

---

## Build & Start

Alle Befehle aus dem Solution-Verzeichnis:

```bash
cd src/ContactManager

# Solution bauen
dotnet build ContactManager.slnx

# Anwendung starten
dotnet run --project ContactManager.UI.WinForms
```

> **Plattform:** `ContactManager.UI.WinForms` zielt auf `net10.0-windows` und läuft nur
> unter **Windows**. Die drei Bibliotheksprojekte (`net10.0`) sind plattformunabhängig.

In Visual Studio: `ContactManager.slnx` öffnen, `ContactManager.UI.WinForms` als
Startprojekt setzen, F5.

---

## Datenablage

- Der gesamte Datenstamm liegt in **`contacts.json`** neben der Exe
  (`src/ContactManager/ContactManager.UI.WinForms/bin/Debug/net10.0-windows/`).
- Gespeichert wird **automatisch** nach jeder Änderung — kein Speichern-Button.
- Fehlt die Datei, startet die Anwendung mit leerem Datenstamm.
- Ist die Datei beschädigt, wird sie als `contacts.json.backup_<Zeitstempel>` gesichert und
  die Anwendung meldet dies verständlich, statt abzustürzen. Dasselbe gilt für `users.json`.
- Beide Dateien sind über `.gitignore` (`bin/`) vom Repository ausgeschlossen — jede
  Installation hat ihren eigenen Datenstamm.

---

## Testdaten

Der Ordner **[`Testdaten/`](Testdaten/)** enthält CSV-Dateien zum Ausprobieren des Imports:

- `Mitarbeitende_gueltig.csv` / `Kundschaft_gueltig.csv` — fehlerfreie Datensätze
- `Mitarbeitende_fehlerhaft.csv` / `Kundschaft_fehlerhaft.csv` — pro Zeile **ein**
  gezielter Fehler, um Validierung und Fehlermeldungen vorzuführen
- `Mitarbeitende_KopfzeileUnvollstaendig.csv` und `Leer.csv` — fehlerhafte Dateien, die
  bereits beim Einlesen abgewiesen werden

Import und Export laufen über die Schaltflächen **CSV Import** / **CSV Export** in der
Mitarbeiter- bzw. Kundenliste. Details und die erwarteten Fehlermeldungen stehen in
[`Testdaten/README.md`](Testdaten/README.md).

---

## Projektstruktur

```
ZbW.ContactManager/
├── README.md
├── Testdaten/                                  Beispiel-CSV-Dateien für den Import
├── Klassendiagramm.drawio.pdf
├── Semesterprojekt ContactManager_Stand 17.08.26.pdf
└── src/ContactManager/
    ├── ContactManager.slnx
    ├── ContactManager.Model/                   Person, Customer, Employee, Apprentice, Address, …
    ├── ContactManager.Persistence.Json/        JsonContactRepository, JsonUserRepository
    ├── ContactManager.Business/                Services, ContactManagerFacade, Validierung
    └── ContactManager.UI.WinForms/             Formulare, Startprojekt
```

---

## Konventionen

- **Code auf Englisch** (Klassen, Properties, Methoden), **Inline-Dokumentation auf Deutsch**
  (`/// <summary>` auf allen `public`-Membern).
- Meldungen an die Benutzerin/den Benutzer sind durchgehend deutsch.
- Fehleingaben werden abgefangen (`TryParse`, zentrale Validierung in
  `ContactManager.Business/Helpers/ContactValidator.cs`) — ungültige Daten werden nie
  gespeichert, die Anwendung stürzt nicht ab.

---

## Referenzen

- Aufgabenstellung: `Semesterprojekt ContactManager_Stand 17.08.26.pdf`
- Klassendiagramm: `Klassendiagramm.drawio.pdf`
