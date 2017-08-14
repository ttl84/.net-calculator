using System.Collections.Generic;
using System.Linq;

namespace calculator
{
    public class Model
    {
        private List<Tokenizer.Token> tokens;
        private string _error;

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

        public string GetExpressionString()
        {
            string text = "";
            foreach(Tokenizer.Token token in tokens)
            {
                text += token.Text;
            }
            return text;
        }
    }
}
