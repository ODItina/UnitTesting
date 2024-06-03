using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.BasicConsoleTest.Core.Tests
{
    public class BasicConsoleTestRunnerTests
    {

        //Naming Convention - ClassName_MethodName_ExpectedResult
        public static void BasicConsoleTestRunnerTests_CheckIfInputIsZero_ReturnsString()
        {
            try
            {
                //Arrange - Go get variables, whatever you need (classes, functions, etc.)
                int num = 0;

                //Act - Execute the function you want to test
                BasicConsoleTestRunner testFunction = new BasicConsoleTestRunner();
                string result = testFunction.CheckIfInputIsZero(num);

                //Assert - Is whatever is returned what you were actually expecting?
                if (result == "Number is zero")
                {
                    Console.WriteLine("PASSED: BasicConsoleTestRunner.CheckIfInputIsZero_ReturnsString");
                }
                else
                {
                    Console.WriteLine("FAILED: BasicConsoleTestRunner.CheckIfInputIsZero_ReturnsString");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
