using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model.Enums
{
    /// <summary>
    /// Activity state of a customer.
    /// </summary>
    public enum Status
    {
        /// <summary>Customer is currently active.</summary>
        Active = 1,

        /// <summary>Customer is inactive / dormant.</summary>
        Passive = 2
    }
}
