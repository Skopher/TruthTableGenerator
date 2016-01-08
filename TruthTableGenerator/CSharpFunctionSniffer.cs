using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthTableGenerator
{
    public class CSharpFunctionSniffer: IStatementSniffer
    {
        private Func<bool> function;

        public CSharpFunctionSniffer(Func<bool> functionToSniff)
        {
            function = functionToSniff;
        }

        public List<string> GetVariables()
        {
            return null;
        }
    }
}
