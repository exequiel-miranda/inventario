
namespace Desktop.Administrador
{
    partial class ReporteVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteVentas));
            this.GridReporte = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCombo = new System.Windows.Forms.ComboBox();
            this.dtpfechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpfechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.botones2 = new Desktop.Botones.Botones();
            this.botones1 = new Desktop.Botones.Botones();
            ((System.ComponentModel.ISupportInitialize)(this.GridReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // GridReporte
            // 
            this.GridReporte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GridReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridReporte.Location = new System.Drawing.Point(3, 311);
            this.GridReporte.Name = "GridReporte";
            this.GridReporte.RowHeadersWidth = 43;
            this.GridReporte.RowTemplate.Height = 25;
            this.GridReporte.Size = new System.Drawing.Size(725, 282);
            this.GridReporte.TabIndex = 0;
            this.GridReporte.TabStop = false;
            this.GridReporte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridReporte_CellContentClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(525, 604);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(174, 48);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "GENERAR PDF";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(8, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 21);
            this.label2.TabIndex = 59;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Sitka Small", 36.35643F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(730, 64);
            this.label7.TabIndex = 0;
            this.label7.Text = "Reporte de las Ventas.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 15.68317F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(236, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Seleccionar Filtro de Factura:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCombo
            // 
            this.btnCombo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCombo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCombo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCombo.FormattingEnabled = true;
            this.btnCombo.Location = new System.Drawing.Point(266, 115);
            this.btnCombo.Name = "btnCombo";
            this.btnCombo.Size = new System.Drawing.Size(225, 29);
            this.btnCombo.TabIndex = 1;
            this.btnCombo.DropDown += new System.EventHandler(this.btnCombo_DropDown);
            this.btnCombo.SelectedValueChanged += new System.EventHandler(this.btnCombo_SelectedValueChanged);
            // 
            // dtpfechaFin
            // 
            this.dtpfechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaFin.Location = new System.Drawing.Point(481, 161);
            this.dtpfechaFin.Name = "dtpfechaFin";
            this.dtpfechaFin.Size = new System.Drawing.Size(149, 23);
            this.dtpfechaFin.TabIndex = 69;
            this.dtpfechaFin.ValueChanged += new System.EventHandler(this.dtpfechaFin_ValueChanged);
            // 
            // dtpfechaInicio
            // 
            this.dtpfechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaInicio.Location = new System.Drawing.Point(187, 161);
            this.dtpfechaInicio.Name = "dtpfechaInicio";
            this.dtpfechaInicio.Size = new System.Drawing.Size(149, 23);
            this.dtpfechaInicio.TabIndex = 68;
            this.dtpfechaInicio.ValueChanged += new System.EventHandler(this.dtpfechaInicio_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(412, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 67;
            this.label3.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(113, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 66;
            this.label1.Text = "Desde:";
            // 
            // botones2
            // 
            this.botones2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.botones2.BackGroundColor = System.Drawing.Color.DarkSeaGreen;
            this.botones2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.botones2.BorderRadius = 45;
            this.botones2.BorderSize = 0;
            this.botones2.FlatAppearance.BorderSize = 0;
            this.botones2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botones2.ForeColor = System.Drawing.Color.White;
            this.botones2.Location = new System.Drawing.Point(398, 226);
            this.botones2.Name = "botones2";
            this.botones2.Size = new System.Drawing.Size(150, 40);
            this.botones2.TabIndex = 85;
            this.botones2.Text = "Nuevo";
            this.botones2.TextGroundColor = System.Drawing.Color.White;
            this.botones2.UseVisualStyleBackColor = false;
            this.botones2.Click += new System.EventHandler(this.botones2_Click);
            // 
            // botones1
            // 
            this.botones1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.botones1.BackGroundColor = System.Drawing.Color.DarkSlateBlue;
            this.botones1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.botones1.BorderRadius = 45;
            this.botones1.BorderSize = 0;
            this.botones1.FlatAppearance.BorderSize = 0;
            this.botones1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botones1.ForeColor = System.Drawing.Color.White;
            this.botones1.Location = new System.Drawing.Point(223, 226);
            this.botones1.Name = "botones1";
            this.botones1.Size = new System.Drawing.Size(150, 40);
            this.botones1.TabIndex = 84;
            this.botones1.Text = "Generar reporte";
            this.botones1.TextGroundColor = System.Drawing.Color.White;
            this.botones1.UseVisualStyleBackColor = false;
            this.botones1.Click += new System.EventHandler(this.botones1_Click);
            // 
            // ReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(730, 659);
            this.Controls.Add(this.botones2);
            this.Controls.Add(this.botones1);
            this.Controls.Add(this.dtpfechaFin);
            this.Controls.Add(this.dtpfechaInicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GridReporte);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReporteVentas";
            this.Text = "ReporteProveedor";
            this.Load += new System.EventHandler(this.ReporteVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridReporte;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox btnCombo;
        private System.Windows.Forms.DateTimePicker dtpfechaFin;
        private System.Windows.Forms.DateTimePicker dtpfechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Botones.Botones botones2;
        private Botones.Botones botones1;
    }
}