using AdminEmpleadoEntidades;
using AdminEmpleadosDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosNegocio
{
    public class EmpladoNegocio
    {
        public static List<Empleado> GET(Empleado e)
        {
            return EmpleadosDatos.Get(e);
        }
    }
}