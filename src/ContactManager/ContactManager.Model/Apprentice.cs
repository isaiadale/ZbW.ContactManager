using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model
{
    /// <summary>
    /// An apprentice. A special kind of <see cref="Employee"/> that additionally
    /// tracks the apprenticeship duration and current year.
    /// </summary>
    public class Apprentice : Employee
    {
        /// <summary>Total duration of the apprenticeship in years (e.g. 3 or 4).</summary>
        public int ApprenticeshipYears { get; set; }

        /// <summary>Current year of the apprenticeship; should not exceed <see cref="ApprenticeshipYears"/>.</summary>
        public int? CurrentApprenticeshipYear { get; set; }
    }
}
