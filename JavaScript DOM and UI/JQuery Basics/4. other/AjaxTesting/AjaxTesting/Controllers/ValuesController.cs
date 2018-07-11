using AjaxTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AjaxTesting.Controllers
{
    public class ValuesController : ApiController
    {
        private static List<ValueModel> values = new List<ValueModel>();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(values);
        }

        [HttpPost]
        public IHttpActionResult Post(ValueModel val)
        {
            values.Add(val);
            return Ok(val);
        }

        [HttpPut]
        public IHttpActionResult Put(ValueModel val)
        {
            if (values.Count == 0)
            {
                return BadRequest();
            }

            values[0] = val;

            return Ok(val);
        }

        [HttpDelete]
        public IHttpActionResult Delete(ValueModel val)
        {
            var toDelete = values.FirstOrDefault(c => c.Input == val.Input);
            if (toDelete == null)
            {
                return NotFound();
            }

            values.Remove(toDelete);

            return this.Ok();
        }
    }
}