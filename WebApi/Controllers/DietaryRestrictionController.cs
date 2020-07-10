using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Recodme.Rd.JadeRest.BusinessLayer;
using Recodme.Rd.JadeRest.DataLayer;
using Recodme.Rd.JadeRest.WebApi.Models;

namespace Recodme.Rd.JadeRest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietaryRestrictionController : BaseController
    {
        private DietaryRestrictionBusinessObject _bo = new DietaryRestrictionBusinessObject();

        [HttpPost]
        public ActionResult Create([FromBody] DietaryRestrictionViewModel vm)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id) => Ok();

        [HttpPut]
        public ActionResult Update([FromBody] DietaryRestrictionViewModel vm)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}