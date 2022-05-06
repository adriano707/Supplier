using Supplier.Domain.Entities;
using Supplier.Domain.Entities.Enums;

namespace Supplier.Api.Dtos
{
    public class PersonContactDto
    {
        public int Id { get; set; }
        public string Contact { get; set; }
        public ContactType Type { get; set; }       
    }
}
