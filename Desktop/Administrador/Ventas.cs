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
        string myformat = "dd/MM/yyyy hh:mm tt";
        conexion conexion = new conexion();

        public cmbFechaVenta()
        {
            InitializeComponent();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            llenar_ComboPro();
            llenar_ComboCliente();
            GridCategoria.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDVentas as N,p.nombre as Producto,c.nombre as Cliente,v.cantidad as Cantidad,fechaVenta as 'Fecha Venta', vendedor as 'Usuario' FROM Ventas as v inner join Producto as p on v.IDProducto = p.IDProducto inner join Clientes as c on v.IDCliente = c.IDCliente";
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
            String consulta = "select IDProducto, nombre from Producto where Disponibilidad = 'True'";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            cmbProducto.DataSource = dt;
            cmbProducto.DisplayMember = "nombre";
            cmbProducto.ValueMember = "IDProducto"; //identificador
            //cmbProducto.SelectedIndex = 0;
        }

        public void llenar_ComboCliente()
        {
            //conexion.abrir(); 
            DataTable dt = new DataTable();
            String consulta = "select IDCliente, nombre from Clientes";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            cmbCliente.DataSource = dt;
            cmbCliente.DisplayMember = "nombre";
            cmbCliente.ValueMember = "IDCliente"; //identificador
            //cmbProducto.SelectedIndex = 0;
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        { 
            if (string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");
                txtCantidad.Focus();
                return;
            }

            else
            {
                //-----------------------------------------------------------------
                //aqui se asigna el valor a la variable si es menor o mayor
                string validacion1 = "Declare @CantidadP int select @CantidadP = Producto.cantidad from Producto where @IDProducto = Producto.IDProducto IF(@Cantidad <= @CantidadP) begin update Producto set sepuedeono='sepuede' where @IDProducto = IDProducto end else begin update Producto set sepuedeono='nosepuede' where @IDProducto = IDProducto end";
                SqlCommand cmd3 = new SqlCommand(validacion1, conexion.conectarbd);
                cmd3.Parameters.AddWithValue("@IDProducto", cmbProducto.SelectedValue);
                cmd3.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
                cmd3.ExecuteNonQuery();

                //-----------------------------------------------------------------
                //ok aqui ya me muestra como esta la variable
                string validacion2 = "select sepuedeono from Producto where @IDProducto = Producto.IDProducto ";
                SqlCommand cmd2 = new SqlCommand(validacion2, conexion.conectarbd);
                cmd2.Parameters.AddWithValue("@IDProducto", cmbProducto.SelectedValue);
                cmd2.ExecuteNonQuery();

                string sepuedeonosepuede = (string)cmd2.ExecuteScalar();
                //-----------------------------------------------------------------

                if (sepuedeonosepuede == "sepuede")
                {
                    string insertar44 = "Declare @PIDProducto int select @PIDProducto = Producto.IDProducto from Producto where @IDProducto = Producto.IDProducto Declare @PCantidad int select @PCantidad = Producto.cantidad from Producto where @IDProducto = Producto.IDProducto IF(@PIDProducto = @IDProducto AND @Cantidad < @PCantidad) begin insert into Ventas(IDProducto, IDCliente, cantidad, fechaVenta, vendedor) values (@IDProducto, @IDCliente, @Cantidad, @Fecha, 'Administrador') update Producto set cantidad = cantidad - @Cantidad where @IDProducto = IDProducto end else begin select IDVentas from Ventas end";
                    SqlCommand cmd = new SqlCommand(insertar44, conexion.conectarbd);
                    cmd.Parameters.AddWithValue("@IDProducto", cmbProducto.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDCliente", cmbCliente.SelectedValue);
                    cmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
                    DateTime stdate = DateTime.ParseExact(dtpFechaVenta.Text, myformat, null);
                    cmd.Parameters.AddWithValue("@Fecha", stdate);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Los datos fueron agregados con exito");
                    GridCategoria.DataSource = llenar_grid();
                }

                else
                {
                    MessageBox.Show("No hay tanto stock de este producto");
                }


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
        {
            if (string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {

                //-----------------------------------------------------------------
                //aqui se asigna el valor a la variable si es menor o mayor
                string validacion1 = "Declare @CantidadP int select @CantidadP = Producto.cantidad from Producto where @IDProducto = Producto.IDProducto IF(@Cantidad <= @CantidadP) begin update Producto set sepuedeono='sepuede' where @IDProducto = IDProducto end else begin update Producto set sepuedeono='nosepuede' where @IDProducto = IDProducto end";
                SqlCommand cmd3 = new SqlCommand(validacion1, conexion.conectarbd);
                cmd3.Parameters.AddWithValue("@IDProducto", cmbProducto.SelectedValue);
                cmd3.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
                cmd3.ExecuteNonQuery();

                //-----------------------------------------------------------------
                //ok aqui ya me muestra como esta la variable
                string validacion2 = "select sepuedeono from Producto where @IDProducto = Producto.IDProducto ";
                SqlCommand cmd2 = new SqlCommand(validacion2, conexion.conectarbd);
                cmd2.Parameters.AddWithValue("@IDProducto", cmbProducto.SelectedValue);
                cmd2.ExecuteNonQuery();

                string sepuedeonosepuede = (string)cmd2.ExecuteScalar();
                //-----------------------------------------------------------------


                if (sepuedeonosepuede == "sepuede")
                {

                    //conexion.abrir();
                    string actualizar = "Declare @cantYa int Declare @CantTotal int select @cantYa = Ventas.cantidad  from Ventas where @IDVentas = Ventas.IDVentas IF(@cantYa > @cantidad) begin  select @CantTotal = @cantYa - @Cantidad  update Producto set cantidad = cantidad + @CantTotal where Producto.nombre = @nombreProducto  update Ventas set IDProducto = @IDProducto, IDCliente = @IDCliente, cantidad = @Cantidad,   fechaVenta = @FechaVenta where IDVentas = @IDVentas  end else begin  select @CantTotal = @Cantidad - @cantYa  update Producto set cantidad = cantidad - @CantTotal where Producto.nombre = @nombreProducto  update Ventas set IDProducto = @IDProducto, IDCliente = @IDCliente, cantidad = @Cantidad,  fechaVenta = @FechaVenta where IDVentas = @IDVentas end";
                    SqlCommand cmd7 = new SqlCommand(actualizar, conexion.conectarbd);
                    string id = Convert.ToString(GridCategoria.CurrentRow.Cells[0].Value);
                    string name = Convert.ToString(GridCategoria.CurrentRow.Cells[1].Value);
                    cmd7.Parameters.AddWithValue("@IDVentas", id);
                    cmd7.Parameters.AddWithValue("@nombreProducto", name);
                    cmd7.Parameters.AddWithValue("@IDProducto", cmbProducto.SelectedValue);
                    cmd7.Parameters.AddWithValue("@IDCliente", cmbCliente.SelectedValue);
                    cmd7.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);

                    //Subir fecha
                    DateTime stdate = DateTime.ParseExact(dtpFechaVenta.Text, myformat, null);
                    cmd7.Parameters.AddWithValue("@FechaVenta", stdate);
                    cmd7.ExecuteNonQuery();
                    MessageBox.Show("Los datos fueron actualizados con exito");
                    GridCategoria.DataSource = llenar_grid();
                }
                else
                {
                    MessageBox.Show("No hay tanto stock de este producto");
                }

            }

            /*
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
                cmbCliente.Text = GridCategoria.CurrentRow.Cells[2].Value.ToString();
                txtCantidad.Text = GridCategoria.CurrentRow.Cells[3].Value.ToString();
                dtpFechaVenta.Text = GridCategoria.CurrentRow.Cells[4].Value.ToString();
            }
            catch { }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminar = "Delete from Ventas where IDVentas = @IDVentas update Producto set cantidad = cantidad + @cantidad where nombre = @NombreProducto	";
            SqlCommand cmd = new SqlCommand(eliminar, conexion.conectarbd);
            string id = Convert.ToString(GridCategoria.CurrentRow.Cells[0].Value);
            string name = Convert.ToString(GridCategoria.CurrentRow.Cells[1].Value);
            string cant = Convert.ToString(GridCategoria.CurrentRow.Cells[3].Value);
            cmd.Parameters.AddWithValue("@IDVentas", id);
            cmd.Parameters.AddWithValue("@NombreProducto", name);
            cmd.Parameters.AddWithValue("@cantidad", cant);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos han sido eliminados correctamente");
            GridCategoria.DataSource = llenar_grid();
           // txtProducto.Clear();
            txtCantidad.Clear();
            //txtPrecio.Clear();
            //txtCategoria.Clear();
            //txtMarca.Clear();
            //  txtProveedor.Clear();
            //txtFechaCompra.Clear();
            //conexion.abrir();
        }
    }
}
