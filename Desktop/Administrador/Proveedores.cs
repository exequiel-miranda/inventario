﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Desktop.Administrador
{
    public partial class Proveedores : Form
    {
        conexion conexion = new conexion();
        public Proveedores()
        {
            InitializeComponent();
        }

       
        private void Proveedores_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            GridProveedor.DataSource = llenar_grid();
            //conexion.cerrar();
        }

        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDProveedor as N,nombre as Nombre,correo as Correo,telefono as Telefono FROM Proveedor";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            return dt;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnombre.Text.Trim()) || string.IsNullOrEmpty(txtCorreo.Text.Trim()) || string.IsNullOrEmpty(txtTelefono.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {

                string insertar = "INSERT INTO Proveedor (Nombre, Direccion, Contacto, Telefono) Values (@Nombre,@Direccion,@Contacto,@Telefono)";
                SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
                cmd.Parameters.AddWithValue("@Nombre", txtnombre.Text);
                cmd.Parameters.AddWithValue("@Contacto", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados con exito");

                GridProveedor.DataSource = llenar_grid();
                txtnombre.Clear();
                txtCorreo.Clear();
                txtTelefono.Clear();
                //conexion.abrir();
                //conexion.cerrar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnombre.Text.Trim()) ||  string.IsNullOrEmpty(txtCorreo.Text.Trim()) || string.IsNullOrEmpty(txtTelefono.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                //conexion.abrir();
                string actualizar = "UPDATE Proveedor set Nombre = @Nombre, Direccion = @Direccion, Contacto = @Contacto, Telefono = @Telefono where IdProveedor = @IdProveedor";
                SqlCommand cmd = new SqlCommand(actualizar, conexion.conectarbd);
                string id = Convert.ToString(GridProveedor.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@IdProveedor", id);
                cmd.Parameters.AddWithValue("@Nombre", txtnombre.Text);
                cmd.Parameters.AddWithValue("@Contacto", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Los datos fueron actualizados con exito");
                GridProveedor.DataSource = llenar_grid();
                txtnombre.Clear();
  
                txtCorreo.Clear();
                txtTelefono.Clear();
                //conexion.abrir();
                //conexion.cerrar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminar = "Delete from Proveedor where IdProveedor = @IdProveedor";
            SqlCommand cmd = new SqlCommand(eliminar, conexion.conectarbd);
            string id = Convert.ToString(GridProveedor.CurrentRow.Cells[0].Value);
            cmd.Parameters.AddWithValue("@IdProveedor", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos han sido eliminados correctamente");
            GridProveedor.DataSource = llenar_grid();
            txtnombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            //conexion.abrir();
        }

        private void GridProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtnombre.Text = GridProveedor.CurrentRow.Cells[1].Value.ToString();
                txtCorreo.Text = GridProveedor.CurrentRow.Cells[2].Value.ToString();
                txtTelefono.Text = GridProveedor.CurrentRow.Cells[3].Value.ToString();
            }
            catch { }
        }
    }
}
