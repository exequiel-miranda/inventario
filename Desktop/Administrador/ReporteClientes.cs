using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Administrador
{
    public partial class ReporteClientes : Form
    {
        conexion conexion = new conexion();
        public ReporteClientes()
        {
            InitializeComponent();
            conexion.abrir();
            GridReporte.DataSource = llenar_grid();
            conexion.cerrar();
        }
        public DataTable llenar_grid()
        {
            conexion.abrir();
            DataTable dt = new DataTable();
            String consulta = "SELECT IDCliente as [N], nombre as [Nombre], creditoFiscal as [Número de NIT], telefono as [Telefono]  FROM Clientes";
            SqlCommand cmd = new SqlCommand(consulta, conexion.conectarbd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexion.cerrar();
            return dt;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = llenar_grid();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No Hay Datos Para Realizar Un Reporte", "ERROR...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                Document document = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                save.FileName = "ReporteClientes";

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
                        img.ScaleAbsoluteWidth(150);
                        img.ScaleAbsoluteHeight(40);
                        Paragraph parrafo2 = new Paragraph(string.Format("Reporte de los Cliente"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 22));
                        parrafo2.SpacingBefore = 200;
                        parrafo2.SpacingAfter = 25;
                        parrafo2.Alignment = Element.ALIGN_CENTER;
                        document.Add(parrafo2);

                        //Generar detalles
                        Paragraph prgGeneratedBY = new Paragraph();
                        BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 12, 2, iTextSharp.text.BaseColor.BLUE);
                        prgGeneratedBY.Alignment = Element.ALIGN_CENTER;
                        //prgGeneratedBY.Add(new Chunk("Reporte generado por:", fntAuthor));
                        prgGeneratedBY.Add(new Chunk("Reporte generado el: " + DateTime.Now.ToShortDateString(), fntAuthor));
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
                        PdfPCell cell = new PdfPCell(new Phrase("Clientes", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff")))));
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
    }
}
