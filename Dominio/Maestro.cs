using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesAPP.Dominio
{
    public class Maestro
    {
        public int NroOrden { get; set; }
        public DateTime Fecha { get; set; }
        public string Responsable { get; set; }
        public List<Detalle> Detalles { get; set; }


        public Maestro() 
        {
            Detalles = new List<Detalle>();
        }

        public void AgregarDetalle(Detalle detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int indice)
        {
            Detalles.RemoveAt(indice);
        }
    }
}
