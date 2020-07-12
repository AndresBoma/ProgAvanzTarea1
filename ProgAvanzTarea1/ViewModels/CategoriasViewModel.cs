using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ProgAvanzTarea1.Helpers;
using ProgAvanzTarea1.Models;
using Windows.UI.Popups;

namespace ProgAvanzTarea1.ViewModels
{
    public class CategoriasViewModel : Observable
    {
        public CategoriasViewModel()
        {
            Categorias = new Categoria[20];

            //Creacion de productos de ejemplo para asignacion de valores de entrada.
            Categoria TemporalCategoria = new Categoria { Codigo = 1234, Descripcion = "Ropa"};
            Categoria TemporalCategoria1 = new Categoria { Codigo = 2345, Descripcion = "Electrodomesticos"};
            

            //Preasignacion de ejemplos para mostrar valores de entrada
            Categorias[0] = TemporalCategoria;
            Categorias[1] = TemporalCategoria1;
            Counter = 1;


            TextoAMostrar = ImprimirArray();
        }

        //array para guardar todas las instancias de Categorias
        public Categoria[] Categorias { get; set; }

        //Counter para facilitar el index de nuevas Categorias para ser agregadas
        public int Counter { get; set; }

        //Commando que permite llamar metodo asincronico de llamar nueva categoria
        private ICommand _NuevoCajero;
        public ICommand NuevoCajero
        {
            get
            {
                _NuevoCajero = new RelayCommand(async () => { await AsignarNuevaCategoria(); }); ; // llamada al metodo de asignar nueva informacion del formulario

                return _NuevoCajero;
            }
        }
        //Region que guarda las Propiedades del Formulario para generar neuvas instancias de Categoria.
        #region Form Properties
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
        #endregion

        //Propiedad para mostrar Tiempo Real Los cambios del arreglo.
        private string _TextoAMostrar = string.Empty;
        public string TextoAMostrar
        {
            get { return _TextoAMostrar; }
            set
            {
                Set<string>(ref _TextoAMostrar, value);
            }
        }

        //MEtodo para retornas la representacion string del arreglo

        private string ImprimirArray()
        {
            string temp = string.Empty;

            foreach (Categoria c in Categorias)
            {
                if (c is null) // if there are no more Instances drop the printing
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

        //Metodo asincronico para asignar nueva Cateegoria al Array. Asincronico asi no la interfaz grafica no se lockea independientemente de donde este guardado el array.
        public async Task AsignarNuevaCategoria()
        {
            try
            {
                if (Codigo != 0 &&  Descripcion != string.Empty)
                {
                    Categoria temporal = new Categoria()
                    {
                        Codigo = this.Codigo,
                        Descripcion = this.Descripcion
                    };

                    Counter++;
                    Categorias[Counter] = temporal;

                }
                else
                {

                }

                TextoAMostrar = ImprimirArray();
            }
            catch (System.IndexOutOfRangeException)
            {
                MessageDialog msg = new MessageDialog("Solo puede asignar hasta veinte valores en esta sección. Por favor contactar a su administrador para aumentar la capacidad");//en lugar de usar el contador, esta excepcion permite entender cuando el array esta lleno.
                await msg.ShowAsync();
            }
            catch (Exception e)
            {
                MessageDialog msg = new MessageDialog("Favor contactar a su administrador de sistema y reportarle el siguiente error :" + e.Message); // Cualquier otra excepcion solo para ejemplificar la excepcion general.
                await msg.ShowAsync();
            }
        }
    }
}
