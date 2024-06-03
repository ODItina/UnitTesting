using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.BasicConsoleTest.Core
{
    public  class BasicConsoleTestRunner
    {
        public string CheckIfInputIsZero(int num)
        {
            string returnValue = "Number is not zero";
            if (num == 0)
            {
                returnValue = "Number is zero";
            }
            return returnValue;
        }
    }
}
