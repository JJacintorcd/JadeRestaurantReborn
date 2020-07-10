using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Controllers.MenuControllers
{
    public abstract class BaseController : ControllerBase
    {
        protected StatusCodeResult InternalServerError()
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        protected StatusCodeResult NotModified()
        {
            return StatusCode((int)HttpStatusCode.NotModified);
        }
    }
}
