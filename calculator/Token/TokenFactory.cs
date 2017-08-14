namespace calculator.Token
{
    public static class TokenFactory
    {
        public static Token MakeToken(string text)
        {
            char first = text[0];
            if (first == '.')
            {
                return new DotToken(text);
            }
            else if (char.IsDigit(first))
            {
                return new NumberToken(text);
            }
            else if (first == '+' || first == '-' || first == '*' || first == '/')
            {
                return new BinaryOperatorToken(text);
            }
            else
            {
                return null;
            }
        }
    }
}
