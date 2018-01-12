using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryOperator
{
    class CalcTester : IUserInput, IParseInput
    {
        private string[] _tests;
        private int _currentTest;

        public CalcTester()
        {
            _currentTest = 0;
            _tests = new string[]
            {
                "23 + 4",
                "23 * 4",
                "23 / 4",
                "34 - 12",
                "123.34 + 234.54",
                "23 + 4",
                "23 * 4",
                "23 / 4",
                "34 - 12",
                "123.34 + 234.54",
                "23 + 4",
                "23 * 4",
                "23 / 4",
                "34 - 12",
                "123.34 + 234.54",
                "foo + bar"
            };
        }



        public string GetUserInput()
        {
            if (_currentTest < _tests.Length)
            {
                return _tests[_currentTest++];
            }
            return "quit";
        }

        public bool ParseUserInput(string input, out double num1, out string oper, out double num2)
        {
            string[] parts = input.Split(' ');

            num1 = 0;
            num2 = 0;
            oper = null;

            if (parts.Length != 3)
            {
                return false;
            }

            if (false == Double.TryParse(parts[0], out num1))
            {
                return false;
            }
            if (false == Double.TryParse(parts[2], out num2))
            {
                return false;
            }

            oper = parts[1];
            return true;
        }

    }
}
