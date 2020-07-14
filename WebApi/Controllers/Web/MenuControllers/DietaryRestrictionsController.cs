using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO;
using Recodme.Rd.JadeRest.WebApi.Models.MenuViewModels;

namespace Recodme.Rd.JadeRest.WebApi.Controllers.Web.MenuControllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DietaryRestrictionsController : Controller
    {
        private readonly DietaryRestrictionBusinessObject _bo = new DietaryRestrictionBusinessObject();

        public async Task<IActionResult> Index()
        {
            var listOperation = await _bo.ListUnDeletedAsync();
            if (!listOperation.Success) return View("Error", listOperation.Exception.Message);
            var lst = new List<DietaryRestrictionViewModel>();
            foreach(var item in listOperation.Result)
            {
                lst.Add(DietaryRestrictionViewModel.Parse(item));
            }
            return View(lst);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();
            var getOperation = await _bo.ReadAsync((Guid)id);
            if(!getOperation.Success) return View("Error", getOperation.Exception.Message);
            if (getOperation.Result == null) return NotFound();
            var vm = DietaryRestrictionViewModel.Parse(getOperation.Result);
            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")]DietaryRestrictionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dr = vm.ToDietaryRestriction();
                var createOperation = await _bo.CreateAsync(dr);
                if (!createOperation.Success) return View("Error", new ErrorViewModel() { RequestId = createOperation.Exception.Message });
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();
            var getOperation = await _bo.ReadAsync((Guid)id);
            if (!getOperation.Success) return View("Error", getOperation.Exception.Message);
            if (getOperation.Result == null) return NotFound();
            var vm = DietaryRestrictionViewModel.Parse(getOperation.Result);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, Name")]DietaryRestrictionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var getOperation = await _bo.ReadAsync(id);
                if (!getOperation.Success) return View("Error", getOperation.Exception.Message);
                if (getOperation.Result == null) return NotFound();
                var result = getOperation.Result;
                result.Name = vm.Name;
                var updateOperation = await _bo.UpdateAsync(result);
                if (!updateOperation.Success) return View("Error", getOperation.Exception.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();
            var deleteOperation = await _bo.DeleteAsync((Guid)id);
            if(!deleteOperation.Success) return View("Error", deleteOperation.Exception.Message);
            return RedirectToAction(nameof(Index));
        }
    }
}