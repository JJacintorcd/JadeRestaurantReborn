using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Models.UserViewModels
{
    public class ClientRecordViewModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public DateTime RegisterDate { get; set; }
        //public Guid RestaurantId { get; set; }

        public ClientRecord ToClient()
        {
            return new ClientRecord(RegisterDate, PersonId/*, RestaurantId*/);
        }

        public static ClientRecordViewModel Parse(ClientRecord Client)
        {
            return new ClientRecordViewModel()
            {
                Id = Client.Id,
                PersonId = Client.PersonId,
                RegisterDate = Client.RegisterDate,
                //RestaurantId = Client.RestaurantId
            };

        }
    }
}
