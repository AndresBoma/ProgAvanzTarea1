using System;

using ProgAvanzTarea1.Helpers;
using ProgAvanzTarea1.Models;

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


        private string _TextoAMostrar = string.Empty;
        public string TextoAMostrar
        {
            get { return _TextoAMostrar; }
            set
            {
                Set<string>(ref _TextoAMostrar, value);
            }
        }

        public void AsignarNuevoSupervisor()
        {

            TextoAMostrar = ImprimirArray();
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
