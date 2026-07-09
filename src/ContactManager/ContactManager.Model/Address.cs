using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model
{
    /// <summary>
    /// Postanschrift (Schweizer Format). Eigenständiges Wertobjekt,
    /// das von Personen z. B. als Wohn- oder Geschäftsadresse referenziert wird.
    /// </summary>
    public class Address
    {

        /// <summary>Strasse inklusive Hausnummer, z. B. "Bahnhofstrasse 1".</summary>
        public required string Street { get; set; }

        /// <summary>Schweizer Postleitzahl (4-stellig), z. B. "9000".</summary>
        public required string PostalCode { get; set; }

        /// <summary>Ort bzw. Stadt, z. B. "St. Gallen".</summary>
        public required string City { get; set; }
        
    }
}
