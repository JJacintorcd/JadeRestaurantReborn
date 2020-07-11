using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Models.UserViewModels
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public long VATNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        //public Guid UserId { get; set; }

        public Person ToPerson()
        {
            return new Person(VATNumber, FirstName, LastName, PhoneNumber, Birthdate/*, UserId*/);

        }

        public static PersonViewModel Parse(Person Staff)
        {
            return new PersonViewModel()
            {
                Id = Staff.Id,
                VATNumber = Staff.VatNumber,
                FirstName = Staff.FirstName,
                LastName = Staff.LastName,
                PhoneNumber = Staff.PhoneNumber,
                Birthdate = Staff.BirthDate,
                //UserId = Staff.UserId,

            };

        }
    }
}
