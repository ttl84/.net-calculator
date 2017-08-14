namespace calculator.Tokenizer
{
    public class ErrorToken : Token
    {
        public ErrorToken(string text, string reason) : base(text)
        {
            Reason = reason;
        }

        private string _reason;
        public string Reason
        {
            get => _reason;
            set => _reason = value;
        }
    }
}
