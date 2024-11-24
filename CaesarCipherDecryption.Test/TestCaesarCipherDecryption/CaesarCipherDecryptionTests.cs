using NUnit.Framework;
using CaesarCipherDecryption;

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
            string cipherText = "abc"; // 'a' -> 'd', 'b' -> 'e', 'c' -> 'f'
            string expectedPlainText = "def";

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
            string cipherText = "a1b.c!"; // Only 'a', 'b', 'c' are alphabetic
            string expectedPlainText = "d1e.f!"; // 'a' -> 'd', 'b' -> 'e', 'c' -> 'f'

            // Act
            string actualPlainText = _decryptor.Decrypt(cipherText);

            // Assert
            Assert.AreEqual(expectedPlainText, actualPlainText);
        }

        [Test]
        public void Decrypt_ShouldHandleEmptyString()
        {
            // Arrange
            string cipherText = ""; // Empty string
            string expectedPlainText = ""; // Should remain empty

            // Act
            string actualPlainText = _decryptor.Decrypt(cipherText);

            // Assert
            Assert.AreEqual(expectedPlainText, actualPlainText);
        }

        [Test]
        public void Decrypt_ShouldReturnCorrectPlaintext_ForFullAlphabet()
        {
            // Arrange
            string cipherText = "abcdefghijklmnopqrstuvwxyz";
            string expectedPlainText = "defghijklmnopqrstuvwxyzabc";

            // Act
            string actualPlainText = _decryptor.Decrypt(cipherText);

            // Assert
            Assert.AreEqual(expectedPlainText, actualPlainText);
        }
    }
}
