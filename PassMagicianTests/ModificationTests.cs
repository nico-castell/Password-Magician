using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassMagician;

namespace PassMagicianTests
{
    [TestClass]
    public class ModificationTests
    {
        [TestMethod]
        public void Generator_ShouldOutputCorrectly()
        {
            // Arrange
            Generator generator = new Generator();
            int passl = 8;
            // Act
            string output = generator.GeneratePass(passl);
            int outputLength = output.Length;
            // Assert
            if (outputLength < 1)
                Assert.Fail("The generator should output something.");
            else if (outputLength > passl)
                Assert.Fail($"The generator should not output a longer than requested password.\nIt outputted {outputLength} of {passl} characters.");
            return;
        }

        [TestMethod]
        public void Obfuscator_ShouldGeneratePasswordOfSameLength()
        {
            // Arrange
            Obfuscator obfuscator = new Obfuscator();
            string pass = "3X^Y9!ja)%NVK`=N";
            // Act
            string output = obfuscator.ObfuscatePass(pass);
            // Assert
            if (output.Length != pass.Length)
                Assert.Fail($"Obfuscator should output a string of the same length as it's input.\nIt outputted {output.Length} of {pass.Length} characters.");
        }
    }
}
