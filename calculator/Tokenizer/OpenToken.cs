namespace calculator.Tokenizer
{
    class OpenToken : IToken
    {
        public string Text => "(";

        IToken IToken.Combine(IToken other)
        {
            if (other is CloseToken)
            {
                return new ErrorToken(Text + other.Text, "can not close empty parenthesis");
            }
            return null;
        }
    }
}
