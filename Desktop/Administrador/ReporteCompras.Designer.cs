﻿
namespace Desktop.Administrador
{
    partial class ReporteCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteCompras));
            this.GridReporte = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpfechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpfechaFin = new System.Windows.Forms.DateTimePicker();
            this.precio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // GridReporte
            // 
            this.GridReporte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GridReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridReporte.Location = new System.Drawing.Point(3, 218);
            this.GridReporte.Name = "GridReporte";
            this.GridReporte.RowHeadersWidth = 43;
            this.GridReporte.RowTemplate.Height = 25;
            this.GridReporte.Size = new System.Drawing.Size(725, 449);
            this.GridReporte.TabIndex = 0;
            this.GridReporte.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(525, 685);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(174, 54);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "GENERAR PDF";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(-1, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 22);
            this.label2.TabIndex = 61;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Sitka Small", 36.35643F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(730, 73);
            this.label7.TabIndex = 0;
            this.label7.Text = "Reporte de las Compras.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(216, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 28);
            this.label1.TabIndex = 62;
            this.label1.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(439, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 28);
            this.label3.TabIndex = 63;
            this.label3.Text = "Hasta:";
            // 
            // dtpfechaInicio
            // 
            this.dtpfechaInicio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpfechaInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpfechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaInicio.Location = new System.Drawing.Point(181, 149);
            this.dtpfechaInicio.Name = "dtpfechaInicio";
            this.dtpfechaInicio.Size = new System.Drawing.Size(149, 25);
            this.dtpfechaInicio.TabIndex = 64;
            this.dtpfechaInicio.ValueChanged += new System.EventHandler(this.dtpfechaInicio_ValueChanged);
            // 
            // dtpfechaFin
            // 
            this.dtpfechaFin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpfechaFin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpfechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaFin.Location = new System.Drawing.Point(402, 149);
            this.dtpfechaFin.Name = "dtpfechaFin";
            this.dtpfechaFin.Size = new System.Drawing.Size(149, 25);
            this.dtpfechaFin.TabIndex = 65;
            this.dtpfechaFin.ValueChanged += new System.EventHandler(this.dtpfechaFin_ValueChanged);
            // 
            // precio
            // 
            this.precio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.precio.AutoSize = true;
            this.precio.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.precio.Location = new System.Drawing.Point(3, 696);
            this.precio.Name = "precio";
            this.precio.Size = new System.Drawing.Size(242, 28);
            this.precio.TabIndex = 69;
            this.precio.Text = "Monto total según filtro: $";
            // 
            // ReporteCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(730, 747);
            this.Controls.Add(this.precio);
            this.Controls.Add(this.dtpfechaFin);
            this.Controls.Add(this.dtpfechaInicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GridReporte);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReporteCompras";
            this.Text = "ReporteEmpleados";
            this.Load += new System.EventHandler(this.ReporteCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridReporte;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpfechaInicio;
        private System.Windows.Forms.DateTimePicker dtpfechaFin;
        private System.Windows.Forms.Label precio;
    }
}