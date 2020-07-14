using Microsoft.AspNetCore.Mvc;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO;
using Recodme.Rd.JadeRest.WebApi.Models.MenuViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Controllers.Api.MenuControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : BaseController
    {
        private DishBusinessObject _bo = new DishBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]DishViewModel vm)
        {
            var rt = vm.ToDish();
            var res = _bo.Create(rt);

            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<DishViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);

            if (res.Success)
            {
                if (res.Result == null)
                    return NotFound();

                var vm = DishViewModel.Parse(res.Result);

                return vm;
            }
            else
                return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<DishViewModel>> ListUndeleted()
        {
            var res = _bo.ListUnDeleted();

            if (!res.Success)
                return InternalServerError();

            var list = new List<DishViewModel>();

            foreach (var item in res.Result)
            {
                list.Add(DishViewModel.Parse(item));
            }

            return list;
        }

        [HttpGet("FullList")]
        public ActionResult<List<DishViewModel>> List()
        {
            var res = _bo.List();

            if (!res.Success)
                return InternalServerError();

            var list = new List<DishViewModel>();

            foreach (var item in res.Result)
            {
                list.Add(DishViewModel.Parse(item));
            }

            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]DishViewModel rt)
        {
            var currentResult = _bo.Read(rt.Id);

            if (!currentResult.Success)
                return InternalServerError();
            var current = currentResult.Result;

            if (current == null)
                return NotFound();

            if (current.Name == rt.Name && current.DietaryRestrictionId == rt.DietaryRestrictionId)
                return NotModified();

            if (current.Name != rt.Name)
                current.Name = rt.Name;

            if (current.DietaryRestrictionId != rt.DietaryRestrictionId)
                current.DietaryRestrictionId = rt.DietaryRestrictionId;

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