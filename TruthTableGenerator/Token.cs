using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruthTableGenerator
{
    public class Token
    {
        private TokenType tokenType;
        private object tokenValue;

        /// <summary>
        /// Initializes a new Token object, which encapsulates the 
        /// token type and a value for that token.
        /// </summary>
        /// <param name="type">Token type (ex: Token.AND)</param>
        /// <param name="value">value of the Token (ex: "&")</param>
        public Token(TokenType type, object value)
        {
            this.tokenType = type;
            this.tokenValue = value;
        }

        public override string ToString()
        {
            return String.Format("Token of type '{0}', value '{1}'", this.tokenType.ToString(), this.tokenValue.ToString());
        }

        // Getters
        public TokenType getTokenType()
        {
            return this.tokenType;
        }

        public object getTokenValue()
        {
            return this.tokenValue; 
        }

    }
}
