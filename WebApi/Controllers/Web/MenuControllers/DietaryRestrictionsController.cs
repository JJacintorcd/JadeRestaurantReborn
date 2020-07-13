using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Recodme.Rd.JadeRest.WebApi.Controllers.Web.MenuControllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DietaryRestrictionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}