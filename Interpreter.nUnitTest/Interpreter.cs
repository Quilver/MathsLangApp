using NUnit.Framework;
using MathsLangApp.Language;
namespace Interpreter.nUnitTest
{
    public class Tests
    {
        MathsLangApp.Language.Parser parse;
        [SetUp]
        public void Setup()
        {
            parse = new Parser();
        }
        [Test]
        public void Interpreter_1TermTest()
        {
            string equation = "3";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.Valid);
            Assert.That(output.outputNum == 3);
        }
        [Test]
        public void Interpreter_2TermTest()
        {
            string equation = "3 2";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.InvalidFormat);
        }
        [Test]
        public void Interpreter_1MinusTermTest()
        {
            string equation = "-3";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.Valid);
            Assert.That(output.outputNum == -3);
        }
        [Test]
        public void Interpreter_1GroupTermTest()
        {
            string equation = "(3)";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.Valid);
            Assert.That(output.outputNum == 3);
        }
        [Test]
        public void Interpreter_AddTest()
        {
            string equation = "3+4";
            var output = parse.Parse(equation);
            Assert.That(output.type==ReturnType.Valid);
            Assert.That(output.outputNum == 7);
        }
        [Test]
        public void Interpreter_SubTest()
        {
            string equation = "3-4";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.Valid);
            Assert.That(output.outputNum == -1);
        }
        [Test]
        public void Interpreter_MultiTest()
        {
            string equation = "3*4";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.Valid);
            Assert.That(output.outputNum == 12);
        }
        [Test]
        public void Interpreter_DivideTest()
        {
            string equation = "8/4";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.Valid);
            Assert.That(output.outputNum == 2);
        }
        [Test]
        public void Interpreter_LargeSum1()
        {
            string equation = "3+4+2";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.Valid);
            Assert.That(output.outputNum == 9);
        }
        [Test]
        public void Interpreter_LargeSum2()
        {
            string equation = "(3+4)*2";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.Valid);
            Assert.That(output.outputNum == 14);
        }
        [Test]
        public void Interpreter_LargeSum3()
        {
            string equation = "3+4--2";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.Valid);
            Assert.That(output.outputNum == 9);
        }
        [Test]
        public void Interpreter_IntegerDivision()
        {
            string equation = "3/2";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.Valid);
            Assert.That(output.outputNum == 1);
        }
        [Test]
        public void Interpreter_realDivision()
        {
            string equation = "3/2.0";
            var output = parse.Parse(equation);
            Assert.That(output.type == ReturnType.Valid);
            Assert.That(output.outputNum == 1.5);
        }

    }
}