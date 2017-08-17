using System;

namespace calculator.Tokenizer
{
    class ErrorToken : IToken
    {
        public ErrorToken(string text, string reason)
        {
            Text = text;
            Reason = reason;
        }

        public string Text
        {
            get;
            set;
        }
        public string Reason
        {
            get;
            set;
        }

        public IToken Combine(IToken other)
        {
            return new ErrorToken("", "error tokens can not combine");
        }
    }
}
