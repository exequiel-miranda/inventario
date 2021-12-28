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
    public partial class Categoria : Form
    {
        conexion conexion = new conexion();

        public Categoria()
        {
            InitializeComponent();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            GridCategoria.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "select  IdCategoria as Codigo, Nombre from Categoria ";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            return dt;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreC.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                string insertar = "INSERT INTO CATEGORIA (Nombre) Values (@Nombre)";
                SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
                cmd.Parameters.AddWithValue("@Nombre", txtNombreC.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados con exito");

                GridCategoria.DataSource = llenar_grid();
                txtNombreC.Clear();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreC.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                //conexion.abrir();
                string actualizar = "UPDATE Categoria set Nombre = @Nombre where IdCategoria = @IdCategoria";
                SqlCommand cmd = new SqlCommand(actualizar, conexion.conectarbd);
                string id = Convert.ToString(GridCategoria.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@IdCategoria", id);
                cmd.Parameters.AddWithValue("@Nombre", txtNombreC.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Los datos fueron actualizados con exito");
                GridCategoria.DataSource = llenar_grid();
                txtNombreC.Clear();
            }
        }

        private void GridCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNombreC.Text = GridCategoria.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
        }
    }


}
