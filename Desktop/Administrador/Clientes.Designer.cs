
namespace Desktop.Administrador
{
    partial class Clientes
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.GridClientes = new System.Windows.Forms.DataGridView();
            this.txtCreditoF = new System.Windows.Forms.TextBox();
            this.txtTelefonoC = new System.Windows.Forms.MaskedTextBox();
            this.txtNombreC = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Small", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(415, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 45);
            this.label3.TabIndex = 7;
            this.label3.Text = "Clientes";
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIngresar.Image = global::Desktop.Properties.Resources.icons8_agregar_propiedad_48;
            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresar.Location = new System.Drawing.Point(396, 672);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(149, 39);
            this.btnIngresar.TabIndex = 16;
            this.btnIngresar.Text = "AGREGAR";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(122, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nombre:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(533, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 22);
            this.label5.TabIndex = 19;
            this.label5.Text = "Crédito Fiscal:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(122, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "Teléfono:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnModificar.Image = global::Desktop.Properties.Resources.icons8_editar_propiedad_48;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(551, 672);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(149, 39);
            this.btnModificar.TabIndex = 23;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Image = global::Desktop.Properties.Resources.icons8_eliminar_propiedad_48;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(706, 672);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(149, 39);
            this.btnEliminar.TabIndex = 24;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // GridClientes
            // 
            this.GridClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridClientes.Location = new System.Drawing.Point(122, 311);
            this.GridClientes.Name = "GridClientes";
            this.GridClientes.ReadOnly = true;
            this.GridClientes.RowHeadersWidth = 43;
            this.GridClientes.RowTemplate.Height = 25;
            this.GridClientes.Size = new System.Drawing.Size(733, 312);
            this.GridClientes.TabIndex = 25;
            this.GridClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridClientes_CellContentClick);
            this.GridClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridClientes_CellContentClick);
            // 
            // txtCreditoF
            // 
            this.txtCreditoF.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCreditoF.Location = new System.Drawing.Point(654, 155);
            this.txtCreditoF.Name = "txtCreditoF";
            this.txtCreditoF.Size = new System.Drawing.Size(194, 30);
            this.txtCreditoF.TabIndex = 20;
            this.txtCreditoF.TextChanged += new System.EventHandler(this.txtSexoC_TextChanged);
            // 
            // txtTelefonoC
            // 
            this.txtTelefonoC.Location = new System.Drawing.Point(224, 229);
            this.txtTelefonoC.Mask = "0000-0000";
            this.txtTelefonoC.Name = "txtTelefonoC";
            this.txtTelefonoC.Size = new System.Drawing.Size(175, 25);
            this.txtTelefonoC.TabIndex = 27;
            this.txtTelefonoC.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtTelefonoC_MaskInputRejected);
            // 
            // txtNombreC
            // 
            this.txtNombreC.Location = new System.Drawing.Point(224, 155);
            this.txtNombreC.Name = "txtNombreC";
            this.txtNombreC.Size = new System.Drawing.Size(269, 25);
            this.txtNombreC.TabIndex = 28;
            this.txtNombreC.TextChanged += new System.EventHandler(this.txtNombreC_TextChanged);
            this.txtNombreC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreC_KeyPress);
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1003, 827);
            this.Controls.Add(this.txtNombreC);
            this.Controls.Add(this.txtTelefonoC);
            this.Controls.Add(this.GridClientes);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCreditoF);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Clientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView GridClientes;
        private System.Windows.Forms.TextBox txtCreditoF;
        private System.Windows.Forms.MaskedTextBox txtTelefonoC;
        private System.Windows.Forms.TextBox txtNombreC;
    }
}