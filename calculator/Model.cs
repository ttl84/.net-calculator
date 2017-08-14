using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Model
    {
        private List<string> tokens;

        public Model()
        {
            tokens = new List<string>();
        }

        public void PushInput(string text)
        {
            if (tokens.Count() == 0)
            {
                tokens.Add(text);
            }
            else
            {
                tokens.Add(text);
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
            foreach(string token in tokens)
            {
                text += token;
            }
            return text;
        }
    }
}
