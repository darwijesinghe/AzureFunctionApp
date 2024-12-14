namespace App.Models.Response
{
    /// <summary>
    /// Response class for the methods
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Indicates operation is done or failed
        /// </summary>
        public bool Success   { get; set; } = false;

        /// <summary>
        /// Response message
        /// </summary>
        public string Message { get; set; } = "Ok";
    }

    /// <summary>
    /// Generic response class
    /// </summary>
    public class Result<T> where T : class
    {
        /// <summary>
        /// Indicates operation is done or failed
        /// </summary>
        public bool Success   { get; set; } = false;

        /// <summary>
        /// Response message
        /// </summary>
        public string Message { get; set; } = "Ok";

        // Extra fields -------------------
        public T Data         { get; set; }
    }
}
