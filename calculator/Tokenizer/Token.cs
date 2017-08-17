namespace calculator.Tokenizer
{
    interface IToken
    {
        string Text
        {
            get;
        }

        IToken Combine(IToken other);
    }
}
