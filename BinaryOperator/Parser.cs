using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryOperator
{
    public class Parser : IParseInput
    {
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

    public class LiberalParser : IParseInput
    {
        public bool ParseUserInput(string input, out double num1, out string oper, out double num2)
        {
            string trimmed = input.Trim();

            num1 = 0;
            num2 = 0;
            oper = null;

            int start = 0;
            int end = 0;
            while (end < input.Length)
            {
                char ch = input[end];
                if (Char.IsDigit(ch) || ch == '.')
                    end++;
                else
                    break;
            }

            if (start == end)
                return false;

            if (false == Double.TryParse(input.Substring(start, end - start), out num1))
            {
                return false;
            }

            // Skip all spaces
            start = end;
            while (start < input.Length && Char.IsWhiteSpace(input[start]))
                start++;

            end = start;
            while (end < input.Length)
            {
                char ch = input[end];
                if (Char.IsWhiteSpace(ch) || Char.IsDigit(ch))
                    break;

                end++;
            }

            oper = input.Substring(start, end - start);

            // Skip all spaces again
            start = end;
            while (start < input.Length && Char.IsWhiteSpace(input[start]))
                start++;

            end = start;
            while (end < input.Length)
            {
                char ch = input[end];
                if (Char.IsDigit(ch) || ch == '.')
                    end++;
                else
                    break;
            }

            if (start == end)
                return false;

            if (false == Double.TryParse(input.Substring(start, end - start), out num2))
            {
                return false;
            }

            return true;
        }
    }

}
