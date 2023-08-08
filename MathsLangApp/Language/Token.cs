using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsLangApp.Language
{
    public enum TokenType
    {
        Error,
        Add,
        Multi,
        LeftParen,
        RightParen,
        Num,
        Divide,
        Sub,
        Equals,
        X,
        Y
    }
    
    internal class Token
    {
        public TokenType Type;
        public double Value;
        public bool integer;
        public Token() { }
        public Token(TokenType type, double value = 0, bool integer = false)
        {
            Type = type;
            Value = value;
            this.integer = integer;
        }
    }
}
