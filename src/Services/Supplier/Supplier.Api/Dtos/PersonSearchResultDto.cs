using Supplier.Domain.Entities.Enums;

namespace Supplier.Api.Dtos
{
    public class PersonSearchResultDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsNational { get; set; }
        public PersonType Type { get; set; }
        public string Document { get; set; }
    }
}
