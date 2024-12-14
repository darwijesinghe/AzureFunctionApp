using App.Models.Response;
using App.Services.Interfaces;
using App.Utilities;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Threading.Tasks;

namespace App.Services.Classes
{
    /// <summary>
    /// Implements IConvertService interface methods.
    /// </summary>
    public class ConvertService : IConvertService
    {
        // Services
        private readonly ILogger<ConvertService> _logger;

        public ConvertService(ILogger<ConvertService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Converts the specified <see cref="DataTable"/> into an Excel file.
        /// </summary>
        /// <param name="table">The <see cref="DataTable"/> containing the data to be converted to an Excel file.</param>
        /// <returns>
        /// A <see cref="Result{T}"/> object containing a byte array representing the Excel file. 
        /// If the conversion is successful, <c>Success</c> will be <c>true</c>, and the <c>Data</c> property will contain the file bytes.
        /// If the conversion fails or the input table is empty, <c>Success</c> will be <c>false</c>, and an appropriate message will be provided in the <c>Message</c> property.
        /// </returns>
        public async Task<Result<byte[]>> ConvertDataTableToExcel(DataTable table)
        {
            if (table == null || table.Rows.Count <= 0)
                return new Result<byte[]>();

            // gets the file result
            var fileBytes = await Convertor.ConvertDataTableToExcel(table);
            if (fileBytes.Length == 0)
                return new Result<byte[]> { Success = false, Message = "File conversion failed." };

            // returns the result
            return new Result<byte[]> { Success = true, Data = fileBytes };
        }
    }
}
