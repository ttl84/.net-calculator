using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Model
    {
        private List<Tokenizer.Token> tokens;
        private string error;

        public Model()
        {
            tokens = new List<Tokenizer.Token>();
            error = null;
        }

        public void PushInput(string text)
        {
            error = null;
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
                    error = (combinedToken as Tokenizer.ErrorToken).Reason;
                }
                else
                {
                    tokens[tokens.Count() - 1] = combinedToken;
                }
            }
        }

        public void PopInput()
        {
            error = null;
            if (tokens.Count() != 0)
            {
                tokens.RemoveAt(tokens.Count() - 1);
            }
            else
            {
                error = "nothing to delete";
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

        public string GetInfoString()
        {
            if (error != null)
            {
                return "Error: " + error;
            }
            else
            {
                return "";
            }
        }
    }
}
