using System;
using System.Text.RegularExpressions;

namespace CaesarCipherDecryption
{
    /// <summary>
    /// A class responsible for handling user input operations for the Caesar Cipher decryption process.
    /// </summary>
    public class InputHandler
    {
        /// <summary>
        /// Prompts the user to enter the encrypted message and validates the input.
        /// Only lowercase alphabetic characters are accepted.
        /// </summary>
        /// <returns>The validated encrypted message as a string.</returns>
        public string GetCipherText()
        {
            string? input = null;

            while (input == null || !IsValidInput(input))
            {
                Console.WriteLine("Enter the encrypted message (only lowercase letters allowed):");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !IsValidInput(input))
                {
                    Console.WriteLine("Invalid input. Please enter only lowercase alphabetic characters (a-z) with no spaces or special symbols.");
                    input = null; // Reset input to trigger the loop again
                }
            }

            return input!;
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
