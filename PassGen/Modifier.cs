namespace PassGen
{
    public class Modifier
    {
        /// <summary>
        /// Should allow ASCII ranges: 65-90, 97-122 (dec)
        /// </summary>
        bool _allowLetters = true;
        /// <summary>
        /// Allow letters to be used in the password
        /// </summary>
        public bool AllowLetters
        {
            set
            {
                _allowLetters = value;
            }
        }
        //
        /// <summary>
        /// Should allow ASCII range 48-57 (dec)
        /// </summary>
        bool _allowNumbers = true;
        /// <summary>
        /// Allow numbers to be used in the password
        /// </summary>
        public bool AllowNumbers
        {
            set
            {
                _allowNumbers = value;
            }
        }
        //
        /// <summary>
        /// Should allow ASCII ranges: 33-47, 58-64, 91-96, 123-126 (dec)
        /// </summary>
        bool _allowSymbols = true;
        /// <summary>
        /// Allow symbols to be used in the password
        /// </summary>
        public bool AllowSymbols
        {
            set
            {
                _allowSymbols = value;
            }
        }
        //
        /// <summary>
        /// Validate that the number represents a valid character.
        /// </summary>
        /// <param name="charToTest">The integer representing a character to test</param>
        /// <returns>True if valid, False if not valid</returns>
        public bool ValidateChar(in int charToTest)
        {
            bool result = false;
            // Test letters (ASCII range and allowance)
            if (((charToTest > 64 && charToTest < 91) ||
                 (charToTest > 96 && charToTest < 123)) &&
               _allowLetters == true)
            {
                result = true;
            }
            // Test symbols (ASCII range and allowance)
            if (((charToTest > 32 && charToTest < 48) ||
                 (charToTest > 57 && charToTest < 65) ||
                 (charToTest > 90 && charToTest < 97) ||
                 (charToTest > 122 && charToTest < 127)) &&
                _allowSymbols == true)
            {
                result = true;
            }
            // Test numbers (ASCII range and allowance)
            if ((charToTest > 47 && charToTest < 58) &&
                _allowNumbers == true)
            {
                result = true;
            }
            return result;
        }
    }
}
