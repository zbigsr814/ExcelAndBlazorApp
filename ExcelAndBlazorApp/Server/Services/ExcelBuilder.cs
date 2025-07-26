using ExcelAndBlazorApp.Dtos;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExcelAndBlazorApp.Services
{
    public static class ExcelBuilder
    {
        public static byte[] GetExcel(List<Summary> summaries) 
        {
            // Ustaw licencji EPPlus
            ExcelPackage.License.SetNonCommercialPersonal("Jan Kowalski");

            // tworzenie pliku i arkusza
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Summary");

            // nagłówki tabeli
            worksheet.Cells[1, 1].Value = "Data";
            worksheet.Cells[1, 2].Value = "Koszt pracowników [zł]";
            worksheet.Cells[1, 3].Value = "Koszt materiałów [zł]";
            worksheet.Cells[1, 4].Value = "Dochód firmy [zł]";
            worksheet.Cells[1, 5].Value = "Przychód brutto [zł]";
            worksheet.Cells[1, 6].Value = "Przychód netto [zł]";

            // stylowanie nagłówków
            var range = worksheet.Cells[1, 1, 1, 6];
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // seedowanie danych
            int row = 2;
            foreach (var summary in summaries)
            {
                worksheet.Cells[row, 1].Value = summary.YearMonth.ToString();
                worksheet.Cells[row, 2].Value = summary.EmployeesExpenses;
                worksheet.Cells[row, 3].Value = summary.OrdersExpenses;
                worksheet.Cells[row, 4].Value = summary.CompanyIncomes;
                worksheet.Cells[row, 5].Value = summary.ProfitBrutto;
                worksheet.Cells[row, 6].Value = summary.ProfitNetto;
                row++;
            }

            worksheet.Columns.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            worksheet.Columns.AutoFit();

            // dodanie podsumowania
            worksheet.Cells[row, 1].Value = "Podsumowanie";
            worksheet.Cells[row, 2].Formula = $"=SUM(B2:B{row-1})";
            worksheet.Cells[row, 3].Formula = $"=SUM(C2:C{row - 1})";
            worksheet.Cells[row, 4].Formula = $"=SUM(D2:D{row - 1})";
            worksheet.Cells[row, 5].Formula = $"=SUM(E2:E{row - 1})";
            worksheet.Cells[row, 6].Formula = $"=SUM(F2:F{row - 1})";

            // stylowanie podsumowania
            worksheet.Cells[row, 1].Style.Font.Bold = true;
            range = worksheet.Cells[row, 2, row, 6];
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.LightYellow);

            // dodanie wykresu kołowego
            var pieChart = worksheet.Drawings.AddPieChart("crtExtensionsSize", ePieChartType.PieExploded3D);
            pieChart.SetPosition(2, 0, 8, 0); // umieszczony poniżej danych
            pieChart.SetSize(600, 400);
            pieChart.Series.Add($"B{row}:D{row}", $"B1:D1");

            // stylowanie wykresu kołowego
            pieChart.Title.Text = "Zestawienie zysków";
            pieChart.DataLabel.ShowCategory = true;
            pieChart.DataLabel.ShowPercent = true;
            pieChart.DataLabel.ShowLeaderLines = true;
            pieChart.Legend.Remove();

            return package.GetAsByteArray();
        }
    }
}
