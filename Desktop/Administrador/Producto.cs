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
            GridProductos.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDProducto as 'N', nombre as 'Producto',categoria as 'Categoria',marca as 'Marca',precioUnitario as 'Precio Unitario',cantidad as 'Cantidad',Disponibilidad FROM Producto  where categoria is not null";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            return dt;
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || string.IsNullOrEmpty(txtPrecio.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()) || string.IsNullOrEmpty(txtCategoria.Text.Trim()) || string.IsNullOrEmpty(txtMarca.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");
                if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    txtNombre.Focus();
                }
                else if (string.IsNullOrEmpty(txtCantidad.Text.Trim()))
                {
                    txtCantidad.Focus();
                }
                else if (string.IsNullOrEmpty(txtPrecio.Text.Trim()))
                {
                    txtPrecio.Focus();
                }
                else if (string.IsNullOrEmpty(txtMarca.Text.Trim()))
                {
                    txtMarca.Focus();
                }
                else
                {
                    txtCategoria.Focus();
                }
                return;
            }

            else
            {

                //-----------------------------------------------------------------
                //ok aqui vemos si la cantidad es mayor a cero y la leemos
                string validacion1 = "Declare @CantidadVar int select @CantidadVar =  @Cantidad select @CantidadVar";
                SqlCommand cmd2323 = new SqlCommand(validacion1, conexion.conectarbd);
                cmd2323.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
                cmd2323.ExecuteNonQuery();
                int cantidad = Convert.ToInt32(cmd2323.ExecuteScalar());
                //-----------------------------------------------------------------


                //-----------------------------------------------------------------
                //ok aqui vemos si el precio unitario es mayor a cero y la leemos
                string validacion2 = "Declare @precioUnitarioVar decimal(9,2) select @precioUnitarioVar =  @precioUnitario select @precioUnitario";
                SqlCommand cmd3434 = new SqlCommand(validacion2, conexion.conectarbd);
                cmd3434.Parameters.AddWithValue("@precioUnitario", txtPrecio.Text);
                cmd3434.ExecuteNonQuery();
                decimal precioUnitario = Convert.ToDecimal(cmd3434.ExecuteScalar());
                //-----------------------------------------------------------------


                if (precioUnitario > 0 && cantidad > 0)
                {
                    string insertar2 = "INSERT INTO PRODUCTO (nombre, categoria, marca, precioUnitario, cantidad, disponibilidad) Values (@nombre,@categoria, @marca, @precioUnitario, @cantidad, 'True')";
                    SqlCommand cmd3 = new SqlCommand(insertar2, conexion.conectarbd);
                    // cmd2.Parameters.AddWithValue("@IDProducto", txtCodigo.Text);
                    cmd3.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                    cmd3.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd3.Parameters.AddWithValue("@precioUnitario", txtPrecio.Text);
                    cmd3.Parameters.AddWithValue("@marca", txtMarca.Text);
                    cmd3.Parameters.AddWithValue("@cantidad", txtCantidad.Text);

                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Los datos fueron agregados con exito");
                }
                else
                {
                    MessageBox.Show("ingrese un numero mayor de cero en Cantidad o Precio");
                }

                GridProductos.DataSource = llenar_grid();
                txtNombre.Clear();
                txtCantidad.Clear();
                txtMarca.Clear();
                txtPrecio.Clear();
                txtCategoria.Clear();
            }
        }

        private void GridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //conexion.abrir();
            try
            {
                //txtCodigo.Text = GridProductos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = GridProductos.CurrentRow.Cells[1].Value.ToString();
                txtCategoria.Text = GridProductos.CurrentRow.Cells[2].Value.ToString();
                txtMarca.Text = GridProductos.CurrentRow.Cells[3].Value.ToString();
                txtPrecio.Text = GridProductos.CurrentRow.Cells[4].Value.ToString();
                txtCantidad.Text = GridProductos.CurrentRow.Cells[5].Value.ToString();
            }
            catch { }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || string.IsNullOrEmpty(txtPrecio.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                if (MessageBox.Show("¿Esta seguro que desea modificar este registro?", "Advertencia",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //Se ingresa a la tabla Productos
                    string actualizar = "UPDATE PRODUCTO SET nombre = @nombre, categoria = @categoria, marca = @marca, precioUnitario = @precioUnitario, cantidad = @cantidad, disponibilidad = @disponibilidad where IDProducto = @IDProducto and marca = @marca";
                    SqlCommand cmd2 = new SqlCommand(actualizar, conexion.conectarbd);
                    string id = Convert.ToString(GridProductos.CurrentRow.Cells[0].Value);
                    cmd2.Parameters.AddWithValue("@IDProducto", id);
                    string disponibilidadCheque = Convert.ToString(GridProductos.CurrentRow.Cells[6].Value);
                    cmd2.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                    cmd2.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd2.Parameters.AddWithValue("@precioUnitario", txtPrecio.Text);
                    cmd2.Parameters.AddWithValue("@marca", txtMarca.Text);
                    cmd2.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
                    cmd2.Parameters.AddWithValue("@disponibilidad", disponibilidadCheque);

                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Los datos fueron actualizados con exito");

                    GridProductos.DataSource = llenar_grid();
                    txtNombre.Clear();
                    txtCantidad.Clear();
                    txtMarca.Clear();
                    txtPrecio.Clear();
                    txtCategoria.Clear();
                }
                else
                {

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || string.IsNullOrEmpty(txtPrecio.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                if (MessageBox.Show("¿Esta seguro que desea eliminar este registro?", "Advertencia",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string eliminar = "UPDATE PRODUCTO SET  categoria = null, cantidad = 0 where IDProducto = @IDProducto";
                    SqlCommand cmd = new SqlCommand(eliminar, conexion.conectarbd);
                    string id = Convert.ToString(GridProductos.CurrentRow.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@IdProducto", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Los datos han sido eliminados correctamente");

                    GridProductos.DataSource = llenar_grid();
                    txtNombre.Clear();
                    txtCantidad.Clear();
                    txtMarca.Clear();
                    txtPrecio.Clear();
                    txtCategoria.Clear();
                }
                else
                {

                }
            }
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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                MessageBox.Show("Sólo números acompañados de punto decimal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                MessageBox.Show("Solamente 2 números decimales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
                }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombre.Text);
            txtNombre.SelectionStart = txtNombre.Text.Length;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
