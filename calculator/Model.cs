using System.Collections.Generic;
using System.Linq;

namespace calculator
{
    public class Model
    {
        private List<Tokenizer.Token> tokens;
        private string _error;
        private string _result;

        public Model()
        {
            tokens = new List<Tokenizer.Token>();
            _error = null;
        }

        
        public string Error
        {
            get => _error;
            private set
            {
                _error = value;
            }
        }

        public string Result
        {
            get => _result;
            private set
            {
                _result = value;
            }
        }
        
        private static IEnumerable<Tokenizer.Token> ConvertToPostfix(List<Tokenizer.Token> tokens)
        {
            var operators = new Stack<Tokenizer.Token>();
            foreach (var token in tokens)
            {
                if (token is Tokenizer.NumberToken)
                {
                    yield return token;
                }
                else if (token is Tokenizer.BinaryOperatorToken)
                {
                    while (operators.Count() != 0)
                    {
                        yield return operators.Pop();
                    }
                    operators.Push(token);
                }
            }
            while (operators.Count() != 0)
            {
                yield return operators.Pop();
            }
            yield break;
        }

        private static Tokenizer.Token ComputeExpression(List<Tokenizer.Token> tokens)
        {
            var stack = new Stack<Tokenizer.Token>();
            foreach (var token in ConvertToPostfix(tokens))
            {
                if (token is Tokenizer.NumberToken)
                {
                    stack.Push(token);
                }
                else if (token is Tokenizer.BinaryOperatorToken)
                {
                    var op = token as Tokenizer.BinaryOperatorToken;
                    var operand2 = stack.Pop() as Tokenizer.NumberToken;
                    var operand1 = stack.Pop() as Tokenizer.NumberToken;
                    stack.Push(op.Compute(operand1, operand2));
                }
                else
                {
                    stack.Push(new Tokenizer.ErrorToken(token.Text, "unimplemented expression"));
                }
            }
            return stack.Peek();
        }

        private void Compute()
        {
            Result = null;
            var result = ComputeExpression(tokens);
            if (result is Tokenizer.NumberToken)
            {
                Result = result.Text;
            }
            else if (result is Tokenizer.ErrorToken)
            {
                Error = (result as Tokenizer.ErrorToken).Reason;
            }
            else
            {
                Error = "unknown result";
            }
        }

        public void PushInput(string text)
        {
            Error = null;
            Tokenizer.Token newToken = Tokenizer.Factory.MakeToken(text);
            if (tokens.Count() == 0)
            {
                tokens.Add(newToken);
            }
            else
            {
                Tokenizer.Token combinedToken = tokens.Last().Combine(newToken);
                if (combinedToken == null)
                {
                    tokens.Add(newToken);
                }
                else if (combinedToken is Tokenizer.ErrorToken)
                {
                    Error = (combinedToken as Tokenizer.ErrorToken).Reason;
                }
                else
                {
                    tokens[tokens.Count() - 1] = combinedToken;
                }
            }
        }

        public void PopInput()
        {
            Error = null;
            if (tokens.Count() != 0)
            {
                tokens.RemoveAt(tokens.Count() - 1);
            }
            else
            {
                Error = "nothing to delete";
            }
        }

        public string ExpressionString
        {
            get
            {
                string text = "";
                foreach (Tokenizer.Token token in tokens)
                {
                    text += token.Text;
                }
                return text;
            }
        }
    }
}
