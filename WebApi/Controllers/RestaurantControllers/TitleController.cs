using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.TitleBO;
using Recodme.Rd.JadeRest.WebApi.Controllers.MenuControllers;
using Recodme.Rd.JadeRest.WebApi.Models.RestaurantViewModels;

namespace Recodme.Rd.JadeRest.WebApi.Controllers.RestaurantControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : BaseController
    {
        private TitleBusinessObject _bo = new TitleBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]TitleViewModel vm)
        {
            var rt = vm.ToTitle();
            var res = _bo.Create(rt);
            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<TitleViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);
            if (res.Success)
            {
                if (res.Result == null) return NotFound();
                var vm = TitleViewModel.Parse(res.Result);
                return vm;
            }
            else return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<TitleViewModel>> ListUndeleted()
        {
            var res = _bo.ListUnDeleted();
            if (!res.Success) return InternalServerError();
            var list = new List<TitleViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(TitleViewModel.Parse(item));
            }
            return list;
        }

        [HttpGet("FullList")]
        public ActionResult<List<TitleViewModel>> List()
        {
            var res = _bo.List();
            if (!res.Success) return InternalServerError();
            var list = new List<TitleViewModel>();
            foreach (var item in res.Result)
            {
                list.Add(TitleViewModel.Parse(item));
            }
            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]TitleViewModel rt)
        {
            var currentResult = _bo.Read(rt.Id);
            if (!currentResult.Success) return InternalServerError();
            var current = currentResult.Result;
            if (current == null) return NotFound();

            if (current.Name == rt.Name && current.Position == rt.Position && current.Description == rt.Description) return NotModified();

            if (current.Name != rt.Name) current.Name = rt.Name;
            if (current.Position != rt.Position) current.Position = rt.Position;
            if (current.Description != rt.Description) current.Description = rt.Description;

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