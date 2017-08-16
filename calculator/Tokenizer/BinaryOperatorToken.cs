namespace calculator.Tokenizer
{
    public class BinaryOperatorToken : Token
    {
        public BinaryOperatorToken(string text) : base(text)
        {
        }

        public Token Compute(NumberToken a, NumberToken b)
        {
            double value = 0;
            if (Text == "+")
            {
                value = a.Value + b.Value;
            }
            else if (Text == "-")
            {
                value = a.Value - b.Value;
            }
            else if (Text == "*")
            {
                value = a.Value * b.Value;
            }
            else if (Text == "/")
            {
                value = a.Value / b.Value;
            }
            else
            {
                return new ErrorToken(Text, "unimplemented operator");
            }
            return new NumberToken(value.ToString());
        }
    }
}
