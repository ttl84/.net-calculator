namespace calculator.Tokenizer
{
    interface IOperator
    {
        int Precedence
        {
            get;
        }
        uint Arity
        {
            get;
        }
    }
}
