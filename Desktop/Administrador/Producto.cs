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
            String consulta = "SELECT nombre as 'Producto',categoria as 'Categoria',marca as 'Marca',precioUnitario as 'Precio Unitario',cantidad as 'Cantidad',Disponibilidad FROM Producto";
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
            if ( string.IsNullOrEmpty(txtNombre.Text.Trim()) || string.IsNullOrEmpty(txtPrecio.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()) || string.IsNullOrEmpty(txtCategoria.Text.Trim()) || string.IsNullOrEmpty(txtMarca.Text.Trim()))
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
                //Se ingresa a la tabla Productos
                string insertar2 = "INSERT INTO PRODUCTO (nombre, categoria, marca, precioUnitario, cantidad, disponibilidad) Values (@nombre,@categoria, @marca, @precioUnitario, @cantidad, @disponibilidad)";
                SqlCommand cmd2 = new SqlCommand(insertar2, conexion.conectarbd);
               // cmd2.Parameters.AddWithValue("@IDProducto", txtCodigo.Text);
                cmd2.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                cmd2.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd2.Parameters.AddWithValue("@precioUnitario", txtPrecio.Text);
                cmd2.Parameters.AddWithValue("@marca", txtMarca.Text);
                cmd2.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
                if (cbmDis.Text == "Verdadera")
                {
                    cbmDis.Text = "True";
                    cmd2.Parameters.AddWithValue("@disponibilidad", cbmDis.Text);
                }
                else if (cbmDis.Text == "Falsa")
                {
                    cbmDis.Text = "False";
                    cmd2.Parameters.AddWithValue("@disponibilidad", cbmDis.Text);
                }
                else
                {
                    MessageBox.Show("No ha seleccionado Disponibilidad");
                    return;
                }
                //cmd2.Parameters.AddWithValue("@disponibilidad", txtDisponibilidadP.Text);
                cmd2.ExecuteNonQuery();
                

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
//=======
                //cmd.ExecuteNonQuery();

//>>>>>>> Stashed changes

                MessageBox.Show("Los datos fueron agregados con exito");

                GridProductos.DataSource = llenar_grid();
                //txtCodigo.Clear();
                txtNombre.Clear();
                txtCantidad.Clear();
                txtMarca.Clear();
                txtPrecio.Clear();
                cbmDis.ResetText();
                //txtDisponibilidadP.Clear();
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
                cbmDis.Text = GridProductos.CurrentRow.Cells[6].Value.ToString();
                if (cbmDis.Text == "True")
                {
                    cbmDis.Text = "Verdadera";
                }
                else
                {
                    cbmDis.Text = "Falso";
                }
                //txtDisponibilidadP.Text = GridProductos.CurrentRow.Cells[6].Value.ToString();
            }
            catch { }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbmDis.Text.Trim()) || string.IsNullOrEmpty(txtNombre.Text.Trim()) || string.IsNullOrEmpty(txtPrecio.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                //Se ingresa a la tabla Productos
                string actualizar = "UPDATE PRODUCTO SET nombre = @nombre, categoria = @categoria,  precioUnitario = @precioUnitario, cantidad = @cantidad, disponibilidad = @disponibilidad where IDProducto = @IDProducto";
                SqlCommand cmd2 = new SqlCommand(actualizar, conexion.conectarbd);
                string id = Convert.ToString(GridProductos.CurrentRow.Cells[0].Value);
                cmd2.Parameters.AddWithValue("@IDProducto", id);
                cmd2.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                cmd2.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd2.Parameters.AddWithValue("@precioUnitario", txtPrecio.Text);
                cmd2.Parameters.AddWithValue("@marca", txtMarca.Text);
                cmd2.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
                //cmd2.Parameters.AddWithValue("@proveedorId", cmbProveedor.Text);
                if (cbmDis.Text == "Verdadera")
                {
                    cbmDis.Text = "True";
                    cmd2.Parameters.AddWithValue("@disponibilidad", cbmDis.Text);
                }
                else if (cbmDis.Text == "Falsa")
                {
                    cbmDis.Text = "False";
                    cmd2.Parameters.AddWithValue("@disponibilidad", cbmDis.Text);
                }
                else
                {
                    MessageBox.Show("No ha seleccionado Disponibilidad");
                    return;
                }

                cmd2.ExecuteNonQuery();

                /*
                //Se ingresa a la tabla Almacen
                string actualizar2 = "UPDATE Almacen set  IdProveedor = @IdProveedor, Cantidad = @Cantidad, FechaIngreso = @FechaIngreso where IdProducto = @IdProducto";
                SqlCommand cmd = new SqlCommand(actualizar2, conexion.conectarbd);
                //cmd.Parameters.AddWithValue("@IdProducto", txtCodigo.Text);
              //  cmd.Parameters.AddWithValue("@IdProveedor", cmbProveedor.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
                //cmd.Parameters.AddWithValue("@FechaIngreso", fechaingreso.Text);
                cmd.ExecuteNonQuery();*/


                MessageBox.Show("Los datos fueron actualizados con exito");

                GridProductos.DataSource = llenar_grid();
                txtNombre.Clear();
                txtCantidad.Clear();
                txtMarca.Clear();
                txtPrecio.Clear();
                //txtDisponibilidadP.Clear();
                txtCategoria.Clear();
                //txtCodigo.Clear();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminar = "Delete from Producto where IDProducto = @IDProducto";
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
            //txtDisponibilidadP.Clear();
            txtCategoria.Clear();
            //txtCodigo.Clear();
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
    }
}
