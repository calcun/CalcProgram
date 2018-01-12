using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryOperator
{
    public delegate double OperatorDelegate(double num1, double num2);

    public abstract class BinaryOperator
    {
        public string Name { get; protected set; }
        public string Symbol { get; protected set; }

        public abstract double DoOperator(double arg1, double arg2);

        public virtual string CreateDescription(double arg1, double arg2)
        {
            return String.Format("{0}: {1} {2} {3} = {4}", this.Name,
                  arg1, this.Symbol, arg2, DoOperator(arg1, arg2));
        }
    }

    public class DelegatedOperator : BinaryOperator
    {
        private OperatorDelegate _delegate;
        public DelegatedOperator(String name, string symbol, OperatorDelegate del)
        {
            this.Name = name;
            this.Symbol = symbol;
            this._delegate = del;
        }

        public override double DoOperator(double arg1, double arg2)
        {
            return _delegate(arg1, arg2);
        }
    }

    // Implement AdditionOperator
    //public class AdditionOperator : BinaryOperator
    //{
    //    public AdditionOperator()
    //    {
    //        this.Name = "Add";
    //        this.Symbol = "+";
    //    }

    //    public override double DoOperator(double arg1, double arg2)
    //    {
    //        return arg1 + arg2;
    //    }
    //}

    public class SubtractOperator : BinaryOperator
    {
        public SubtractOperator()
        {
            this.Name = "Sub";
            this.Symbol = "-";
        }

        public override double DoOperator(double arg1, double arg2)
        {
            return arg1 - arg2;
        }
    }

    public class MultiplyOperator : BinaryOperator
    {
        public MultiplyOperator()
        {
            this.Name = "Mul";
            this.Symbol = "*";
        }

        public override double DoOperator(double arg1, double arg2)
        {
            return arg1 * arg2;
        }
    }

    public class DivisionOperator : BinaryOperator
    {
        public DivisionOperator()
        {
            this.Name = "Div";
            this.Symbol = "/";
        }

        public override double DoOperator(double arg1, double arg2)
        {
            return arg1 / arg2;
        }

        public override string CreateDescription(double arg1, double arg2)
        {
            if (arg2 == 0)
            {
                return String.Format("{0}: {1} {2} {3} = {4}", this.Name,
                   arg1, this.Symbol, arg2, "DIV BY ZERO ERROR!");
            }
            else
                return base.CreateDescription(arg1, arg2);
        }
    }
}
