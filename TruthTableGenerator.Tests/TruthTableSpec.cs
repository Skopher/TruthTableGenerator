/*
Note to self:
a Statement is composed of statement variables (p, q, r) and logical connectives (AND, OR, NOT...)
that evaluates to either true or false.

At this version, the TruthTableGenerator will have the overall responsibility of taking a Boolean Function
with Boolean arguments (1 to n many) and generating a display of that function's truth table.

In my initial design, I visualize the flow as:
1) Get arguments from the function (so that they can be displayed). Raise error if 0 arguments.
2) Given the arguments, evaluate the function for all combination of arguments and store results (possibly
as a list of structs)
3) Take the arguments and results, and display them in truth-table form.

This may change, as I might write a parser to take a command-line statement (ex: "a -> b & b -> c")
instead of a C# function. I would like to also consider building this so that I can use the Truth
Table Generator like an annotation, decorating ANY function (ex: [GetTruthTable]SomeMethod(...) )
to get its truth table.

Sending for help:
http://stackoverflow.com/questions/34669795/c-defining-a-delegate-that-takes-n-boolean-args-to-extract-argument-names-lat
 
Update:
I was hoping the C# function analyzer would be fairly supported/straight-forward, but it is not. 
After some responses on StackOverflow, I've decided that focusing on building an interpretter would be more
beneficial in the long-run. I'll abandon the previous effort for now, as there will be plenty to learn
building an interpretter (tokenizer, lexer, etc.).
*/

/*
using System;
using NUnit.Framework;
using Moq;
using TruthTableGenerator;

namespace TruthTableGenerator.Tests
{
    [TestFixture]
    public class TruthTableSpec
    {
        public bool threeArgFunction(bool foo, bool bar, bool bird) { return false; }

        [Test]
        public void GivenBooleanFunctionWithThreeArgumentsStatementSnifferShouldExtractThreeArgumentNames()
        {
            // Setup
            IStatementSniffer functionSniffer = new CSharpFunctionSniffer(CSharpBoolDelegate threeArgFunction);

            // Action
            List<string> actualArgs = functionSniffer.GetVariables();

            // Assert
            Assert.AreEqual("foo", actualArgs[0]);
            Assert.AreEqual("bar", actualArgs[1]);
            Assert.AreEqual("bird", actualArgs[2]);
        }
    }
}
*/