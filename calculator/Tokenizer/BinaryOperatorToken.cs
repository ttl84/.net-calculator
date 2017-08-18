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
            if (other is BinaryOperatorToken)
            {
                return new ErrorToken(other.Text, "can not combine two binary operators");
            }
            else
            {
                return null;
            }
        }

        public abstract double Apply(double a, double b);
    }
}
