using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using SecretFunctionApp;

namespace SecretFunction.Tests
{
    [TestFixture]
    public class Tests
    {
        public IHelperClass HelperClass { get; set; }

        private static readonly object[] _exclusivePrimeNumersTestCases =
        {
            new object[] { 3, 1, new List<int> { 2 } },
            new object[] { 30, 10, new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 } },
            new object[] { 71, 19, new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67 } },
            new object[] { 100, 25, new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 } }
        };

        private static readonly object[] _inclusivePrimeNumersTestCases =
        {
            new object[] { 5, 3, new List<int> { 2, 3, 5 } },
            new object[] { 53, 16, new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53 } },
            new object[] { 71, 20, new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71} },
            new object[] { 200, 46, new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199 } }
        };

        private static readonly object[] _isFunctionAdditiveTestCases =
        {
            new object[] {new List<int> {2, 3, 5}, false},
            new object[] {new List<int> {2, 3, 5, 48, 20}, true}
        };

        [SetUp]
        public void Setup()
        {
            HelperClass = new HelperClass();
        }

        [TestCaseSource("_exclusivePrimeNumersTestCases")]
        public void Exclusive_PrimeNumbers(int input, int expectedPrimeNumberCount, List<int> expectedPrimeNumebers)
        {
            //Act
            var primeNumbers = HelperClass.GetPrimeNumbers(input);
            //Assert
            primeNumbers.Count.Should().Be(expectedPrimeNumberCount);
            primeNumbers.Should().Equal(expectedPrimeNumebers);

        }

        [TestCaseSource("_inclusivePrimeNumersTestCases")]
        public void Inclusive_PrimeNumbers(int input, int expectedPrimeNumberCount, List<int> expectedPrimeNumebers)
        {
            //Act
            var primeNumbers = HelperClass.GetPrimeNumbers(input, true);
            //Assert
            primeNumbers.Count.Should().Be(expectedPrimeNumberCount);
            primeNumbers.Should().Equal(expectedPrimeNumebers);

        }

        [TestCaseSource("_isFunctionAdditiveTestCases")]
        public void IsFuncAdditiveForAllInputs(List<int> inputs, bool expectedVal)
        {
            //Setup
            Func<int,int> secretFunction;
            if (expectedVal)
            {
                secretFunction = AdditiveSecretFunction;
            }
            else
            {
                secretFunction = NotAdditiveSecretFunction;
            }

            //Act
            var isAdditive = HelperClass.IsFuncAdditiveForAllInputs(inputs, secretFunction);

            //Assert
            isAdditive.Should().Be(expectedVal);
        }


        //Returning 0 for all input combinations will ensure that the secret function is additive
        private static int AdditiveSecretFunction(int x)
        {
            return 0;
        }

        //Returning 1 will result in 1 = (1 + 1) resulting in a non additive function 
        private static int NotAdditiveSecretFunction(int x)
        {
            return 1;
        }
    }
}
