using System;
using System.Collections.Generic;

namespace SecretFunctionApp
{
    public class HelperClass : IHelperClass
    {
        /// <summary>
        /// Gets a list of prime numbers contain
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inclusiveIndicator">When true if value passed in as a is a prime number it will be returned in the list of prime numbers. False input value will not be contained in output list.</param>
        /// <returns></returns>
        public List<int> GetPrimeNumbers(int input, bool inclusiveIndicator = false)
        {
            List<int> primeNumbers = new List<int>();
            //get prime numbers
            if (inclusiveIndicator)
            {
                for (int i = 2; i <= input; i++)
                {
                    AddPrimeNumberToList(i, primeNumbers);
                }
            }
            else
            {
                for (int i = 2; i < input; i++)
                {
                    AddPrimeNumberToList(i, primeNumbers);
                }
            }

            return primeNumbers;
        }

        /// <summary>
        /// Adds value to a list if the value is a prime number
        /// </summary>
        /// <param name="i"></param>
        /// <param name="primeNumbers"></param>
        private void AddPrimeNumberToList(int i, List<int> primeNumbers)
        {
            if (i%2 == 0 && i != 2)
            {
                //not a prime number
            }
            else
            {
                var numbersLessThanI = 2;
                var isPrime = true;
                while (numbersLessThanI < i)
                {
                    if (i%numbersLessThanI == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    numbersLessThanI++;
                }

                if (isPrime)
                {
                    primeNumbers.Add(i);
                }
            }
        }

        /// <summary>
        /// Checks if a function is additive for all combinations of int values provided in numbers list
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="someFunc"></param>
        /// <returns></returns>
        public bool IsFuncAdditiveForAllInputs(List<int> numbers, Func<int, int> someFunc)
        {
            bool isAdditive = true;
            //Not using linq for readability 
            foreach (var currentNumberX in numbers)
            {
                foreach (var currentNumberY in numbers)
                {
                    isAdditive &= IsFunctionAdditive(someFunc, currentNumberX, currentNumberY);
                }   
            }
            return isAdditive;
        }

        /// <summary>
        /// Checks if a function is additive: someFunc(x + y) = someFunc(x) + someFunc(y) 
        /// </summary>
        /// <param name="someFunc"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsFunctionAdditive(Func<int, int> someFunc, int x, int y)
        {
            var isAdditive = someFunc(x + y) == someFunc(x) + someFunc(y);
            return isAdditive;
        }
    }

    public interface IHelperClass
    {
        List<int> GetPrimeNumbers(int input, bool inclusiveIndicator = false);
        bool IsFuncAdditiveForAllInputs(List<int> numbers, Func<int, int> someFunc);
        bool IsFunctionAdditive(Func<int, int> someFunc, int x, int y);
    }
}