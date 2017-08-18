namespace calculator.Tokenizer
{
    class CloseToken : IToken
    {
        public string Text => ")";

        public IToken Combine(IToken other)
        {
            if (other is OpenToken)
            {
                return new ErrorToken(Text + other.Text, "can not combine close with open");
            }
            else
            {
                return null;
            }
        }
    }
}
