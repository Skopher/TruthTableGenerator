using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

/*
Not sure how I will put up rail diagrams for the syntax...I'll probably upload them 
separately as handwritten images/pdfs.

For now, the symbols are:

Symbol    | Meaning
  !       | NOT
  &       | AND
  |       | OR (capital or lowercase)
  @       | XOR 


*/

namespace TruthTableGenerator.Tests.Integration_Tests
{
    [TestFixture]
    class InterpretterSpec
    {
        [TestCase("1&1", ExpectedResult = true)]
        [TestCase("1&0", ExpectedResult = false)]
        [TestCase("0&1", ExpectedResult = false)]
        [TestCase("0&0", ExpectedResult = false)]
        public bool GivenANDexpressionsThenInterpretterShouldReturnCorrectANDInterpretation(string ANDexpression)
        {
            ITruthInterpretter interpretter = new SimpleTruthInterpretter(ANDexpression);

            bool result = interpretter.Interpret();

            return result;
        }

    }
}
