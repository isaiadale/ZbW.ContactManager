namespace ContactManager.Business.Exceptions
{
    /// <summary>
    /// Wird geworfen, wenn ein Kontakt eine Geschäftsregel verletzt (z. B. leerer Name,
    /// ungültiges E-Mail-Format oder ein Austrittsdatum vor dem Eintrittsdatum).
    /// Trägt eine für den Anwender verständliche, deutschsprachige Meldung.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>Erzeugt die Ausnahme mit einer beschreibenden Fehlermeldung.</summary>
        /// <param name="message">Die deutschsprachige, anzeigbare Fehlermeldung.</param>
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
