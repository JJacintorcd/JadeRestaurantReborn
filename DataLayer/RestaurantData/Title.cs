using Recodme.Rd.JadeRest.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Rd.JadeRest.DataLayer.RestaurantData
{
    public class Title : NamedEntity
    {
        private string _position;

        [Required]
        public string Position
        {
            get => _position;

            set
            {
                _position = value;
                RegisterChange();
            }
        }


        private string _description;

        [Required]
        public string Description
        {
            get => _description;

            set
            {
                _description = value;
                RegisterChange();
            }
        }

        public virtual ICollection<StaffTitle> TitleStaff { get; set; }

        public Title(string name, string position, string description) : base(name)
        {
            _position = position;
            _description = description;
        }

        public Title(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name, string position, string description) : base(id, createdAt, updatedAt, isDeleted, name)
        {
            _position = position;
            _description = description;
        }

    }

}
