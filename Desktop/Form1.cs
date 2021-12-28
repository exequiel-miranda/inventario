using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class Form1 : Form
    {
        conexion conexion = new conexion();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
            txtContraseña.PasswordChar = '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
            conexion.abrir();
            if (txtUsuario.Text != ""||txtContraseña.Text!="") {
                String consulta = "select Nombre,Correo from Empleado where Nombre= '" + txtUsuario.Text + "' and Correo='" + txtContraseña.Text + "'";
                SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    this.Hide();
                    Desktop.Vendedor.MenuVend frm = new Desktop.Vendedor.MenuVend();
                    frm.Show();
                }

                else if (txtUsuario.Text.Equals("Administrador") && txtContraseña.Text.Equals("admin1234"))
                {
                    this.Hide();
                    Desktop.Administrador.MenuAdm frm = new Desktop.Administrador.MenuAdm();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Datos Incorrectos", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else {
                MessageBox.Show("Campos Vacios", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            conexion.cerrar();
        }
    }
}
