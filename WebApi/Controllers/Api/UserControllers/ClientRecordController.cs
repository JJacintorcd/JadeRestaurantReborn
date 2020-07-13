using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.UserBO;
using Recodme.Rd.JadeRest.WebApi.Controllers.MenuControllers;
using Recodme.Rd.JadeRest.WebApi.Models.UserViewModels;

namespace Recodme.Rd.JadeRest.WebApi.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientRecordController : BaseController
    {
        private ClientRecordBusinessObject _bo = new ClientRecordBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]ClientRecordViewModel vm)
        {
            var rt = vm.ToClient();
            var res = _bo.Create(rt);
            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<ClientRecordViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = ClientRecordViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<ClientRecordViewModel>> ListUndeleted()
        {
            var res = _bo.ListUnDeleted();
            if (!res.Success) return InternalServerError();
            var list = new List<ClientRecordViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(ClientRecordViewModel.Parse(item));
            }
            return list;
        }

        [HttpGet("FullList")]
        public ActionResult<List<ClientRecordViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
            var list = new List<ClientRecordViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(ClientRecordViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]ClientRecordViewModel rt)
        {
            var currentResult = _bo.Read(rt.Id);
            if (!currentResult.Success) return InternalServerError();
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.RegisterDate == rt.RegisterDate) return NotModified();

            if (current.RegisterDate != rt.RegisterDate) current.RegisterDate = rt.RegisterDate;

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