using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace App.Utilities
{
    /// <summary>
    /// Provides utility methods and helpers that can be used across the application.
    /// </summary>
    public static class Convertor
    {
        /// <summary>
        /// Writes the specified DataTable to an Excel file with a designated sheet name.
        /// </summary>
        /// <param name="table">The source data to write the Excel file.</param>
        /// <returns>
        /// A <see cref="byte[]"/> representing the generated Excel file, which can be saved or streamed as needed.
        /// </returns>
        public static async Task<byte[]> ConvertDataTableToExcel(DataTable table)
        {
            try
            {
                // creates a workbook for .xlsx files
                IWorkbook workbook = new XSSFWorkbook();

                // creates a sheet with the given name
                ISheet sheet = workbook.CreateSheet("Sheet1");

                // writes the table to the sheet
                WriteSheet(table, sheet);

                // writes the workbook to a memory stream and return the byte array
                await using var memoryStream = new MemoryStream();
                workbook.Write(memoryStream);
                return memoryStream.ToArray();
            }
            catch (Exception ex)
            {
                // returns an empty byte array in case of an error
                return Array.Empty<byte>();
            }
        }

        /// <summary>
        /// Writes the contents of the specified DataTable to the provided Excel sheet.
        /// </summary>
        /// <param name="dataTable">The DataTable containing the data to be written to the sheet.</param>
        /// <param name="sheet">The Excel sheet where the DataTable's contents will be written.</param>
        private static void WriteSheet(DataTable dataTable, ISheet sheet)
        {
            try
            {
                // creates header row
                IRow headerRow = sheet.CreateRow(0);

                // sets the header values
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    var cell = headerRow.CreateCell(i);
                    cell.SetCellValue(dataTable.Columns[i].ColumnName);
                }

                // populates rest of data
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    // creates data row
                    IRow dataRow = sheet.CreateRow(i + 1);

                    // adds cell values
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        // data table cell value
                        var cellValue = dataTable.Rows[i][j];

                        // crates new cell
                        var cell      = dataRow.CreateCell(j);

                        // handles null values
                        if (cellValue == DBNull.Value || cellValue == null)
                            cellValue = dataTable.Columns[j].DataType == typeof(string) ? string.Empty : 0;

                        // sets the cell value
                        cell.SetCellValue(cellValue.ToString());
                    }

                    // adjusts column widths for all columns after populating data
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                        sheet.AutoSizeColumn(col);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
