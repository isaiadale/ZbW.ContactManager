using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model
{
    /// <summary>
    /// Postal address (Swiss format). Standalone value object,
    /// referenced by persons as e.g. home or business address.
    /// </summary>
    public class Address
    {
        
        /// <summary>Street including house number, e.g. "Bahnhofstrasse 1".</summary>
        public required string Street { get; set; }

        /// <summary>Swiss postal code (4 digits), e.g. "9000".</summary>
        public required string PostalCode { get; set; }

        /// <summary>City or town, e.g. "St. Gallen".</summary>
        public required string City { get; set; }
        
    }
}
