using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Search
{
    /// <summary>
    /// Art eines Kontakts, um eine Suche auf einen Personentyp einzugrenzen.
    /// Beginnt bei <c>1</c>, damit <c>0</c> nicht versehentlich ein gültiger Wert ist.
    /// </summary>
    public enum ContactType
    {
        /// <summary>Kunde (<see cref="Model.Customer"/>).</summary>
        Customer = 1,

        /// <summary>Mitarbeiter (<see cref="Model.Employee"/>).</summary>
        Employee = 2,

        /// <summary>Lernender (<see cref="Model.Apprentice"/>) – ist zugleich ein Mitarbeiter.</summary>
        Apprentice = 3
    }
}
