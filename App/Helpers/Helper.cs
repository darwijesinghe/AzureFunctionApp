using System.Text.Json;

namespace App.Helpers
{
    /// <summary>
    /// Provides helper methods that can be used across the application.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Checks whether the provided string is a valid JSON string.
        /// </summary>
        /// <param name="json">The string to validate as JSON.</param>
        /// <returns>
        /// <c>True</c> if the string is valid JSON, otherwise <c>false</c>.
        /// </returns>
        public static bool IsValidJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return false;
            }

            try
            {
                // attempts to parse the JSON string
                JsonDocument.Parse(json);
                return true;
            }
            catch (JsonException)
            {
                // if an exception occurs, it's not valid JSON
                return false;
            }
        }
    }
}
