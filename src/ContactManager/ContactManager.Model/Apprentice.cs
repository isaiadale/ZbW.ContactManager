using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model
{
    /// <summary>
    /// Ein Lernender. Eine besondere Art von <see cref="Employee"/>, die zusätzlich
    /// die Dauer der Lehre und das aktuelle Lehrjahr festhält.
    /// </summary>
    public class Apprentice : Employee
    {
        /// <summary>Gesamtdauer der Lehre in Jahren (z. B. 3 oder 4).</summary>
        public int ApprenticeshipYears { get; set; }

        /// <summary>Aktuelles Lehrjahr; sollte <see cref="ApprenticeshipYears"/> nicht überschreiten.</summary>
        public int? CurrentApprenticeshipYear { get; set; }
    }
}
