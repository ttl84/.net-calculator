namespace calculator.Tokenizer
{
    class SubtractionToken : BinaryOperatorToken
    {
        public override int Precedence => 0;

        public override string Text => "-";

        public override double Apply(double a, double b)
        {
            return a - b;
        }
    }
}
