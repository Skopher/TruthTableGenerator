using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthTableGenerator
{
    public class Token
    {
        private Token dataType;
        private object dataValue;

        /// <summary>
        /// Initializes a new Token object, which encapsulates the 
        /// token type and a value for that token.
        /// </summary>
        /// <param name="type">Token type (ex: Token.AND)</param>
        /// <param name="value">value of the Token (ex: "&")</param>
        public Token(Token type, object value)
        {
            this.dataType = type;
            this.dataValue = value;
        }

        public override string ToString()
        {
            return String.Format("Token of type '{0}', value '{1}'", this.dataType.ToString(), this.dataValue.ToString());
        }


    }
}
