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
        public MenuVend()
        {
            InitializeComponent();
        }

        private void MenuVend_Load(object sender, EventArgs e)
        {

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
            AbrirFormularios(new Desktop.Vendedor.Catalogo());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
