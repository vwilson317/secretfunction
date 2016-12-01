using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretFunctionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var shouldExit = false;
            while (!shouldExit)
            {
                Console.WriteLine("Input an Int");
                int? input = null;
                try
                {
                    input = Int16.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }

                if (input != null)
                {
                    var helperClass = new HelperClass();
                    var primeNumbersLessThanInput = helperClass.GetPrimeNumbers(input.Value);

                    Console.WriteLine(string.Join(", ", primeNumbersLessThanInput));

                    var isAdditive = helperClass.IsFuncAdditiveForAllInputs(primeNumbersLessThanInput, SecretFunction);
                    Console.WriteLine($"The {nameof(SecretFunction)} isAdditive equals: {isAdditive}");

                    Console.WriteLine("Press any key to enter another input. Enter [x] to exit program.");
                    shouldExit = Console.ReadLine() == "x";
                }
            }
        }

        public static int SecretFunction(int someNumber)
        {
            return someNumber;
        }
    }
}
