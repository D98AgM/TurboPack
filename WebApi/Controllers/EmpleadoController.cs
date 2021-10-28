using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class EmpleadoController : ApiController
    {

        // GET api/getall
        [HttpGet]
        [Route("api/Empleado/GetAll")]
        public IHttpActionResult GetAll()
        {
            var result = BL.Empleado.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }


        // GET api/empleado/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/empleado
        public void Post([FromBody]string value)
        {
        }

        // PUT api/empleado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/empleado/5
        public void Delete(int id)
        {
        }
    }
}
