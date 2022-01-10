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

namespace Desktop.Administrador
{
    public partial class Producto : Form
    {
        conexion conexion = new conexion();
        public Producto()
        {
            InitializeComponent();
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            conexion.abrir();
           // llenar_ComboPro();
            //llenar_ComboCat();
            GridProductos.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDProducto,nombre,categoria,marca,precioUnitario,cantidad,Disponibilidad FROM Producto";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            return dt;
        }

        /*
        public void llenar_ComboPro()
        {
            //conexion.abrir(); 
            DataTable dt = new DataTable();
            String consulta = "SELECT IDProveedor,nombre FROM Proveedor";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            cmbProveedor.DataSource = dt;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "IdProveedor"; //identificador
            cmbProveedor.SelectedIndex = 0;
        }
        
        
        public void llenar_ComboCat()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "Select IDProducto,Categoria from Producto";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            cbCategoria.DataSource = dt;
            cbCategoria.DisplayMember = "Categoria";
            cbCategoria.ValueMember = "IdProducto"; //identificador
            cbCategoria.SelectedIndex = 0;
        }
        */

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text.Trim()) || string.IsNullOrEmpty(txtNombre.Text.Trim()) || string.IsNullOrEmpty(txtPrecio.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {

             


                /*
                //Se ingresa a la tabla Productos
                string insertar2 = "INSERT INTO PRODUCTO (nombre, categoria, marca, precioUnitario, cantidad, disponibilidad, proveedorID) Values (@nombre,@categoria, @marca, @precioUnitario, @cantidad, @disponibilidad, @proveedorID)";
                SqlCommand cmd2 = new SqlCommand(insertar2, conexion.conectarbd);
               // cmd2.Parameters.AddWithValue("@IDProducto", txtCodigo.Text);
                cmd2.Parameters.AddWithValue("@categoria", cbCategoria.SelectedValue.ToString());
                cmd2.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd2.Parameters.AddWithValue("@precioUnitario", txtPrecio.Text);
                cmd2.Parameters.AddWithValue("@marca", txtMarca.Text);
                cmd2.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
                cmd2.Parameters.AddWithValue("@proveedorId", Convert.ToInt32(cmbProveedor.SelectedItem).ToString());
                cmd2.Parameters.AddWithValue("@disponibilidad", txtDisponibilidadP.Text);
                cmd2.ExecuteNonQuery();
                */

                /*
                //Se ingresa a la tabla Almacen
                string insertar = "INSERT INTO ALMACEN (IdProducto,IdProveedor, Cantidad, FechaIngreso) Values (@IdProducto,@IdProveedor,@Cantidad,@FechaIngreso)";
                SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
                cmd.Parameters.AddWithValue("@IdProducto", txtCodigo.Text);
                //cmd.Parameters.AddWithValue("@IdProveedor", cmbProveedor.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
                //cmd.Parameters.AddWithValue("@FechaIngreso", fechaingreso.Text);
<<<<<<< Updated upstream
                cmd.ExecuteNonQuery();
                */
=======
                cmd.ExecuteNonQuery();*/

>>>>>>> Stashed changes

                MessageBox.Show("Los datos fueron agregados con exito");

                GridProductos.DataSource = llenar_grid();
                txtCodigo.Clear();
                txtNombre.Clear();
                txtCantidad.Clear();
                txtMarca.Clear();
                txtPrecio.Clear();
                txtDisponibilidadP.Clear();
                txtCategoria.Clear();
            }
        }


        private void GridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //conexion.abrir();
            try
            {
                txtCodigo.Text = GridProductos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = GridProductos.CurrentRow.Cells[1].Value.ToString();
                txtCategoria.Text = GridProductos.CurrentRow.Cells[2].Value.ToString();
                txtMarca.Text = GridProductos.CurrentRow.Cells[3].Value.ToString();
                txtPrecio.Text = GridProductos.CurrentRow.Cells[4].Value.ToString();
                txtCantidad.Text = GridProductos.CurrentRow.Cells[5].Value.ToString();
                txtDisponibilidadP.Text = GridProductos.CurrentRow.Cells[6].Value.ToString();
            }
            catch { }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text.Trim()) || string.IsNullOrEmpty(txtNombre.Text.Trim()) || string.IsNullOrEmpty(txtPrecio.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                //Se ingresa a la tabla Productos
                string actualizar = "UPDATE Producto set  IdCategoria = @IdCategoria, Nombre = @Nombre, PrecioU = @Precio where IdProducto = @IdProducto ";
                SqlCommand cmd2 = new SqlCommand(actualizar, conexion.conectarbd);
                cmd2.Parameters.AddWithValue("@categoria", cbCategoria.SelectedValue.ToString());
                cmd2.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd2.Parameters.AddWithValue("@precioUnitario", txtPrecio.Text);
                cmd2.Parameters.AddWithValue("@marca", txtMarca.Text);
                cmd2.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
                cmd2.Parameters.AddWithValue("@proveedorId", cmbProveedor.Text);
                cmd2.Parameters.AddWithValue("@disponibilidad", txtDisponibilidadP.Text);
                cmd2.ExecuteNonQuery();


                //Se ingresa a la tabla Almacen
                string actualizar2 = "UPDATE Almacen set  IdProveedor = @IdProveedor, Cantidad = @Cantidad, FechaIngreso = @FechaIngreso where IdProducto = @IdProducto";
                SqlCommand cmd = new SqlCommand(actualizar2, conexion.conectarbd);
                cmd.Parameters.AddWithValue("@IdProducto", txtCodigo.Text);
              //  cmd.Parameters.AddWithValue("@IdProveedor", cmbProveedor.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
                //cmd.Parameters.AddWithValue("@FechaIngreso", fechaingreso.Text);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Los datos fueron actualizados con exito");

                GridProductos.DataSource = llenar_grid();
                txtNombre.Clear();
                txtPrecio.Clear();
                txtCantidad.Clear();
                txtCodigo.Clear();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminar = "Delete from Producto where IdProducto = @IdProducto";
            SqlCommand cmd = new SqlCommand(eliminar, conexion.conectarbd);
            string id = Convert.ToString(GridProductos.CurrentRow.Cells[0].Value);
            cmd.Parameters.AddWithValue("@IdProducto", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos han sido eliminados correctamente");

            GridProductos.DataSource = llenar_grid();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtCodigo.Clear();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
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

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
