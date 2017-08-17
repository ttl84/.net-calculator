namespace calculator.Tokenizer
{
    class DivisionToken : BinaryOperatorToken
    {
        public override int Precedence => 1;

        public override string Text => "/";

        public override double Apply(double a, double b)
        {
            return a / b;
        }
    }
}
