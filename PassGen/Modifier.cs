namespace PassGen
{
    class Modifier
    {
        /// <summary>
        /// Should allow ASCII ranges: 65-90, 97-122 (dec)
        /// </summary>
        public bool _allowLetters = true;
        /// <summary>
        /// Allow letters to be used in the password
        /// </summary>
        public bool AllowLetters
        {
            get
            {
                return _allowLetters;
            }
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
            get
            {
                return _allowNumbers;
            }
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
            get
            {
                return _allowSymbols;
            }
            set
            {
                _allowSymbols = value;
            }
        }
    }
}
