using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassMagician;

namespace PassMagicianTests
{
    /**
     * How this testing works:
     * Modifier Allowance:
     *   It tests that the validation method in the Modifier class, which validates if a certain type of character is being
     *   allowed by the user, works correctly. There are 3 levels of testing:
     *     Level 1: The user is only allowing 1 of 3 types.
     *     Level 2: The user is only allowing 2 of 3 types.
     *     Level 3: The user is allowing all 3 types.
     */
    [TestClass]
    public class ModifierAllowance
    {
        #region Prepare tests
        /// <summary>
        /// If the int corresponds to a letter in ASCII.
        /// </summary>
        /// <returns>True if it is, False if it isn't</returns>
        bool IsLetter(in int i)
        {
            if ((i > 64 && i < 91) || (i > 96 && i < 123))
                return true;
            return false;
        }
        /// <summary>
        /// If the int corresponds to a number in ASCII.
        /// </summary>
        /// <returns>True if it is, False if it isn't</returns>
        bool IsNumber(in int i)
        {
            if (i > 47 && i < 58)
                return true;
            return false;
        }
        /// <summary>
        /// If the int corresponds to a symbol in ASCII.
        /// </summary>
        /// <returns>True if it is, False if it isn't</returns>
        bool IsSymbol(in int i)
        {
            if ((i > 32 && i < 48) || (i > 57 && i < 65) || (i > 90 && i < 97) || (i > 122 && i < 127))
                return true;
            return false;
        }
        #endregion Prepare tests

        #region Modifier Allowance Level 1
        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 1")]
        public void ModifierAllowingOnlyLetters_ShouldOnlyAllowLetters()
        {
            // Arrange
            Modifier modifier = new Modifier
            {
                AllowLetters = true,
                AllowNumbers = false,
                AllowSymbols = false
            };
            // Act
            // Iterate through the ASCII table.
            for (int i = 33; i < 127; i++)
            {
                bool _IsLetter = IsLetter(i);
                bool _IsValid = modifier.ValidateChar(i);
                // If is not a Letter, and modifier says it's valid, there's a bug in the code.
                if (!_IsLetter && _IsValid) // Assert
                {
                    Assert.Fail($"It should allow letters only, but it's allowing '{(char)i}' {i}.");
                    return;
                }
                // If it's a letter, and modifier says it's not valid, there's a bug in the code.
                if (_IsLetter && !_IsValid) // Assert
                {
                    Assert.Fail($"It should allow letters, but it's not allowing '{(char)i}' {i}.");
                    return;
                }
            }
        }

        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 1")]
        public void ModifierAllowingOnlyNumbers_ShouldOnlyAllowNumbers()
        {
            // Arrange
            Modifier modifier = new Modifier
            {
                AllowLetters = false,
                AllowNumbers = true,
                AllowSymbols = false
            };
            // Act
            // Iterate through the ASCII table.
            for (int i = 33; i < 127; i++)
            {
                bool _IsNumber = IsNumber(i);
                bool _IsValid = modifier.ValidateChar(i);
                // If not a number, and modifier says it's valid, there's a bug in the code.
                if (!_IsNumber && _IsValid)
                {
                    Assert.Fail($"It should only allow numbers, but it's allowing '{(char)i}' {i}.");
                    return;
                }
                // If it is a number, and modifier says it's not valid, there's a bug in the code.
                if (_IsNumber && !_IsValid)
                {
                    Assert.Fail($"It should allow letters, but it's not allowing '{(char)i}' {i}.");
                    return;
                }
            }
        }

        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 1")]
        public void ModifierAllowingOnlySymbols_ShouldOnlyAllowSymbols()
        {
            // Arrange
            Modifier modifier = new Modifier
            {
                AllowLetters = false,
                AllowNumbers = false,
                AllowSymbols = true
            };
            // Act
            // Iterate through the ASCII table.
            for (int i = 33; i < 127; i++)
            {
                bool _IsSymbol = IsSymbol(i);
                bool _IsValid = modifier.ValidateChar(i);
                // If it is not a symbol, and modifier says it's valid, there's a bug in the code.
                if (!_IsSymbol && _IsValid)
                {
                    Assert.Fail($"It should only allow symbols, but it's allowing '{(char)i}' {i}.");
                    return;
                }
                // If it is a symbol, and modifier says it's not valid, there's a bug in the code.
                if (_IsSymbol && !_IsValid)
                {
                    Assert.Fail($"It should allow symbols, but it's not allowing '{(char)i}' {i}.");
                    return;
                }
            }
        }
        #endregion Modifer Allowance Level 1

        #region Modifier Allowance Level 2
        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 2")]
        public void ModifierAllowingOnlyLettersNumbers_ShouldOnlyAllowLettersNumbers()
        {
            // Arrange
            Modifier modifier = new Modifier
            {
                AllowLetters = true,
                AllowNumbers = true,
                AllowSymbols = false
            };
            // Act
            for (int i = 33; i < 127; i++)
            {
                bool _IsInRange = IsLetter(i) || IsNumber(i); // Wether it's a Letter or Number.
                bool _IsValid = modifier.ValidateChar(i);
                // If not in range, and modifier says it's valid, there's a bug in the code.
                if (!_IsInRange && _IsValid)
                {
                    Assert.Fail($"It should only allow letters and numbers, but it's allowing '{(char)i}' {i}.");
                    return;
                }
                // If in range, and modifier says it's not valid, there's a bug in the code.
                if (_IsInRange && !_IsValid)
                {
                    Assert.Fail($"It should allow letters and numbers, but it's not allowing '{(char)i}' {i}.");
                    return;
                }
            }
        }

        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 2")]
        public void ModifierAllowingOnlyNumbersSymbols_ShouldOnlyAllowNumbersSymbols()
        {
            // Arrange
            Modifier modifier = new Modifier
            {
                AllowLetters = false,
                AllowNumbers = true,
                AllowSymbols = true
            };
            // Act
            // Iterate through the ASCII table.
            for (int i = 33; i < 127; i++)
            {
                bool _IsInRange = IsNumber(i) || IsSymbol(i);
                bool _IsValid = modifier.ValidateChar(i);
                // If not in range, and modifier says it's valid, there's a bug in the code.
                if (!_IsInRange && _IsValid)
                {
                    Assert.Fail($"It should only allow numbers and symbols, but it's allowing '{(char)i}' {i}.");
                    return;
                }
                // If in range, and modifier says it's not valid, there's a bug in the code.
                if (_IsInRange && !_IsValid)
                {
                    Assert.Fail($"It should allow numbers and symbols, but it's not allowing '{(char)i}' {i}.");
                    return;
                }
            }
        }

        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 2")]
        public void ModifierAllowingOnlyLettersSymbols_ShouldOnlyAllowLettersSymbols()
        {
            // Arrange
            Modifier modifier = new Modifier
            {
                AllowLetters = true,
                AllowNumbers = false,
                AllowSymbols = true
            };
            // Act
            // Iterate through the ASCII table.
            for (int i = 33; i < 127; i++)
            {
                bool _IsInRange = IsLetter(i) || IsSymbol(i);
                bool _IsValid = modifier.ValidateChar(i);
                // If not in range, and modifier says it's valid, there's a bug in the code.
                if (!_IsInRange && _IsValid)
                {
                    Assert.Fail($"It should only allow letters and symbols, but it's allowing '{(char)i}' {i}.");
                    return;
                }
                // If in range, and modifier says it's not valid, there's a bug in the code.
                if (_IsInRange && !_IsValid)
                {
                    Assert.Fail($"It should allow letters and symbols, but it's not allowing '{(char)i}' {i}.");
                    return;
                }
            }
        }
        #endregion Modifier Allowance Level 2

        #region Modifier Allowance Level 3
        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 3")]
        public void ModifierAllowingEverything_ShouldAllowEverything()
        {
            // Arrange
            Modifier modifier = new Modifier(); // Defaults all allowances to 'true'.
            // Act
            for (int i = 33; i < 127; i++)
                if (!(modifier.ValidateChar(i)))
                {
                    Assert.Fail($"It should allow all characters, but it's not allowing '{(char)i}' {i}.");
                    return;
                }
        }
        #endregion Modifier Allowance Level 3
    }
}
