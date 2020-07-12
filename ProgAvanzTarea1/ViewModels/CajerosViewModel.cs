using System;
using System.Security.Cryptography.X509Certificates;
using ProgAvanzTarea1.Helpers;
using ProgAvanzTarea1.Models;

namespace ProgAvanzTarea1.ViewModels
{
    public class CajerosViewModel : Observable
    {

        public CajerosViewModel()
        {
            Cajeros = new Cajero[20];

            Cajero TemporalCajero1 = new Cajero { ID = 377973, Nombre = "Alexander", PrimerApellido = "Acuna", SegundoApellido = "Arias" };
            Cajero TemporalCajero2 = new Cajero { ID = 102263641, Nombre = "Maria Fernanda", PrimerApellido = "Camacho", SegundoApellido = "Camacho" };

            Cajeros[0] = TemporalCajero1;
            Cajeros[1] = TemporalCajero2;

            Counter = 1;

            TextoAMostrar = ImprimirArray();
        }

        public Cajero[] Cajeros { get; set; }

       
        public int Counter { get; set; }


        private string _TextoAMostrar = string.Empty;
        public string TextoAMostrar {
            get { return _TextoAMostrar; }
            set
            {
                Set<string>(ref _TextoAMostrar, value);
            }
        }

        public void AsignarNuevoCajero() {

            TextoAMostrar = ImprimirArray();
        }


        private string ImprimirArray() {
            string temp = string.Empty;

            foreach (Cajero c in Cajeros) {
                if (c is null)
                {

                }
                else {
                    temp = c.ToString();
                }
            }

            return temp;
        }

    }
}
