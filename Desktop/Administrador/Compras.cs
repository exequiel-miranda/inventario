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
    public partial class Compras : Form
    {
        string myformat = "dd/MM/yyyy";
        conexion conexion = new conexion();
        public Compras()
        {
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            GridEmpleados.DataSource = llenar_grid();
           // llenar_ComboPro();
            //conexion.cerrar();
        }


        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDCompras,nombreProducto,cantidad,precio,categoria,marca,fechaCompra FROM Compras";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            return dt;

        }

        /*public void llenar_ComboPro()
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
        */

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtProducto.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()) || string.IsNullOrEmpty(txtPrecio.Text.Trim()) || string.IsNullOrEmpty(txtMarca.Text.Trim()) || string.IsNullOrEmpty(txtCategoria.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");
                if (string.IsNullOrEmpty(txtProducto.Text.Trim()))
                {
                    txtProducto.Focus();
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

                //Hago el procedimiento almacenado por string
                string insertar22 = "Declare @Pnombre varchar(75) select @Pnombre = Producto.nombre from Producto where @CNombreProducto = Producto.nombre IF(@CNombreProducto = @Pnombre) Begin insert into Compras(NombreProducto, cantidad,precio,fechaCompra, categoria, marca) values(@CNombreProducto, @Ccantidad, @Cprecio,@CfechaCompra, @Ccategoria, @Cmarca) update Producto set cantidad = cantidad + @Ccantidad where @CNombreProducto = nombre End Else Begin insert into Compras(NombreProducto, cantidad,precio,fechaCompra, categoria, marca) values(@CNombreProducto, @Ccantidad, @Cprecio,@CfechaCompra, @Ccategoria, @Cmarca) insert into Producto(nombre, categoria, marca,precioUnitario,cantidad, Disponibilidad) values (@CNombreProducto, @Ccategoria,@Cmarca, @Cprecio,@Ccantidad, 'True') End";
                SqlCommand cmd2 = new SqlCommand(insertar22, conexion.conectarbd);
                cmd2.Parameters.AddWithValue("@CNombreProducto", txtProducto.Text);
                cmd2.Parameters.AddWithValue("@Ccantidad", txtCantidad.Text);
                cmd2.Parameters.AddWithValue("@CMarca", txtMarca.Text);
                cmd2.Parameters.AddWithValue("@CPrecio", txtPrecio.Text);
                cmd2.Parameters.AddWithValue("@Precio", txtPrecio.Text);
                cmd2.Parameters.AddWithValue("@CCategoria", txtCategoria.Text);
                //Subir fecha
                DateTime stdate = DateTime.ParseExact(DTPfechaCompra.Text, myformat, null);
                cmd2.Parameters.AddWithValue("@CFechaCompra", stdate);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados con exito");



                /*
                string insertar = "INSERT INTO COMPRAS (Producto, Cantidad, Precio, Proveedor, fechaCompra) Values (@IDProducto,@cantidad,@precio,@IDProveedor,@fechaCompra)";
                SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
                cmd.Parameters.AddWithValue("@IDProducto", txtProducto.Text);
                cmd.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
                cmd.Parameters.AddWithValue("@precio", txtPrecio.Text);
               // cmd.Parameters.AddWithValue("@IDProveedor", cmbProveedor.Text);
                cmd.Parameters.AddWithValue("@fechaCompra", DTPfechaCompra.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados con exito");
                */
                GridEmpleados.DataSource = llenar_grid();
                txtProducto.Clear();
                txtCantidad.Clear();
                txtPrecio.Clear();
                txtCategoria.Clear();
                txtMarca.Clear();
              //  txtProveedor.Clear();
               // txtFechaCompra.Clear();
                //conexion.abrir();
                //conexion.cerrar();
            }
        }

        private void GridEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtProducto.Text = GridEmpleados.CurrentRow.Cells[1].Value.ToString();
                txtCantidad.Text = GridEmpleados.CurrentRow.Cells[2].Value.ToString();
                txtPrecio.Text = GridEmpleados.CurrentRow.Cells[3].Value.ToString();
                txtCategoria.Text = GridEmpleados.CurrentRow.Cells[4].Value.ToString();
                txtMarca.Text = GridEmpleados.CurrentRow.Cells[5].Value.ToString();
                DTPfechaCompra.Text = GridEmpleados.CurrentRow.Cells[6].Value.ToString();

            }
            catch { }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProducto.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()) || string.IsNullOrEmpty(txtPrecio.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                //conexion.abrir();
                string actualizar = "UPDATE COMPRAS set nombreProducto = @nombreProducto, precio = @precio, fechaCompra = @fechaCompra, cantidad = @cantidad, categoria = @categoria, marca = @marca where IDCompras = @IDCompras";
                SqlCommand cmd = new SqlCommand(actualizar, conexion.conectarbd);
                string id = Convert.ToString(GridEmpleados.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@IDCompras", id);
                cmd.Parameters.AddWithValue("@nombreProducto", txtProducto.Text);
                cmd.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
                cmd.Parameters.AddWithValue("@precio", txtPrecio.Text);
                cmd.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                //Subir fecha
                DateTime stdate = DateTime.ParseExact(DTPfechaCompra.Text, myformat, null);
                cmd.Parameters.AddWithValue("@fechaCompra", stdate);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron actualizados con exito");

                GridEmpleados.DataSource = llenar_grid();
                txtProducto.Clear();
                txtCantidad.Clear();
                txtPrecio.Clear();
                txtCategoria.Clear();
                txtMarca.Clear();
                // txtProveedor.Clear();
                //txtFechaCompra.Clear();
                //conexion.abrir();
                //conexion.cerrar();;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminar = "Delete from Compras where IDCompras = @IDCompras";
            SqlCommand cmd = new SqlCommand(eliminar, conexion.conectarbd);
            string id = Convert.ToString(GridEmpleados.CurrentRow.Cells[0].Value);
            cmd.Parameters.AddWithValue("@IDCompras", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos han sido eliminados correctamente");
            GridEmpleados.DataSource = llenar_grid();
            txtProducto.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtCategoria.Clear();
            txtMarca.Clear();
          //  txtProveedor.Clear();
            //txtFechaCompra.Clear();
            //conexion.abrir();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
                {
                    MessageBox.Show("Solo letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
