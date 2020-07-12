using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgAvanzTarea1.Models
{
    public class Supervisor:Empleado
    {

        public int Sucursal { get; set; }


        public override string ToString()
        {
            return string.Format("Identificación: {0} Nombre {1} {2} {3}: Sucursal Asignada {4}", ID, Nombre, PrimerApellido, SegundoApellido, Sucursal);
        }
    }
}
