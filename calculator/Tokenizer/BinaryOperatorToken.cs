namespace calculator.Tokenizer
{
    abstract class BinaryOperatorToken : IOperator, IToken
    {
        public abstract int Precedence
        {
            get;
        }

        public uint Arity => 2;

        public abstract string Text
        {
            get;
        }

        public IToken Combine(IToken other)
        {
            return new ErrorToken("", "can not combine");
        }

        public abstract double Apply(double a, double b);
    }
}
