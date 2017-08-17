using System;

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
            else
            {
                return new ErrorToken(Text, "can not combine");
            }
        }
    }
}
