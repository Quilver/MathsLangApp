using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsLangApp.Language
{
    //Just to note that I substiture X for a random value and then run it through an expression
    public class Parser
    {
        List<Token> tokens;
        int index;
        public CompilerOutput Parse(string input, string xValue = "99")
        {
            input = input.ToUpper();
            input = input.Replace("X", xValue);
            var lexerReturnType = Lexer.Tokenise(input);
            if (lexerReturnType != ReturnType.Valid)
                return new CompilerOutput(lexerReturnType);
            tokens = Lexer.tokens;
            index = 0;
            var statement = Statement(0);
            if (index == tokens.Count)
                return statement;
            else
                return new CompilerOutput(ReturnType.InvalidFormat);
        }
        #region BNF functions
        CompilerOutput Statement(int depth)
        {
            var equation = Equation(depth+1);
            if (equation.type == ReturnType.ValidEquation) return equation;
            else if(equation.type == ReturnType.BrokenEquation) return equation;
            else return Expression(depth + 1);
                
        }
        CompilerOutput Expression(int depth)
        {
            double number = 0;
            var t1 = Term(depth + 1);
            
            if (t1.type != ReturnType.Valid) return new CompilerOutput(ReturnType.InvalidFormat);
            while (tokens.Count > index) 
                if (Match(TokenType.Add) || Match(TokenType.Sub))
            {
                bool add = Match(TokenType.Add);
                Advance(depth + 1);
                var t2 = Term(depth + 1);
                if (add) number += t2.outputNum;
                else number -= t2.outputNum;
                if (t2.type != ReturnType.Valid) return new CompilerOutput(ReturnType.InvalidFormat);
            }
                else break;
            number += t1.outputNum;
            return new CompilerOutput(ReturnType.Valid, number);
        }
        CompilerOutput Term(int depth)
        {
            double number= 1;
            bool integer = true;
            var t1 = Factor(depth + 1);
            number= t1.outputNum;
            if (t1.type != ReturnType.Valid) return new CompilerOutput(ReturnType.InvalidFormat);
            while (tokens.Count > index)
                if (Match(TokenType.Multi) || Match(TokenType.Divide))
            {
                bool multi = Match(TokenType.Multi);
                Advance(depth + 1);
                var t2 = Factor(depth + 1);
                if (!multi && t2.outputNum == 0) return new CompilerOutput(ReturnType.DivideByZero);
                if (multi) number *= t2.outputNum;
                else number /= t2.outputNum;
                    if (t2.integer && integer) number = (int)number;
                    else if (!t2.integer)integer= false;
                if (t2.type != ReturnType.Valid) return new CompilerOutput(ReturnType.InvalidFormat);
            }
                else break; 
            //number *= t1.outputNum;
            integer=t1.integer;
            return new CompilerOutput(ReturnType.Valid, number, integer);
        }
        CompilerOutput Factor(int depth)
        {
            if (Match(TokenType.Num))
            {
                var num = GetNum();
                var integer = isInteger();
                Advance(depth+1);
                return new CompilerOutput(ReturnType.Valid, num, integer);

            }
            else if (Match(TokenType.Sub))
            {
                Advance(depth + 1);
                double num = Factor(depth + 1).outputNum;
                return new CompilerOutput(ReturnType.Valid, -1*num);
            }
            else if (Match(TokenType.LeftParen))
            {
                Advance(depth + 1);
                var t = Expression(depth + 1);
                if (t.type== ReturnType.Valid) Advance(depth + 1);
                if (Match(TokenType.RightParen)) Advance(depth + 1);
                
                return new CompilerOutput(ReturnType.Valid, t.outputNum);
            }
            return new CompilerOutput(ReturnType.InvalidFormat);
        }
        #endregion

        #region Equations
        CompilerOutput Equation(int depth)
        {
            if (!Match(TokenType.Y))
            {
                return new CompilerOutput(ReturnType.InvalidFormat);
            }
            Advance(depth + 1);
            if (!Match(TokenType.Equals))
            {
                return new CompilerOutput(ReturnType.BrokenEquation);
            }
            Advance(depth + 1);
            var exp=Expression(depth + 1);
            if(exp.type== ReturnType.Valid || exp.type == ReturnType.DivideByZero)
            {
                return new CompilerOutput(ReturnType.ValidEquation, exp.outputNum);
            }
            return new CompilerOutput(ReturnType.InvalidFormat);
        }
        #endregion

        #region Helper functions
        void Advance(int depth) { index++; }
        void Reset(int depth) { index = 0; }
        bool Match(TokenType type) { 
            if(index >= tokens.Count)
                return false;
            return tokens[index].Type == type; 
        }
        double GetNum() {
            if (index >= tokens.Count)
                return -1;
            return tokens[index].Value;
        }
        bool isInteger()
        {
            if (index >= tokens.Count)
                return false;
            return tokens[index].integer;
        }
        #endregion
    }
}
