using System;

namespace PassGen
{
    /// <summary>
    /// Password generator that supports numbers, letters, and symbols.
    /// </summary>
    public class Generator : Modifier
    {
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
                output += GenValidChar();
            }
            return output;
        }
        //
        /// <summary>
        /// Generates valid characters based on _allowLetters, _allowNumbers, and _allowSymbols
        /// </summary>
        /// <returns>A valid chracter to be used in the password</returns>
        char GenValidChar()
        {
            Random random = new Random();
            char output;
            while (true)
            {
                output = (char)random.Next(33, 126);
                if (ValidateChar(output)) break;
            }
            return output;
        }
    }
}
