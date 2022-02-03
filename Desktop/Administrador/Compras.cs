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
        string myformat = "dd/MM/yyyy hh:mm:ss";
        String precioF;
        conexion conexion = new conexion();
        public Compras()
        {
            InitializeComponent();
            
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            llenar_suma();
            GridEmpleados.DataSource = llenar_grid();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }


        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDCompras as 'N',nombreProducto as 'Producto',cantidad as 'Cantidad', categoria as 'Categoria',marca as 'Marca',fechaCompra as 'Fecha de Compra', precio as 'Precio Unitario', precioTotal as 'Precio Total' FROM Compras";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            return dt;

        }
        public void llenar_suma()
        {
            String consulta = "Declare @IDFacturaVar varchar(50)  select @IDFacturaVar = IDCompras from Compras IF(@IDFacturaVar is not null)  begin select SUM(precioTotal) from Compras end";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            precioF = Convert.ToString(cmd.ExecuteScalar());
            priceTXT.Text = ("$" + precioF);

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtProducto.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()) || string.IsNullOrEmpty(txtPrecio.Text.Trim()) || string.IsNullOrEmpty(txtMarca.Text.Trim()) || string.IsNullOrEmpty(txtCategoria.Text.Trim()) || string.IsNullOrEmpty(txtPrecioTotal.Text.Trim()))
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
                else if (string.IsNullOrEmpty(txtPrecioTotal.Text.Trim()))
                {
                    txtPrecioTotal.Focus();
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

                //-----------------------------------------------------------------
                //ok aqui vemos si el precio total es mayor a cero y la leemos



                string validacion3 = "Declare @precioTotalVar decimal(9,2) select @precioTotalVar =  @precioTotal select @precioTotal";
                SqlCommand cmd4434 = new SqlCommand(validacion3, conexion.conectarbd);
                cmd4434.Parameters.AddWithValue("@precioTotal", txtPrecioTotal.Text);
                cmd4434.ExecuteNonQuery();
                decimal precioTotal = Convert.ToDecimal(cmd4434.ExecuteScalar());
                //-----------------------------------------------------------------


                if (cantidad > 0 && precioUnitario > 0 && precioTotal > 0)
                {
                    //Hago el procedimiento almacenado por string
                    string insertar22 = "Declare @Pnombre varchar(75) select @Pnombre = Producto.nombre from Producto where @CNombreProducto = Producto.nombre Declare @PMarca varchar(75) select @PMarca = Producto.marca from Producto where @CMarca = Producto.marca  IF(@CNombreProducto = @Pnombre     and @CMarca = @PMarca) begin   	insert into Compras(NombreProducto, cantidad,precio,fechaCompra, categoria, marca, precioTotal)  	values(@CNombreProducto, @Ccantidad, @Cprecio,@CfechaCompra, @Ccategoria, @Cmarca, @CprecioTotal)  	update Producto set cantidad = cantidad + @Ccantidad, categoria = @Ccategoria, precioUnitario = @CPrecio  	where @CNombreProducto = nombre and @CMarca = marca end else begin 	insert into Compras(NombreProducto, cantidad,precio,fechaCompra, categoria, marca, precioTotal) 	values(@CNombreProducto, @Ccantidad, @Cprecio,@CfechaCompra, @Ccategoria, @Cmarca, @CPrecioTotal)  	insert into Producto(nombre, categoria, marca,precioUnitario,cantidad, Disponibilidad) 	values (@CNombreProducto, @Ccategoria,@Cmarca, @Cprecio,@Ccantidad, 'True')  end";
                    SqlCommand cmd2 = new SqlCommand(insertar22, conexion.conectarbd);
                    cmd2.Parameters.AddWithValue("@CNombreProducto", txtProducto.Text);
                    cmd2.Parameters.AddWithValue("@Ccantidad", txtCantidad.Text);
                    cmd2.Parameters.AddWithValue("@CMarca", txtMarca.Text);
                    cmd2.Parameters.AddWithValue("@CPrecio", txtPrecio.Text);
                    cmd2.Parameters.AddWithValue("@CCategoria", txtCategoria.Text);
                    cmd2.Parameters.AddWithValue("@CPrecioTotal", txtPrecioTotal.Text);
                    //Subir fecha
                    DateTime stdate = DateTime.ParseExact(DTPfechaCompra.Text, myformat, null);
                    cmd2.Parameters.AddWithValue("@CFechaCompra", stdate);
                    cmd2.ExecuteNonQuery();
                    llenar_suma();
                    MessageBox.Show("Los datos fueron agregados con exito");
                    GridEmpleados.DataSource = llenar_grid();
                    txtProducto.Clear();
                    txtCantidad.Clear();
                    txtPrecio.Clear();
                    txtCategoria.Clear();
                    txtMarca.Clear();
                    txtPrecioTotal.Clear();
                }

                else
                {
                    MessageBox.Show("ingrese un numero mayor de cero en Cantidad o Precio");
                }
            }
        }

        private void GridEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(GridEmpleados.RowCount > 0 )
                {
                    txtProducto.Text = GridEmpleados.CurrentRow.Cells[1].Value.ToString();
                    txtCantidad.Text = GridEmpleados.CurrentRow.Cells[2].Value.ToString();
                    txtCategoria.Text = GridEmpleados.CurrentRow.Cells[3].Value.ToString();
                    txtMarca.Text = GridEmpleados.CurrentRow.Cells[4].Value.ToString();
                    DTPfechaCompra.Text = GridEmpleados.CurrentRow.Cells[5].Value.ToString();
                    txtPrecio.Text = GridEmpleados.CurrentRow.Cells[6].Value.ToString();
                    txtPrecioTotal.Text = GridEmpleados.CurrentRow.Cells[7].Value.ToString();

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
            if (string.IsNullOrEmpty(txtProducto.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()) || string.IsNullOrEmpty(txtPrecio.Text.Trim()) || string.IsNullOrEmpty(txtPrecioTotal.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {

                if (MessageBox.Show("¿Esta seguro que desea modificar este registro?", "Advertencia",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //conexion.abrir();
                    string actualizar = "Declare @ceroProductosono int select @ceroProductosono = Producto.cantidad from Producto where nombre = @nombreProducto  and marca = @marca IF(@ceroProductosono = 0) begin 		UPDATE COMPRAS set nombreProducto = @nombreProducto, precio = @precio, precioTotal = @precioTotal, 		fechaCompra = @fechaCompra, 	cantidad = @cantViene, categoria = @categoria, marca = @marca where IDCompras = @IDCompras end else begin 	Declare @cantYa int 	Declare @CantTotal int  	select @cantYa = Compras.cantidad  from Compras where @IDCompras = Compras.IDCompras  	IF(@cantYa > @cantViene)   begin 		select @CantTotal = @cantYa -  @CantViene   		update Producto set cantidad = cantidad - @CantTotal where Producto.nombre = @nombreProducto and Producto.marca = @marca  		UPDATE COMPRAS set nombreProducto = @nombreProducto, precio = @precio, precioTotal = @precioTotal, 		fechaCompra = @fechaCompra, 	cantidad = @cantViene, categoria = @categoria, marca = @marca where IDCompras = @IDCompras end else begin 		select @CantTotal = @CantViene - @cantYa  		update Producto set cantidad = cantidad + @CantTotal where Producto.nombre = @nombreProducto  and Producto.marca = @marca  		UPDATE COMPRAS set nombreProducto = @nombreProducto, precio = @precio, precioTotal = @precioTotal,fechaCompra = @fechaCompra, 		cantidad = @cantViene, categoria = @categoria, marca = @marca where IDCompras = @IDCompras  end end";
                    SqlCommand cmd = new SqlCommand(actualizar, conexion.conectarbd);
                    string id = Convert.ToString(GridEmpleados.CurrentRow.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@IDCompras", id);
                    cmd.Parameters.AddWithValue("@nombreProducto", txtProducto.Text);
                    cmd.Parameters.AddWithValue("@cantViene", txtCantidad.Text);
                    cmd.Parameters.AddWithValue("@precio", txtPrecio.Text);
                    cmd.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                    cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                    cmd.Parameters.AddWithValue("@precioTotal", txtPrecioTotal.Text);
                    //Subir fecha
                    DateTime stdate = DateTime.ParseExact(DTPfechaCompra.Text, myformat, null);
                    cmd.Parameters.AddWithValue("@fechaCompra", stdate);
                    cmd.ExecuteNonQuery();
                    llenar_suma();
                    MessageBox.Show("Los datos fueron actualizados con exito");

                    GridEmpleados.DataSource = llenar_grid();
                    txtProducto.Clear();
                    txtCantidad.Clear();
                    txtPrecio.Clear();
                    txtCategoria.Clear();
                    txtMarca.Clear();

                }
                else
                {

                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProducto.Text.Trim()) || string.IsNullOrEmpty(txtCantidad.Text.Trim()) || string.IsNullOrEmpty(txtPrecio.Text.Trim()))
            {
                MessageBox.Show("Hay Campos Vacios");

                return;
            }

            else
            {


                if (MessageBox.Show("¿Esta seguro que desea modificar este registro?", "Advertencia",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string eliminar = "Declare @numerodeProducto int select @numerodeProducto = Producto.cantidad from Producto where nombre = @nombreProducto  and marca = @marca  IF(@numerodeProducto < @cantidad) begin 		Declare @ceroProductosono int  		select @ceroProductosono = Producto.cantidad from Producto where nombre = @nombreProducto  and marca = @marca  		IF(@ceroProductosono = 0) begin 			Delete from Compras where IDCompras = @IDCompras  end else begin Delete from Compras where IDCompras = @IDCompras  			update Producto set cantidad = 0 where nombre = @NombreProducto and marca = @marca	 end end else begin 		IF(@ceroProductosono = 0) begin 			Delete from Compras where IDCompras = @IDCompras  end else begin 		Delete from Compras where IDCompras = @IDCompras   		update Producto set cantidad = cantidad - @cantidad where nombre = @NombreProducto and marca = @marca	 end end";
                    SqlCommand cmd = new SqlCommand(eliminar, conexion.conectarbd);
                    string id = Convert.ToString(GridEmpleados.CurrentRow.Cells[0].Value);
                    string name = Convert.ToString(GridEmpleados.CurrentRow.Cells[1].Value);
                    string cant = Convert.ToString(GridEmpleados.CurrentRow.Cells[2].Value);
                    string marc = Convert.ToString(GridEmpleados.CurrentRow.Cells[4].Value);
                    cmd.Parameters.AddWithValue("@IDCompras", id);
                    cmd.Parameters.AddWithValue("@NombreProducto", name);
                    cmd.Parameters.AddWithValue("@cantidad", cant);
                    cmd.Parameters.AddWithValue("@marca", marc);
                    cmd.ExecuteNonQuery();
                    llenar_suma();
                    MessageBox.Show("Los datos han sido eliminados correctamente");
                    GridEmpleados.DataSource = llenar_grid();
                    txtProducto.Clear();
                    txtCantidad.Clear();
                    txtPrecio.Clear();
                    txtCategoria.Clear();
                    txtMarca.Clear();
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
                else
                {

                }


            }
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
                    MessageBox.Show("Solo números acompañados de punto decimal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            txtProducto.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtProducto.Text);
            txtProducto.SelectionStart = txtProducto.Text.Length;
        }

        private void txtPrecioTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo números acompañados de punto decimal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        Double s1, s2, suma;

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            txtCategoria.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCategoria.Text);
            txtCategoria.SelectionStart = txtCategoria.Text.Length;
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            txtMarca.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMarca.Text);
            txtMarca.SelectionStart = txtMarca.Text.Length;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            Suma();
        }
        
        private void Suma()
        {
            Double.TryParse(txtPrecio.Text, out s1);
            Double.TryParse(txtCantidad.Text, out s2);
         suma = s1 *s2;
            txtPrecioTotal.Text = Convert.ToString(Math.Round(suma, 2));
        }
    }
}
