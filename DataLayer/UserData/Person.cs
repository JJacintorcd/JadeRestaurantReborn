using Recodme.Rd.JadeRest.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recodme.Rd.JadeRest.DataLayer.UserData
{
    public class Person : Entity
    {
        private long _vatNumber;

        [Required]
        [Display(Name = "VAT")]
        public long VatNumber
        {
            get => _vatNumber;

            set
            {
                _vatNumber = value;
                RegisterChange();

            }

        }

        private string _firstName;

        [Required]
        [Display(Name = "First Name")]
        public string FirstName
        {
            get => _firstName;

            set
            {
                _firstName = value;
                RegisterChange();

            }

        }

        private string _lastName;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName
        {
            get => _lastName;

            set
            {
                _lastName = value;
                RegisterChange();

            }

        }

        private long _phoneNumber;

        [Required]
        [Display(Name = "Phone Number")]
        public long PhoneNumber
        {
            get => _phoneNumber;

            set
            {
                _phoneNumber = value;
                RegisterChange();

            }

        }

        private DateTime _birthDate;

        [Required]
        [Display(Name = "Birthday")]
        public DateTime BirthDate
        {
            get => _birthDate;

            set
            {
                _birthDate = value;
                RegisterChange();

            }

        }

        //[ForeignKey("JadeUser")]
        //public Guid UserId { get; set; }
        //public virtual JadeUser JadeUser { get; set; }

        //public virtual ICollection<StaffRecord> StaffRecords { get; set; }
        //public virtual ICollection<ClientRecord> ClientRecords { get; set; }


        public Person(long vatNumber, string firstName, string lastName, long phoneNumber, DateTime birthDate/*, Guid userId*/)
        {
            _vatNumber = vatNumber;
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _birthDate = birthDate;
            //UserId = userId;
        }

        public Person(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, long vatNumber, string firstName, string lastName, long phoneNumber, DateTime birthDate/*, Guid userId*/) : base(id, createdAt, updatedAt, isDeleted)
        {
            _vatNumber = vatNumber;
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _birthDate = birthDate;
            //UserId = userId;
        }
    }
}
