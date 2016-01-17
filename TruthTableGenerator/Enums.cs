using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthTableGenerator
{
    /// <summary>
    /// Enum for all token types "AND", "OR", etc. used for truth table evaluation.
    /// </summary>
    public enum TokenType
    {
        BOOL,   // Boolean values 
        AND,    // logical AND
        EOF     // end of file
    };
}
