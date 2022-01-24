﻿using Microsoft.Data.SqlClient;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void botonesSalir_Click(object sender, EventArgs e)
        {
            conexion.abrir();
            if (txtUsuario.Text != "" || txtContraseña.Text != "")
            {
                String consulta = "select nivel from Usuarios where usuario = @usuario and password = @password";
                SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
                //SqlDataReader dr = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@password", txtContraseña.Text);
                cmd.ExecuteNonQuery();
                string nivel = (string)cmd.ExecuteScalar();
                if (nivel == "Administrador")
                {
                    this.Hide();
                    Desktop.Administrador.MenuAdm frm = new Desktop.Administrador.MenuAdm();
                    frm.Show();
                }

                else if (nivel == "Vendedor")
                {
                    this.Hide();
                    Desktop.Vendedor.MenuVend frm = new Desktop.Vendedor.MenuVend();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña inválidos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContraseña.Clear();
                }

            }
            else
            {
                MessageBox.Show("Campos Vacios", "Campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            conexion.cerrar();
        }

        private void textBoxTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                botonesSalir_Click(sender, new KeyEventArgs(Keys.Enter));
            }
        }

        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = txtContraseña.PasswordChar == '\0' ? '*' : '\0';

            /*if (txtContraseña.PasswordChar == '\0')
            {
                //this.pictureBox2.Image = System.Drawing.Image.FromFile(@"C:\Users\ruben\Desktop\inventario\Desktop\Resources\hidepassword.png", true);
            }
            else 
            {
               // this.pictureBox2.Image = System.Drawing.Image.FromFile(@"C:\Users\ruben\Desktop\inventario\Desktop\Resources\showpassword.png", true);
            }*/
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                botonesSalir_Click(sender, new KeyEventArgs(Keys.Enter));
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtUsuario.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtUsuario.Text);
            txtUsuario.SelectionStart = txtUsuario.Text.Length;
        }
    }
}
