using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Vendedor
{
    public partial class MenuVend : Form
    {
        Form1 f1 = new Form1();
        public MenuVend()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 68)
            {
                MenuVertical.Width = 217;
            }
            else
            {
                MenuVertical.Width = 68;
            }
        }
        private void AbrirFormularios(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new Desktop.Administrador.Clientes());
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new Desktop.Administrador.Producto());
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new Desktop.Vendedor.Ventas());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
                if (WindowState == FormWindowState.Normal)
                    WindowState = FormWindowState.Minimized;
                else if (WindowState == FormWindowState.Maximized)
                    WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea cerrar sesión?", "Warning",
   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
            f1.ShowDialog();
        }
    }
}
