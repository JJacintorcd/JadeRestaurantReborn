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
            return View();
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();
            return View();
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

            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, Name")]DietaryRestrictionViewModel vm)
        {
            if (ModelState.IsValid)
            {

            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}