using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgAvanzTarea1.Models
{
    public class Cajero:Empleado
    {
        public int Caja { get; set; }

        public override string ToString()
        {
            return string.Format("Identificación: {0} Nombre: {1} {2} {3}: Caja Asignada {4}.\n", ID, Nombre, PrimerApellido, SegundoApellido, Caja);
        }
    }
}
