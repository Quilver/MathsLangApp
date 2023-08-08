using System;

public enum TokenType
{
    Null,
    Add,
    Multi,
    LeftParen,
    RightParen,
    Comma,
    Num,
    Divide,
    Sub,
    Equals,
    X,
    Y
}

public class Token
{
    public TokenType Type;
    public object? Value;
    public Token(TokenType type, object? value)
    {
        Type= type;
        Value= value;
    }
}
