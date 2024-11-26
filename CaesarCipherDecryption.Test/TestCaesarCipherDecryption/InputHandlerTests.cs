using NUnit.Framework;
using CaesarCipherDecryption;
using System.IO;

namespace CaesarCipherDecryption.Tests
{
    [TestFixture]
    public class InputHandlerTests
    {
        private InputHandler _inputHandler;

        [SetUp]
        public void SetUp()
        {
            _inputHandler = new InputHandler();
        }

        [Test]
        public void IsValidInput_ShouldReturnTrue_ForValidLowercaseString()
        {
            // Arrange
            string validInput = "abcxyz";

            // Act
            bool isValid = _inputHandler.IsValidInput(validInput);

            // Assert
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void IsValidInput_ShouldReturnFalse_ForInputWithUppercaseLetters()
        {
            // Arrange
            string invalidInput = "AbcXyz";

            // Act
            bool isValid = _inputHandler.IsValidInput(invalidInput);

            // Assert
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void IsValidInput_ShouldReturnFalse_ForInputWithNumbers()
        {
            // Arrange
            string invalidInput = "abc123";

            // Act
            bool isValid = _inputHandler.IsValidInput(invalidInput);

            // Assert
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void IsValidInput_ShouldReturnFalse_ForInputWithSpecialCharacters()
        {
            // Arrange
            string invalidInput = "abc!@#";

            // Act
            bool isValid = _inputHandler.IsValidInput(invalidInput);

            // Assert
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void IsValidInput_ShouldReturnFalse_ForEmptyString()
        {
            // Arrange
            string invalidInput = "";

            // Act
            bool isValid = _inputHandler.IsValidInput(invalidInput);

            // Assert
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void GetCipherText_ShouldReturnValidLowercaseString_WhenGivenValidInput()
        {
            // Arrange
            using (var stringReader = new StringReader("abcxyz"))
            {
                Console.SetIn(stringReader);

                // Act
                string result = _inputHandler.GetCipherText();

                // Assert
                Assert.That(result, Is.EqualTo("abcxyz"));
            }
        }

        [Test]
        public void GetCipherText_ShouldPromptUntilValidInput_WhenGivenInvalidThenValidInput()
        {
            // Arrange
            string inputSequence = "123\nAbcXyz\nabcxyz\n"; // Invalid inputs followed by valid input
            using (var stringReader = new StringReader(inputSequence))
            {
                Console.SetIn(stringReader);

                // Act
                string result = _inputHandler.GetCipherText();

                // Assert
                Assert.That(result, Is.EqualTo("abcxyz"));
            }
        }
    }
}
