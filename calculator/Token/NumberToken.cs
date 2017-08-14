namespace calculator.Tokenizer
{
    public class NumberToken : Token
    {
        public NumberToken(string text, bool hasDot=false) : base(text)
        {
            HasDot = hasDot;
        }

        // Indicates whether the number has a dot or not.
        // 123 has no dot.
        // 12.3 has a dot.
        private bool _hasDot;
        public bool HasDot
        {
            get => _hasDot;
            private set => _hasDot = value;
        }
    }
}
