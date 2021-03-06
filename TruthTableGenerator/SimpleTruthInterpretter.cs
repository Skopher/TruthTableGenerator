﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// Lexical analyzer; breaks expression (sentence) apart one token at a time.
        /// TODO: Violates Single Responsibility. Break apart later.
        /// </summary>
        private Token getNextToken()
        {
            string text = this.expression;
            char currentChar = '\0'; // initialize to NULL
            Token token = null;

            // If the current position is greater than the
            // size of the expression, return an EOF token.
            // Otherwise, set to character in the current 
            // position of the expression
            if (this.currentPosition > text.Length-1)
            {
                Console.WriteLine("Reached end of expression.");
                return new Token(TokenType.EOF, null);
            }
            else
            {
                currentChar = text[this.currentPosition];
            }

            if ( currentChar == '1' || currentChar == '0' )
            {
                Console.WriteLine(String.Format("Character '{0}' is a boolean.", currentChar));
                token = new Token(TokenType.BOOL, currentChar);
                this.currentPosition++;
                return token;
            }
            
            if(currentChar == '&')
            {
                Console.WriteLine(String.Format("Character '{0}' is logical operator AND.", currentChar));
                token = new Token(TokenType.AND, currentChar);
                this.currentPosition++;
                return token;
            }

            throw new Exception("Could not recognize the character" + currentChar.ToString());
           
        }

        /// <summary>
        /// Compare the current token with the passed-in tokenType and
        /// if they match "eat" the current token and get the next token.
        /// Otherwise, throw an error.
        /// </summary>
        /// <param name="tokenType"></param>
        private void eat(TokenType expectedTokenType)
        {
            TokenType actualTokenType = this.currentToken.getTokenType();
            Console.WriteLine(String.Format("Expecting token {0}, finding actul token {1}", expectedTokenType, actualTokenType));
            if ( actualTokenType == expectedTokenType) 
            {
                this.currentToken = this.getNextToken();
            }
            else
            {
                throw new Exception(
                    String.Format("Error in Eat: current token {0} doesn't match expected token type {1}.", actualTokenType, expectedTokenType)
                );
            }
        }


        /// <summary>
        /// Interpret the boolean expression and return the result.
        /// </summary>
        /// <returns></returns>
        public bool Interpret()
        {
            // Set the current token
            this.currentToken = this.getNextToken();

            // Expect a boolean on the left
            Console.WriteLine("Interpretting left character");
            Token left = this.currentToken;
            this.eat(TokenType.BOOL);

            // Expect an "AND" operator as the next token
            Console.WriteLine("Interpretting middle character");
            Token oper = this.currentToken;
            this.eat(TokenType.AND);

            // Lastly, expect another boolean on the right
            Console.WriteLine("Interpretting right character");
            Token right = this.currentToken;
            this.eat(TokenType.BOOL);

            // Evaluate the sentence and return the result
            return ((bool)left.getTokenValue() && (bool)right.getTokenValue());
        }
    }
}
