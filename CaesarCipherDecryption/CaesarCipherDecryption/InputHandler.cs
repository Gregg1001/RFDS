using System;
using System.Text.RegularExpressions;

namespace CaesarCipherDecryption
{
    /// <summary>
    /// A class responsible for handling user input operations for the Caesar Cipher decryption process.
    /// </summary>
    public class InputHandler
    {
        private const string InvalidInputMessage = "Invalid input. Please enter only lowercase alphabetic characters (a-z) with no spaces or special symbols.";
        private const string PromptMessage = "Enter the encrypted message (only lowercase letters allowed), or type 'exit' to quit:";

        /// <summary>
        /// Prompts the user to enter the encrypted message and validates the input.
        /// Only lowercase alphabetic characters are accepted.
        /// </summary>
        /// <returns>The validated encrypted message as a string, or null if the user exits.</returns>
        public string? GetCipherText()
        {
            string? input = null;

            while (input == null || !IsValidInput(input))
            {
                Console.WriteLine(PromptMessage);
                try
                {
                    input = Console.ReadLine();

                    if (input?.ToLower() == "exit")
                    {
                        Console.WriteLine("Exiting the program...");
                        return null; // Exit the loop and the program
                    }

                    if (string.IsNullOrEmpty(input) || !IsValidInput(input))
                    {
                        Console.WriteLine(InvalidInputMessage);
                        input = null; // Reset input to trigger the loop again
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while reading input: {ex.Message}");
                    input = null; // Continue prompting the user
                }
            }

            return input;
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
