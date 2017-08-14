using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Tokenizer
{
    public abstract class Token
    {
        public Token(string text)
        {
            Text = text;
        }
        
        private string _text;
        public string Text
        {
            get => _text;
            set => _text = value;
        }
    }
}
