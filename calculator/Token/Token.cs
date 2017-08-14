using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Token
{
    public abstract class Token
    {
        public Token(string text)
        {
            Text = text;
            SetType();
        }
        
        private string _text;
        public string Text
        {
            get => _text;
            set => _text = value;
        }

        private TokenType _type;
        public TokenType Type
        {
            get => _type;
            set => _type = value;
        }

        protected abstract void SetType();

    }
}
