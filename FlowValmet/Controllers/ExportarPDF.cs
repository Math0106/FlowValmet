using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FlowValmet.Controllers
{
    internal class ExportarPDF
    {

       
        public void ExportarRelatorioEstilizado(DataGridView dataGridView, string filePath)
        {

            // Configurações do documento
            Document document = new Document(PageSize.A4.Rotate(), 15, 15, 15, 15);

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Especificando os namespaces completos para evitar ambiguidade
                iTextSharp.text.Font titleFont = iTextSharp.text.FontFactory.GetFont(
                    iTextSharp.text.FontFactory.HELVETICA_BOLD,
                    16,
                    iTextSharp.text.BaseColor.DARK_GRAY);

                iTextSharp.text.Font headerFont = iTextSharp.text.FontFactory.GetFont(
                    iTextSharp.text.FontFactory.HELVETICA_BOLD,
                    10,
                    iTextSharp.text.BaseColor.WHITE);

                iTextSharp.text.Font cellFont = iTextSharp.text.FontFactory.GetFont(
                    iTextSharp.text.FontFactory.HELVETICA,
                    9,
                    iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font cellFont_Red = iTextSharp.text.FontFactory.GetFont(
                    iTextSharp.text.FontFactory.HELVETICA,
                    9,
                    iTextSharp.text.BaseColor.RED);

                // Adicionar título ao documento
                iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(
                    "RELATÓRIO DE ORDENS DE PRODUÇÃO",
                    titleFont);

                title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                title.SpacingAfter = 10f;
                document.Add(title);

                // Adicionar data de emissão
                iTextSharp.text.Paragraph emissionDate = new iTextSharp.text.Paragraph(
                    $"Emitido em: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}",
                    iTextSharp.text.FontFactory.GetFont(
                        iTextSharp.text.FontFactory.HELVETICA,
                        8,
                        iTextSharp.text.BaseColor.GRAY));

                emissionDate.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
                document.Add(emissionDate);

                // Criar tabela
                PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count);
                pdfTable.WidthPercentage = 100;
                pdfTable.SpacingBefore = 10f;
                pdfTable.SpacingAfter = 10f;


                int totalColumns = dataGridView.Columns.Count;
                float[] columnWidths = new float[totalColumns];

                // Definir as larguras fixas para as primeiras colunas
                if (totalColumns > 0) columnWidths[0] = 12f;
                if (totalColumns > 1) columnWidths[1] = 20f;
                if (totalColumns > 2) columnWidths[2] = 10f;
                if (totalColumns > 3) columnWidths[3] = 10f;
                if (totalColumns > 4) columnWidths[4] = 10f;

                // Preencher o restante com 6f
                for (int i = 5; i < totalColumns; i++)
                {
                    columnWidths[i] = 6f;
                }
                pdfTable.SetWidths(columnWidths);

                // Cabeçalhos das colunas
                BaseColor headerColor = new BaseColor(51, 102, 153); // Azul escuro

                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                    headerCell.BackgroundColor = headerColor;
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerCell.Padding = 5;
                    headerCell.BorderWidth = 0.5f;
                    pdfTable.AddCell(headerCell);
                }

                // Dados das células
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        PdfPCell pdfCell;

                        if (cell.Value is System.Drawing.Image)
                        {
                            // Processar imagem
                            System.Drawing.Image cellImage = (System.Drawing.Image)cell.Value;
                            using (MemoryStream ms = new MemoryStream())
                            {
                                cellImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                                pdfImage.ScaleToFit(15f, 15f);
                                pdfCell = new PdfPCell(pdfImage);
                            }
                        }
                        else
                        {
                            // Processar texto
                            string cellValue = cell.Value?.ToString() ?? "";

                            // Estilo condicional para datas inválidas
                            if ((cell.OwningColumn.HeaderText.Contains("Data de Entrega") &&
                                !string.IsNullOrEmpty(cellValue) &&
                                Convert.ToDateTime(cellValue) < DateTime.Now)) // Data inválida de exemplo
                            {
                                pdfCell = new PdfPCell(new Phrase(cellValue, cellFont_Red));
                            }
                            else
                            {
                                pdfCell = new PdfPCell(new Phrase(cellValue, cellFont));
                            }
                        }

                        // Configurações comuns da célula
                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfCell.Padding = 5;
                        pdfCell.BorderWidth = 0.25f;
                        pdfCell.BorderColor = new BaseColor(200, 200, 200);

                        pdfTable.AddCell(pdfCell);
                    }
                }

                document.Add(pdfTable);

                // Rodapé
                Paragraph footer = new Paragraph("Sistema de Gestão de Produção - © 2025",
                                       FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY));
                footer.Alignment = Element.ALIGN_CENTER;
                footer.SpacingBefore = 20f;
                document.Add(footer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}");
            }
            finally
            {
                document.Close();
            }
        }
    }
}
