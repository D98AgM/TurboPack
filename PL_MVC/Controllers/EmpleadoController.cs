using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Globalization;
using System.Net.Http;

namespace PL_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            ML.Result result = BL.Empleado.GetAll();
            empleado.Empleados = new List<Object>();

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:40840//api/");

            //    var responseTask = client.GetAsync("empleado ");
            //    responseTask.Wait();

            //    var result = responseTask.Result;

            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsAsync<ML.Result>();
            //        readTask.Wait();

            //        foreach (var resultItem in readTask.Result.Objects)
            //        {
            //            ML.Empleado resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empleado>(resultItem.ToString());
            //            empleado.Empleados.Add(resultItemList);
            //        }
            //    }
            //}
            //return View(empleado);



            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }

        }





        [HttpGet]
        public ActionResult Form(string RFC) //Add { Id null } //Update {Id > 0 }
        {
            ML.Empleado empleado = new ML.Empleado();

              if (RFC == null)
                {
                    empleado.Action = "Add";
                    return View(empleado);
                    
                }
                else
                {
                    //GetById
                   ML.Result result = BL.Empleado.GetById(RFC);

                    if (result.Correct)

                    {
                        empleado.Action = "Update";
                        empleado.RFC = ((ML.Empleado)result.Object).RFC;
                        empleado.NumEmpleado = ((ML.Empleado)result.Object).NumEmpleado;
                        empleado.Nombre = ((ML.Empleado)result.Object).Nombre;
                        empleado.FechaControl = ((ML.Empleado)result.Object).FechaControl;
                        empleado.Salario = ((ML.Empleado)result.Object).Salario;

                        return View(empleado);

                    }
                    else
                    {
                        ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                        return PartialView("ValidationModal");
                    }
                }

            }
            
        


        [HttpPost]
        public ActionResult Form(ML.Empleado empleado) //Add { Id null } //Update {Id > 0 }
        {
            ML.Result result = new ML.Result();

            if (empleado.Action == "Add")
            {
                result = BL.Empleado.Add(empleado);
                if (result.Correct)
                {
                    ViewBag.Message = "usuario agregada correctamente";
                }
            }
            else
            {
                result = BL.Empleado.Update(empleado);
                if (result.Correct)
                {
                    ViewBag.Message = "usuario actualizada correctamente";
                }
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el usuario " + result.ErrorMessage;
            }

            return PartialView("ValidationModal");

        }



        [HttpPost]
        public ActionResult CargaMasiva()
        {
            HttpPostedFileBase file = Request.Files["Archivo"];
            if (file.ContentLength > 0)
            {
                var lines = new List<string>();
                using (StreamReader reader = new StreamReader(file.InputStream))
                {
                    string headerLine = reader.ReadLine();
                    //bool IsFirst = true;
                    do
                    {

                        string line = reader.ReadLine();
                        string[] datosEmpleados = line.Split('|');

                        ML.Empleado empleado = new ML.Empleado();
                        empleado.RFC = datosEmpleados[0];
                        empleado.NumEmpleado = int.Parse(datosEmpleados[1]);
                        empleado.Nombre = datosEmpleados[2];
                        empleado.FechaControl = DateTime.ParseExact(datosEmpleados[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        empleado.Salario = decimal.Parse(datosEmpleados[4]);

                        ML.Result result = BL.Empleado.Add(empleado);

                    }
                    while (reader.Peek() != -1);
                }



            }
            ViewBag.Message = "Se agrego correctamente";

            return PartialView("ValidationModal");


        }

        








	}
}