using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {

        public string RFC { get; set; }

       public int NumEmpleado { get; set; }

       public string Nombre { get; set; }

       public DateTime FechaControl { get; set; }

       public Decimal Salario { get; set; }

       public List<object> Empleados { get; set; }

       public string Action { get; set; }
    }
}
