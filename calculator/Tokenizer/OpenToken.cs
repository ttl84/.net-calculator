namespace calculator.Tokenizer
{
    class OpenToken : IToken
    {
        string IToken.Text => "(";

        IToken IToken.Combine(IToken other)
        {
            return null;
        }
    }
}
