using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model.Enums
{
    /// <summary>
    /// Aktivitätsstatus eines Kunden.
    /// </summary>
    public enum Status
    {
        /// <summary>Kunde ist aktuell aktiv.</summary>
        Active = 1,

        /// <summary>Kunde ist inaktiv / ruhend (passiv).</summary>
        Passive = 2
    }
}
