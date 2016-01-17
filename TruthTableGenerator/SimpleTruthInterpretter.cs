using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthTableGenerator
{
    /// <summary>
    /// Interprets a boolean statement; expects actual values (not variables).
    /// Example: "1&1" is valid. "x&y" is not. 
    /// Following http://ruslanspivak.com/lsbasi-part1/. Will expand/refactor later...
    /// </summary>
    /// <param name="expression"></param>
    /// <returns>boolean</returns>
    public class SimpleTruthInterpretter : ITruthInterpretter
    {

        private Token currentToken;
        private int currentPosition;
        private string expression;

        public bool Interpret(string expr)
        {

            return true; 
        }
    }
}
