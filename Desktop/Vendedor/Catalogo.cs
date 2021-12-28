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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Desktop.Vendedor
{
    public partial class Catalogo : Form
    {
        conexion conexion = new conexion();
        public Catalogo()
        {
            InitializeComponent();
            
        }

        private void Catalogo_Load(object sender, EventArgs e)
        {
            conexion.abrir();
            GridCatalogo.DataSource = llenar_grid();
            
        }
        public DataTable llenar_grid()
        {
            //conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "select IdProducto as Codigo, Nombre, PrecioU from Producto ";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //conexion.cerrar();
            return dt;
        }

        private void GridCatalogo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //conexion.abrir();
            try
            {
                lblCodigo.Text = GridCatalogo.CurrentRow.Cells[0].Value.ToString();
                lblNombre.Text = GridCatalogo.CurrentRow.Cells[1].Value.ToString();
                lblPrecio.Text = GridCatalogo.CurrentRow.Cells[2].Value.ToString();
            }
            catch { }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            string insertar = "INSERT INTO FACTURALOCAL (IdCompra, IdProducto, IdEmpleado, Cantidad, Fecha) Values (@IdCompra,@IdProducto,@IdEmpleado,@Cantidad,@Fecha)";
            SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
            cmd.Parameters.AddWithValue("@IdCompra", txtCompra.Text);
            cmd.Parameters.AddWithValue("@IdProducto", lblCodigo.Text);
            cmd.Parameters.AddWithValue("@IdEmpleado", 2);
            cmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmd.Parameters.AddWithValue("@Fecha", fechaingreso.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron agregados con exito");

            GridCatalogo.DataSource = llenar_grid();
            txtCantidad.Clear();

        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {

            lblEncabezado.Text = "Listado de productos";

            DataTable dt = new DataTable();
            String consulta = "select p.IdProducto as [Codigo],p.Nombre as [Producto],p.PrecioU,fl.Cantidad from FacturaLocal as fl inner join Producto as p on fl.IdProducto = p.idProducto where IdCompra = @IdCompra";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            cmd.Parameters.AddWithValue("@IdCompra", txtCompra.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridCatalogo.DataSource = dt;

            btnIngresar.Visible = false;
            btnCarrito.Visible = false;
            label3.Visible = false;
            fechaingreso.Visible = false;


            btnEliminar.Visible = true;
            btnModificar.Visible = true;
            btnFacturar.Visible = true;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string insertar = "UPDATE FacturaLocal set IdProducto = @IdProducto, IdEmpleado = @IdEmpleado, Cantidad = @Cantidad where IdCompra = @IdCompra";
            SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
            cmd.Parameters.AddWithValue("@IdCompra", txtCompra.Text);
            cmd.Parameters.AddWithValue("@IdProducto", lblCodigo.Text);
            cmd.Parameters.AddWithValue("@IdEmpleado", 2);
            cmd.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizados con exito");

            GridCatalogo.DataSource = llenar_grid();
            txtCantidad.Clear();
            lblCodigo.Text = "";
            lblNombre.Text = "";
            lblPrecio.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string insertar = "Delete from FacturaLocal where IdCompra = @IdCompra";
            SqlCommand cmd = new SqlCommand(insertar, conexion.conectarbd);
            cmd.Parameters.AddWithValue("@IdCompra", txtCompra.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizados con exito");

            GridCatalogo.DataSource = llenar_grid();
            txtCantidad.Clear();
            lblCodigo.Text = "";
            lblNombre.Text = "";
            lblPrecio.Text = "";
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            int idCompra = int.Parse(txtCompra.Text);

            DataTable dt = new DataTable();
            String consulta = "select p.IdProducto as [Codigo],p.Nombre as [Producto],p.PrecioU,fl.Cantidad from FacturaLocal as fl inner join Producto as p on fl.IdProducto = p.idProducto where IdCompra = " + idCompra;
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No Hay Datos Para Realizar Un Reporte", "ERROR...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                Document document = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                save.FileName = txtCompra.Text;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    string filename = save.FileName;

                    FileStream file = new FileStream(filename, FileMode.OpenOrCreate);
                    PdfWriter writer = PdfWriter.GetInstance(document, file);

                    if (dt.Rows.Count > 0)
                    {
                        document.Open();

                        iTextSharp.text.Font fontTitle = FontFactory.GetFont(FontFactory.COURIER_BOLD, 25);
                        iTextSharp.text.Font font9 = FontFactory.GetFont(FontFactory.TIMES, 9);

                        iTextSharp.text.Font LineBreak = FontFactory.GetFont("Arial", size: 16);

                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Path.Combine(Application.StartupPath, "Resources/Logotipo.png"));
                        img.ScaleAbsoluteWidth(200);
                        img.ScaleAbsoluteHeight(70);
                        Paragraph parrafo2 = new Paragraph(string.Format("FACTURACION"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 22));
                        parrafo2.SpacingBefore = 200;
                        parrafo2.SpacingAfter = 0;
                        parrafo2.Alignment = Element.ALIGN_CENTER;
                        document.Add(parrafo2);

                        //Generar detalles
                        Paragraph prgGeneratedBY = new Paragraph();
                        BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 12, 2, iTextSharp.text.BaseColor.BLUE);
                        prgGeneratedBY.Alignment = Element.ALIGN_CENTER;
                        prgGeneratedBY.Add(new Chunk("Reporte generado por: MEDILIFE", fntAuthor));
                        prgGeneratedBY.Add(new Chunk("\nFecha: " + DateTime.Now.ToShortDateString(), fntAuthor));
                        document.Add(prgGeneratedBY);

                        document.Add(new Chunk("\n"));
                        Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                        document.Add(p);
                        document.Add(Chunk.NEWLINE);
                        img.SetAbsolutePosition(0, 750);
                        document.Add(img);
                        img.ScaleToFit(115f, 50F);

                        PdfPTable table = new PdfPTable(dt.Columns.Count);
                        document.Add(new Chunk("\n"));

                        float[] widths = new float[dt.Columns.Count];
                        for (int i = 0; i < dt.Columns.Count; i++)
                            widths[i] = 4f;

                        table.SetWidths(widths);
                        table.WidthPercentage = 90;
                        PdfPCell cell = new PdfPCell(new Phrase("Productos comprados", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff")))));
                        cell.Colspan = dt.Columns.Count;
                        cell.BackgroundColor = new BaseColor(ColorTranslator.FromHtml("#008B8B"));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.PaddingBottom = 5;
                        table.AddCell(cell);

                        foreach (DataColumn c in dt.Columns)
                        {
                            string cellText = c.ColumnName;

                            PdfPCell cell1 = new PdfPCell();
                            cell1.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))));
                            cell1.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#424242"));
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell1.PaddingBottom = 5;
                            table.AddCell(cell1);
                        }

                        foreach (DataRow r in dt.Rows)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                for (int h = 0; h < dt.Columns.Count; h++)
                                {
                                    table.AddCell(new Phrase(r[h].ToString(), font9));
                                }
                            }
                        }
                        document.Add(table);
                    }
                    document.Close();
                }
            }
        }

        private void txtCompra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
