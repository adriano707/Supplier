using Supplier.Domain.Entities.Enums;
using System;

namespace Supplier.Domain.Entities
{
    public class NaturalPerson : Person
    {
        public MaritalStatus MaritalStatus { get; private set; }
        public string Profession { get; private set; }
        public virtual CompanyType CompanyType { get; private set; }
        public virtual int CompanyTypeId { get; set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public string Nationality { get; private set; }

        public NaturalPerson()
        {

        }

        public NaturalPerson(string name, string document, MaritalStatus maritalStatus, string profession, CompanyType companyType, DateTime birthDate, Gender gender, string nacionality) 
            : base(name, document, PersonType.NaturalPerson)
        {
            MaritalStatus = maritalStatus;
            Profession = profession ?? throw new ArgumentNullException(nameof(profession));    
            CompanyType = companyType;
            BirthDate = birthDate;  
            Gender = gender;
            Nationality = nacionality ?? throw new ArgumentNullException(nameof(nacionality));
        }

        public void UpdateNaturalPerson(string name, string document, MaritalStatus maritalStatus, string profession, CompanyType companyType, DateTime birthDate, Gender gender, string nacionality)
        {
            if (Status == PersonStatus.InPreparation)
            {
                UpdatePerson(name, document);
                MaritalStatus = maritalStatus;
                Profession = profession ?? throw new ArgumentNullException(nameof(profession));
                CompanyType = companyType;
                BirthDate = birthDate;
                Gender = gender;
                Nationality = nacionality ?? throw new ArgumentNullException(nameof(nacionality));
            }
        }
    }
}
