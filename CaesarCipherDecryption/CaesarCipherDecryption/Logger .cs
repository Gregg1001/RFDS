using System;
using System.IO;

namespace CaesarCipherDecryption
{
    /// <summary>
    /// logger class to write logs to a file.
    /// </summary>
    public static class Logger
    {
        private static readonly string logFilePath = "application.log";

        /// <summary>
        /// Logs a message with the current timestamp.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Log(string message)
        {
            try
            {
                using (var writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
}
