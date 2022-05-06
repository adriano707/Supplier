using Supplier.Domain.Entities;
using Supplier.Domain.Entities.Enums;
using System.Collections.Generic;

namespace Supplier.Api.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public PersonType Type { get; set; }
        public PersonStatus Status { get; set; }
        public List<PersonContactDto> Contacts { get; set; }
    }
}
