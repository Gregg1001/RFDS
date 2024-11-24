using System;

namespace CaesarCipherDecryption
{
    public class InputHandler
    {
        public string GetCipherText()
        {
            Console.WriteLine("Enter the encrypted message:");
            return Console.ReadLine();
        }
    }
}
