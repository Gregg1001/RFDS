using NUnit.Framework;
using CaesarCipherDecryption; // Ensure you add this reference

namespace CaesarCipherDecryption.Tests
{
    [TestFixture]
    public class CaesarCipherDecryptorTests
    {
        private CaesarCipherDecryptor _decryptor;

        [SetUp]
        public void SetUp()
        {
            // Create an instance of the decryptor before each test
            _decryptor = new CaesarCipherDecryptor();
        }

        [Test]
        public void Decrypt_ShouldReturnCorrectPlaintext_ForSimpleCiphertext()
        {
            // Arrange
            string cipherText = "def"; // 'd' -> 'g', 'e' -> 'h', 'f' -> 'i'
            string expectedPlainText = "ghi";

            // Act
            string actualPlainText = _decryptor.Decrypt(cipherText);

            // Assert
            Assert.AreEqual(expectedPlainText, actualPlainText);
        }

        [Test]
        public void Decrypt_ShouldHandleWraparoundCorrectly()
        {
            // Arrange
            string cipherText = "xyz"; // 'x' -> 'a', 'y' -> 'b', 'z' -> 'c'
            string expectedPlainText = "abc";

            // Act
            string actualPlainText = _decryptor.Decrypt(cipherText);

            // Assert
            Assert.AreEqual(expectedPlainText, actualPlainText);
        }

        [Test]
        public void Decrypt_ShouldIgnoreNonAlphabeticCharacters()
        {
            // Arrange
            string cipherText = "d3f g!"; // Only 'd' and 'f' are alphabetic
            string expectedPlainText = "g3i j!";

            // Act
            string actualPlainText = _decryptor.Decrypt(cipherText);

            // Assert
            Assert.AreEqual(expectedPlainText, actualPlainText);
        }
    }
}
