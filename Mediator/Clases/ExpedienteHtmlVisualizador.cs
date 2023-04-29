using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Mediator.Clases
{
    class VisualizadorTextoPlano : IExpedienteVisualizador
    {
        public string Visualizar(List<string> datos)
        {
            StringBuilder textoBuilder = new StringBuilder();
            textoBuilder.Append("Expediente de Docente\n\n");
            textoBuilder.Append("Información Personal\n");
            foreach (var dato in datos)
            {
                textoBuilder.Append(dato + "\n");
            }

            return textoBuilder.ToString();
        }
    }

   class VisualizadorHTML : IExpedienteVisualizador
    {
        public string Visualizar(List<string> datos)
        {
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<html><head><title>Expediente de Docente</title></head><body>");
            htmlBuilder.Append("<h1>Información Personal</h1>");
            htmlBuilder.Append("<ul>");
            foreach (var dato in datos)
            {
                htmlBuilder.Append("<li>" + dato + "</li>");
            }
            htmlBuilder.Append("</ul></body></html>");

            return htmlBuilder.ToString();
        }
    }
    
    class VisualizadorPDF : IExpedienteVisualizador
    {
        public string Visualizar(List<string> datos)
        {
            Document doc = new Document();
            FileStream fileStream = new FileStream("C:/Windows/System32/inetsrv/Expediente.pdf", FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(doc, fileStream);
            doc.Open();

            // Añadir contenido al documento PDF
            Paragraph titulo = new Paragraph("Expediente de Docente", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);
            doc.Add(Chunk.NEWLINE);

            Paragraph informacionPersonal = new Paragraph("Información Personal", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD));
            doc.Add(informacionPersonal);
            doc.Add(Chunk.NEWLINE);

            List lista = new List(List.UNORDERED);
            foreach (var dato in datos)
            {
                lista.Add(new ListItem(dato));
            }
            doc.Add(lista);

            // Cerrar documento PDF
            doc.Close();
            fileStream.Close();

            return "El archivo PDF ha sido guardado en la ruta predefinida";
        }
    }

    public class VisualizadorExcel : IExpedienteVisualizador
    {
        public string Visualizar(List<string> datos)
        {
            // Crear archivo Excel
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            var worksheet = excel.Workbook.Worksheets.Add("Expediente");

            // Añadir contenido al archivo Excel
            int row = 1;
            int col = 1;

            // Encabezado
            worksheet.Cells[row, col].Value = "Expediente de Docente";
            worksheet.Cells[row, col].Style.Font.Bold = true;
            worksheet.Cells[row, col].Style.Font.Size = 18;
            worksheet.Cells[row, col, row, datos.Count].Merge = true;
            row++;

            // Información personal
            worksheet.Cells[row, col].Value = "Información Personal";
            worksheet.Cells[row, col].Style.Font.Bold = true;
            worksheet.Cells[row, col].Style.Font.Size = 14;
            worksheet.Cells[row, col, row, datos.Count].Merge = true;
            row++;

            foreach (var dato in datos)
            {
                worksheet.Cells[row, col].Value = dato;
                col++;
            }

            // Establecer el ancho de las columnas
            worksheet.Cells.AutoFitColumns();

            // Guardar archivo Excel en disco
            string rutaArchivo = "//165.98.12.158/b231-neotech/WfBridgeeexpediente.xlsx";
            File.WriteAllBytes(rutaArchivo, excel.GetAsByteArray());

            return "El archivo Excel ha sido guardado en la ruta predefinida";
        }
    }
}