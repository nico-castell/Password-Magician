using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassGen;

namespace PassGenTests
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
    public class PassGenTests
    {
        #region Testing ASCII
        /// <summary>
        /// If the int corresponds to a letter in ASCII.
        /// </summary>
        /// <returns>True if it is, False if it isn´t</returns>
        bool IsLetter(in int i)
        {
            if ((i > 64 && i < 91) || (i > 96 && i < 123))
                return true;
            return false;
        }
        /// <summary>
        /// If the int corresponds to a number in ASCII.
        /// </summary>
        /// <returns>True if it is, False if it isn´t</returns>
        bool IsNumber(in int i)
        {
            if (i > 47 && i < 58)
                return true;
            return false;
        }
        /// <summary>
        /// If the int corresponds to a symbol in ASCII.
        /// </summary>
        /// <returns>True if it is, False if it isn´t</returns>
        bool IsSymbol(in int i)
        {
            if ((i > 32 && i < 48) || (i > 57 && i < 65) || (i > 90 && i < 97) || (i > 122 && i < 127))
                return true;
            return false;
        }
        #endregion Testing ASCII

        #region Modifier Allowance Level 1
        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 1")]
        public void ModifierAllowingOnlyLetters_ShouldOnlyAllowLetters()
        {
            // Arrange
            bool HasFailed = false;
            Modifier modifier = new Modifier();
            // Act
            // If the character in ASCII is not a Letter, and modifier says it's valid, there's a bug in the code.
            for (int i = 33; i < 127; i++)
                if (!IsLetter(i) && modifier.ValidateChar(i))
                {
                    HasFailed = true;
                    break;
                }
            // Assert
            Assert.IsTrue(HasFailed, "ValidateChar() should only allow Letters");
        }

        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 1")]
        public void ModifierAllowingOnlyNumbers_ShouldOnlyAllowNumbers()
        {
            // Arrange
            bool HasFailed = false;
            Modifier modifier = new Modifier();
            // Act
            // If the character in ASCII is not a number, and modifier says it's valid, there's a bug in the code.
            for (int i = 33; i < 127; i++)
                if (!IsNumber(i) && modifier.ValidateChar(i))
                {
                    HasFailed = true;
                    break;
                }
            // Assert
            Assert.IsTrue(HasFailed, "ValidateChar() should only allow Numbers");
        }

        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 1")]
        public void ModifierAllowingOnlySymbols_ShouldOnlyAllowSymbols()
        {
            // Arrange
            bool HasFailed = false;
            Modifier modifier = new Modifier();
            // Act
            // If the character in ASCII is not a symbol, and modifier says it's valid, there's a bug in the code.
            for (int i = 33; i < 127; i++)
                if (!IsSymbol(i) && modifier.ValidateChar(i))
                {
                    HasFailed = true;
                    break;
                }
            // Assert
            Assert.IsTrue(HasFailed, "ValidateChar() should only allow Symbols");
        }
        #endregion Modifer Allowance Level 1

        #region Modifier Allowance Level 2
        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 2")]
        public void ModifierAllowingOnlyLettersNumbers_ShouldOnlyAllowLettersNumbers()
        {
            // Arrange
            bool HasFailed = false;
            Modifier modifier = new Modifier();
            // Act
            // If the ASCII character is a not Letter or Number, and modifier says it's valid, there's a bug in the code.
            for (int i = 33; i < 127; i++)
                if (!IsLetter(i) && !IsNumber(i) && modifier.ValidateChar(i))
                {
                    HasFailed = true;
                    break;
                }
            // Assert
            Assert.IsTrue(HasFailed, "ValidateChar() should only allow Letters or Numbers");
        }

        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 2")]
        public void ModifierAllowingOnlyNumbersSymbols_ShouldOnlyAllowNumbersSymbols()
        {
            // Arrange
            bool HasFailed = false;
            Modifier modifier = new Modifier();
            // Act
            for (int i = 33; i < 127; i++)
                if (!IsNumber(i) && !IsSymbol(i) && modifier.ValidateChar(i))
                {
                    HasFailed = true;
                    break;
                }
            // Assert
            Assert.IsTrue(HasFailed, "ValidateChar() should only allow Numbers or Symbols");
        }

        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 2")]
        public void ModifierAllowingOnlyLettersSymbols_ShouldOnlyAllowLettersSymbols()
        {
            // Arrange
            bool HasFailed = false;
            Modifier modifier = new Modifier();
            // Act
            for (int i = 33; i < 127; i++)
                if (!IsLetter(i) && !IsSymbol(i) && modifier.ValidateChar(i))
                {
                    HasFailed = true;
                    break;
                }
            // Assert
            Assert.IsTrue(HasFailed, "ValidateChar() should only allow Letters or Symbols");
        }
        #endregion Modifier Allowance Level 2

        #region Modifier Allowance Level 3
        [TestMethod, TestCategory("Modifier Allowance"), TestCategory("Modifier Allowance Level 3")]
        public void ModifierAllowingEverything_ShouldAllowEverything()
        {
            // Arrange
            bool HasFailed = false;
            Modifier modifier = new Modifier();
            // Act
            for (int i = 33; i < 127; i++)
                if (!(modifier.ValidateChar(i)))
                {
                    HasFailed = true;
                    break;
                }
            // Assert
            Assert.IsFalse(HasFailed, "ValidateChar() should allow all characters");
        }
        #endregion Modifier Allowance Level 3
    }
}
