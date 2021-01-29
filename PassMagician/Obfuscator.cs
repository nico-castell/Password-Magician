using System;

namespace PassMagician
{
    /// <summary>
    /// An object capable of obfuscating text into a secure password using Letters, Numbers, and/or Symbols.
    /// </summary>
    public class Obfuscator : Modifier
    {
        /// <summary>
        /// An array of 4 characters used to obfuscate the password.
        /// </summary>
        readonly char[] _key = new char[4];
        /// <summary>
        /// Assign a string and some of its characters will be used in the key.
        /// </summary>
        public string Key {
            set {
                _key[0] = value[0];
                _key[1] = value[1];
                _key[2] = value[^2]; // Use 'from the end' operator.
                _key[3] = value[^1];
            }
        }

        /// <summary>
        /// Use an algorithm to obfuscate the password into something that complies with what the user allows.
        /// </summary>
        /// <param name="input">The password to obfuscate</param>
        /// <returns>A seemingly random password</returns>
        public string ObfuscatePass(in string input)
        {
            string output = "";
            int i = 0;
            while (true)
            {
                // Iterate through every char in the input.
                foreach (char alpha in input)
                {
                    char t = (char)0;
                    for (int k = 0; k < 4; k++)
                    {
                        t = MakeChar(alpha, _key[^((i % 4) + 1)]); // Acess the '_key' indexes like: 3, 2, 1, 0, 3, 2, 1, 0...
                        i++;
                        if (ValidateChar(t))
                            break;
                    }
                    if (!ValidateChar(t))
                        t = ForceChar(t);
                    output += t;
                    if (output.Length == input.Length) return output;
                }
            }
        }

        /// <summary>
        /// Use 4 arithmetic operations to create a valid character.
        /// </summary>
        /// <param name="base_char">The character to obfuscate</param>
        /// <param name="key_char">The character used to obfuscate</param>
        /// <returns>A char (hopefully valid)</returns>
        char MakeChar(in char base_char, in char key_char)
        {
            char t = (char)0;
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                case 0:
                    t = AddChars(base_char, key_char);
                    break;
                case 1:
                    t = RestChars(base_char, key_char);
                    break;
                case 2:
                    t = MultiplyChars(base_char, key_char);
                    break;
                case 3:
                    t = TriChars(base_char, key_char);
                    break;
                }
                if (ValidateChar(t))
                    return t;
            }
            return t;
        }

        /// <summary>
        /// When all else has failed, force the creation of a valid char.
        /// </summary>
        /// <param name="failed_char">The failed character</param>
        /// <returns>A validated char</returns>
        char ForceChar(char failed_char)
        {
            while (!ValidateChar(failed_char))
            {
                if (failed_char > 126)
                    failed_char = (char)33;
                failed_char++;
            }
            return failed_char;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
