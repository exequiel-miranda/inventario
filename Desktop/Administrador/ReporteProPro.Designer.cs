
namespace Desktop.Administrador
{
    partial class ReporteProPro
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
            this.btnCombo = new System.Windows.Forms.ComboBox();
            this.GridReporte = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCombo
            // 
            this.btnCombo.DisplayMember = "4";
            this.btnCombo.FormattingEnabled = true;
            this.btnCombo.Location = new System.Drawing.Point(439, 146);
            this.btnCombo.Name = "btnCombo";
            this.btnCombo.Size = new System.Drawing.Size(121, 23);
            this.btnCombo.TabIndex = 74;
            this.btnCombo.ValueMember = "4";
            this.btnCombo.SelectedValueChanged += new System.EventHandler(this.btnCombo_SelectedValueChanged);
            // 
            // GridReporte
            // 
            this.GridReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridReporte.Location = new System.Drawing.Point(129, 219);
            this.GridReporte.Name = "GridReporte";
            this.GridReporte.RowTemplate.Height = 25;
            this.GridReporte.Size = new System.Drawing.Size(713, 320);
            this.GridReporte.TabIndex = 73;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Image = global::Desktop.Properties.Resources.ic_action_copy;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(693, 561);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(149, 34);
            this.btnEliminar.TabIndex = 72;
            this.btnEliminar.Text = "PDF";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(129, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(251, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(523, 44);
            this.label4.TabIndex = 70;
            this.label4.Text = "Reportes de Productos Proveedor";
            // 
            // ReporteProPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(971, 652);
            this.Controls.Add(this.btnCombo);
            this.Controls.Add(this.GridReporte);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReporteProPro";
            this.Text = "ReporteProPro";
            ((System.ComponentModel.ISupportInitialize)(this.GridReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox btnCombo;
        private System.Windows.Forms.DataGridView GridReporte;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}