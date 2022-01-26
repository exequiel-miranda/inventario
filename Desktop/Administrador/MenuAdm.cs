using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Administrador
{
    public partial class MenuAdm : Form
    {
        private Button currentBtn;
        private Panel leftBorderBtn;
        Form1 f1 = new Form1();

        //Mover Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public MenuAdm()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 68);
            MenuVertical.Controls.Add(leftBorderBtn);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
        }
        private void AbrirFormularios(object Formhijo)
        {
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);
  
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Contenedor.Controls.Add(fh);
            this.Contenedor.Tag = fh;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            fh.StartPosition = FormStartPosition.CenterScreen;
            fh.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            AbrirFormularios(new Desktop.Administrador.Clientes());
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
            AbrirFormularios(new Desktop.Administrador.Compras());
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            AbrirFormularios(new Desktop.Administrador.Producto());
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            AbrirFormularios(new Desktop.Administrador.cmbFechaVenta());
        }
        private void btnReporte_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color5);
            AbrirFormularios(new Desktop.Administrador.ReporteClientes());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color6);
            AbrirFormularios(new Desktop.Administrador.ReporteCompras());
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color7);
            AbrirFormularios(new Desktop.Administrador.ReporteVentas());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color8);
            AbrirFormularios(new Desktop.Administrador.ReporteProductos());
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }   
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea cerrar sesión?", "Advertencia",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
                f1.ShowDialog();
            }
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172,126,241);
            public static Color color2 = Color.FromArgb(249,118,176);
            public static Color color3 = Color.FromArgb(253,138,114);
            public static Color color4 = Color.FromArgb(95,77,221);
            public static Color color5 = Color.FromArgb(249,88,155);
            public static Color color6 = Color.FromArgb(0, 255, 204);
            public static Color color7 = Color.FromArgb(255, 255, 0);
            public static Color color8 = Color.FromArgb(46, 204, 113);
        }

        private void ActiveButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37,36,81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.Transparent;
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.TextImageRelation = TextImageRelation.Overlay;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);

        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            Reset();
        }
    }
}
