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
        public Categoria Categoria { get; set; }


        public override string ToString()
        {
            return string.Format("Codidgo de Producto: {0} Descripcion: {1} Precio: {2} Cantidad: {3} Codigo de Categoria {4} Descripcion de Categoria {5}.\n", Codigo, Descripcion, Precio, Cantidad, Categoria.Codigo, Categoria.Descripcion );
        }
    }
}
