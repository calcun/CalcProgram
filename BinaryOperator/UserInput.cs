using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryOperator
{
    public class UserInput : IUserInput
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}
