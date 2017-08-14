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

        public override Token Combine(Token other)
        {
            if (other is NumberToken)
            {
                NumberToken otherNumber = other as NumberToken;
                if (HasDot && otherNumber.HasDot)
                {
                    return new ErrorToken(Text + other.Text, "number can not have more than 1 dot");
                }
                else
                {
                    return new NumberToken(Text + otherNumber.Text, HasDot || otherNumber.HasDot);
                }
            }
            else if (other is DotToken)
            {
                if (HasDot)
                {
                    return new ErrorToken(Text + other.Text, "two dots can not be adjacent");
                }
                else
                {
                    return new NumberToken(Text + other.Text, true);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
