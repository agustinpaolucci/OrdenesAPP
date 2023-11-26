using OrdenesAPP.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OrdenesAPP.Presentacion
{
    public partial class Frm_NuevaOrden : Form
    {
        private OrdenRetiro nuevo;

        public Frm_NuevaOrden()
        {
            InitializeComponent();
            nuevo = new OrdenRetiro();
        }

        private void Frm_NuevaOrden_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarCombo();
        }

        //1 - LIMPIAR Y CARGA COMBO.
        
        private void LimpiarCampos()
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yy");
            txtResponsable.Text = string.Empty;
            txtCantidad.Text = "0";
            this.ActiveControl = txtFecha;
        }

        
        private void CargarCombo()
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=PREPARCIAL;Integrated Security=True;");
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SP_CONSULTAR_MATERIALES";
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());

            cboMateriales.DataSource = tabla;
            cboMateriales.ValueMember = "id_material";
            cboMateriales.DisplayMember = "nom_material";
            cboMateriales.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMateriales.SelectedIndex = -1;

            cnn.Close();
        }

        // 2 BOTON AGREGAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtFecha.Text))
            {
                MessageBox.Show("Debe ingresar una FECHA válida","CONTROL"); 
                return;
            }

            if (String.IsNullOrEmpty(txtFecha.Text))
            {
                MessageBox.Show("Debe ingresar una FECHA válida", "CONTROL");
                return;
            }
            if (String.IsNullOrEmpty(txtResponsable.Text))
            {
                MessageBox.Show("Debe ingresar una RESPONSABLE", "CONTROL");
                return;
            }

            if (cboMateriales.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir un MATERIAL del LISTADO", "CONTROL");
                return;
            }

            if (String.IsNullOrEmpty(txtCantidad.Text) || txtCantidad.Text == "0")
            {
                MessageBox.Show("Debe ingresar una CANTIDAD válida", "CONTROL");
                return;
            }

            // 3 - NO DOS VECES EN GRILLA
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["ColMaterial"].Value.ToString().Equals(cboMateriales.Text))
                {
                    MessageBox.Show("Ese MATERIAL ya se encuentra cargado en el DETALLE", "CONTROL",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }


            DataRowView item = (DataRowView)cboMateriales.SelectedItem;
            int cod = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            int stock = Convert.ToInt32(item.Row.ItemArray[2]);

            Material m = new Material(cod,nom,stock);

            int cantidad = Convert.ToInt32(txtCantidad.Text);

            DetalleOrden detalle = new DetalleOrden(m, cantidad);

            nuevo.AgregarDetalle(detalle);

            dgvDetalles.Rows.Add(new object[] { cod, nom, stock, cantidad });
        }
        
        // 4 - BOTON QUITAR EN DGV
        // TOCANDO EN LA GRILLA >>> PROPIEDADES >>> EVENTOS >>> CELL CONTENT CLICK
        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (dgvDetalles.CurrentCell.ColumnIndex == 4)
                {
                    nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                    dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                }
            }
        }

        // 5 - CLICK EN ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //1) VALIDACIONES
            if (string.IsNullOrWhiteSpace(txtResponsable.Text))
            {
                MessageBox.Show("Debe ingresar un RESPONSABLE", "CONTROL",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Debe ingresar un valor en CANTIDAD", "CONTROL",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //2) IMPORTANTE: GRILLA CON AL MENOS 1 DETALLE
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos UN DETALLE", "Control",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GuardarMaestro();

        }

        // 6 - GUARDAR MAESTRO.
        private void GuardarMaestro()
        {
            nuevo.Fecha = Convert.ToDateTime(txtFecha.Text);
            nuevo.Responsable = txtResponsable.Text;
           
            if (Confirmar())
            {
                MessageBox.Show("Nueva ORDEN Confirmada.",
                "INFORME",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar LA ORDEN",
                "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 7 - CONFIRMAR
        private bool Confirmar()
        {
            bool resultado = true;

            SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=PREPARCIAL;Integrated Security=True;");
            
            SqlTransaction transaccion = null;

            try
            {
                cnn.Open();

                transaccion = cnn.BeginTransaction();

                SqlCommand cmdMaestro = new SqlCommand();
                cmdMaestro.Connection = cnn;
                cmdMaestro.Transaction = transaccion;
                cmdMaestro.CommandText = "SP_INSERTAR_ORDEN"; // 3 ENTRADA 1 SALIDA
                cmdMaestro.CommandType = CommandType.StoredProcedure;

                cmdMaestro.Parameters.AddWithValue("@fecha_orden", nuevo.Fecha);
                cmdMaestro.Parameters.AddWithValue("@responsable", nuevo.Responsable);
                

                // CREO UN PARAMETRO PARA RECIBIR EL PARAMETRO DE SALIDA NRO PRESUPUESTO.
                SqlParameter param = new SqlParameter("@prox_orden", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmdMaestro.Parameters.Add(param);
                cmdMaestro.ExecuteNonQuery();

                int NroOrden = Convert.ToInt32(param.Value); // ALMACENO VALOR PARAM SALIDA


                // PONGO nroDetalle en 1!!!!
                int numeroDetalle = 1;

                //RECORRE CADA DETALLE
                foreach (DetalleOrden det in nuevo.Detalles)
                {
                    SqlCommand cmdDetalle = new SqlCommand();
                    cmdDetalle.Connection = cnn;
                    cmdDetalle.Transaction = transaccion;
                    cmdDetalle.CommandText = "SP_INSERTAR_DETALLE"; //USA PARAM SALIDA ANTERIOR
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_detalle", numeroDetalle);
                    cmdDetalle.Parameters.AddWithValue("@id_orden", NroOrden);
                    cmdDetalle.Parameters.AddWithValue("@material", det.Material.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", det.Cantidad);

                    cmdDetalle.ExecuteNonQuery();

                    numeroDetalle++;
                }
                // TRY >>> COMMIT!
                transaccion.Commit();
            }

            catch (Exception)
            {
                // SI SALIO ALGO MAL, CATCH CON UN ROLLBACK.
                transaccion.Rollback();
                resultado = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            // FINALLY SIEMPRE CIERRA LA CONEXION.
            return resultado;
        }
    

        private void brnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro desea CANCELAR la carga?", "CONTROL",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        /////////////////////////////////////////////////////////////////////
        // Propiedades VISUALES FORMULARIO:
        // Orden de Tabulacion de los componentes
        // StartPosition: CenterParent
        // Maximize Box: False
        // MinimizeBox: False
        // FormerBorderStyle: FixedSingle
        /////////////////////////////////////////////////////////////////////

    }
}
