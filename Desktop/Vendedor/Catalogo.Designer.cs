
namespace Desktop.Vendedor
{
    partial class Catalogo
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
            this.label8 = new System.Windows.Forms.Label();
            this.GridCatalogo = new System.Windows.Forms.DataGridView();
            this.Mostrarlbl = new System.Windows.Forms.Label();
            this.fechaingreso = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCarrito = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lvListaEmpleado = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompra = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridCatalogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(489, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 21);
            this.label8.TabIndex = 86;
            this.label8.Text = "CODIGO:";
            // 
            // GridCatalogo
            // 
            this.GridCatalogo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridCatalogo.Location = new System.Drawing.Point(126, 165);
            this.GridCatalogo.Name = "GridCatalogo";
            this.GridCatalogo.RowTemplate.Height = 25;
            this.GridCatalogo.Size = new System.Drawing.Size(334, 445);
            this.GridCatalogo.TabIndex = 85;
            this.GridCatalogo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCatalogo_CellContentClick);
            this.GridCatalogo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCatalogo_CellContentClick);
            // 
            // Mostrarlbl
            // 
            this.Mostrarlbl.AutoSize = true;
            this.Mostrarlbl.Location = new System.Drawing.Point(380, 121);
            this.Mostrarlbl.Name = "Mostrarlbl";
            this.Mostrarlbl.Size = new System.Drawing.Size(0, 15);
            this.Mostrarlbl.TabIndex = 84;
            // 
            // fechaingreso
            // 
            this.fechaingreso.Checked = false;
            this.fechaingreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaingreso.Location = new System.Drawing.Point(741, 402);
            this.fechaingreso.Name = "fechaingreso";
            this.fechaingreso.Size = new System.Drawing.Size(182, 23);
            this.fechaingreso.TabIndex = 83;
            this.fechaingreso.Value = new System.DateTime(2021, 10, 7, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(675, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 21);
            this.label3.TabIndex = 82;
            this.label3.Text = "FECHA:";
            // 
            // btnCarrito
            // 
            this.btnCarrito.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnCarrito.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCarrito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarrito.Location = new System.Drawing.Point(675, 469);
            this.btnCarrito.Name = "btnCarrito";
            this.btnCarrito.Size = new System.Drawing.Size(149, 34);
            this.btnCarrito.TabIndex = 80;
            this.btnCarrito.Text = "CARRITO";
            this.btnCarrito.UseVisualStyleBackColor = false;
            this.btnCarrito.Click += new System.EventHandler(this.btnCarrito_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresar.Location = new System.Drawing.Point(520, 469);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(149, 34);
            this.btnIngresar.TabIndex = 78;
            this.btnIngresar.Text = "AGREGAR";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lvListaEmpleado
            // 
            this.lvListaEmpleado.HideSelection = false;
            this.lvListaEmpleado.Location = new System.Drawing.Point(126, 142);
            this.lvListaEmpleado.Name = "lvListaEmpleado";
            this.lvListaEmpleado.Size = new System.Drawing.Size(0, 0);
            this.lvListaEmpleado.TabIndex = 76;
            this.lvListaEmpleado.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(489, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 21);
            this.label4.TabIndex = 72;
            this.label4.Text = "CANTIDAD:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(489, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 69;
            this.label2.Text = "PRECIO:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(489, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 68;
            this.label1.Text = "NOMBRE:";
            // 
            // lblEncabezado
            // 
            this.lblEncabezado.AutoSize = true;
            this.lblEncabezado.Font = new System.Drawing.Font("Sitka Small", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEncabezado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEncabezado.Location = new System.Drawing.Point(347, 41);
            this.lblEncabezado.Name = "lblEncabezado";
            this.lblEncabezado.Size = new System.Drawing.Size(356, 44);
            this.lblEncabezado.TabIndex = 88;
            this.lblEncabezado.Text = "Catalogo de productos";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCodigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCodigo.Location = new System.Drawing.Point(577, 236);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(0, 21);
            this.lblCodigo.TabIndex = 90;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNombre.Location = new System.Drawing.Point(577, 291);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 21);
            this.lblNombre.TabIndex = 91;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrecio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrecio.Location = new System.Drawing.Point(577, 345);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(0, 21);
            this.lblPrecio.TabIndex = 92;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(577, 402);
            this.txtCantidad.Mask = "99999";
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(78, 23);
            this.txtCantidad.TabIndex = 93;
            this.txtCantidad.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(489, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 21);
            this.label5.TabIndex = 94;
            this.label5.Text = "COMPRA #:";
            // 
            // txtCompra
            // 
            this.txtCompra.Location = new System.Drawing.Point(587, 182);
            this.txtCompra.Name = "txtCompra";
            this.txtCompra.Size = new System.Drawing.Size(132, 23);
            this.txtCompra.TabIndex = 95;
            this.txtCompra.TextChanged += new System.EventHandler(this.txtCompra_TextChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(636, 514);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(149, 34);
            this.btnEliminar.TabIndex = 97;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(481, 514);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(149, 34);
            this.btnModificar.TabIndex = 96;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnFacturar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturar.Location = new System.Drawing.Point(791, 514);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(149, 34);
            this.btnFacturar.TabIndex = 98;
            this.btnFacturar.Text = "FACTURAR";
            this.btnFacturar.UseVisualStyleBackColor = false;
            this.btnFacturar.Visible = false;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // Catalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1003, 730);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtCompra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblEncabezado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.GridCatalogo);
            this.Controls.Add(this.Mostrarlbl);
            this.Controls.Add(this.fechaingreso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCarrito);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.lvListaEmpleado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Catalogo";
            this.Text = "Catalogo";
            this.Load += new System.EventHandler(this.Catalogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridCatalogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView GridCatalogo;
        private System.Windows.Forms.Label Mostrarlbl;
        private System.Windows.Forms.DateTimePicker fechaingreso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCarrito;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.ListView lvListaEmpleado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEncabezado;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.MaskedTextBox txtCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCompra;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnFacturar;
    }
}