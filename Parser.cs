using System;

public class Parser
{

	List<Token> tokens;
    int index;
    public bool Parse(string input)
	{
		if(!Lexer.Tokenise)
			return false;
		tokens = Lexer.Tokens;
        index = 0;
		return Statement(0);
	}
    #region BNF functions
    bool Statement(int depth)
    {
        if(Expression(depth+1))
            return true;
        return false;
    }
    bool Expression(int depth)
    {
        if (!Term(depth + 1)) return false;
        if (!Match(TokenType.Add) && !Match(TokenType.Sub)) return false;
        Advance(depth+1);
        if(!Term(depth+1))return false;
        return true;
    }
    bool Term(int depth)
    {
        if (!Factor(depth + 1)) return false;
        if (!Match(TokenType.Multi) && !Match(TokenType.Divide)) return false;
        Advance(depth + 1);
        if (!Factor(depth + 1)) return false;
        return true;
    }
    bool Factor(int depth)
    {
        if (Match(TokenType.Num))
        {
            Advance(depth+1);
            return true;
        }
        else if (Match(TokenType.Sub)){
            Advance(depth+1);
            return Factor(depth+1);
        }
        else if (Match(TokenType.LeftParen))
        {
            Advance(depth+1);
            if(Expression(depth+ 1)) Advance(depth+1);
            if (Match(TokenType.RightParen)) Advance(level + 1);
            return true;
        }
        return false;
    }
    #endregion

    #region Helper functions
    void Advance(int depth) { index++; }
    void Reset(int depth) { index = 0; }
    void Match(TokenType type) { return tokens[index].type == type; }
    #endregion
}
