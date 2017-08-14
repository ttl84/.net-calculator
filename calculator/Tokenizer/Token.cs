namespace calculator.Tokenizer
{
    public abstract class Token
    {
        public Token(string text)
        {
            Text = text;
        }
        
        private string _text;
        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public virtual Token Combine(Token other)
        {
            // assume atomic Token by default, return null to mean can't combine
            return null;
        }
    }
}
