using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ProgAvanzTarea1.Helpers;
using ProgAvanzTarea1.Models;
using Windows.UI.Popups;

namespace ProgAvanzTarea1.ViewModels
{
    public class SupervisoresViewModel : Observable
    {
        public SupervisoresViewModel()
        {
            Supervisores = new Supervisor[20];

            Supervisor TemporalSupervisor = new Supervisor { ID = 100010569, Nombre = "Andres", PrimerApellido = "Bolanos", SegundoApellido = "Marin", Sucursal = 1 };

            Supervisores[0] = TemporalSupervisor;
            Counter = 1;

            TextoAMostrar = ImprimirArray();
        }

        public Supervisor[] Supervisores { get; set; }


        public int Counter { get; set; }

        private ICommand _NuevoSupervisor;
        public ICommand NuevoSupervisor
        {
            get
            {
                _NuevoSupervisor = new RelayCommand(async () => { await AsignarNuevoSupervisor(); }); ;

                return _NuevoSupervisor;
            }
        }

        private string _Nombre = string.Empty;
        public string Nombre
        {
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

        private int _Sucursal;
        public int Sucursal
        {
            get { return _Sucursal; }
            set
            {
                Set<int>(ref _Sucursal, value);
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

        public async Task AsignarNuevoSupervisor()
        {
            try
            {
                if (ID != 0 && Sucursal != 0 && Nombre != string.Empty && Apellido1 != string.Empty && Apellido2 != string.Empty)
                {
                    Supervisor temporal = new Supervisor()
                    {
                        ID = this.ID,
                        Nombre = this.Nombre,
                        Sucursal = this.Sucursal,
                        PrimerApellido = Apellido1,
                        SegundoApellido = this.Apellido2
                    };

                    Counter++;
                    Supervisores[Counter] = temporal;

                }
                else
                {

                }

                TextoAMostrar = ImprimirArray();
            }
            catch (System.IndexOutOfRangeException )
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


        private string ImprimirArray()
        {
            string temp = string.Empty;

            foreach (Supervisor c in Supervisores)
            {
                if (c is null)
                {

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
