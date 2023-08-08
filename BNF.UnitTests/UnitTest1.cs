using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BNF.UnitTests
{
    [TestClass]
    public class Language
    {
        [TestMethod]
        public void AddSimple()
        {
            string input = "3+4";
            var parser = new Parser();
            var result = parser.Parse(input);
            result.
            Assert.IsNotNull(result);
        }

    }
}
