namespace calculator.Tokenizer
{
    class NumberToken : IToken
    {
        public NumberToken(string text, bool hasDot=false)
        {
            Text = text;
            HasDot = hasDot;
        }

        public string Text
        {
            get;
            private set;
        }

        // Indicates whether the number has a dot or not.
        // 123 has no dot.
        // 12.3 has a dot.
        public bool HasDot
        {
            get;
            private set;
        }

        public IToken Combine(IToken other)
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
                    return new ErrorToken(Text + other.Text, "number can not have more than 1 dot");
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

        public double Value
        {
            get => System.Convert.ToDouble(Text);
        }
    }
}
