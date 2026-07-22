# Business-Schicht — Benutzung durch die UI

Diese Beschreibung richtet sich an die **UI-Schicht** (`ContactManager.UI.WinForms`) und
erklärt, wie die Geschäftslogik korrekt verwendet wird. Die UI kennt **ausschliesslich**
die Fassade `ContactManagerFacade` und die Model-Klassen — nie die einzelnen Services
direkt (deren Konstruktoren sind bewusst `internal`).

Abhängigkeitsrichtung: **UI → Business → Persistence → Model**.

---

## 1. Einstieg: Fassade aufbauen

Die UI baut **einmal** beim Start ein Repository und übergibt es der Fassade. Ab da läuft
alles über die Fassade.

```csharp
using ContactManager.Business;
using ContactManager.Persistence.Json;

// 1. Konkrete Ablage wählen (JSON-Datei auf der Festplatte).
IContactRepository repository = new JsonContactRepository(pfadZurDatei);

// 2. Fassade erzeugen — lädt den Datenstamm genau einmal und baut alle Services auf.
var contacts = new ContactManagerFacade(repository);
```

> **Hinweis:** Die Fassade lädt im Konstruktor **einmalig** den kompletten Datenstamm.
> Alle Services teilen sich anschliessend dieselben Daten. Es gibt **kein** manuelles
> „Laden" oder „Speichern" — siehe [Automatisches Speichern](#7-automatisches-speichern).

Die Fassade stellt vier Services als Properties bereit:

| Property | Typ | Zuständigkeit |
|---|---|---|
| `contacts.Customers` | `CustomerService` | Kunden: CRUD + Aktiv/Passiv |
| `contacts.Employees` | `EmployeeService` | Mitarbeiter **und** Lernende: CRUD + Aktiv/Passiv |
| `contacts.Notes` | `ContactNoteService` | Notizen zu Kunden (Historie) |
| `contacts.Search` | `SearchService` | Lesende Suche über alle Personen |

---

## 2. Kunden verwalten (`contacts.Customers`)

| Methode | Rückgabe | Beschreibung |
|---|---|---|
| `GetAll()` | `IReadOnlyList<Customer>` | Alle Kunden. |
| `GetById(Guid id)` | `Customer?` | Kunde oder `null`, wenn nicht gefunden. |
| `GetByNumber(int customerNumber)` | `Customer?` | Kunde oder `null`. |
| `Add(Customer customer)` | `void` | Erfasst neu, **vergibt die Kundennummer automatisch**, speichert. |
| `Update(Customer customer)` | `void` | Überträgt Änderungen auf den bestehenden Kunden (per `Id`), speichert. |
| `Delete(Guid id)` | `void` | Löscht, speichert. |
| `Activate(Guid id)` | `void` | Setzt Status auf `Active`, speichert. |
| `Deactivate(Guid id)` | `void` | Setzt Status auf `Passive`, speichert. |

### Kunde erfassen

```csharp
var kunde = new Customer
{
    // Pflichtfelder (required):
    FirstName = "Anna",
    LastName = "Muster",
    PersonStatus = Status.Active,

    // Optional:
    Salutation = Salutation.Mrs,
    Email = "anna.muster@example.ch",
    Title = "Dr.",
    Address = new Address
    {
        Street = "Bahnhofstrasse 1",
        PostalCode = "9000",
        City = "St. Gallen"
    }
};

contacts.Customers.Add(kunde);
// Erst NACH Add trägt kunde.CustomerNumber die vergebene Nummer.
```

> ⚠️ **`CustomerNumber` nie selbst setzen** — die Nummer ist von aussen schreibgeschützt
> und wird beim `Add` automatisch vergeben. Vor dem `Add` ist sie `0`.

### Kunde mutieren

`Update` findet den bestehenden Kunden über seine **`Id`** und kopiert die geänderten
Felder darauf. `Id` und `CustomerNumber` bleiben dabei garantiert unverändert.

```csharp
kunde.Email = "neu@example.ch";
contacts.Customers.Update(kunde);   // kunde muss dieselbe Id wie der gespeicherte tragen
```

Typisches UI-Muster: den zu bearbeitenden Kunden per `GetById` holen, Felder aus dem
Formular übernehmen, `Update` aufrufen.

---

## 3. Mitarbeiter und Lernende verwalten (`contacts.Employees`)

Gleiche Methoden wie beim `CustomerService`, aber für `Employee`. **Wichtig:** Dank
Vererbung deckt *ein* `Add(Employee)` sowohl `Employee` als auch `Apprentice` ab — es gibt
keinen separaten „ApprenticeService".

| Methode | Rückgabe | Beschreibung |
|---|---|---|
| `GetAll()` | `IReadOnlyList<Employee>` | Alle Mitarbeiter, **inkl. Lernende**. |
| `GetById(Guid id)` | `Employee?` | Mitarbeiter oder `null`. |
| `GetByNumber(int employeeNumber)` | `Employee?` | Mitarbeiter oder `null`. |
| `Add(Employee employee)` | `void` | Erfasst neu, **vergibt die Mitarbeiternummer automatisch**, speichert. |
| `Update(Employee employee)` | `void` | Überträgt Änderungen (per `Id`), speichert. Bei Lernenden werden auch die Lehr-Felder übernommen. |
| `Delete(Guid id)` | `void` | Löscht, speichert. |
| `Activate(Guid id)` | `void` | Setzt Status auf `Active`, speichert. |
| `Deactivate(Guid id)` | `void` | Setzt Status auf `Passive`, speichert. |

### Lernenden erfassen

```csharp
var lernender = new Apprentice
{
    FirstName = "Tim",
    LastName = "Beispiel",
    PersonStatus = Status.Active,
    HireDate = new DateOnly(2025, 8, 1),
    EmploymentLevel = 100,
    ManagementLevel = 0,
    ApprenticeshipYears = 4,
    CurrentApprenticeshipYear = 1
};

contacts.Employees.Add(lernender);
```

> **Lernende in der Liste erkennen:** `GetAll()` liefert `Employee` — ein Lernender ist
> zugleich ein `Employee`. Zum Unterscheiden in der UI ein Typtest:
> `if (employee is Apprentice a) { /* a.CurrentApprenticeshipYear … */ }`.

---

## 4. Notizen zu Kunden (`contacts.Notes`)

Kundenkontakte werden als **laufende Historie** dokumentiert. Notizen werden nur
**angehängt** und nie geändert oder gelöscht.

| Methode | Rückgabe | Beschreibung |
|---|---|---|
| `AddNote(Guid customerId, string text)` | `void` | Hängt eine Notiz mit Zeitstempel an, speichert. |
| `GetNotes(Guid customerId)` | `IReadOnlyList<ContactNote>` | Notizen des Kunden, **neueste zuerst**. |

```csharp
contacts.Notes.AddNote(kunde.Id, "Telefonat: Kunde wünscht Rückruf nächste Woche.");

foreach (ContactNote note in contacts.Notes.GetNotes(kunde.Id))
{
    // note.CreatedAt (DateTime), note.Text (string) — beide nur lesbar
}
```

> Notizen gibt es nur für **Kunden**, nicht für Mitarbeiter. Ein leerer/leerzeichen-only
> Notiztext wird abgewiesen (`ArgumentException`).

---

## 5. Suche (`contacts.Search`)

Rein lesend. Die UI füllt ein `SearchCriteria`-Objekt; **jedes gesetzte Feld verengt** die
Treffermenge, `null`-Felder werden ignoriert. Alle Felder `null` ⇒ alle Personen.

```csharp
using ContactManager.Business.Search;

var criteria = new SearchCriteria
{
    LastName = "mus",                 // Teiltreffer, Gross-/Kleinschreibung egal
    Type = ContactType.Customer       // nur Kunden
    // FirstName, DateOfBirth, Number bleiben null → ignoriert
};

IReadOnlyList<Person> treffer = contacts.Search.Search(criteria);
```

`SearchCriteria`-Felder:

| Feld | Typ | Verhalten |
|---|---|---|
| `FirstName` | `string?` | Teiltreffer, case-insensitive |
| `LastName` | `string?` | Teiltreffer, case-insensitive |
| `DateOfBirth` | `DateOnly?` | exakter Treffer |
| `Type` | `ContactType?` | `Customer` / `Employee` / `Apprentice` |
| `Number` | `int?` | Kunden- **oder** Mitarbeiternummer (je nach Typ der Person) |

> ⚠️ **`ContactType.Employee` schliesst Lernende bewusst aus.** Lernende sind nur über
> `ContactType.Apprentice` auffindbar.

Die Suche liefert `IReadOnlyList<Person>` (der gemeinsame Basistyp). Zum Anzeigen der
typspezifischen Felder in der UI ein Typtest:

```csharp
foreach (Person p in treffer)
{
    switch (p)
    {
        case Apprentice a: /* Lernender */ break;
        case Employee e:   /* Mitarbeiter */ break;
        case Customer c:   /* Kunde */ break;
    }
}
```

---

## 6. Model-Klassen im Überblick

Die UI erzeugt und liest diese Klassen. **Pflichtfelder** (`required`) müssen beim Erzeugen
gesetzt werden, alles andere ist optional (`null` erlaubt).

### `Person` (abstrakt — gemeinsame Felder von Kunde & Mitarbeiter)
`Id` (auto), **`FirstName`**, **`LastName`**, **`PersonStatus`**, `Salutation?`,
`DateOfBirth?`, `Gender?`, `MobilePhone?`, `BusinessPhone?`, `Email?`

### `Customer : Person`
`CustomerNumber` (auto, nur lesen), `Title?`, `Address?`, `Notes` (über den NoteService)

### `Employee : Person`
`EmployeeNumber` (auto, nur lesen), `Department?`, `SocialSecurityNumber?`, `Nationality?`,
`HireDate?`, `TerminationDate?`, `EmploymentLevel?` (0–100), `JobTitle?`,
`ManagementLevel?` (0–5), `BusinessAddress?`, `HomeAddress?`

### `Apprentice : Employee`
`ApprenticeshipYears` (int), `CurrentApprenticeshipYear?`

### `Address`
**`Street`**, **`PostalCode`** (4-stellig), **`City`**

### `ContactNote` (nur über den NoteService erzeugt)
`Id` (auto), `CreatedAt` (auto), `Text` (nur lesen)

### Enums
- `Status`: `Active` (1), `Passive` (2)
- `Gender`: `Male` (1), `Female` (2), `Diverse` (3)
- `Salutation`: `Mr` (1), `Mrs` (2)
- `ContactType`: `Customer` (1), `Employee` (2), `Apprentice` (3)

---

## 7. Automatisches Speichern

Es gibt **keinen Speichern-Button**. Jede mutierende Methode (`Add`, `Update`, `Delete`,
`Activate`, `Deactivate`, `AddNote`) schreibt den Datenstamm sofort auf die Festplatte.
Reine Lesemethoden (`GetAll`, `GetById`, `Search`, `GetNotes`) speichern nicht.

Ebenso wird beim Erstellen der Fassade **automatisch geladen**. Fehlt die Datei beim ersten
Start, beginnt die App mit leerem Datenstamm (das Repository wirft dann **nicht**).

---

## 8. Fehlerbehandlung (was die UI abfangen muss)

Die Meldungen der `ValidationException` sind **deutsch und für Endanwender gedacht** — sie
können direkt in einer MessageBox angezeigt werden. Die übrigen Exceptions signalisieren
eher Programmier- oder Datenfehler.

| Exception | Namespace | Wann | Empfehlung UI |
|---|---|---|---|
| `ValidationException` | `ContactManager.Business.Exceptions` | Ungültige Eingabe (leerer Name, E-Mail-Format, PLZ, Wertebereiche, Datumsreihenfolge …) | `.Message` in MessageBox anzeigen |
| `ArgumentException` | `System` | Leerer Notiztext bei `AddNote` | Hinweis anzeigen |
| `KeyNotFoundException` | `System` | `Id` existiert nicht (z. B. bereits gelöscht) | „Datensatz nicht gefunden" |
| `InvalidOperationException` | `System` | Doppelte `Id` beim `Add` / Nummer bereits vergeben | generische Fehlermeldung |
| `ArgumentNullException` | `System` | `null` übergeben | Programmierfehler — sollte nicht passieren |

Typisches Muster beim Speichern aus einem Formular:

```csharp
try
{
    contacts.Customers.Add(kunde);
}
catch (ValidationException ex)
{
    MessageBox.Show(ex.Message, "Ungültige Eingabe",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
```

### Validierungsregeln (Auslöser einer `ValidationException`)

Die UI kann diese Regeln vorab prüfen (bessere Usability), muss die Exception aber in jedem
Fall abfangen:

- Vor- und Nachname nicht leer / nicht nur Leerzeichen
- `Email` (falls gesetzt) hat ein gültiges Format
- `DateOfBirth` (falls gesetzt) liegt nicht in der Zukunft
- `Address`: Strasse und Ort nicht leer, PLZ genau **4 Ziffern**
- `Employee`: `EmploymentLevel` 0–100, `ManagementLevel` 0–5,
  `TerminationDate` nicht vor `HireDate`
- `Apprentice`: `ApprenticeshipYears` > 0, `CurrentApprenticeshipYear` zwischen 1 und
  `ApprenticeshipYears`

---

## 9. Vollständiges Beispiel

```csharp
using ContactManager.Business;
using ContactManager.Business.Exceptions;
using ContactManager.Business.Search;
using ContactManager.Model;
using ContactManager.Model.Enums;
using ContactManager.Persistence.Json;

// Start
IContactRepository repository = new JsonContactRepository(pfadZurDatei);
var contacts = new ContactManagerFacade(repository);

// Kunde erfassen (Nummer wird automatisch vergeben, sofort gespeichert)
var kunde = new Customer
{
    FirstName = "Anna",
    LastName = "Muster",
    PersonStatus = Status.Active,
    Email = "anna.muster@example.ch"
};

try
{
    contacts.Customers.Add(kunde);
}
catch (ValidationException ex)
{
    MessageBox.Show(ex.Message);
    return;
}

// Notiz dokumentieren
contacts.Notes.AddNote(kunde.Id, "Erstkontakt am Telefon.");

// Deaktivieren
contacts.Customers.Deactivate(kunde.Id);

// Suchen
IReadOnlyList<Person> treffer = contacts.Search.Search(new SearchCriteria
{
    LastName = "muster",
    Type = ContactType.Customer
});
```
