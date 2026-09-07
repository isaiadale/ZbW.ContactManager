using ContactManager.Business.Statistics;
using ContactManager.Model;

namespace ContactManager.Business.Services
{
    /// <summary>
    /// Geschäftslogik für die Kennzahlen des Dashboards. Rein lesend: verdichtet die
    /// geladenen Kunden und Mitarbeiter (inkl. Lernende) zu Auswertungen, ohne den
    /// Datenstamm zu verändern oder zu persistieren. Folgt damit demselben Muster wie
    /// <see cref="SearchService"/>: kein <see cref="Persistence.Json.IContactRepository"/>,
    /// kein <c>SaveChanges</c>.
    /// </summary>
    public class StatisticsService
    {
        private readonly List<Customer> _customers;

        private readonly List<Employee> _employees;

        /// <summary>
        /// Erzeugt den Service auf Basis der bereits geladenen Listen.
        /// Wird von der Fassade aufgebaut, nicht direkt von der UI.
        /// </summary>
        /// <param name="customers">Alle erfassten Kunden des Datenstamms.</param>
        /// <param name="employees">Alle erfassten Mitarbeiter (inkl. Lernende) des Datenstamms.</param>
        internal StatisticsService(List<Customer> customers, List<Employee> employees)
        {
            ArgumentNullException.ThrowIfNull(customers);
            ArgumentNullException.ThrowIfNull(employees);

            _customers = customers;
            _employees = employees;
        }

        /// <summary>
        /// Berechnet sämtliche Kennzahlen des Dashboards zum heutigen Datum in einem
        /// einzigen Durchgang über den Datenstamm.
        /// </summary>
        /// <param name="topCount">Anzahl Einträge je „Top"-Auswertung (Nationalitäten, Orte, Postleitzahlen).</param>
        /// <returns>Die verdichteten Kennzahlen; nie <c>null</c>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Wird geworfen, wenn <paramref name="topCount"/> kleiner als 1 ist.</exception>
        public DashboardStatistics GetSnapshot(int topCount = 5) =>
            GetSnapshot(DateOnly.FromDateTime(DateTime.Today), topCount);

        /// <summary>
        /// Berechnet sämtliche Kennzahlen des Dashboards zu einem frei wählbaren Stichtag
        /// in einem einzigen Durchgang über den Datenstamm. Der Stichtag bestimmt u. a.
        /// das Referenzalter, die laufende Betriebszugehörigkeit und die Zwölf-Monats-Fenster.
        /// </summary>
        /// <param name="referenceDate">Der Stichtag, auf den sich alle Kennzahlen beziehen.</param>
        /// <param name="topCount">Anzahl Einträge je „Top"-Auswertung (Nationalitäten, Orte, Postleitzahlen).</param>
        /// <returns>Die verdichteten Kennzahlen; nie <c>null</c>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Wird geworfen, wenn <paramref name="topCount"/> kleiner als 1 ist.</exception>
        public DashboardStatistics GetSnapshot(DateOnly referenceDate, int topCount = 5)
        {
            if (topCount < 1)
                throw new ArgumentOutOfRangeException(nameof(topCount), "Die Anzahl Top-Einträge muss mindestens 1 sein.");

            // Mitarbeiter (inkl. Lernende) und Kunden zu einer gemeinsamen Personen-Sequenz
            // vereinen - dieselbe Idee wie in SearchService.Search.
            List<Person> allPersons = _customers.Cast<Person>().Concat(_employees).ToList();

            // Lernende stecken in _employees mit drin (Employee.GetAll enthält sie) - hier
            // einmalig sauber getrennt, damit sich kein Aufruf verzählt.
            List<Employee> staffOnly = _employees.Where(e => e is not Apprentice).ToList();
            List<Apprentice> apprentices = _employees.OfType<Apprentice>().ToList();

            return new DashboardStatistics
            {
                Mix = BuildMix(staffOnly, apprentices),
                Employees = BuildGroup(_employees),
                Apprentices = BuildGroup(apprentices),
                Customers = BuildGroup(_customers),
                Compact = BuildCompact(allPersons),
                Timeline = BuildTimeline(allPersons, referenceDate),
                Staff = BuildStaff(topCount),
                Quality = BuildQuality(allPersons, topCount)
            };
        }

        // Anteile für das gemeinsame Ringdiagramm: Mitarbeitende ohne Lernende, Lernende
        // und Kundschaft separat, damit die drei Segmente zusammen 100 % ergeben.
        private ContactMixStatistics BuildMix(List<Employee> staffOnly, List<Apprentice> apprentices) =>
            new()
            {
                EmployeeCount = staffOnly.Count,
                ApprenticeCount = apprentices.Count,
                CustomerCount = _customers.Count,
                TotalCount = staffOnly.Count + apprentices.Count + _customers.Count
            };

        // Gesamtzahl und Status-Aufteilung einer Personengruppe.
        private static GroupStatistics BuildGroup(IReadOnlyCollection<Person> people) =>
            new()
            {
                Total = people.Count,
                ActiveCount = people.Count(p => p.PersonStatus == Model.Enums.Status.Active),
                PassiveCount = people.Count(p => p.PersonStatus == Model.Enums.Status.Passive)
            };

        private CompactStatistics BuildCompact(List<Person> allPersons)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            List<int> ages = allPersons
                .Where(p => p.DateOfBirth is not null && p.DateOfBirth.Value <= today)
                .Select(p => CalculateAge(p.DateOfBirth!.Value, today))
                .ToList();

            List<int> employmentLevels = _employees
                .Where(e => e.EmploymentLevel is not null)
                .Select(e => e.EmploymentLevel!.Value)
                .ToList();

            IReadOnlyList<GenderCount> genderDistribution = allPersons
                .GroupBy(p => p.Gender)
                .Select(g => new GenderCount { Gender = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Gender.HasValue ? (int)x.Gender.Value : int.MaxValue)
                .ToList();

            IReadOnlyList<LabelCount> employeesPerDepartment = _employees
                .Select(e => e.Department?.Trim())
                .Where(d => !string.IsNullOrWhiteSpace(d))
                .GroupBy(d => d!, StringComparer.OrdinalIgnoreCase)
                .Select(g => new LabelCount { Label = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Label, StringComparer.OrdinalIgnoreCase)
                .ToList();

            return new CompactStatistics
            {
                AverageAge = ages.Count == 0 ? null : ages.Average(),
                GenderDistribution = genderDistribution,
                EmployeesPerDepartment = employeesPerDepartment,
                AverageEmploymentLevel = employmentLevels.Count == 0 ? null : employmentLevels.Average(),
                NoteCount = _customers.Sum(c => c.Notes.Count)
            };
        }

        private TimelineStatistics BuildTimeline(List<Person> allPersons, DateOnly referenceDate)
        {
            List<(int Year, int Month)> buckets = BuildLastTwelveMonths(referenceDate);
            DateOnly windowStart = new DateOnly(referenceDate.Year, referenceDate.Month, 1).AddMonths(-11);
            DateTime windowStartTime = windowStart.ToDateTime(TimeOnly.MinValue);
            DateTime windowEndTime = referenceDate.ToDateTime(TimeOnly.MaxValue);

            // Eintritte jahresweise statt in ein Zwölf-Monats-Fenster: Anders als Notizen
            // liegen Eintritte oft Jahre zurück, ein Monatsraster wäre praktisch leer.
            IReadOnlyList<YearCount> hiresPerYear = _employees
                .Where(e => e.HireDate is not null)
                .GroupBy(e => e.HireDate!.Value.Year)
                .Select(g => new YearCount { Year = g.Key, Count = g.Count() })
                .OrderBy(x => x.Year)
                .ToList();

            Dictionary<(int, int), int> notes = _customers
                .SelectMany(c => c.Notes)
                .Where(n => n.CreatedAt >= windowStartTime && n.CreatedAt <= windowEndTime)
                .GroupBy(n => (n.CreatedAt.Year, n.CreatedAt.Month))
                .ToDictionary(g => g.Key, g => g.Count());

            List<double> tenures = _employees
                .Where(e => e.HireDate is not null)
                .Select(e => (e.TerminationDate ?? referenceDate).DayNumber - e.HireDate!.Value.DayNumber)
                .Where(days => days >= 0)
                .Select(days => days / 365.25d)
                .ToList();

            return new TimelineStatistics
            {
                HiresPerYear = hiresPerYear,
                NotesPerMonth = ToMonthCounts(buckets, notes),
                BirthdaysThisMonth = allPersons.Count(p => p.DateOfBirth?.Month == referenceDate.Month),
                AverageTenureYears = tenures.Count == 0 ? null : tenures.Average()
            };
        }

        private StaffStatistics BuildStaff(int topCount)
        {
            IReadOnlyList<ValueCount> managementLevels = _employees
                .Where(e => e is not Apprentice && e.ManagementLevel is not null)
                .GroupBy(e => e.ManagementLevel)
                .Select(g => new ValueCount { Value = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Value)
                .ToList();

            IReadOnlyList<ValueCount> apprenticesPerYear = _employees
                .OfType<Apprentice>()
                .GroupBy(a => a.CurrentApprenticeshipYear)
                .Select(g => new ValueCount { Value = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Value)
                .ToList();

            IReadOnlyList<LabelCount> topNationalities = _employees
                .Select(e => e.Nationality?.Trim())
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .GroupBy(n => n!, StringComparer.OrdinalIgnoreCase)
                .Select(g => new LabelCount { Label = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Label, StringComparer.OrdinalIgnoreCase)
                .Take(topCount)
                .ToList();

            return new StaffStatistics
            {
                ManagementLevels = managementLevels,
                ApprenticesPerYear = apprenticesPerYear,
                TopNationalities = topNationalities,
                PartTimeCount = _employees.Count(e => e.EmploymentLevel is not null && e.EmploymentLevel.Value < 100),
                LeftCount = _employees.Count(e => e.TerminationDate is not null)
            };
        }

        private DataQualityStatistics BuildQuality(List<Person> allPersons, int topCount)
        {
            IReadOnlyList<LabelCount> topCities = _customers
                .Select(c => c.Address?.City?.Trim())
                .Where(city => !string.IsNullOrWhiteSpace(city))
                .GroupBy(city => city!, StringComparer.OrdinalIgnoreCase)
                .Select(g => new LabelCount { Label = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Label, StringComparer.OrdinalIgnoreCase)
                .Take(topCount)
                .ToList();

            IReadOnlyList<LabelCount> topPostalCodes = _customers
                .Select(c => c.Address?.PostalCode?.Trim())
                .Where(plz => !string.IsNullOrWhiteSpace(plz))
                .GroupBy(plz => plz!, StringComparer.OrdinalIgnoreCase)
                .Select(g => new LabelCount { Label = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Label, StringComparer.OrdinalIgnoreCase)
                .Take(topCount)
                .ToList();

            return new DataQualityStatistics
            {
                WithoutEmail = allPersons.Count(p => string.IsNullOrWhiteSpace(p.Email)),
                WithoutPhone = allPersons.Count(p =>
                    string.IsNullOrWhiteSpace(p.MobilePhone) && string.IsNullOrWhiteSpace(p.BusinessPhone)),
                WithoutAddress = _customers.Count(c => c.Address is null),
                TopCustomerCities = topCities,
                TopCustomerPostalCodes = topPostalCodes,
                CustomersWithoutNote = _customers.Count(c => c.Notes.Count == 0)
            };
        }

        // Berechnet das erreichte Alter in vollen Jahren zum Stichtag.
        private static int CalculateAge(DateOnly birthDate, DateOnly referenceDate)
        {
            int age = referenceDate.Year - birthDate.Year;

            // Geburtstag im laufenden Jahr noch nicht erreicht -> ein Jahr abziehen.
            if (birthDate > referenceDate.AddYears(-age))
                age--;

            return age;
        }

        // Erzeugt die zwölf Monatskörbe bis und mit dem Stichtagsmonat, chronologisch.
        private static List<(int Year, int Month)> BuildLastTwelveMonths(DateOnly referenceDate)
        {
            DateOnly firstBucket = new DateOnly(referenceDate.Year, referenceDate.Month, 1).AddMonths(-11);

            return Enumerable.Range(0, 12)
                .Select(offset => firstBucket.AddMonths(offset))
                .Select(date => (date.Year, date.Month))
                .ToList();
        }

        // Füllt die zwölf Monatskörbe mit den gezählten Werten auf; Monate ohne Treffer
        // erhalten 0, damit ein Balkendiagramm keine Lücken in der Zeitachse hat.
        private static IReadOnlyList<MonthCount> ToMonthCounts(
            List<(int Year, int Month)> buckets, Dictionary<(int, int), int> counts) =>
            buckets
                .Select(b => new MonthCount
                {
                    Year = b.Year,
                    Month = b.Month,
                    Count = counts.TryGetValue(b, out int count) ? count : 0
                })
                .ToList();
    }
}
