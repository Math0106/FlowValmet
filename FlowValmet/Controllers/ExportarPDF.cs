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
        // Cores ajustadas para um visual mais sóbrio
        private static readonly BaseColor VERDE_PRINCIPAL = new BaseColor(0, 104, 71); // Verde corporativo
        private static readonly BaseColor CINZA_ESCURO = new BaseColor(64, 64, 64);
        private static readonly BaseColor CINZA_CLARO = new BaseColor(240, 240, 240);
        private static readonly BaseColor BRANCO = new BaseColor(255, 255, 255);

        public void ExportarRelatorioEstilizado(DataGridView dataGridView, string filePath, string setorUsuario, string emailUsuario)
        {
            Document document = new Document(PageSize.A4, 15, 15, 15, 15);

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Fontes para a capa
                iTextSharp.text.Font titleFontCapa = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, VERDE_PRINCIPAL);
                iTextSharp.text.Font infoFontCapa = FontFactory.GetFont(FontFactory.HELVETICA, 12, CINZA_ESCURO);
                iTextSharp.text.Font footerFontCapa = FontFactory.GetFont(FontFactory.HELVETICA, 10, CINZA_ESCURO);

                // Capa com design limpo
                Paragraph titleCapa = new Paragraph("RELATÓRIO DE ORDENS DE PRODUÇÃO", titleFontCapa);
                titleCapa.Alignment = Element.ALIGN_CENTER;
                titleCapa.SpacingAfter = 30f;
                document.Add(titleCapa);

                // Informações do relatório
                Paragraph infoRelatorio = new Paragraph(
                    $"Data de emissão: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}\n\n" +
                    $"Setor responsável: {setorUsuario}\n" +
                    $"Emitido por: {emailUsuario}",
                    infoFontCapa);

                infoRelatorio.Alignment = Element.ALIGN_CENTER;
                infoRelatorio.SpacingAfter = 50f;
                document.Add(infoRelatorio);

                // Rodapé da capa
                Paragraph footerCapa = new Paragraph("Sistema de Gestão de Produção - © 2025", footerFontCapa);
                footerCapa.Alignment = Element.ALIGN_CENTER;
                footerCapa.SpacingBefore = 100f;
                document.Add(footerCapa);

                document.NewPage();
                document.SetPageSize(PageSize.A4.Rotate());

                // Fontes para o conteúdo principal
                iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, CINZA_ESCURO);
                iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BRANCO);
                iTextSharp.text.Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, CINZA_ESCURO);
                iTextSharp.text.Font cellFontRed = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.RED);
                iTextSharp.text.Font footerFont = FontFactory.GetFont(FontFactory.HELVETICA, 8, CINZA_ESCURO);

                // Título da tabela
                Paragraph title = new Paragraph("DETALHES DAS ORDENS DE PRODUÇÃO", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 10f;
                document.Add(title);

                // Informações de emissão
                Paragraph emissionInfo = new Paragraph(
                    $"Emitido em: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")} | " +
                    $"Setor: {setorUsuario} | " +
                    $"Responsável: {emailUsuario}",
                    FontFactory.GetFont(FontFactory.HELVETICA, 8, CINZA_ESCURO));

                emissionInfo.Alignment = Element.ALIGN_RIGHT;
                document.Add(emissionInfo);

                // Tabela com design limpo
                PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count);
                pdfTable.WidthPercentage = 100;
                pdfTable.SpacingBefore = 10f;
                pdfTable.SpacingAfter = 10f;

                float[] columnWidths = new float[dataGridView.Columns.Count];
                for (int i = 0; i < columnWidths.Length; i++)
                {
                    columnWidths[i] = i < 5 ? 10f : 6f;
                }
                pdfTable.SetWidths(columnWidths);

                // Cabeçalhos com toque de verde
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
                    headerCell.BackgroundColor = VERDE_PRINCIPAL;
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerCell.Padding = 5;
                    headerCell.BorderWidth = 0.5f;
                    headerCell.BorderColor = VERDE_PRINCIPAL;
                    pdfTable.AddCell(headerCell);
                }

                // Dados das células
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        PdfPCell pdfCell;
                        string cellValue = cell.Value?.ToString() ?? "";

                        if (cell.Value is System.Drawing.Image)
                        {
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
                            if ((cell.OwningColumn.HeaderText.Contains("Data de Entrega") &&
                                !string.IsNullOrEmpty(cellValue) &&
                                DateTime.TryParse(cellValue, out DateTime cellDate) &&
                                cellDate < DateTime.Now))
                            {
                                pdfCell = new PdfPCell(new Phrase(cellValue, cellFontRed));
                            }
                            else
                            {
                                pdfCell = new PdfPCell(new Phrase(cellValue, cellFont));
                            }
                        }

                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfCell.Padding = 5;
                        pdfCell.BorderWidth = 0.25f;
                        pdfCell.BorderColor = new BaseColor(220, 220, 220);
                        pdfCell.BackgroundColor = row.Index % 2 == 0 ? CINZA_CLARO : BRANCO;

                        pdfTable.AddCell(pdfCell);
                    }
                }

                document.Add(pdfTable);

                // Rodapé discreto
                Paragraph footer = new Paragraph(
                    $"Sistema de Gestão de Produção - © 2025 | Emitido por: {emailUsuario}",
                    footerFont);

                footer.Alignment = Element.ALIGN_CENTER;
                footer.SpacingBefore = 20f;
                document.Add(footer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                document.Close();
            }
        }
    }
    //public void ExportarRelatorioEstilizado(DataGridView dataGridView, string filePath, string setorUsuario, string emailUsuario)
    //{
    //    // Configurações do documento - começamos com A4 retrato para a capa
    //    Document document = new Document(PageSize.A4, 15, 15, 15, 15);

    //    try
    //    {
    //        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
    //        document.Open();

    //        // Fontes para a capa
    //        iTextSharp.text.Font titleFontCapa = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.DARK_GRAY);
    //        iTextSharp.text.Font infoFontCapa = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);

    //        // Adicionar capa (página A4 retrato)
    //        // Logo (opcional - descomente se tiver um logo)
    //        // Image logo = Image.GetInstance("caminho/para/logo.png");
    //        // logo.ScaleToFit(150f, 150f);
    //        // logo.Alignment = Element.ALIGN_CENTER;
    //        // document.Add(logo);

    //        // Espaçamento
    //        document.Add(new Paragraph(" "));
    //        document.Add(new Paragraph(" "));
    //        document.Add(new Paragraph(" "));

    //        // Título do relatório na capa
    //        Paragraph titleCapa = new Paragraph("RELATÓRIO DE ORDENS DE PRODUÇÃO", titleFontCapa);
    //        titleCapa.Alignment = Element.ALIGN_CENTER;
    //        titleCapa.SpacingAfter = 30f;
    //        document.Add(titleCapa);

    //        // Informações do relatório
    //        // Informações do relatório
    //        Paragraph infoRelatorio = new Paragraph(
    //            $"Data de emissão: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}\n\n" +
    //            $"Setor responsável: {setorUsuario}\n" +
    //            $"Emitido por: {emailUsuario}",
    //            infoFontCapa);

    //        infoRelatorio.Alignment = Element.ALIGN_CENTER;
    //        infoRelatorio.SpacingAfter = 50f;
    //        document.Add(infoRelatorio);

    //        // Rodapé da capa
    //        Paragraph footerCapa = new Paragraph(
    //            "Sistema de Gestão de Produção\n© 2025",
    //            FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY));

    //        footerCapa.Alignment = Element.ALIGN_CENTER;
    //        footerCapa.SpacingBefore = 100f;
    //        document.Add(footerCapa);

    //        // Fechamos a página da capa
    //        document.NewPage();

    //        // Agora mudamos para paisagem para a tabela
    //        document.SetPageSize(PageSize.A4.Rotate());

    //        // Fontes para o relatório principal
    //        iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.DARK_GRAY);
    //        iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
    //        iTextSharp.text.Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);
    //        iTextSharp.text.Font cellFontRed = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.RED);


    //        // Título da tabela
    //        Paragraph title = new Paragraph("DETALHES DAS ORDENS DE PRODUÇÃO", titleFont);
    //        title.Alignment = Element.ALIGN_CENTER;
    //        title.SpacingAfter = 10f;
    //        document.Add(title);

    //        // Informações de emissão
    //        Paragraph emissionInfo = new Paragraph(
    //            $"Emitido em: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")} | " +
    //            $"Setor: {setorUsuario} | " +
    //            $"Responsável: {emailUsuario}",
    //            FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY));

    //        emissionInfo.Alignment = Element.ALIGN_RIGHT;
    //        document.Add(emissionInfo);

    //        // Criar tabela de dados
    //        PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count);
    //        pdfTable.WidthPercentage = 100;
    //        pdfTable.SpacingBefore = 10f;
    //        pdfTable.SpacingAfter = 10f;

    //        // Configurar larguras das colunas (adaptar conforme necessário)
    //        float[] columnWidths = new float[dataGridView.Columns.Count];
    //        for (int i = 0; i < columnWidths.Length; i++)
    //        {
    //            columnWidths[i] = i < 5 ? 10f : 6f; // Primeiras colunas mais largas
    //        }
    //        pdfTable.SetWidths(columnWidths);

    //        // Cabeçalhos das colunas
    //        BaseColor headerColor = new BaseColor(51, 102, 153); // Azul escuro
    //        foreach (DataGridViewColumn column in dataGridView.Columns)
    //        {
    //            PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
    //            headerCell.BackgroundColor = headerColor;
    //            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //            headerCell.Padding = 5;
    //            headerCell.BorderWidth = 0.5f;
    //            pdfTable.AddCell(headerCell);
    //        }

    //        // Dados das células
    //        foreach (DataGridViewRow row in dataGridView.Rows)
    //        {
    //            foreach (DataGridViewCell cell in row.Cells)
    //            {
    //                PdfPCell pdfCell;

    //                if (cell.Value is System.Drawing.Image)
    //                {
    //                    // Processar imagem
    //                    System.Drawing.Image cellImage = (System.Drawing.Image)cell.Value;
    //                    using (MemoryStream ms = new MemoryStream())
    //                    {
    //                        cellImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    //                        iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
    //                        pdfImage.ScaleToFit(15f, 15f);
    //                        pdfCell = new PdfPCell(pdfImage);
    //                    }
    //                }
    //                else
    //                {
    //                    // Processar texto
    //                    string cellValue = cell.Value?.ToString() ?? "";

    //                    // Estilo condicional para datas inválidas
    //                    if ((cell.OwningColumn.HeaderText.Contains("Data de Entrega") &&
    //                        !string.IsNullOrEmpty(cellValue) &&
    //                        Convert.ToDateTime(cellValue) < DateTime.Now)) // Data inválida de exemplo
    //                    {
    //                        pdfCell = new PdfPCell(new Phrase(cellValue, cellFontRed));
    //                    }
    //                    else
    //                    {
    //                        pdfCell = new PdfPCell(new Phrase(cellValue, cellFont));
    //                    }
    //                }

    //                // Configurações comuns da célula
    //                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
    //                pdfCell.Padding = 5;
    //                pdfCell.BorderWidth = 0.25f;
    //                pdfCell.BorderColor = new BaseColor(200, 200, 200);

    //                pdfTable.AddCell(pdfCell);
    //            }
    //        }

    //        document.Add(pdfTable);

    //        // Rodapé
    //        Paragraph footer = new Paragraph(
    //            $"Sistema de Gestão de Produção - © 2025 | Emitido por: {emailUsuario}",
    //            FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY));

    //        footer.Alignment = Element.ALIGN_CENTER;
    //        footer.SpacingBefore = 20f;
    //        document.Add(footer);
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //    finally
    //    {
    //        document.Close();
    //    }
    //}


    //public void ExportarRelatorioEstilizado(DataGridView dataGridView, string filePath)
    //{

    //    // Configurações do documento
    //    Document document = new Document(PageSize.A4.Rotate(), 15, 15, 15, 15);

    //    try
    //    {
    //        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
    //        document.Open();

    //        // Especificando os namespaces completos para evitar ambiguidade
    //        iTextSharp.text.Font titleFont = iTextSharp.text.FontFactory.GetFont(
    //            iTextSharp.text.FontFactory.HELVETICA_BOLD,
    //            16,
    //            iTextSharp.text.BaseColor.DARK_GRAY);

    //        iTextSharp.text.Font headerFont = iTextSharp.text.FontFactory.GetFont(
    //            iTextSharp.text.FontFactory.HELVETICA_BOLD,
    //            10,
    //            iTextSharp.text.BaseColor.WHITE);

    //        iTextSharp.text.Font cellFont = iTextSharp.text.FontFactory.GetFont(
    //            iTextSharp.text.FontFactory.HELVETICA,
    //            9,
    //            iTextSharp.text.BaseColor.BLACK);
    //        iTextSharp.text.Font cellFont_Red = iTextSharp.text.FontFactory.GetFont(
    //            iTextSharp.text.FontFactory.HELVETICA,
    //            9,
    //            iTextSharp.text.BaseColor.RED);

    //        // Adicionar título ao documento
    //        iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(
    //            "RELATÓRIO DE ORDENS DE PRODUÇÃO",
    //            titleFont);

    //        title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
    //        title.SpacingAfter = 10f;
    //        document.Add(title);

    //        // Adicionar data de emissão
    //        iTextSharp.text.Paragraph emissionDate = new iTextSharp.text.Paragraph(
    //            $"Emitido em: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}",
    //            iTextSharp.text.FontFactory.GetFont(
    //                iTextSharp.text.FontFactory.HELVETICA,
    //                8,
    //                iTextSharp.text.BaseColor.GRAY));

    //        emissionDate.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
    //        document.Add(emissionDate);

    //        // Criar tabela
    //        PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count);
    //        pdfTable.WidthPercentage = 100;
    //        pdfTable.SpacingBefore = 10f;
    //        pdfTable.SpacingAfter = 10f;


    //        int totalColumns = dataGridView.Columns.Count;
    //        float[] columnWidths = new float[totalColumns];

    //        // Definir as larguras fixas para as primeiras colunas
    //        if (totalColumns > 0) columnWidths[0] = 12f;
    //        if (totalColumns > 1) columnWidths[1] = 20f;
    //        if (totalColumns > 2) columnWidths[2] = 10f;
    //        if (totalColumns > 3) columnWidths[3] = 10f;
    //        if (totalColumns > 4) columnWidths[4] = 10f;

    //        // Preencher o restante com 6f
    //        for (int i = 5; i < totalColumns; i++)
    //        {
    //            columnWidths[i] = 6f;
    //        }
    //        pdfTable.SetWidths(columnWidths);

    //        // Cabeçalhos das colunas
    //        BaseColor headerColor = new BaseColor(51, 102, 153); // Azul escuro

    //        foreach (DataGridViewColumn column in dataGridView.Columns)
    //        {
    //            PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, headerFont));
    //            headerCell.BackgroundColor = headerColor;
    //            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //            headerCell.Padding = 5;
    //            headerCell.BorderWidth = 0.5f;
    //            pdfTable.AddCell(headerCell);
    //        }

    //        // Dados das células
    //        foreach (DataGridViewRow row in dataGridView.Rows)
    //        {
    //            foreach (DataGridViewCell cell in row.Cells)
    //            {
    //                PdfPCell pdfCell;

    //                if (cell.Value is System.Drawing.Image)
    //                {
    //                    // Processar imagem
    //                    System.Drawing.Image cellImage = (System.Drawing.Image)cell.Value;
    //                    using (MemoryStream ms = new MemoryStream())
    //                    {
    //                        cellImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    //                        iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
    //                        pdfImage.ScaleToFit(15f, 15f);
    //                        pdfCell = new PdfPCell(pdfImage);
    //                    }
    //                }
    //                else
    //                {
    //                    // Processar texto
    //                    string cellValue = cell.Value?.ToString() ?? "";

    //                    // Estilo condicional para datas inválidas
    //                    if ((cell.OwningColumn.HeaderText.Contains("Data de Entrega") &&
    //                        !string.IsNullOrEmpty(cellValue) &&
    //                        Convert.ToDateTime(cellValue) < DateTime.Now)) // Data inválida de exemplo
    //                    {
    //                        pdfCell = new PdfPCell(new Phrase(cellValue, cellFont_Red));
    //                    }
    //                    else
    //                    {
    //                        pdfCell = new PdfPCell(new Phrase(cellValue, cellFont));
    //                    }
    //                }

    //                // Configurações comuns da célula
    //                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
    //                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
    //                pdfCell.Padding = 5;
    //                pdfCell.BorderWidth = 0.25f;
    //                pdfCell.BorderColor = new BaseColor(200, 200, 200);

    //                pdfTable.AddCell(pdfCell);
    //            }
    //        }

    //        document.Add(pdfTable);

    //        // Rodapé
    //        Paragraph footer = new Paragraph("Sistema de Gestão de Produção - © 2025",
    //                               FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.GRAY));
    //        footer.Alignment = Element.ALIGN_CENTER;
    //        footer.SpacingBefore = 20f;
    //        document.Add(footer);
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show($"Erro ao gerar relatório: {ex.Message}");
    //    }
    //    finally
    //    {
    //        document.Close();
    //    }
    //}
}

