namespace calculator.Tokenizer
{
    static class Factory
    {
        public static IToken MakeToken(string text)
        {
            char first = text[0];
            if (first == '.')
            {
                return new DotToken();
            }
            else if (char.IsDigit(first))
            {
                return new NumberToken(text);
            }
            else if (first == '+')
            {
                return new AdditionToken();
            }
            else
            {
                return new ErrorToken(text, "unknown token");
            }
        }
    }
}
