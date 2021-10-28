using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SApi.Controllers
{
    public class EmpleadoController : ApiController
    {
        // GET api/getall
        [HttpGet]
        [Route ("api/Empleado/GetAll")]
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

        // GET api/getall/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/getall
        [HttpPost]
        [Route("api/Empleado/Add")]

        public  IHttpActionResult  Post([FromBody]ML.Empleado empleado)
        {
            var result = BL.Empleado.Add(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }


        }

        // PUT api/getall/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/getall/5
        public void Delete(int id)
        {
        }
    }
}
