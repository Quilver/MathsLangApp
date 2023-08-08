using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsLangApp.Language
{
    public enum ReturnType
    {
        Valid,
        ValidEquation,
        //Lexer errors
        InvalidToken,
        NumberTooLarge,
        //Parser errors
        InvalidFormat,
        DivideByZero,
        BrokenEquation
    }
    public class CompilerOutput
    {
        public ReturnType type;
        public double outputNum;
        public bool integer;
        public CompilerOutput(ReturnType type, double outputNum=0, bool integer = false)
        {
            this.type = type;
            this.outputNum = outputNum;
            this.integer = integer;
        }
    }
}
