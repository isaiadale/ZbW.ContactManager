using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Model.Enums;

namespace ContactManager.Model
{
    /// <summary>
    /// A customer contact. Inherits the common person data from <see cref="Person"/>
    /// and adds customer-specific information.
    /// </summary>
    public class Customer : Person
    {
        /// <summary>Academic or professional title (e.g. "Dr."); optional.</summary>
        public string? Title { get; set; }

        /// <summary>Whether the customer is currently active or passive. Mandatory.</summary>
        public required Status CustomerStatus { get; set; }

        /// <summary>Postal address of the customer; optional.</summary>
        public Address? Address { get; set; }
    }
}
