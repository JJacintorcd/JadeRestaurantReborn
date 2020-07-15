using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recodme.Rd.JadeRest.BusinessLayer.BObjects.MenuBO;
using Recodme.Rd.JadeRest.WebApi.Models;
using Recodme.Rd.JadeRest.WebApi.Models.MenuViewModels;

namespace Recodme.Rd.JadeRest.WebApi.Controllers.MenuControllers
{
    public class HomeController : Controller
    {
        private readonly MenuBusinessObject _menubo = new MenuBusinessObject();
        private readonly MealBusinessObject _mealbo = new MealBusinessObject();
        private readonly CourseBusinessObject _coursebo = new CourseBusinessObject();
        private readonly DietaryRestrictionBusinessObject _drbo = new DietaryRestrictionBusinessObject();
        private readonly DishBusinessObject _dishbo = new DishBusinessObject();
        private readonly ServingBusinessObject _servingbo = new ServingBusinessObject();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var menuOfTheDay = new MenuOfTheDayViewModel();

            var menuListOperation = await _menubo.ListUnDeletedAsync();
            if(!menuListOperation.Success) return View("Error");
            if(menuListOperation.Result.Count == 0) return View("Error");

            var servingListOperation = await _servingbo.ListUnDeletedAsync();
            if (!servingListOperation.Success) return View("Error");
            if (servingListOperation.Result.Count == 0) return View("Error");

            var dishListOperation = await _dishbo.ListUnDeletedAsync();
            if (!dishListOperation.Success) return View("Error");
            if (dishListOperation.Result.Count == 0) return View("Error");

            var drListOperation = await _drbo.ListUnDeletedAsync();
            if (!drListOperation.Success) return View("Error");
            if (drListOperation.Result.Count == 0) return View("Error");

            var mealListOperation = await _mealbo.ListUnDeletedAsync();
            if (!mealListOperation.Success) return View("Error");
            if (mealListOperation.Result.Count == 0) return View("Error");

            var courseListOperation = await _coursebo.ListUnDeletedAsync();
            if (!courseListOperation.Success) return View("Error");
            if (courseListOperation.Result.Count == 0) return View("Error");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
