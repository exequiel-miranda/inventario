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
    public partial class cmbFechaVenta : Form
    {
        string myformat = "dd/MM/yyyy";
        conexion conexion = new conexion();

        public cmbFechaVenta()
        {
            InitializeComponent();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            llenar_ComboPro();
            GridCategoria.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDVentas as N,p.nombre as Producto,c.nombre as Cliente,v.cantidad as Cantidad,fechaVenta as 'Fecha Venta' FROM Ventas as v inner join Producto as p on v.IDProducto = p.IDProducto inner join Clientes as c on v.IDCliente = c.IDCliente";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            return dt;
        }

        public void llenar_ComboPro()
        {
            //conexion.abrir(); 
            DataTable dt = new DataTable();
            String consulta = "select IDProducto, nombre from Producto ";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            cmbProducto.DataSource = dt;
            cmbProducto.DisplayMember = "nombre";
            cmbProducto.ValueMember = "IDProducto"; //identificador
            //cmbProducto.SelectedIndex = 0;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        { 
            if (string.IsNullOrEmpty(cmbProducto.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                string insertar = "Declare @PIDProducto int select @PIDProducto = Producto.IDProducto from Producto where @IDProducto = Producto.IDProducto IF(@PIDProducto = @IDProducto) begin insert into Ventas(IDProducto, IDCliente, cantidad, fechaVenta) values (@IDProducto, 1, @Cantidad, @Fecha) update Producto set cantidad = cantidad - @Cantidad where @IDProducto = IDProducto end else begin select IDProducto from Ventas end ";
                SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
                cmd.Parameters.AddWithValue("@IDProducto", cmbProducto.SelectedValue);
                cmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
                //Subir fecha
                DateTime stdate = DateTime.ParseExact(dtpFechaVenta.Text, myformat, null);
                cmd.Parameters.AddWithValue("@Fecha", stdate);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados con exito");

                GridCategoria.DataSource = llenar_grid();
                //cmbProducto.Clear();


                /*
                string insertar = "INSERT INTO CATEGORIA (Nombre) Values (@Nombre)";
                SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
                cmd.Parameters.AddWithValue("@Nombre", txtProducto.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados con exito");

                GridCategoria.DataSource = llenar_grid();
                txtProducto.Clear();
                */
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {/*
            if (string.IsNullOrEmpty(txtProducto.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                //conexion.abrir();
                string actualizar = "UPDATE Categoria set Nombre = @Nombre where IdCategoria = @IdCategoria";
                SqlCommand cmd = new SqlCommand(actualizar, conexion.conectarbd);
                string id = Convert.ToString(GridCategoria.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@IdCategoria", id);
                cmd.Parameters.AddWithValue("@Nombre", txtProducto.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Los datos fueron actualizados con exito");
                GridCategoria.DataSource = llenar_grid();
               // cmbProducto.Clear();
            }*/
        }

        private void GridCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cmbProducto.Text = GridCategoria.CurrentRow.Cells[1].Value.ToString();
                txtCliente.Text = GridCategoria.CurrentRow.Cells[2].Value.ToString();
                txtCantidad.Text = GridCategoria.CurrentRow.Cells[3].Value.ToString();
                dtpFechaVenta.Text = GridCategoria.CurrentRow.Cells[4].Value.ToString();
            }
            catch { }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }


}
