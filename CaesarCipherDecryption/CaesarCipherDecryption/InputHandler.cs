using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace CaesarCipherDecryption
{
    /// <summary>
    /// A class responsible for handling user input operations for the Caesar Cipher decryption process.
    /// </summary>
    public class InputHandler
    {
        private const string InvalidInputMessage = "Invalid input. Please enter only lowercase alphabetic characters (a-z) with no spaces or special symbols.";
        private const string PromptMessage = "Enter the encrypted message (only lowercase letters allowed), or type 'exit' to quit:";
        private const int InputTimeoutMilliseconds = 30000; // 30-second timeout

        private string? _inputBuffer = null;

        /// <summary>
        /// Prompts the user to enter the encrypted message and validates the input.
        /// Only lowercase alphabetic characters are accepted. Includes a timeout mechanism.
        /// </summary>
        /// <returns>The validated encrypted message as a string, or null if the user exits or times out.</returns>
        public string? GetCipherText()
        {
            string? input = null;

            while (input == null || !IsValidInput(input))
            {
                Console.WriteLine(PromptMessage);
                try
                {
                    input = GetUserInputWithTimeout();

                    if (input == null)
                    {
                        Console.WriteLine("Input timed out. Exiting the program...");
                        Logger.Log("[INFO] User input timed out. Exiting the program.");
                        return null; // Exit the program due to timeout
                    }

                    // Handle exit command
                    if (input.ToLower() == "exit")
                    {
                        Logger.Log("[INFO] User chose to exit the program.");
                        Console.WriteLine("Exiting the program...");
                        return null; // Exit the loop and the program
                    }

                    // Sanitize and validate input
                    input = input.Trim();
                    if (string.IsNullOrWhiteSpace(input) || !IsValidInput(input))
                    {
                        Logger.Log($"[WARN] Invalid input received: \"{input}\"");
                        Console.WriteLine(InvalidInputMessage);
                        input = null; // Reset input to trigger the loop again
                    }
                }
                catch (IOException ioEx)
                {
                    Logger.Log($"[ERROR] IOException occurred while reading input: {ioEx.Message}");
                    Console.WriteLine("An error occurred while reading your input. Please try again.");
                    input = null; // Reset input to trigger the loop again
                }
                catch (Exception ex)
                {
                    Logger.Log($"[ERROR] Unexpected error occurred: {ex.Message}");
                    Console.WriteLine("An unexpected error occurred. Please try again.");
                    input = null; // Reset input to trigger the loop again
                }
            }

            Logger.Log($"[INFO] Valid input received: \"{input}\"");
            return input;
        }

        /// <summary>
        /// Waits for user input with a specified timeout.
        /// </summary>
        /// <returns>User input as a string or null if the input times out.</returns>
        private string? GetUserInputWithTimeout()
        {
            _inputBuffer = null;

            Thread inputThread = new Thread(() =>
            {
                _inputBuffer = Console.ReadLine();
            });

            inputThread.Start();

            bool inputReceived = inputThread.Join(InputTimeoutMilliseconds);
            if (inputReceived)
            {
                return _inputBuffer;
            }
            else
            {
                return null; // Timeout occurred
            }
        }

        /// <summary>
        /// Validates whether the provided input contains only lowercase alphabetic characters.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the input is valid; otherwise, false.</returns>
        public bool IsValidInput(string input)
        {
            // Check if input contains only lowercase letters
            return Regex.IsMatch(input, @"^[a-z]+$");
        }
    }
}
