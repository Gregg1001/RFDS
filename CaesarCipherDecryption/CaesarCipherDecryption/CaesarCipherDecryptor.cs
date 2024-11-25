namespace CaesarCipherDecryption
{
    /// <summary>
    /// A class that provides functionality to decrypt text encrypted with the Caesar Cipher method.
    /// </summary>
    public class CaesarCipherDecryptor
    {
        /// <summary>
        /// Decrypts the provided ciphertext by reversing the Caesar Cipher encryption process.
        /// </summary>
        /// <param name="cipherText">The encrypted string that needs to be decrypted.</param>
        /// <returns>The original decrypted message as plaintext.</returns>
        public string Decrypt(string cipherText)
        {
            char[] decryptedText = new char[cipherText.Length];

            for (int i = 0; i < cipherText.Length; i++)
            {
                if (cipherText[i] >= 'a' && cipherText[i] <= 'z')
                {
                    decryptedText[i] = DecryptChar(cipherText[i]);
                }
                else
                {
                    // Keep characters unchanged if they are not lowercase letters
                    decryptedText[i] = cipherText[i];
                }
            }

            return new string(decryptedText);
        }

        /// <summary>
        /// Decrypts a single character by shifting it three positions to the right in the alphabet, including wraparound.
        /// </summary>
        /// <param name="ch">The character to decrypt.</param>
        /// <returns>The decrypted character after shifting 3 positions in the alphabet.</returns>
        private char DecryptChar(char ch)
        {
            // Shift character 3 positions to the right in the alphabet
            int shiftedChar = ch + 3;

            // Wraparound logic for characters beyond 'z'
            if (shiftedChar > 'z')
            {
                shiftedChar -= 26; // Wrap around to the beginning of the alphabet
            }

            return (char)shiftedChar;
        }
    }
}
