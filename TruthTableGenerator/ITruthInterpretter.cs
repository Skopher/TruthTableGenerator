using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthTableGenerator
{
    public interface ITruthInterpretter
    {
        bool Interpret(string expression);
    }
}
