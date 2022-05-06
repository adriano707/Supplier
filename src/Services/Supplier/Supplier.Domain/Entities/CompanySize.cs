using System;

namespace Supplier.Domain.Entities
{
    public class CompanySize
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public CompanySize()
        {

        }

        public CompanySize(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
