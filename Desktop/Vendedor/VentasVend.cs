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
    public partial class VentasVend : Form
    {
        string myformat = "dd/MM/yyyy hh:mm tt";
        conexion conexion = new conexion();
        public VentasVend()
        {
            InitializeComponent();
        }

        private void Catalogo_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            llenar_ComboPro();
            llenar_ComboCliente();
            GridCatalogo.DataSource = llenar_grid();
            
        }
        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDVentas as N,p.nombre as Producto,c.nombre as Cliente,v.cantidad as Cantidad,fechaVenta as 'Fecha Venta' FROM Ventas as v inner join Producto as p on v.IDProducto = p.IDProducto inner join Clientes as c on v.IDCliente = c.IDCliente where v.vendedor = 'Vendedor'";
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
                    string insertar44 = "Declare @PIDProducto int select @PIDProducto = Producto.IDProducto from Producto where @IDProducto = Producto.IDProducto Declare @PCantidad int select @PCantidad = Producto.cantidad from Producto where @IDProducto = Producto.IDProducto IF(@PIDProducto = @IDProducto AND @Cantidad < @PCantidad) begin insert into Ventas(IDProducto, IDCliente, cantidad, fechaVenta, vendedor) values (@IDProducto, @IDCliente, @Cantidad, @Fecha, 'Vendedor') update Producto set cantidad = cantidad - @Cantidad where @IDProducto = IDProducto end else begin select IDVentas from Ventas end";
                    SqlCommand cmd = new SqlCommand(insertar44, conexion.conectarbd);
                    cmd.Parameters.AddWithValue("@IDProducto", cmbProducto.SelectedValue);
                    cmd.Parameters.AddWithValue("@IDCliente", cmbCliente.SelectedValue);
                    cmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
                    DateTime stdate = DateTime.ParseExact(dtpFechaVenta.Text, myformat, null);
                    cmd.Parameters.AddWithValue("@Fecha", stdate);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Los datos fueron agregados con exito");
                    GridCatalogo.DataSource = llenar_grid();
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
        private void GridCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cmbProducto.Text = GridCatalogo.CurrentRow.Cells[1].Value.ToString();
                cmbCliente.Text = GridCatalogo.CurrentRow.Cells[2].Value.ToString();
                txtCantidad.Text = GridCatalogo.CurrentRow.Cells[3].Value.ToString();
                dtpFechaVenta.Text = GridCatalogo.CurrentRow.Cells[4].Value.ToString();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminar = "Delete from Ventas where IDVentas = @IDVentas update Producto set cantidad = cantidad + @cantidad where nombre = @NombreProducto	";
            SqlCommand cmd = new SqlCommand(eliminar, conexion.conectarbd);
            string id = Convert.ToString(GridCatalogo.CurrentRow.Cells[0].Value);
            string name = Convert.ToString(GridCatalogo.CurrentRow.Cells[1].Value);
            string cant = Convert.ToString(GridCatalogo.CurrentRow.Cells[3].Value);
            cmd.Parameters.AddWithValue("@IDVentas", id);
            cmd.Parameters.AddWithValue("@NombreProducto", name);
            cmd.Parameters.AddWithValue("@cantidad", cant);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos han sido eliminados correctamente");
            GridCatalogo.DataSource = llenar_grid();
            // txtProducto.Clear();
            txtCantidad.Clear();
            //txtPrecio.Clear();
            //txtCategoria.Clear();
            //txtMarca.Clear();
            //  txtProveedor.Clear();
            //txtFechaCompra.Clear();
            //conexion.abrir();
        }


        /*
        private void GridCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //conexion.abrir();
            try
            {
                //lblCodigo.Text = GridCatalogo.CurrentRow.Cells[0].Value.ToString();
                //lblNombre.Text = GridCatalogo.CurrentRow.Cells[1].Value.ToString();
                //lblPrecio.Text = GridCatalogo.CurrentRow.Cells[2].Value.ToString();
            }
            catch { }
        }
        
        private void btnIngresar_Click(object sender, EventArgs e)
        {

            string insertar = "INSERT INTO FACTURALOCAL (IdCompra, IdProducto, IdEmpleado, Cantidad, Fecha) Values (@IdCompra,@IdProducto,@IdEmpleado,@Cantidad,@Fecha)";
            SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
            //cmd.Parameters.AddWithValue("@IdCompra", txtCompra.Text);
            cmd.Parameters.AddWithValue("@IdProducto", lblCodigo.Text);
            cmd.Parameters.AddWithValue("@IdEmpleado", 2);
            //cmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            //cmd.Parameters.AddWithValue("@Fecha", fechaingreso.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron agregados con exito");

            GridCatalogo.DataSource = llenar_grid();
            //txtCantidad.Clear();

        }
        private void btnCarrito_Click(object sender, EventArgs e)
        {

            lblEncabezado.Text = "Listado de productos";

            DataTable dt = new DataTable();
            String consulta = "select p.IdProducto as [Codigo],p.Nombre as [Producto],p.PrecioU,fl.Cantidad from FacturaLocal as fl inner join Producto as p on fl.IdProducto = p.idProducto where IdCompra = @IdCompra";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            //cmd.Parameters.AddWithValue("@IdCompra", txtCompra.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridCatalogo.DataSource = dt;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string insertar = "UPDATE FacturaLocal set IdProducto = @IdProducto, IdEmpleado = @IdEmpleado, Cantidad = @Cantidad where IdCompra = @IdCompra";
            SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
            //cmd.Parameters.AddWithValue("@IdCompra", txtCompra.Text);
            cmd.Parameters.AddWithValue("@IdProducto", lblCodigo.Text);
            cmd.Parameters.AddWithValue("@IdEmpleado", 2);
            //cmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizados con exito");

            GridCatalogo.DataSource = llenar_grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string insertar = "Delete from FacturaLocal where IdCompra = @IdCompra";
            SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizados con exito");

            GridCatalogo.DataSource = llenar_grid();
        }*/
    }
}
