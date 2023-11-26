namespace OrdenesAPP.Presentacion
{
    partial class Frm_NuevaOrden
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblResponsable = new System.Windows.Forms.Label();
            this.txtResponsable = new System.Windows.Forms.TextBox();
            this.cboMateriales = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.brnCancelar = new System.Windows.Forms.Button();
            this.txtFecha = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(22, 19);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha";
            // 
            // lblResponsable
            // 
            this.lblResponsable.AutoSize = true;
            this.lblResponsable.Location = new System.Drawing.Point(22, 56);
            this.lblResponsable.Name = "lblResponsable";
            this.lblResponsable.Size = new System.Drawing.Size(69, 13);
            this.lblResponsable.TabIndex = 2;
            this.lblResponsable.Text = "Responsable";
            // 
            // txtResponsable
            // 
            this.txtResponsable.Location = new System.Drawing.Point(125, 48);
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.Size = new System.Drawing.Size(241, 20);
            this.txtResponsable.TabIndex = 3;
            // 
            // cboMateriales
            // 
            this.cboMateriales.FormattingEnabled = true;
            this.cboMateriales.Location = new System.Drawing.Point(12, 89);
            this.cboMateriales.Name = "cboMateriales";
            this.cboMateriales.Size = new System.Drawing.Size(188, 21);
            this.cboMateriales.TabIndex = 4;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(227, 90);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 5;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(388, 88);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colMaterial,
            this.colStock,
            this.colCantidad,
            this.colAcciones});
            this.dgvDetalles.Location = new System.Drawing.Point(12, 133);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.Size = new System.Drawing.Size(451, 150);
            this.dgvDetalles.TabIndex = 7;
            this.dgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellContentClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "Column1";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colMaterial
            // 
            this.colMaterial.HeaderText = "MATERIAL";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.ReadOnly = true;
            // 
            // colStock
            // 
            this.colStock.HeaderText = "STOCK";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "CANTIDAD";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colAcciones
            // 
            this.colAcciones.HeaderText = "ACCIONES";
            this.colAcciones.Name = "colAcciones";
            this.colAcciones.ReadOnly = true;
            this.colAcciones.Text = "QUITAR";
            this.colAcciones.UseColumnTextForButtonValue = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(125, 303);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // brnCancelar
            // 
            this.brnCancelar.Location = new System.Drawing.Point(279, 303);
            this.brnCancelar.Name = "brnCancelar";
            this.brnCancelar.Size = new System.Drawing.Size(75, 23);
            this.brnCancelar.TabIndex = 9;
            this.brnCancelar.Text = "Cancelar";
            this.brnCancelar.UseVisualStyleBackColor = true;
            this.brnCancelar.Click += new System.EventHandler(this.brnCancelar_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(125, 12);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 10;
            // 
            // Frm_NuevaOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 358);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.brnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cboMateriales);
            this.Controls.Add(this.txtResponsable);
            this.Controls.Add(this.lblResponsable);
            this.Controls.Add(this.lblFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_NuevaOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Orden Retiro";
            this.Load += new System.EventHandler(this.Frm_NuevaOrden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblResponsable;
        private System.Windows.Forms.TextBox txtResponsable;
        private System.Windows.Forms.ComboBox cboMateriales;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button brnCancelar;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewButtonColumn colAcciones;
    }
}