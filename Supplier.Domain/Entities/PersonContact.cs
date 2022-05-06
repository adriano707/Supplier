using Supplier.Domain.Entities.Enums;
using System;

namespace Supplier.Domain.Entities
{
    public class PersonContact
    {
        public int Id { get; private set; }
        public string Contact { get; private set; }
        public ContactType Type { get; private set; }
        public virtual Person Person { get; private set; }
        public virtual int PersonId { get; private set; }

        public PersonContact()
        {

        }

        public PersonContact(string contact, ContactType type)
        {
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
            Type = type;
        }
    }
}
