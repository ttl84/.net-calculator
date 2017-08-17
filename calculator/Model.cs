using System.Collections.Generic;
using System.Linq;

namespace calculator
{
    public class Model
    {
        private List<Tokenizer.IToken> tokens;

        public Model()
        {
            tokens = new List<Tokenizer.IToken>();
            Error= null;
            Result = null;
        }

        
        public string Error
        {
            get;
            private set;
        }

        public string Result
        {
            get;
            private set;
        }
        
        private static IEnumerable<Tokenizer.IToken> ConvertToPostfix(List<Tokenizer.IToken> tokens)
        {
            var operators = new Stack<Tokenizer.IToken>();
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

        private static Tokenizer.IToken ComputeExpression(List<Tokenizer.IToken> tokens)
        {
            var stack = new Stack<Tokenizer.IToken>();
            foreach (var token in ConvertToPostfix(tokens))
            {
                if (token is Tokenizer.NumberToken)
                {
                    stack.Push(token);
                }
                else if (token is Tokenizer.BinaryOperatorToken)
                {
                    if (stack.Count() < 2)
                    {
                        return null;
                    }
                    var operation = token as Tokenizer.BinaryOperatorToken;
                    var operand2 = stack.Pop() as Tokenizer.NumberToken;
                    var operand1 = stack.Pop() as Tokenizer.NumberToken;
                    if (operand1 != null && operand2 != null)
                    {
                        double value = operation.Apply(operand1.Value, operand2.Value);
                        stack.Push(new Tokenizer.NumberToken(value.ToString()));
                    }
                    else
                    {
                        stack.Push(new Tokenizer.ErrorToken("", "not enough arguments"));
                    }
                }
                else
                {
                    stack.Push(new Tokenizer.ErrorToken(token.Text, "unimplemented expression"));
                }
            }
            if (stack.Count() != 0)
            {
                return stack.Peek();
            }
            else
            {
                return null;
            }
        }

        private void Compute()
        {
            var result = ComputeExpression(tokens);
            if (result == null)
            {
                Result = null;
            }
            else if (result is Tokenizer.NumberToken)
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
            Tokenizer.IToken newToken = Tokenizer.Factory.MakeToken(text);
            if (newToken == null)
            {
                Error = "unknown token: " + text;
            }
            else if (tokens.Count() == 0)
            {
                tokens.Add(newToken);
            }
            else
            {
                Tokenizer.IToken combinedToken = tokens.Last().Combine(newToken);
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
            if (Error == null)
            {
                Compute();
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
            if (Error == null)
            {
                Compute();
            }
        }

        public string ExpressionString
        {
            get
            {
                string text = "";
                foreach (Tokenizer.IToken token in tokens)
                {
                    text += token.Text;
                }
                return text;
            }
        }
    }
}
