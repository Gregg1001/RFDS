namespace CaesarCipherDecryption
{
    public class CaesarCipherDecryptor
    {
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
