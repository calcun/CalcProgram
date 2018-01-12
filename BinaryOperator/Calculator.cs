using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryOperator
{
    public interface IUserInput
    {
        string GetUserInput();
    }

    public interface IParseInput
    {
        bool ParseUserInput(string input, out double num1, out string oper, out double num2);
    }

    public class Calculator
    {
        public ArrayList Operators = new ArrayList();

        private IUserInput _inputter;
        private IParseInput _parser;

        public Calculator(IUserInput inputter, IParseInput parser)
        {
            this._inputter = inputter;
            this._parser = parser;
        }

        private BinaryOperator FindOperator(string oper)
        { 
            BinaryOperator userOp = null;
            foreach (BinaryOperator op in this.Operators)
            {
                if (op.Symbol == oper)
                {
                    userOp = op;
                    break;
                }
            }

            return userOp;
        }


        public void RunCalculator()
        {
            string[] exitTerms = new string[] {"exit","quit","q","x" };

            while (true)
            {
                Console.Write("Enter Equation (or type exit): ");
                string input = _inputter.GetUserInput();

                if (exitTerms.Contains(input.ToLower()))
                {
                    return;
                }

                double num1, num2;
                string oper;

                if (false == _parser.ParseUserInput(input, out num1, out oper, out num2))
                {
                    Console.WriteLine("Invalid Input! Try Again...");
                    return;
                }

                BinaryOperator op = FindOperator(oper);
                if (op == null)
                {
                    Console.WriteLine("{0} is an invalid operator! Try Again...", oper);
                    return;
                }

                Console.WriteLine(op.CreateDescription(num1, num2));
            }

        }
    }
}
