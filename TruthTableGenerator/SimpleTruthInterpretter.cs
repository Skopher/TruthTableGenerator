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

        private string expression;
        private Token currentToken;
        private int currentPosition;
        
        /// <summary>
        /// Constructor for the simple truth interpretter. Sets the 
        /// expression passed in, but also internally sets the current Token
        /// to NULL and the current Position to zero.
        /// </summary>
        /// <param name="expr">String that represents a truth expression, such as "1&0".</param>
        public SimpleTruthInterpretter(string expr)
        {
            this.expression = expr;
            this.currentToken = null;
            this.currentPosition = 0;
        }

        /// <summary>
        /// Not 100% sure why the blog author created a method to raise an error. 
        /// Just copying exactly for now, maybe there will be a reason later...
        /// </summary>
        private void raiseError()
        {
            throw new Exception("Error parsing the expression");
        }

        /// <summary>
        /// Lexical analyzer; breaks expression (sentence) apart one token at a time.
        /// TODO: Violates Single Responsibility. Break apart later.
        /// </summary>
        private Token getNextToken()
        {
            string text = this.expression;
            char currentChar = '\0'; // initialize to NULL
            object actualChar = null;
            Token token = null;

            // If the current position is greater than the
            // size of the expression, return an EOF token.
            // Otherwise, set to character in the current 
            // position of the expression
            if (this.currentPosition > text.Length -1)
            {
                return new Token(TokenType.EOF, null);
            }
            else
            {
                currentChar = text[this.currentPosition];
            }

            // The below is a manual implementation of a syntax tree...?

            bool boolResult;
            if ( Boolean.TryParse(currentChar.ToString(), out boolResult) )
            {
                token = new Token(TokenType.BOOL, boolResult);
                this.currentPosition++;
                return token;
            }
            
            if(currentChar == '&')
            {
                token = new Token(TokenType.AND, currentChar);
                return token;
            }

            this.raiseError();
            return null;

        }

        /// <summary>
        /// Compare the current token with the passed-in tokenType and
        /// if they match "eat" the current token and get the next token.
        /// Otherwise, throw an error.
        /// </summary>
        /// <param name="tokenType"></param>
        private void eat(TokenType tokenType)
        {
            if( this.currentToken.getTokenType() == tokenType) 
            {
                this.currentToken = this.getNextToken();
            }
            else
            {
                this.raiseError();
            }
        }

        public bool Interpret(string expr)
        {
            return true;    
        }
    }
}
