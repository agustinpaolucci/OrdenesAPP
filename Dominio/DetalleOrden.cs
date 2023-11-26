using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesAPP.Dominio
{
    public class DetalleOrden
    {

        public Material Material { get; set; }
        public int Cantidad { get; set; }

        public DetalleOrden(Material mat, int cant)
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
