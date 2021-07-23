using GemBox.Spreadsheet;

namespace DamData
{
    class ExcelFileReader
    {
        string filePath = @"C:\Users\IArch\Documents\C#\QuintessenceInternship\InternProjects\DamData\DamData\DamDataFile.xlsx";
        private string fileContents = "";

        public string GetExcelFileContents() => this.fileContents;

        public void OpenAndReadFile()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile workbook = ExcelFile.Load(filePath);

            foreach (ExcelWorksheet worksheet in workbook.Worksheets)
                foreach (ExcelRow row in worksheet.Rows)
                {
                    foreach (ExcelCell cell in row.AllocatedCells)
                        fileContents += cell?.Value;
                    fileContents += "\n"; //Add a newline at the end of every row
                }
        }
    }
}
