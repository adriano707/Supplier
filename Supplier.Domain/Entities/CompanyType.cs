using System;

namespace Supplier.Domain.Entities
{
    public class CompanyType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public CompanyType(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
