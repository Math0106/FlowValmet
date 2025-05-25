using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;

public class ExportarExcel : IDisposable
{
    private Excel.Application _excelApp;
    private Excel.Workbook _workbook;
    private Excel.Worksheet _worksheet;
    private bool _disposed = false;

    public void ExportToExcel(DataGridView dataGridView, string filePath)
    {
        InitializeExcelApplication();

        try
        {
            ExportData(dataGridView);
            SaveWorkbook(filePath);
            ShowSuccessMessage();
        }
        catch (Exception ex)
        {
            HandleExportError(ex);
            throw; // Re-throw para permitir tratamento adicional se necessário
        }
    }

    private void InitializeExcelApplication()
    {
        _excelApp = new Excel.Application();
        _workbook = _excelApp.Workbooks.Add();
        _worksheet = (Excel.Worksheet)_workbook.ActiveSheet;
    }

    private void ExportData(DataGridView dataGridView)
    {
        for (int row = 0; row < dataGridView.Rows.Count; row++)
        {
            for (int col = 0; col < dataGridView.Columns.Count; col++)
            {
                ExportCell(dataGridView.Rows[row].Cells[col], row + 1, col + 1);
            }
        }
    }

    private void ExportCell(DataGridViewCell cell, int excelRow, int excelCol)
    {
        Excel.Range excelCell = (Excel.Range)_worksheet.Cells[excelRow, excelCol];

        if (cell.Value is Image image)
        {
            ExportImageToExcel(image, excelCell);
        }
        else
        {
            excelCell.Value = cell.Value?.ToString();
        }
    }

    private void ExportImageToExcel(Image image, Excel.Range cell)
    {
        string tempFile = Path.GetTempFileName() + ".png";
        try
        {
            image.Save(tempFile, ImageFormat.Png);
            InsertPicture(tempFile, cell);
        }
        finally
        {
            SafeDeleteTempFile(tempFile);
        }
    }

    private void InsertPicture(string imagePath, Excel.Range cell)
    {
        float left = (float)(double)cell.Left;
        float top = (float)(double)cell.Top;
        float width = (float)(double)cell.Width;
        float height = (float)(double)cell.Height;

        Excel.Shape picture = _worksheet.Shapes.AddPicture(
            imagePath,
            MsoTriState.msoFalse,
            MsoTriState.msoTrue,
            left, top, width, height);

        ConfigurePicture(picture, left, top, width, height);
    }

    private void ConfigurePicture(Excel.Shape picture, float left, float top, float width, float height)
    {
        picture.LockAspectRatio = MsoTriState.msoTrue;
        picture.Left = left + (width - picture.Width) / 2;
        picture.Top = top + (height - picture.Height) / 2;
    }

    private void SaveWorkbook(string filePath)
    {
        _workbook.SaveAs(filePath);
    }

    private void ShowSuccessMessage()
    {
        MessageBox.Show("Exportação concluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void HandleExportError(Exception ex)
    {
        MessageBox.Show($"Erro ao exportar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void SafeDeleteTempFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        catch
        {
            // Silenciosamente falha se não puder deletar o arquivo temporário
        }
    }

    #region IDisposable Implementation

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Liberar recursos gerenciados
                if (_workbook != null)
                {
                    _workbook.Close(false);
                    Marshal.ReleaseComObject(_workbook);
                    _workbook = null;
                }

                if (_excelApp != null)
                {
                    _excelApp.Quit();
                    Marshal.ReleaseComObject(_excelApp);
                    _excelApp = null;
                }

                if (_worksheet != null)
                {
                    Marshal.ReleaseComObject(_worksheet);
                    _worksheet = null;
                }
            }

            _disposed = true;
        }
    }

    ~ExportarExcel()
    {
        Dispose(false);
    }

    #endregion
}