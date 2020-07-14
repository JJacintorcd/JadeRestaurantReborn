using Microsoft.AspNetCore.Mvc;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.RestaurantBO;
using Recodme.Rd.JadeRest.WebApi.Models.RestaurantViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Controllers.Api.RestaurantControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : BaseController
    {
        private BookingBusinessObject _bo = new BookingBusinessObject();
        
        [HttpPost]
        public ActionResult Create([FromBody]BookingViewModel vm)
        {
            var rt = vm.ToBooking();
            var res = _bo.Create(rt);

            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<BookingViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);

            if (res.Success)
            {
                if (res.Result == null)
                    return NotFound();

                var vm = BookingViewModel.Parse(res.Result);

                return vm;
            }
            else
                return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<BookingViewModel>> ListUndeleted()
        {
            var res = _bo.ListUnDeleted();

            if (!res.Success)
                return InternalServerError();

            var list = new List<BookingViewModel>();

            foreach (var item in res.Result)
            {
                list.Add(BookingViewModel.Parse(item));
            }

            return list;
        }

        [HttpGet("FullList")]
        public ActionResult<List<BookingViewModel>> List()
        {
            var res = _bo.List();

            if (!res.Success)
                return InternalServerError();

            var list = new List<BookingViewModel>();

            foreach (var item in res.Result)
            {
                list.Add(BookingViewModel.Parse(item));
            }

            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]BookingViewModel rt)
        {
            var currentResult = _bo.Read(rt.Id);

            if (!currentResult.Success)
                return InternalServerError();
            var current = currentResult.Result;

            if (current == null)
                return NotFound();

            if (current.Date == rt.Date && current.ClientRecordId == rt.ClientRecordId)
                return NotModified();

            if (current.Date != rt.Date)
                current.Date = rt.Date;

            if (current.ClientRecordId != rt.ClientRecordId)
                current.ClientRecordId = rt.ClientRecordId;

            var updateResult = _bo.Update(current);

            if (!updateResult.Success)
                return InternalServerError();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _bo.Delete(id);

            if (result.Success)
                return Ok();

            return InternalServerError();
        }
    }
}