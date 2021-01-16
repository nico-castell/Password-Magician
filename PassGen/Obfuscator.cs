using System;

namespace PassGen
{
    /// <summary>
    /// An object capable of obfuscating text into a secure password using Letters, Numbers, and/or Symbols.
    /// </summary>
    class Obfuscator : Modifier
    {
        /// <summary>
        /// An array of 4 characters used to obfuscate the password.
        /// </summary>
        char[] _key = new char[4];
        /// <summary>
        /// Assign a string and some of its characters will be used in the key.
        /// </summary>
        public string Key
        {
            set
            {
                _key[0] = value[0];
                _key[1] = value[1];
                _key[2] = value[value.Length - 2];
                _key[3] = value[value.Length - 1];
            }
        }
        //
        /// <summary>
        /// Perform 4 mathematical operations on every character to obfuscate the input.
        /// </summary>
        /// <param name="input">The password to obfuscate</param>
        /// <returns>A seemingly random password</returns>
        public string ObfuscatePass(in string input)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                int operation = i % 4;
                switch (operation)
                {
                    case 0:
                        output += AddChars(input[i], _key[operation]);
                        break;
                    case 1:
                        output += RestChars(input[i], _key[operation]);
                        break;
                    case 2:
                        output += MultiplyChars(input[i], _key[operation]);
                        break;
                    case 3:
                        output += TriChars(input[i], _key[operation]);
                        break;
                }
            }
            return output;
        }
        //
        /// <summary>
        /// Add the values of two characters and normalize the output.
        /// </summary>
        /// <param name="base_char">The character to obfuscate</param>
        /// <param name="key_char">The character used to obfuscate</param>
        /// <returns>An obfuscated character</returns>
        char AddChars(in char base_char, in char key_char)
        {
            return NormalizeASCII((base_char + key_char) % 127);
        }
        //
        /// <summary>
        /// Use the absolute value of the rest between two characters and normalize the output.
        /// </summary>
        /// <param name="base_char">The character to obfuscate</param>
        /// <param name="key_char">The character used to obfuscate</param>
        /// <returns>An obfuscated character</returns>
        char RestChars(in char base_char, in char key_char)
        {
            return NormalizeASCII(Math.Abs((base_char - key_char) % 127));
        }
        //
        /// <summary>
        /// Multiply the values of two characters and normalize the output.
        /// </summary>
        /// <param name="base_char">The character to obfuscate</param>
        /// <param name="key_char">The character used to obfuscate</param>
        /// <returns>An obfuscated character</returns>
        char MultiplyChars(in char base_char, in char key_char)
        {
            return NormalizeASCII((base_char * key_char) % 127);
        }
        //
        /// <summary>
        /// Use two characters as two sides of a rectangle triangle, calculate the hyptenunse, and normalize the output.
        /// </summary>
        /// <param name="base_char">The character to obfuscate</param>
        /// <param name="key_char">The character used to obfuscate</param>
        /// <returns>An obfuscated character</returns>
        char TriChars(in char base_char, in char key_char)
        {
            int hypotenunse = (int)Math.Sqrt(base_char * base_char + key_char * key_char);
            return NormalizeASCII(hypotenunse % 127);
        }
        //
        /// <summary>
        /// Normalize the output to avoid ASCII control chars, spaces, and DEL.
        /// </summary>
        /// <param name="character">An integer to normalize and convert into a character</param>
        /// <returns>A normalized character</returns>
        char NormalizeASCII(in int character)
        {
            return (char)(33 + (character % 94));
        }
    }
}
