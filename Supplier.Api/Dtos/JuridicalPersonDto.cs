using Supplier.Domain.Entities;
using System;

namespace Supplier.Api.Dtos
{
    public class JuridicalPersonDto : PersonDto
    {
        public CompanyTypeDto CompanyType { get; set; }
        public string TradeName { get; set; }
        public DateTime DateOfIncorporation { get; set; }
        public CompanySizeDto CompanySize { get; set; }
        public string WebSite { get; set; }
        public int ShareQuantity { get; set; }
        public decimal ValueShare { get; set; }
        public decimal SocialCapital { get; set; }
    }
}
