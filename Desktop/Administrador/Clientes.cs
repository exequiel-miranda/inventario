﻿using Microsoft.Data.SqlClient;
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
        }

        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDCliente as N, nombre as Nombre, creditoFiscal as 'Credito Fiscal', telefono as Telefono  FROM Clientes where creditoFiscal is not null";
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
                //cmd.Parameters.AddWithValue("@DUI", txtDuiC.Text);
                //cmd.Parameters.AddWithValue("@Correo", txtCorreoC.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefonoC.Text);
                cmd.Parameters.AddWithValue("@creditoFiscal", txtCreditoF.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados con exito");

                GridClientes.DataSource = llenar_grid();
                txtNombreC.Clear();
                //txtDuiC.Clear();
                txtTelefonoC.Clear();
                //txtCorreoC.Clear();
                txtCreditoF.Clear();
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
                txtCreditoF.Text = GridClientes.CurrentRow.Cells[2].Value.ToString();
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
            if (string.IsNullOrEmpty(txtNombreC.Text.Trim()) || string.IsNullOrEmpty(txtTelefonoC.Text.Trim()) || string.IsNullOrEmpty(txtCreditoF.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {
                //conexion.abrir();
                string actualizar = "UPDATE CLIENTES set nombre = @nombre, creditoFiscal = @creditoFiscal, telefono = @telefono where IDCliente = @IDCliente";
                SqlCommand cmd = new SqlCommand(actualizar, conexion.conectarbd);
                string id = Convert.ToString(GridClientes.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@IDCliente", id);
                cmd.Parameters.AddWithValue("@nombre", txtNombreC.Text);
                // cmd.Parameters.AddWithValue("@DUI", txtDuiC.Text);
                //  cmd.Parameters.AddWithValue("@Correo", txtCorreoC.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefonoC.Text);
                cmd.Parameters.AddWithValue("@creditoFiscal", txtCreditoF.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Los datos fueron actualizados con exito");
                GridClientes.DataSource = llenar_grid();
                txtNombreC.Clear();
                // txtDuiC.Clear();
                txtTelefonoC.Clear();
                //  txtCorreoC.Clear();
                txtCreditoF.Clear();
                //conexion.abrir();
                //conexion.cerrar();
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

                string eliminar = "UPDATE CLIENTES set creditoFiscal = null where IDCliente = @IDCliente";
                SqlCommand cmd = new SqlCommand(eliminar, conexion.conectarbd);
                string id = Convert.ToString(GridClientes.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@IDCliente", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos han sido eliminados correctamente");
                GridClientes.DataSource = llenar_grid();
                txtNombreC.Clear();
                //txtDuiC.Clear();
                txtTelefonoC.Clear();
                // txtCorreoC.Clear();
                txtCreditoF.Clear();
                //conexion.abrir();
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
