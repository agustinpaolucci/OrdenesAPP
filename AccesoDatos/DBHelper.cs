using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OrdenesAPP.Dominio;

namespace OrdenesAPP.AccesoDatos
{
    public class DBHelper
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ORDENESAPP;Integrated Security=True;");

        public void Conectar()
        {
            cnn.Open();
        }
        public void Desconectar()
        {
            cnn.Close();
        }

        public DataTable ObtenerListado()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SP_CONSULTAR_MATERIALES";
            cmd.CommandType = CommandType.StoredProcedure;
        
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());

            return tabla;
        }

        public bool Confirmar(Maestro objOrden)
        {
            bool flag = true;

            SqlTransaction transaccion = null;

            try
            {
                Conectar();

                transaccion = cnn.BeginTransaction();

                SqlCommand cmdMaestro = new SqlCommand();
                cmdMaestro.Connection = cnn;
                cmdMaestro.Transaction = transaccion;
                cmdMaestro.CommandText = "SP_INSERTAR_ORDEN";
                cmdMaestro.CommandType = CommandType.StoredProcedure;

                cmdMaestro.Parameters.AddWithValue("@fecha_orden", objOrden.Fecha);
                cmdMaestro.Parameters.AddWithValue("@responsable", objOrden.Responsable);


                // CREO UN PARAMETRO PARA RECIBIR EL PARAMETRO DE SALIDA.
                SqlParameter param = new SqlParameter("@prox_orden", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmdMaestro.Parameters.Add(param);
                cmdMaestro.ExecuteNonQuery();

                int numeroMaestro = Convert.ToInt32(param.Value); // ALMACENO VALOR PARAM SALIDA


                // PONGO nroDetalle en 1!!!!
                int numeroDetalle = 1;

                //RECORRE CADA DETALLE
                foreach (Detalle det in objOrden.Detalles)
                {
                    SqlCommand cmdDetalle = new SqlCommand();
                    cmdDetalle.Connection = cnn;
                    cmdDetalle.Transaction = transaccion;
                    cmdDetalle.CommandText = "SP_INSERTAR_DETALLE"; //USA PARAM SALIDA ANTERIOR
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_detalle", numeroDetalle);
                    cmdDetalle.Parameters.AddWithValue("@id_orden", numeroMaestro);
                    cmdDetalle.Parameters.AddWithValue("@material", det.Material.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", det.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    numeroDetalle++;
                }
                
                transaccion.Commit();
                MessageBox.Show("Se cargo la ORDEN NRO: " + numeroMaestro, "INFO", MessageBoxButtons.OK);
            }

            catch (Exception)
            {
                transaccion.Rollback();
                flag = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    Desconectar();
                }
            }

            return flag;
        }
    }
}
