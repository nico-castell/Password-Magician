using System;

namespace PassGen
{
    /// <summary>
    /// Password generator that supports numbers, letters, and symbols.
    /// </summary>
    class Generator
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

        /// <summary>
        /// Generate a password with the pre-selected number of chars.
        /// </summary>
        /// <param name="length">The length of the password</param>
        /// <returns>A password made with ASCII characters</returns>
        public string GeneratePass(in int length)
        {
            string output = "";
            for (int i = 0; i < length; i++)
            {
                output += _GenValidChar();
            }
            return output;
        }

        /// <summary>
        /// Generates valid characters based on _allowLetters, _allowNumbers, and _allowSymbols
        /// </summary>
        /// <returns>A valid chracter to be used in the password</returns>
        char _GenValidChar()
        {
            Random random = new Random();
            char output;
            while (true)
            {
                int t = random.Next(33, 126);

                // Test letters (ASCII range and allowance)
                if (((t > 64 && t < 91)   ||
                     (t > 96 && t < 123)) &&
                   _allowLetters == true)
                {
                    output = (char)t;
                    break;
                }

                // Test numbers (ASCII range and allowance)
                if ((t > 47 && t < 58) &&
                    _allowNumbers == true)
                {
                    output = (char)t;
                    break;
                }

                // Test symbols (ASCII range and allowance)
                if (((t > 32  && t < 48)   ||
                     (t > 57  && t < 65)   ||
                     (t > 90  && t < 97)   ||
                     (t > 122 && t < 127)) &&
                    _allowSymbols == true)
                {
                    output = (char)t;
                    break;
                }
            }
            return output;
        }
    }
}
