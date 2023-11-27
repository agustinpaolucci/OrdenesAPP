using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesAPP.Dominio
{
    public class Detalle
    {
        public Material Material { get; set; }
        public int Cantidad { get; set; }

        public Detalle(Material mat, int cant)
        {
            Material = mat;
            Cantidad = cant;
        }

        public override string ToString()
        {
            return Material.ToString(); 
        }
    }
}
