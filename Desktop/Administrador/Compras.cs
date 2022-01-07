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
        conexion conexion = new conexion();
        public Compras()
        {
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            GridEmpleados.DataSource = llenar_grid();
            llenar_ComboPro();
            //conexion.cerrar();
        }


        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDCompras as N,p.nombre as Producto,c.cantidad as Cantidad,precio as Precio,pro.nombre as Proveedor,fechaCompra as 'Fecha Compra' FROM Compras as c inner join Producto as p on c.IDProducto = p.IDProducto inner join Proveedor as pro on c.IDProveedor = pro.IDProveedor ";
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

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtProducto.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                string insertar = "INSERT INTO Empleado (Nombre, DUI, Correo, Telefono, Sexo) Values (@Nombre,@DUI,@Correo,@Telefono,@Sexo)";
                SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
                cmd.Parameters.AddWithValue("@Nombre", txtProducto.Text);
                cmd.Parameters.AddWithValue("@DUI", txtCantidad.Text);
                cmd.Parameters.AddWithValue("@Correo", txtPrecio.Text);
              //  cmd.Parameters.AddWithValue("@Telefono", txtProveedor.Text);
                //cmd.Parameters.AddWithValue("@Sexo", txtFechaCompra.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados con exito");

                GridEmpleados.DataSource = llenar_grid();
                txtProducto.Clear();
                txtCantidad.Clear();
                txtPrecio.Clear();
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
               // txtProveedor.Text = GridEmpleados.CurrentRow.Cells[4].Value.ToString();
                //txtFechaCompra.Text = GridEmpleados.CurrentRow.Cells[5].Value.ToString();
                DTPfechaCompra.Text = GridEmpleados.CurrentRow.Cells[5].Value.ToString();
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
                string actualizar = "UPDATE Empleado set Nombre = @Nombre, DUI = @DUI, Correo = @Correo, Telefono = @Telefono, Sexo = @Sexo where IdEmpleado = @IdEmpleado";
                SqlCommand cmd = new SqlCommand(actualizar, conexion.conectarbd);
                string id = Convert.ToString(GridEmpleados.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@IdEmpleado", id);
                cmd.Parameters.AddWithValue("@Nombre", txtProducto.Text);
                cmd.Parameters.AddWithValue("@DUI", txtCantidad.Text);
                cmd.Parameters.AddWithValue("@Correo", txtPrecio.Text);
                //cmd.Parameters.AddWithValue("@Telefono", txtProveedor.Text);
                //cmd.Parameters.AddWithValue("@Sexo", txtFechaCompra.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron actualizados con exito");

                GridEmpleados.DataSource = llenar_grid();
                txtProducto.Clear();
                txtCantidad.Clear();
                txtPrecio.Clear();
               // txtProveedor.Clear();
                //txtFechaCompra.Clear();
                //conexion.abrir();
                //conexion.cerrar();;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminar = "Delete from Empleado where IdEmpleado = @IdEmpleado";
            SqlCommand cmd = new SqlCommand(eliminar, conexion.conectarbd);
            string id = Convert.ToString(GridEmpleados.CurrentRow.Cells[0].Value);
            cmd.Parameters.AddWithValue("@IdEmpleado", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos han sido eliminados correctamente");
            GridEmpleados.DataSource = llenar_grid();
            txtProducto.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
