using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEmpleadoEntidades
{
    public class Empleado
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public String? dni { get; set; }
        public string? direccion { get; set; }
        public DateTime? fechaIngreso { get; set; }
        public decimal? salario { get; set; }
        public Departamento? Departamento { get; set; }
        public String? nombreDepartamento
        {
            get
            {
                if (Departamento != null)
                {
                    return nombreDepartamento;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}