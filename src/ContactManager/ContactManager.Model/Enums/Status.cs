using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model.Enums
{
    /// <summary>
    /// Aktivitätsstatus einer Person (Kunde oder Mitarbeiter).
    /// </summary>
    public enum Status
    {
        /// <summary>Person ist aktuell aktiv.</summary>
        Active = 1,

        /// <summary>Person ist inaktiv / ruhend (passiv).</summary>
        Passive = 2
    }
}
