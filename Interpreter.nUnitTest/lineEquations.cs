using MathsLangApp.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.nUnitTest
{
    internal class lineEquations
    {
        MathsLangApp.Language.Parser parse;
        [SetUp]
        public void Setup()
        {
            parse = new Parser();
        }
        [Test]
        public void LineEquation_Test1()
        {
            string equation = "y=5";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.ValidEquation);
        }
        public void LineEquation_Test2()
        {
            string equation = "y=x";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.ValidEquation);
        }
        public void LineEquation_Test3()
        {
            string equation = "y=x+5";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.ValidEquation);
        }
        public void LineEquation_Test4()
        {
            string equation = "y=2*x+5";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.ValidEquation);
        }
    }
}
