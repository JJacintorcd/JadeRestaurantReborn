using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO.BObjects.UserBO;
using Recodme.Rd.JadeRest.WebApi.Controllers.MenuControllers;
using Recodme.Rd.JadeRest.WebApi.Models.UserViewModels;

namespace Recodme.Rd.JadeRest.WebApi.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffRecordController : BaseController
    {
        private StaffRecordBusinessObject _bo = new StaffRecordBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]StaffRecordViewModel vm)
        {
            var rt = vm.ToStaff();
            var res = _bo.Create(rt);
            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<StaffRecordViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = StaffRecordViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<StaffRecordViewModel>> ListUndeleted()
        {
            var res = _bo.ListUnDeleted();
            if (!res.Success) return InternalServerError();
            var list = new List<StaffRecordViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(StaffRecordViewModel.Parse(item));
            }
            return list;
        }

        [HttpGet("FullList")]
        public ActionResult<List<StaffRecordViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
            var list = new List<StaffRecordViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(StaffRecordViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]StaffRecordViewModel rt)
        {
            var currentResult = _bo.Read(rt.Id);
            if (!currentResult.Success) return InternalServerError();
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.BeginDate == rt.BeginDate && current.EndDate == rt.EndDate) return InternalServerError();

            if (current.BeginDate != rt.BeginDate) current.BeginDate = rt.BeginDate;
            if (current.EndDate != rt.EndDate) current.EndDate = rt.EndDate;

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