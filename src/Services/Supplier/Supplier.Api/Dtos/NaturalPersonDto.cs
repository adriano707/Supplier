using Supplier.Domain.Entities;
using Supplier.Domain.Entities.Enums;
using System;

namespace Supplier.Api.Dtos
{
    public class NaturalPersonDto : PersonDto
    {
        public MaritalStatus MaritalStatus { get; set; }
        public string Profession { get; set; }
        public virtual CompanyTypeDto CompanyType { get; set; }
        public virtual int CompanyTypeId { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
    }
}
