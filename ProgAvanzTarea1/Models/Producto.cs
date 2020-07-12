using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgAvanzTarea1.Models
{
    public class Producto
    {
        public int Codigo { get; set; }

        public string Descripcion { get; set; }
        public double Precio { get; set; }

        public int Cantidad { get; set; }
        public int Categoria { get; set; }

    }
}
