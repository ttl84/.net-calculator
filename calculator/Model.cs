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

        public Model()
        {
            tokens = new List<Tokenizer.Token>();
        }

        public void PushInput(string text)
        {
            Tokenizer.Token newToken = Tokenizer.Factory.MakeToken(text);
            if (tokens.Count() == 0)
            {
                tokens.Add(newToken);
            }
            else
            {
                tokens.Add(newToken);
            }
        }

        public void PopInput()
        {
            if (tokens.Count() != 0)
            {
                tokens.RemoveAt(tokens.Count() - 1);
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
