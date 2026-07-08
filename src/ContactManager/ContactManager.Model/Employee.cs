using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model
{
    /// <summary>
    /// An employee contact. Inherits the common person data from <see cref="Person"/>
    /// and adds employment-specific information.
    /// </summary>
    public class Employee : Person
    {
        /// <summary>
        /// Auto-incremented employee number, assigned by the business layer.
        /// Read-only from outside the model.
        /// </summary>
        public int EmployeeNumber { get; private set; }

        /// <summary>Department the employee belongs to; optional.</summary>
        public string? Department { get; set; }

        /// <summary>Swiss social security (AHV) number as free text; optional.</summary>
        public string? SocialSecurityNumber { get; set; }

        /// <summary>Nationality of the employee; optional.</summary>
        public string? Nationality { get; set; }

        /// <summary>Date the employment started; optional.</summary>
        public DateOnly? HireDate { get; set; }

        /// <summary>Date the employment ended; null while still employed.</summary>
        public DateOnly? TerminationDate { get; set; }

        /// <summary>Employment level in percent (0–100); optional.</summary>
        public int? EmploymentLevel { get; set; }

        /// <summary>Job title / role description; optional.</summary>
        public string? JobTitle { get; set; }

        /// <summary>Management level from 0 (none) to 5 (highest); optional.</summary>
        public int? ManagementLevel { get; set; }

        /// <summary>Business address of the employee; optional.</summary>
        public Address? BusinessAddress { get; set; }

        /// <summary>Home address of the employee; optional.</summary>
        public Address? HomeAddress { get; set; }
    }
}
