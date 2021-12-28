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
    public partial class Empleados : Form
    {
        conexion conexion = new conexion();
        public Empleados()
        {
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            GridEmpleados.DataSource = llenar_grid();
            //conexion.cerrar();
        }


        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "select IdEmpleado as N, Nombre, DUI,Correo, Telefono, Sexo from Empleado ";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            return dt;

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || string.IsNullOrEmpty(txtDui.Text.Trim()) || string.IsNullOrEmpty(txtCorreo.Text.Trim()) || string.IsNullOrEmpty(txtTelefono.Text.Trim()) || string.IsNullOrEmpty(txtSexo.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                string insertar = "INSERT INTO Empleado (Nombre, DUI, Correo, Telefono, Sexo) Values (@Nombre,@DUI,@Correo,@Telefono,@Sexo)";
                SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@DUI", txtDui.Text);
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Sexo", txtSexo.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados con exito");

                GridEmpleados.DataSource = llenar_grid();
                txtNombre.Clear();
                txtDui.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                txtSexo.Clear();
                //conexion.abrir();
                //conexion.cerrar();
            }
        }

        private void GridEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNombre.Text = GridEmpleados.CurrentRow.Cells[1].Value.ToString();
                txtDui.Text = GridEmpleados.CurrentRow.Cells[2].Value.ToString();
                txtCorreo.Text = GridEmpleados.CurrentRow.Cells[3].Value.ToString();
                txtTelefono.Text = GridEmpleados.CurrentRow.Cells[4].Value.ToString();
                txtSexo.Text = GridEmpleados.CurrentRow.Cells[5].Value.ToString();
            }
            catch { }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) || string.IsNullOrEmpty(txtDui.Text.Trim()) || string.IsNullOrEmpty(txtCorreo.Text.Trim()) || string.IsNullOrEmpty(txtTelefono.Text.Trim()) || string.IsNullOrEmpty(txtSexo.Text.Trim()))
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
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@DUI", txtDui.Text);
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Sexo", txtSexo.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron actualizados con exito");

                GridEmpleados.DataSource = llenar_grid();
                txtNombre.Clear();
                txtDui.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                txtSexo.Clear();
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
            txtNombre.Clear();
            txtDui.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtSexo.Clear();
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
    }
}
