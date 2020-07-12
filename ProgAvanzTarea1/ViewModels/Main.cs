using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Input;
using ProgAvanzTarea1.Helpers;
using ProgAvanzTarea1.Models;
using Windows.UI.Popups;

namespace ProgAvanzTarea1.ViewModels
{
    public class CajerosViewModel : Observable
    {

        public CajerosViewModel()
        {
            Cajeros = new Cajero[20];

            Cajero TemporalCajero1 = new Cajero { ID = 377973, Nombre = "Alexander", PrimerApellido = "Acuna", SegundoApellido = "Arias", Caja = 1 };
            Cajero TemporalCajero2 = new Cajero { ID = 102263641, Nombre = "Maria Fernanda", PrimerApellido = "Camacho", SegundoApellido = "Camacho", Caja = 2 };

            Cajeros[0] = TemporalCajero1;
            Cajeros[1] = TemporalCajero2;

            Counter = 1;

            TextoAMostrar = ImprimirArray();
        }

        public Cajero[] Cajeros { get; set; }

        public int Counter { get; set; }


        private ICommand _NuevoCajero;
        public ICommand NuevoCajero
        {
            get
            {
                _NuevoCajero = new RelayCommand(async () => { await AsignarNuevoCajero(); }); ;

                return _NuevoCajero;
            }
        }

        private string _Nombre = string.Empty;
        public string Nombre {
            get { return _Nombre; }
            set
            {
                Set<string>(ref _Nombre, value);
            }
        }

        private string _Apellido1 = string.Empty;
        public string Apellido1
        {
            get { return _Apellido1; }
            set
            {
                Set<string>(ref _Apellido1, value);
            }
        }

        private string _Apellido2 = string.Empty;
        public string Apellido2
        {
            get { return _Apellido2; }
            set
            {
                Set<string>(ref _Apellido2, value);
            }
        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                Set<int>(ref _ID, value);
            }
        }

        private int _Caja;
        public int Caja
        {
            get { return _Caja; }
            set
            {
                Set<int>(ref _Caja, value);
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


        private string ImprimirArray() {
            string temp = string.Empty;

            foreach (Cajero c in Cajeros) {
                if (c is null)
                {
                    return temp;
                }
                else {
                    temp += c.ToString();
                }
            }

            return temp;
        }

        public async Task AsignarNuevoCajero()
        {
            try
            {
                if (ID != 0 && Caja != 0 && Nombre != string.Empty && Apellido1 != string.Empty && Apellido2 != string.Empty)
                {
                    Cajero temporal = new Cajero()
                    {
                        ID = this.ID,
                        Nombre = this.Nombre,
                        Caja = this.Caja,
                        PrimerApellido = Apellido1,
                        SegundoApellido = this.Apellido2
                    };

                    Counter++;
                    Cajeros[Counter] = temporal;

                }
                else
                {

                }

                TextoAMostrar = ImprimirArray();
            }
            catch (System.IndexOutOfRangeException)
            {
                MessageDialog msg = new MessageDialog("Solo puede asignar hasta veinte valores en esta sección. Por favor contactar a su administrador para aumentar la capacidad");
                await msg.ShowAsync();
            }
            catch (Exception e)
            {
                MessageDialog msg = new MessageDialog("Favor contactar a su administrador de sistema y reportarle el siguiente error :" + e.Message);
                await msg.ShowAsync();
            }
        }



    }
}
