using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supplier.Api.Dtos;
using Supplier.Data.Contexts;
using Supplier.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("persons")]
    public class PersonController : ControllerBase
    {
        private readonly SupplierDbContext _context;
        public PersonController(SupplierDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Persons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsyncAllPersons()
        {
            var person = _context.Person.ToList();
            return Ok(person);
        }

        /// <summary>
        /// Method add juridical person
        /// </summary>
        /// <param name="juridicalPersonDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("juridical-persons")]
        public async Task<IActionResult> AddAsyncJuridicalPerson([FromBody] JuridicalPersonDto juridicalPersonDto)
        {
            var companyType = _context.CompanyType.FirstOrDefault(c => c.Id == juridicalPersonDto.CompanyType.Id);

            if (companyType is null) return NotFound();

            var companySize = _context.CompanySize.FirstOrDefault(c => c.Id == juridicalPersonDto.CompanySize.Id);

            if (companySize is null) return NotFound();

            JuridicalPerson juridicalPerson = new JuridicalPerson(juridicalPersonDto.Name,
                juridicalPersonDto.Document,
                companyType,
                juridicalPersonDto.TradeName,
                juridicalPersonDto.DateOfIncorporation,
                companySize,
                juridicalPersonDto.WebSite,
                juridicalPersonDto.ShareQuantity,
                juridicalPersonDto.ValueShare,
                juridicalPersonDto.SocialCapital);
            _context.Add(juridicalPerson);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("juridical-persons/{id:int}")]
        public async Task<IActionResult> GetAsyncJuridicalPerson([FromRoute] int id)
        {
            var juridicalPerson = _context.Person.OfType<JuridicalPerson>().FirstOrDefault(j => j.Id == id);

            if (juridicalPerson is null) return NotFound("Pessoa Jurídica não encontrada");

            JuridicalPersonDto dto = new JuridicalPersonDto()
            {
                Name = juridicalPerson.Name,
                CompanySize = juridicalPerson.Size is null ? null : new CompanySizeDto()
                {
                    Id = juridicalPerson.Size.Id,
                    Name = juridicalPerson.Size.Name
                },
                CompanyType = juridicalPerson.CompanyType is null ? null : new CompanyTypeDto()
                {
                    Id = juridicalPerson.CompanyType.Id,
                    Name = juridicalPerson.CompanyType.Name
                },
                Id = juridicalPerson.Id,
                Contacts = juridicalPerson.Contacts.Select(j => new PersonContactDto()
                {
                    Contact = j.Contact,
                    Id = j.Id,
                    Type = j.Type
                }).ToList(),
                Type = juridicalPerson.Type,
                DateOfIncorporation = juridicalPerson.DateOfIncorporation,
                Document = juridicalPerson.Document,
                ShareQuantity = juridicalPerson.ShareQuantity,
                SocialCapital = juridicalPerson.SocialCapital,
                Status = juridicalPerson.Status,
                TradeName = juridicalPerson.TradeName,
                ValueShare = juridicalPerson.ValueShare,
                WebSite = juridicalPerson.WebSite
            };

            return Ok(dto);

        }

        /// <summary>
        /// Method add natural person
        /// </summary>
        /// <param name="naturalPersonDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("natural-persons")]
        public async Task<IActionResult> AddAsyncNaturalPerson([FromBody] NaturalPersonDto naturalPersonDto)
        {
            var companyType = _context.CompanyType.FirstOrDefault(c => c.Id == naturalPersonDto.CompanyType.Id);

            if (companyType is null) return NotFound();

            NaturalPerson naturalPerson = new NaturalPerson(naturalPersonDto.Name,
                naturalPersonDto.Document,
                naturalPersonDto.MaritalStatus,
                naturalPersonDto.Profession,
                companyType,
                naturalPersonDto.BirthDate,
                naturalPersonDto.Gender,
                naturalPersonDto.Nationality);
            _context.Add(naturalPerson);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("natural-person/{id:int}")]
        public async Task<IActionResult> GetAsyncNaturalPerson([FromRoute] int id)
        {
            var naturalPerson = _context.Person.OfType<NaturalPerson>().FirstOrDefault(j => j.Id == id);

            if (naturalPerson is null) return NotFound("Pessoa Física não encontrada");

            NaturalPersonDto dto = new NaturalPersonDto()
            {
                MaritalStatus = naturalPerson.MaritalStatus,
                Profession = naturalPerson.Profession,
                BirthDate = naturalPerson.BirthDate,
                Gender = naturalPerson.Gender,
                Nationality = naturalPerson.Nationality,
                CompanyType = naturalPerson.CompanyType is null ? null : new CompanyTypeDto()
                {
                    Id = naturalPerson.CompanyType.Id,
                    Name = naturalPerson.CompanyType.Name
                },
                Contacts = naturalPerson.Contacts.Select(j => new PersonContactDto()
                {
                    Contact = j.Contact,
                    Id = j.Id,
                    Type = j.Type
                }).ToList(),
                Document = naturalPerson.Document,               
            };

            return Ok(dto);
        }

        [HttpPut]
        [Route("{id:int}/active")]
        public async Task<IActionResult> ActivePersonAsync([FromRoute] int id)
        {
            var person = _context.Person.FirstOrDefault(p => p.Id == id);

            if (person is null) return NotFound();

            person.ActivePerson();
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("{id:int}/inactive")]
        public async Task<IActionResult> InActivePersonAsync([FromRoute] int id) 
        {
            var person = _context.Person.FirstOrDefault(p => p.Id == id);

            if (person is null) return NotFound();

            person.InactivePerson();
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = _context.Person.FirstOrDefault(p => p.Id == id);

            if (person is null) return NotFound();

            _context.Remove(person);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
