using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using OfficeOpenXml;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Notas_Unison.ViewModel;
using Notas_Unison_Core.Modelos;

namespace Notas_Unison.Pages;

public partial class ListaDeNotas : Page
{
    private readonly NotaViewModel _viewModel;

    public ListaDeNotas()
    {
        InitializeComponent();
        _viewModel = App.Current.Services.GetRequiredService<NotaViewModel>();
        DataContext = _viewModel;
    }

    private void GoToNuevaNota(object sender, RoutedEventArgs e)
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;
        mainWindow?.MainFrame.Navigate(new NuevaNota(_viewModel));
    }

    private void ImportarNotas(object sender, RoutedEventArgs e)
    {
        try
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos Excel (*.xlsx)|*.xlsx",
                Title = "Seleccionar archivo Excel para importar"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var package = new ExcelPackage(new FileInfo(openFileDialog.FileName));
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension?.Rows ?? 0;

                for (int row = 2; row <= rowCount; row++) // Empezamos en 2 para saltar el encabezado
                {
                    var titulo = worksheet.Cells[row, 1].Text;
                    var contenido = worksheet.Cells[row, 2].Text;
                    var color = worksheet.Cells[row, 3].Text;

                    if (!string.IsNullOrWhiteSpace(titulo) && !string.IsNullOrWhiteSpace(contenido))
                    {
                        var nota = new Nota
                        {
                            Id = Guid.NewGuid(),
                            Titulo = titulo,
                            Contenido = contenido,
                            Colorin = !string.IsNullOrWhiteSpace(color) ? color : "#FFF4B0" // Color amarillo por defecto
                        };

                        _viewModel.Nota = nota;
                        _viewModel.AgregarNotaCommand.Execute(null);
                    }
                }

                MessageBox.Show("Notas importadas correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al importar las notas: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ExportarNotas(object sender, RoutedEventArgs e)
    {
        try
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos Excel (*.xlsx)|*.xlsx",
                Title = "Guardar notas como Excel",
                FileName = "Mis Notas.xlsx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var package = new ExcelPackage();
                var worksheet = package.Workbook.Worksheets.Add("Notas");

                // Agregar encabezados
                worksheet.Cells["A1"].Value = "Título";
                worksheet.Cells["B1"].Value = "Contenido";
                worksheet.Cells["C1"].Value = "Color";

                // Estilo para encabezados
                var headerRange = worksheet.Cells["A1:C1"];
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                // Agregar datos
                var row = 2;
                foreach (var nota in _viewModel.Notas)
                {
                    worksheet.Cells[row, 1].Value = nota.Titulo;
                    worksheet.Cells[row, 2].Value = nota.Contenido;
                    worksheet.Cells[row, 3].Value = nota.Colorin;
                    row++;
                }

                // Autoajustar columnas
                worksheet.Cells.AutoFitColumns();

                // Guardar archivo
                var file = new FileInfo(saveFileDialog.FileName);
                package.SaveAs(file);

                MessageBox.Show("Notas exportadas correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al exportar las notas: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}