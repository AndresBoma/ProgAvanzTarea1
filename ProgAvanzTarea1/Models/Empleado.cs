using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProgAvanzTarea1.Models
{
    public class Empleado
    {
        public int ID { get; set; }

        public string Nombre { get; set; }
        public string  PrimerApellido { get; set; }

        public string  SegundoApellido { get; set; }

    }
}
