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
    public class MealController : BaseController
    {
        private MealBusinessObject _bo = new MealBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody]MealViewModel vm)
        {
            var rt = vm.ToMeal();
            var res = _bo.Create(rt);

            return (res.Success ? Ok() : InternalServerError());
        }

        [HttpGet("{id}")]
        public ActionResult<MealViewModel> Get(Guid id)
        {
            var res = _bo.Read(id);

            if (res.Success)
            {
                if (res.Result == null)
                    return NotFound();

                var vm = MealViewModel.Parse(res.Result);

                return vm;
            }
            else
                return InternalServerError();
        }

        [HttpGet]
        public ActionResult<List<MealViewModel>> ListUndeleted()
        {
            var res = _bo.ListUnDeleted();

            if (!res.Success)
                return InternalServerError();

            var list = new List<MealViewModel>();

            foreach (var item in res.Result)
            {
                list.Add(MealViewModel.Parse(item));
            }

            return list;
        }

        [HttpGet("FullList")]
        public ActionResult<List<MealViewModel>> List()
        {
            var res = _bo.List();

            if (!res.Success)
                return InternalServerError();

            var list = new List<MealViewModel>();

            foreach (var item in res.Result)
            {
                list.Add(MealViewModel.Parse(item));
            }

            return list;
        }

        [HttpPut]
        public ActionResult Update([FromBody]MealViewModel rt)
        {
            var currentResult = _bo.Read(rt.Id);

            if (!currentResult.Success)
                return InternalServerError();
            var current = currentResult.Result;

            if (current == null)
                return NotFound();

            if (current.Name == rt.Name && current.StartingHours == rt.StartingHours && current.EndingHours == rt.EndingHours)
                return NotModified();

            if (current.Name != rt.Name)
                current.Name = rt.Name;

            if (current.StartingHours != rt.StartingHours)
                current.StartingHours = rt.StartingHours;

            if (current.EndingHours != rt.EndingHours)
                current.EndingHours = rt.EndingHours;

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