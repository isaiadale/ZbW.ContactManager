using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Model.Enums;

namespace ContactManager.Model
{
    /// <summary>
    /// Abstract base class for every person in the system. Bundles the properties
    /// shared by <see cref="Customer"/> and <see cref="Employee"/>. Cannot be
    /// instantiated directly; only its subtypes represent real contacts.
    /// </summary>
    public abstract class Person
    {
        /// <summary>Unique identifier, generated once on creation and never changed.</summary>
        public Guid Id { get; init; } = Guid.NewGuid();

        /// <summary>Form of address (e.g. Mr/Mrs); optional.</summary>
        public Salutation? Salutation { get; set; }

        /// <summary>Given name of the person. Mandatory.</summary>
        public required string FirstName { get; set; }

        /// <summary>Family name of the person. Mandatory.</summary>
        public required string LastName { get; set; }

        /// <summary>Date of birth (without time component); optional.</summary>
        public DateOnly? DateOfBirth { get; set; }

        /// <summary>Gender of the person; optional.</summary>
        public Gender? Gender { get; set; }

        /// <summary>Mobile phone number as free text (keeps leading zeros and "+41"); optional.</summary>
        public string? MobilePhone { get; set; }

        /// <summary>Business phone number as free text; optional.</summary>
        public string? BusinessPhone { get; set; }

        /// <summary>E-mail address; optional.</summary>
        public string? Email { get; set; }
    }
}
