using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipherDecryption
{
    public class OutputHandler
    {
        public void DisplayDecryptedMessage(string plainText)
        {
            Console.WriteLine($"Decrypted message: {plainText}");
        }
    }
}
