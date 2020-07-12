using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ProgAvanzTarea1.Helpers;
using ProgAvanzTarea1.Models;
using Windows.UI.Popups;

namespace ProgAvanzTarea1.ViewModels
{
    public class ProductoViewModel : Observable
    {
        public ProductoViewModel()
        {
            Productos = new Producto[20];

            //Creacion de productos para asignacion de valores de entrada.
            Producto TemporalProducto = new Producto { Codigo = 1234, Descripcion = "Zapatos", Precio = 15000, Cantidad = 150, Categoria = 1 };
            Producto TemporalProducto1 = new Producto { Codigo = 2345, Descripcion = "Medias", Precio = 1500, Cantidad = 1500, Categoria = 1 };
            Producto TemporalProducto2 = new Producto { Codigo = 3456, Descripcion = "Pantalones", Precio = 30000, Cantidad = 50, Categoria = 2 };

            //Preasignacion de ejemplos para mostrar valores de entrada
            Productos[0] = TemporalProducto;
            Productos[1] = TemporalProducto1;
            Productos[2] = TemporalProducto2;
            Counter = 2;


            TextoAMostrar = ImprimirArray();
        }

        public Producto[] Productos { get; set; }


        public int Counter { get; set; }

        private ICommand _NuevoProducto;
        public ICommand NuevoProducto
        {
            get
            {
                _NuevoProducto = new RelayCommand(async () => { await AsignarNuevoProducto(); }); ;

                return _NuevoProducto;
            }
        }

        private int _Codigo;
        public int Codigo
        {
            get { return _Codigo; }
            set
            {
                Set<int>(ref _Codigo, value);
            }
        }

        private string _Descripcion = string.Empty;
        public string Descripcion
        {
            get { return _Descripcion; }
            set
            {
                Set<string>(ref _Descripcion, value);
            }
        }

        private double _Precio;
        public double Precio
        {
            get { return _Precio; }
            set
            {
                Set<double>(ref _Precio, value);
            }
        }

        private int _Cantidad;
        public int Cantidad
        {
            get { return _Cantidad; }
            set
            {
                Set<int>(ref _Cantidad, value);
            }
        }

        private int _Categoria;
        public int Categoria
        {
            get { return _Categoria; }
            set
            {
                Set<int>(ref _Categoria, value);
            }
        }

        private string _TextoAMostrar = string.Empty;
        public string TextoAMostrar
        {
            get { return _TextoAMostrar; }
            set
            {
                Set<string>(ref _TextoAMostrar, value);
            }
        }

        public async Task AsignarNuevoProducto()
        {

            try
            {
                if (Codigo != 0 && Descripcion != string.Empty && Precio > 0 && Cantidad >= 0 && Categoria != 0)
                {
                    Producto temporal = new Producto()
                    {
                        Codigo = this.Codigo,
                        Descripcion = this.Descripcion,
                        Precio = this.Precio,
                        Cantidad = Cantidad,
                        Categoria = this.Categoria
                    };

                    Counter++;
                    Productos[Counter] = temporal;

                }
                else
                {

                }

                TextoAMostrar = ImprimirArray();
            }
            catch (System.IndexOutOfRangeException) {
                MessageDialog msg = new MessageDialog("Solo puede asignar hasta veinte valores en esta sección. Por favor contactar a su administrador para aumentar la capacidad");
                await msg.ShowAsync();
            }
            catch (Exception e) {
                MessageDialog msg = new MessageDialog("Favor contactar a su administrador de sistema y reportarle el siguiente error :" + e.Message );
                await msg.ShowAsync();
            }
             
        }


        private string ImprimirArray()
        {
            string temp = string.Empty;

            foreach (Producto c in Productos)
            {
                if (c is null)
                {
                    return temp;
                }
                else
                {
                    temp += c.ToString();
                }
            }

            return temp;
        }
    }
}
