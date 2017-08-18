namespace calculator.Tokenizer
{
    class CloseToken : IToken
    {
        public string Text => ")";

        public IToken Combine(IToken other)
        {
            return null;
        }
    }
}
