namespace PassMagician
{
    /// <summary>
    /// This class uses XOR encryption to encrypt a phrase.
    /// </summary>
    public class Crypter : Modifier
    {
        /// <summary>
        /// The password the user wants to encrypt
        /// </summary>
        string _pass = "";
        /// <summary>
        /// Set the password to encrypt
        /// </summary>
        public string Pass {
            set {
                _pass = value;
            }
        }
        //
        /// <summary>
        /// Use XOR encryption to process the previously stored phrase with a key
        /// </summary>
        /// <param name="key">The encryption key</param>
        /// <returns>An ecrypted string (Inc. non-rendering chars)</returns>
        public string Encrypt(in string key)
        {
            // Get the length of the variables.
            int passl = _pass.Length;
            int keyl = key.Length;
            // Create array for encryption
            char[] output = new char[passl];
            //
            // Encrypt
            for (int i = 0; i < passl; i++)
                output[i] = (char)(_pass[i] ^ key[i % keyl]);
            return new string(output);
        }
    }
}
