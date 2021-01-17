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
        readonly char[] _key = new char[4];
        /// <summary>
        /// Assign a string and some of its characters will be used in the key.
        /// </summary>
        public string Key
        {
            set
            {
                _key[0] = value[0];
                _key[1] = value[1];
                _key[2] = value[^2]; // Use 'from the end' operator.
                _key[3] = value[^1];
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
            // Loop on every character of the input.
            foreach (char alpha in input)
            {
                char t = (char)0;
                // Loop on every character of the key.
                foreach (char beta in _key)
                {
                    // Loop on every possible operation. (4 operation * 4 possible key chars = 16 ways to obfuscate).
                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                t = AddChars(alpha, beta);
                                break;
                            case 1:
                                t = RestChars(alpha, beta);
                                break;
                            case 2:
                                t = MultiplyChars(alpha, beta);
                                break;
                            case 3:
                                t = TriChars(alpha, beta);
                                break;
                        }
                        // If the character is valid, exit the loop, otherwise try with a different key char.
                        if (ValidateChar(t))
                            break;
                        continue;
                    }
                    // if the char already is valid, then break out of this loop too.
                    if (ValidateChar(t))
                        break;
                }
                // The loop wasn't able to create a valid char. Create one now.
                if (!ValidateChar(t))
                {
                    while (!ValidateChar(t))
                    {
                        // Add 1 to 't' until it's valid.
                        t++;
                        // If 't' exceeds the ASCII "ceiling", force it to be valid.
                        if (t > 126)
                        {
                            t = (char)33;
                            break;
                        }
                    }
                }
                output += t;
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
