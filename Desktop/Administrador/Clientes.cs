using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;  
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
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDCliente as N, nombre as Nombre, creditoFiscal as 'Número de NIT', telefono as Telefono  FROM Clientes where creditoFiscal is not null";
            SqlCommand cmd = new SqlCommand(consulta,conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();

            return dt;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombreC.Text.Trim()) || !txtTelefonoC.MaskCompleted || !txtCreditoF.MaskCompleted)
            {
                MessageBox.Show("Hay Campos Vacios");
                if (string.IsNullOrEmpty(txtNombreC.Text.Trim())){
                    txtNombreC.Focus();
                }
                else if (!txtTelefonoC.MaskCompleted) {
                    txtTelefonoC.Focus();
                }
                else
                {
                    txtCreditoF.Focus();
                }

                return;
            }

            else
            {
                string insertar = "INSERT INTO CLIENTES (nombre, creditoFiscal, telefono) Values (@nombre,@creditoFiscal,@telefono)";
                SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
                cmd.Parameters.AddWithValue("@nombre", txtNombreC.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefonoC.Text);
                cmd.Parameters.AddWithValue("@creditoFiscal", txtCreditoF.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados con exito");

                GridClientes.DataSource = llenar_grid();
                txtNombreC.Clear();
                txtTelefonoC.Clear();
                txtCreditoF.Clear();
            }
        }

        private void GridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //conexion.abrir();
            try
            {

                if (GridClientes.RowCount > 0)
                { 
                    txtNombreC.Text = GridClientes.CurrentRow.Cells[1].Value.ToString();
                txtCreditoF.Text = GridClientes.CurrentRow.Cells[2].Value.ToString();
                txtTelefonoC.Text = GridClientes.CurrentRow.Cells[3].Value.ToString();
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No hay datos");
                }

            }
            catch { }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreC.Text.Trim()) || string.IsNullOrEmpty(txtTelefonoC.Text.Trim()) || string.IsNullOrEmpty(txtCreditoF.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                if (MessageBox.Show("¿Esta seguro que desea modificar este registro?", "Advertencia",
         MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string actualizar = "UPDATE CLIENTES set nombre = @nombre, creditoFiscal = @creditoFiscal, telefono = @telefono where IDCliente = @IDCliente";
                    SqlCommand cmd = new SqlCommand(actualizar, conexion.conectarbd);
                    string id = Convert.ToString(GridClientes.CurrentRow.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@IDCliente", id);
                    cmd.Parameters.AddWithValue("@nombre", txtNombreC.Text);
                    cmd.Parameters.AddWithValue("@telefono", txtTelefonoC.Text);
                    cmd.Parameters.AddWithValue("@creditoFiscal", txtCreditoF.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Los datos fueron actualizados con exito");
                    GridClientes.DataSource = llenar_grid();
                    txtNombreC.Clear();
                    txtTelefonoC.Clear();
                    txtCreditoF.Clear();
                }
                else
                {

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreC.Text.Trim()) || string.IsNullOrEmpty(txtTelefonoC.Text.Trim()) || string.IsNullOrEmpty(txtCreditoF.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {

                if (MessageBox.Show("¿Esta seguro que desea eliminar este registro?", "Advertencia",
         MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string eliminar = "UPDATE CLIENTES set creditoFiscal = null where IDCliente = @IDCliente";
                    SqlCommand cmd = new SqlCommand(eliminar, conexion.conectarbd);
                    string id = Convert.ToString(GridClientes.CurrentRow.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@IDCliente", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Los datos han sido eliminados correctamente");
                    GridClientes.DataSource = llenar_grid();
                    txtNombreC.Clear();
                    txtTelefonoC.Clear();
                    txtCreditoF.Clear();
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
                else
                {

                }


            }
        }

        private void txtNombreC_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCreditoF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Digite cantidades numericas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtCreditoF.Focus();
        }

        private void txtCreditoF_MouseDown(object sender, MouseEventArgs e)
        {
            txtCreditoF.SelectionStart = 0;
        }

        private void txtTelefonoC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Digite cantidades numericas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtTelefonoC.Focus();
        }

        private void txtTelefonoC_MouseDown(object sender, MouseEventArgs e)
        {
            txtTelefonoC.SelectionStart = 0;
        }

        private void txtNombreC_TextChanged(object sender, EventArgs e)
        {
            txtNombreC.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombreC.Text);
            txtNombreC.SelectionStart = txtNombreC.Text.Length;
        }

        private void txtNombreC_TextChanged_1(object sender, EventArgs e)
        {
            txtNombreC.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombreC.Text);
            txtNombreC.SelectionStart = txtNombreC.Text.Length;
        }
    }
}
