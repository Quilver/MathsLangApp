using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsLangApp.Language
{
    internal class Lexer
    {
        public static List<Token> tokens = new List<Token>();
        public static ReturnType Tokenise(string input)
        {
            tokens = new List<Token>();
            int i = 0;
            while (i < input.Length)
            {
                char c = input[i];
                var newToken = new Token();
                switch (c)
                {
                    case ' ':
                        //ignore whitespace
                        break;
                    case '+':
                        tokens.Add(new Token(TokenType.Add));
                        break;
                    case '*':
                        tokens.Add(new Token(TokenType.Multi));
                        break;
                    case '(':
                        tokens.Add(new Token(TokenType.LeftParen));
                        break;
                    case ')':
                        tokens.Add(new Token(TokenType.RightParen));
                        break;
                    case '-':
                        tokens.Add(new Token(TokenType.Sub));
                        break;
                    case '/':
                        tokens.Add(new Token(TokenType.Divide));
                        break;
                    case '=':
                        tokens.Add(new Token(TokenType.Equals));
                        break;
                    case 'X':
                        tokens.Add(new Token(TokenType.X));
                        break;
                    case 'Y':
                        tokens.Add(new Token(TokenType.Y));
                        break;
                    default:
                        if (char.IsDigit(c))
                        {
                            newToken.Type = TokenType.Num;
                            string num = ParseNumber(i, input);
                            i += num.Length - 1;
                            if (num.Contains('.'))
                            {
                                string[] real = num.Split('.');
                                if (real[0].Length < 3 && real[1].Length < 3)
                                    tokens.Add(new Token(TokenType.Num, Convert.ToDouble(num)));
                                
                                else return ReturnType.NumberTooLarge;
                                
                            }
                            else
                            {
                                if (num.Length <= 3)
                                    tokens.Add(new Token(TokenType.Num, int.Parse(num), true));
                                else return ReturnType.NumberTooLarge;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid token:", c);
                            return ReturnType.InvalidToken;
                        }
                        break;
                }
                i++;
            }
            
            return ReturnType.Valid;
        }
        static string ParseNumber(int i, string input)
        {
            string num = "";
            bool integer = true;
            while(i < input.Length)
            {
                char c = input[i];
                if (c == '.')
                {
                    if (!integer)
                    {
                        return num;
                    }
                    integer = false;
                    num += c;
                }
                else if (char.IsDigit(c)) { num += c; }
                else return num;
                i++;
            }
            return num;
        }
    }
}
