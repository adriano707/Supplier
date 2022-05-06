using Supplier.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supplier.Domain.Entities
{
    public class Person
    {
        private List<PersonContact> _contact = new List<PersonContact>();
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public PersonType Type { get; private set; }
        public PersonStatus Status { get; private set; }
        public IReadOnlyCollection<PersonContact> Contacts => _contact;

        public Person()
        {

        }

        public Person(string name, string document, PersonType type)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Document = document ?? throw new ArgumentNullException(nameof(document));
            Type = type;
            Status = PersonStatus.InPreparation;            
        }  
        
        public void UpdatePerson(string name, string document)
        {
            if (Status == PersonStatus.InPreparation)
            {
                Name = name;
                Document = document;
            }
        }

        public void AddPhone(string phone)
        {
            PersonContact contact = new PersonContact(phone, ContactType.Phone);
            _contact.Add(contact);
        }

        public void AddEmail(string email)
        {
            PersonContact contact = new PersonContact(email, ContactType.Email);
            _contact.Add(contact);
        }

        public void RemoveContact(int id)
        {
            PersonContact contact = _contact.FirstOrDefault(c => c.Id == id);

            if(contact is not null)
            {
                _contact.Remove(contact);
            }                       
        }

        public void InPreparationPerson()
        {
            Status = PersonStatus.InPreparation;
        }

        public void ActivePerson()
        {
            Status = PersonStatus.Active;
        }

        public void InactivePerson()
        {
            Status = PersonStatus.Inactive;
        }
    }
}
