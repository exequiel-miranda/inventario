using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Administrador
{
    public partial class Clientes : Form
    {
        conexion conexion = new conexion();
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            
            conexion.abrir();
            GridClientes.DataSource = llenar_grid();
            //conexion.cerrar();
        }

        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDCliente as N, nombre as Nombre, creditoFiscal as 'Credito Fiscal', telefono as Telefono  FROM Clientes ";
            SqlCommand cmd = new SqlCommand(consulta,conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            return dt;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombreC.Text.Trim()) || string.IsNullOrEmpty(txtTelefonoC.Text.Trim()) || string.IsNullOrEmpty(txtSexoC.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                string insertar = "INSERT INTO CLIENTE (Nombre, DUI, Correo, Telefono, Sexo) Values (@Nombre,@DUI,@Correo,@Telefono,@Sexo)";
                SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
                cmd.Parameters.AddWithValue("@Nombre", txtNombreC.Text);
                //cmd.Parameters.AddWithValue("@DUI", txtDuiC.Text);
                //cmd.Parameters.AddWithValue("@Correo", txtCorreoC.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefonoC.Text);
                cmd.Parameters.AddWithValue("@Sexo", txtSexoC.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados con exito");

                GridClientes.DataSource = llenar_grid();
                txtNombreC.Clear();
                //txtDuiC.Clear();
                txtTelefonoC.Clear();
                //txtCorreoC.Clear();
                txtSexoC.Clear();
                //conexion.abrir();
                //conexion.cerrar();
            }
        }

        ///////////////////////////////////////////////////
        private void GridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //conexion.abrir();
            try
            {
                txtNombreC.Text = GridClientes.CurrentRow.Cells[1].Value.ToString();
                txtSexoC.Text = GridClientes.CurrentRow.Cells[2].Value.ToString();
                txtTelefonoC.Text = GridClientes.CurrentRow.Cells[3].Value.ToString();
                /*
                txtCorreoC.Text = GridClientes.CurrentRow.Cells[3].Value.ToString();
                txtTelefonoC.Text = GridClientes.CurrentRow.Cells[4].Value.ToString();
                txtSexoC.Text = GridClientes.CurrentRow.Cells[5].Value.ToString();
                */
            }
            catch { }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreC.Text.Trim()) || string.IsNullOrEmpty(txtTelefonoC.Text.Trim()) || string.IsNullOrEmpty(txtSexoC.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                //conexion.abrir();
                string actualizar = "UPDATE Cliente set Nombre = @Nombre, DUI = @DUI, Correo = @Correo, Telefono = @Telefono, Sexo = @Sexo where IdCliente = @IdCliente";
                SqlCommand cmd = new SqlCommand(actualizar, conexion.conectarbd);
                string id = Convert.ToString(GridClientes.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@IdCliente", id);
                cmd.Parameters.AddWithValue("@Nombre", txtNombreC.Text);
               // cmd.Parameters.AddWithValue("@DUI", txtDuiC.Text);
              //  cmd.Parameters.AddWithValue("@Correo", txtCorreoC.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefonoC.Text);
                cmd.Parameters.AddWithValue("@Sexo", txtSexoC.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Los datos fueron actualizados con exito");
                GridClientes.DataSource = llenar_grid();
                txtNombreC.Clear();
               // txtDuiC.Clear();
                txtTelefonoC.Clear();
              //  txtCorreoC.Clear();
                txtSexoC.Clear();
                //conexion.abrir();
                //conexion.cerrar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminar = "Delete from cliente where IdCliente = @IdCliente";
            SqlCommand cmd = new SqlCommand(eliminar,conexion.conectarbd);
            string id = Convert.ToString(GridClientes.CurrentRow.Cells[0].Value);
            cmd.Parameters.AddWithValue("@IdCliente", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos han sido eliminados correctamente");
            GridClientes.DataSource = llenar_grid();
            txtNombreC.Clear();
            //txtDuiC.Clear();
            txtTelefonoC.Clear();
           // txtCorreoC.Clear();
            txtSexoC.Clear();
            //conexion.abrir();

        }

        private void txtNombreC_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
                {
                    MessageBox.Show("Solo letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
            
        }

        private void txtSexoC_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefonoC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
