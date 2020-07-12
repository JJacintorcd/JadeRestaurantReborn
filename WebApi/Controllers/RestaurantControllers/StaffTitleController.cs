using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.RestaurantBO;
using Recodme.Rd.JadeRest.WebApi.Controllers.MenuControllers;
using Recodme.Rd.JadeRest.WebApi.Models.RestaurantViewModels;

namespace Recodme.Rd.JadeRest.WebApi.Controllers.RestaurantControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffTitleController : BaseController
    {
        private StaffTitleBusinessObject _bo = new StaffTitleBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]StaffTitleViewModel vm)
        {
            var rt = vm.ToStaffTitle();
            var res = _bo.Create(rt);
            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<StaffTitleViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = StaffTitleViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<StaffTitleViewModel>> ListUndeleted()
        {
            var res = _bo.ListUnDeleted();
            if (!res.Success) return InternalServerError();
            var list = new List<StaffTitleViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(StaffTitleViewModel.Parse(item));
            }
            return list;
        }

        [HttpGet("FullList")]
        public ActionResult<List<StaffTitleViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
            var list = new List<StaffTitleViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(StaffTitleViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]StaffTitleViewModel rt)
        {
            var currentResult = _bo.Read(rt.Id);
            if (!currentResult.Success) return InternalServerError();
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.StartDate == rt.StartDate && current.EndDate == rt.EndDate && current.TitleId == rt.TitleId && current.StaffRecordId == rt.StaffRecordId) return NotModified();

            if (current.StartDate != rt.StartDate) current.StartDate = rt.StartDate;
            if (current.EndDate != rt.EndDate) current.EndDate = rt.EndDate;
            if (current.TitleId != rt.TitleId) current.TitleId = rt.TitleId;
            if (current.StaffRecordId != rt.StaffRecordId) current.StaffRecordId = rt.StaffRecordId;

            var updateResult = _bo.Update(current);
            if (!updateResult.Success) return InternalServerError();
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _bo.Delete(id);
            if (result.Success) return Ok();
            return InternalServerError();

        }
    }
}