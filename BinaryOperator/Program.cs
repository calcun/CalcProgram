using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            // CalcTester tester = new CalcTester();

            UserInput input = new UserInput();
            LiberalParser parser = new LiberalParser();
            // Example of creating a delegate and assigning it to a
            // local variable
            OperatorDelegate addFunc = delegate (double num1, double num2) {
                return num1 + num2;
            };

            Calculator calc = new Calculator(input, parser);

            // example of using local variable as the delegate function
            calc.Operators.Add(new DelegatedOperator("Add", "+", addFunc ));

            calc.Operators.Add(new SubtractOperator());
            calc.Operators.Add(new MultiplyOperator());
            calc.Operators.Add(new DivisionOperator());

            // Example of pointing a delegate to an existing function
            calc.Operators.Add(new DelegatedOperator("Mod","%",Modulus));

            // Example of passing in anonymous function as a delegate
            calc.Operators.Add(new DelegatedOperator("Pow", "^",
                     delegate(double num1, double num2) 
                     {
                         return Math.Pow(num1, num2);
                     }
               ) );

            calc.RunCalculator();
        }

        static double Modulus(double num1, double num2)
        {
            return num1 % num2;
        }

    }
}
