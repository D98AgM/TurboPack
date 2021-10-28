using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.DAguilarPruebaTPEntities context = new DL.DAguilarPruebaTPEntities())
                {
                    var query = context.EmpleadoAdd(empleado.RFC, empleado.NumEmpleado, empleado.Nombre, empleado.FechaControl, empleado.Salario);

                    if (query >= 1)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ingresaron correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.DAguilarPruebaTPEntities context = new DL.DAguilarPruebaTPEntities())
                {
                    var query = context.EmpleadoUpdate(empleado.RFC, empleado.NumEmpleado, empleado.Nombre, empleado.FechaControl, empleado.Salario);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se modifico correctamente";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


        public static ML.Result Delete(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.DAguilarPruebaTPEntities conext = new DL.DAguilarPruebaTPEntities())
                {
                    var query = conext.EmpleadoDelete(empleado.RFC);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }


        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.DAguilarPruebaTPEntities context = new DL.DAguilarPruebaTPEntities())
                {
                    var query = context.EmpleadoGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.RFC = obj.RFC;
                            empleado.NumEmpleado = obj.NumEmpleado.Value;
                            empleado.Nombre = obj.Nombre;
                            empleado.FechaControl = obj.FechaControl.Value;
                            empleado.Salario = obj.Salario.Value;

                            result.Objects.Add(empleado);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo consultar la informacion";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }


        public static ML.Result GetById(string RFC)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.DAguilarPruebaTPEntities context = new DL.DAguilarPruebaTPEntities())
                {
                    var query = context.EmpleadoGetById(RFC).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.RFC = query.RFC;
                        empleado.NumEmpleado = query.NumEmpleado.Value;
                        empleado.Nombre = query.Nombre;
                        empleado.FechaControl = query.FechaControl.Value;
                        empleado.Salario = query.Salario.Value;

                        result.Object = empleado;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;


        }
    }
}
