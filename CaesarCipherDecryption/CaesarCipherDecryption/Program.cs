namespace CaesarCipherDecryption
{
    /// <summary>
    /// This class contains the entry point of the application where input is taken, processed, and outputted.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point of the CaesarCipherDecryption application.
        /// Creates instances of handlers to get input, decrypt the message, and display the result.
        /// </summary>
        /// <param name="args">Command line arguments (not used in this application).</param>
        static void Main(string[] args)
        {
            // Create instances of each handler
            var inputHandler = new InputHandler();
            var decryptor = new CaesarCipherDecryptor();
            var outputHandler = new OutputHandler();

            // Process input, decryption, and output
            string cipherText = inputHandler.GetCipherText();
            string plainText = decryptor.Decrypt(cipherText);
            outputHandler.DisplayDecryptedMessage(plainText);
        }
    }
}
