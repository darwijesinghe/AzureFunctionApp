using App.Models.Response;
using System.Data;
using System.Threading.Tasks;

namespace App.Services.Interfaces
{
    /// <summary>
    /// Provides service methods that can be used across the application.
    /// </summary>
    public interface IConvertService
    {
        /// <summary>
        /// Converts the specified <see cref="DataTable"/> into an Excel file.
        /// </summary>
        /// <param name="table">The <see cref="DataTable"/> containing the data to be converted to an Excel file.</param>
        /// <returns>
        /// A <see cref="Result{T}"/> object containing a byte array representing the Excel file. 
        /// If the conversion is successful, <c>Success</c> will be <c>true</c>, and the <c>Data</c> property will contain the file bytes.
        /// If the conversion fails or the input table is empty, <c>Success</c> will be <c>false</c>, and an appropriate message will be provided in the <c>Message</c> property.
        /// </returns>
        Task<Result<byte[]>> ConvertDataTableToExcel(DataTable table);
    }
}
