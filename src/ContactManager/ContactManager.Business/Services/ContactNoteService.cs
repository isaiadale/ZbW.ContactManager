using ContactManager.Model;
using ContactManager.Persistence.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Business.Services
{
    public class ContactNoteService
    {
        private readonly IContactRepository _repo;

        private readonly ContactData _data;

        /// <summary>
        /// Erzeugt den Service auf Basis des bereits geladenen Datenstamms.
        /// Wird von der Fassade aufgebaut, nicht direkt von der UI.
        /// </summary>
        /// <param name="repo">Repository zum Persistieren des Datenstamms.</param>
        /// <param name="data">Der vollständige, bereits geladene Datenstamm.</param>
        internal ContactNoteService(IContactRepository repo, ContactData data)
        {
            ArgumentNullException.ThrowIfNull(repo);
            ArgumentNullException.ThrowIfNull(data);

            _repo = repo;
            _data = data;
        }

        /// <summary>
        /// Erfasst eine neue Notiz zum angegebenen Kunden und speichert die Änderung.
        /// Die Notiz wird der Historie nur angehängt; bestehende Notizen bleiben unverändert.
        /// </summary>
        /// <param name="customerId">Die Id des Kunden, zu dem die Notiz gehört.</param>
        /// <param name="text">Der Notiztext; darf nicht leer sein.</param>
        /// <exception cref="ArgumentException">Wird geworfen, wenn <paramref name="text"/> leer ist oder nur Leerzeichen enthält.</exception>
        /// <exception cref="KeyNotFoundException">Wird geworfen, wenn kein Kunde mit dieser Id erfasst ist.</exception>
        public void AddNote(Guid customerId, string text)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(text);

            Customer customer = GetRequiredCustomer(customerId);

            customer.Notes.Add(new ContactNote { Text = text });

            SaveChanges();
        }

        /// <summary>
        /// Gibt die Notiz-Historie des angegebenen Kunden zurück, chronologisch sortiert                                                                        
        /// mit der neuesten Notiz zuerst.
        /// </summary>
        /// <param name="customerId">Die Id des Kunden, dessen Notizen abgefragt werden.</param>
        /// <returns>Die Notizen des Kunden, neuste zuerst.</returns>
        /// <exception cref="KeyNotFoundException">Wird geworfen, wenn kein Kunde mit dieser Id erfasst ist.</exception>
        public IReadOnlyList<ContactNote> GetNotes(Guid customerId)
        {
            Customer customer = GetRequiredCustomer(customerId);

            return customer.Notes
                .OrderByDescending(n => n.CreatedAt)
                .ToList();
        }

        private Customer GetRequiredCustomer(Guid customerId)
        {
            Customer? customer = _data.Customers.Find(c => c.Id == customerId);

            if (customer is null)
                throw new KeyNotFoundException($"Es ist kein Kunde mit der Id: {customerId} erfasst.");

            return customer;
        }

        private void SaveChanges()
        {
            _repo.Save(_data);
        }
    }
}
