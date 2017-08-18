namespace calculator.Tokenizer
{
    class DotToken : IToken
    {
        public string Text => ".";

        public IToken Combine(IToken other)
        {
            if (other is NumberToken)
            {
                return new NumberToken(Text + other.Text, true);
            }
            else if (other is DotToken)
            {
                return new ErrorToken(Text + other.Text, "can not combine two dots");
            }
            else
            {
                return null;
            }
        }
    }
}
