using MathsLangApp.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.nUnitTest
{
    internal class LexerTest
    {
        MathsLangApp.Language.Parser parse;
        [SetUp]
        public void Setup()
        {
            parse = new Parser();
        }
        [Test]
        public void Lexer_Test1()
        {
            string equation = "a";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.InvalidToken);
        }
        [Test]
        public void Lexer_Test2()
        {
            string equation = "3e";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.InvalidToken);
        }
        [Test]
        public void Lexer_Test3()
        {
            string equation = "1.2.2";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.InvalidToken);
        }
    }
}
