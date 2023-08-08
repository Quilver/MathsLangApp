using System;
using Token;
public class Lexer
{
	public List<Token> tokens;
    public int Tokenise(string input)
    {
        failed = false;
        tokens= new List<Token>();
        for (int i = 0; i < input.Length; i++)
        {
            char c = _input[i];
            var newToken = new Token();
            switch (c)
            {
                case ' ':
                    //ignore whitespace
                    newToken = null;
                    break;
                case ',':
                    newToken.Type = TokenType.Comma;
                    newToken.Word = c.ToString();
                    break;
                case '+':
                    newToken.Type = TokenType.Add;
                    newToken.Word = c.ToString();
                    break;
                case '*':
                    newToken.Type = TokenType.Multi;
                    newToken.Word = c.ToString();
                    break;
                case '(':
                    newToken.Type = TokenType.LeftParen;
                    newToken.Word = c.ToString();
                    break;
                case ')':
                    newToken.Type = TokenType.RightParen;
                    newToken.Word = c.ToString();
                    break;
                case '-':
                    newToken.Type = TokenType.Sub;
                    newToken.Word = c.ToString();
                    break;
                case '/':
                    newToken.Type = TokenType.Divide;
                    newToken.Word = c.ToString();
                    break;
                case '=':
                    newToken.Type = TokenType.Equals;
                    newToken.Word = c.ToString();
                    break;
                default:
                    if (char.IsDigit(c))
                    {
                        newToken.Type = TokenType.Num;
                        newToken.Word = ParseNumber(i);
                        i += newToken.Word.Length - 1;
                        newToken.Value = double.Parse(newToken.Word);
                    }
                    else if (char.IsLetter(c))
                    {
                        newToken.Type = TokenType.String;
                        newToken.Word = ParseWord(i);
                        i += newToken.Word.Length - 1;
                        newToken.Value = newToken.Word;
                    }
                    else
                    {
                        newToken = null;
                        _logger.Error("Invalid lexeme encountered! Disregarding: {invalidToken}", c.ToString());
                        failed = true;
                    }
                    break;
            }

            if (newToken != null)
            {
                _tokens.Add(newToken);
            }
        }
        return !failed;
    }
}
