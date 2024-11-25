using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipherDecryption
{
    /// <summary>
    /// A class responsible for handling output operations related to decrypted messages.
    /// </summary>
    public class OutputHandler
    {
        /// <summary>
        /// Displays the decrypted message to the console.
        /// </summary>
        /// <param name="plainText">The plaintext message that has been decrypted.</param>
        public void DisplayDecryptedMessage(string plainText)
        {
            Console.WriteLine($"Decrypted message: {plainText}");
        }
    }
}
