using Supplier.Domain.Entities.Enums;
using System;

namespace Supplier.Domain.Entities
{
    public class JuridicalPerson : Person
    {
        public virtual CompanyType CompanyType { get; private set; }
        public virtual int CompanyTypeId { get; set; }
        public string TradeName { get; private set; }
        public DateTime DateOfIncorporation { get; private set; }
        public virtual CompanySize Size { get; private set; }
        public virtual int CompanySizeId { get; set; }
        public string WebSite { get; private set; }
        public int ShareQuantity { get; private set; }
        public decimal ValueShare { get; private set; }
        public decimal SocialCapital { get; private set; }

        public JuridicalPerson(string name, string document, CompanyType companyType, string tradeName, DateTime dateOfCorporation, CompanySize size, string webSite, int shareQuantity, decimal valueShare, decimal socialCapital)
            : base(name, document, PersonType.JuridicalPerson)
        {
            CompanyType = companyType;
            TradeName = tradeName ?? throw new ArgumentNullException(nameof(tradeName));
            DateOfIncorporation = dateOfCorporation;
            Size = size;
            WebSite = webSite ?? throw new ArgumentNullException(nameof(webSite));
            ShareQuantity = shareQuantity;
            ValueShare = valueShare;
            SocialCapital = socialCapital;
        }

        public void UpdateJuridicalPerson(string name, string document, CompanyType companyType, string tradeName, DateTime dateOfCorporation, CompanySize size, string webSite, int shareQuantity, decimal valueShare, decimal socialCapital)
        {
            if (Status == PersonStatus.InPreparation)
            {
                UpdatePerson(name, document);
                CompanyType = companyType;
                TradeName = tradeName ?? throw new ArgumentNullException(nameof(tradeName));
                DateOfIncorporation = dateOfCorporation;
                Size = size;
                WebSite = webSite ?? throw new ArgumentNullException(nameof(webSite));
                ShareQuantity = shareQuantity;
                ValueShare = valueShare;
                SocialCapital = socialCapital;
            }
        }
    }
}
