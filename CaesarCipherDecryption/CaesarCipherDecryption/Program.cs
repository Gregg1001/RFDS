
namespace CaesarCipherDecryption
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of each handler
            InputHandler inputHandler = new InputHandler();
            CaesarCipherDecryptor decryptor = new CaesarCipherDecryptor();
            OutputHandler outputHandler = new OutputHandler();

            // Process input, decryption, and output
            string cipherText = inputHandler.GetCipherText();
            string plainText = decryptor.Decrypt(cipherText);
            outputHandler.DisplayDecryptedMessage(plainText);
        }
    }
}
