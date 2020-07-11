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
    public class PersonController : BaseController
    {
        private PersonBusinessObject _bo = new PersonBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]PersonViewModel vm)
        {
            var rt = vm.ToPerson();
            var res = _bo.Create(rt);
            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<PersonViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = PersonViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<PersonViewModel>> ListUnDeleted()
        {
            var res = _bo.ListUnDeleted();
            if (!res.Success) return InternalServerError();
            var list = new List<PersonViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(PersonViewModel.Parse(item));
            }
            return list;
        }

        [HttpGet("FullList")]
        public ActionResult<List<PersonViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
            var list = new List<PersonViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(PersonViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]PersonViewModel rt)
        {
            var currentResult = _bo.Read(rt.Id);
            if (!currentResult.Success) return InternalServerError();
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.VatNumber == rt.VATNumber && current.FirstName == rt.FirstName && current.LastName == rt.LastName && current.PhoneNumber == rt.PhoneNumber && current.BirthDate == rt.Birthdate) return NotModified();

            if (current.VatNumber != rt.VATNumber) current.VatNumber = rt.VATNumber;
            if (current.FirstName != rt.FirstName) current.FirstName = rt.FirstName;
            if (current.LastName != rt.LastName) current.LastName = rt.LastName;
            if (current.PhoneNumber != rt.PhoneNumber) current.PhoneNumber = rt.PhoneNumber;
            if (current.BirthDate != rt.Birthdate) current.BirthDate = rt.Birthdate;

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