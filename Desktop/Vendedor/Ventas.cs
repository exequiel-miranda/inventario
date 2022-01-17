using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Desktop.Vendedor
{
    public partial class Ventas : Form
    {
        conexion conexion = new conexion();
        public Ventas()
        {
            InitializeComponent();
        }

        private void Catalogo_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            GridCatalogo.DataSource = llenar_grid();
            
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

        private void GridCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //conexion.abrir();
            try
            {
                lblCodigo.Text = GridCatalogo.CurrentRow.Cells[0].Value.ToString();
                lblNombre.Text = GridCatalogo.CurrentRow.Cells[1].Value.ToString();
                lblPrecio.Text = GridCatalogo.CurrentRow.Cells[2].Value.ToString();
            }
            catch { }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            string insertar = "INSERT INTO FACTURALOCAL (IdCompra, IdProducto, IdEmpleado, Cantidad, Fecha) Values (@IdCompra,@IdProducto,@IdEmpleado,@Cantidad,@Fecha)";
            SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
            cmd.Parameters.AddWithValue("@IdCompra", txtCompra.Text);
            cmd.Parameters.AddWithValue("@IdProducto", lblCodigo.Text);
            cmd.Parameters.AddWithValue("@IdEmpleado", 2);
            cmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmd.Parameters.AddWithValue("@Fecha", fechaingreso.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron agregados con exito");

            GridCatalogo.DataSource = llenar_grid();
            txtCantidad.Clear();

        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {

            lblEncabezado.Text = "Listado de productos";

            DataTable dt = new DataTable();
            String consulta = "select p.IdProducto as [Codigo],p.Nombre as [Producto],p.PrecioU,fl.Cantidad from FacturaLocal as fl inner join Producto as p on fl.IdProducto = p.idProducto where IdCompra = @IdCompra";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            cmd.Parameters.AddWithValue("@IdCompra", txtCompra.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridCatalogo.DataSource = dt;

            btnIngresar.Visible = false;
            label3.Visible = false;
            fechaingreso.Visible = false;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string insertar = "UPDATE FacturaLocal set IdProducto = @IdProducto, IdEmpleado = @IdEmpleado, Cantidad = @Cantidad where IdCompra = @IdCompra";
            SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
            cmd.Parameters.AddWithValue("@IdCompra", txtCompra.Text);
            cmd.Parameters.AddWithValue("@IdProducto", lblCodigo.Text);
            cmd.Parameters.AddWithValue("@IdEmpleado", 2);
            cmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizados con exito");

            GridCatalogo.DataSource = llenar_grid();
            txtCantidad.Clear();
            lblCodigo.Text = "";
            lblNombre.Text = "";
            lblPrecio.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string insertar = "Delete from FacturaLocal where IdCompra = @IdCompra";
            SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
            cmd.Parameters.AddWithValue("@IdCompra", txtCompra.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizados con exito");

            GridCatalogo.DataSource = llenar_grid();
            txtCantidad.Clear();
            lblCodigo.Text = "";
            lblNombre.Text = "";
            lblPrecio.Text = "";
        }
    }
}
