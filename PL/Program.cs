using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\digis\Documents\DAguilarMartinez\LayoutUsuarios.txt");
              char delimitador = ('|');

            List<string> lineslist = lines.Skip(1).ToList();

            foreach (string line in lineslist)
            {
                string[] datosEmpleados = line.Split('|');

               ML.Empleado empleado = new ML.Empleado();
                  empleado.RFC = datosEmpleados[0];
                  empleado.NumEmpleado = int.Parse(datosEmpleados[1]);
                  empleado.Nombre = datosEmpleados[2];
                  empleado.FechaControl = DateTime.ParseExact( datosEmpleados[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                  empleado.Salario = decimal.Parse(datosEmpleados[4]);
         
                 ML.Result result = BL.Empleado.Add(empleado);


              if (!result.Correct)
              {
                 var errorMessage = "Emp" + empleado.Nombre + "No se aguardo Correctamente";

              }
           }

           // Console.WriteLine(Result);

            Console.ReadKey();






        }
    }
}
