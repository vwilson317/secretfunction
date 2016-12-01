using System;
using System.Collections.Generic;

namespace SecretFunctionApp
{
    public interface IHelperClass
    {
        List<int> GetPrimeNumbers(int input, bool inclusiveIndicator = false);
        bool IsFuncAdditiveForAllInputs(List<int> numbers, Func<int, int> someFunc);
        bool IsFunctionAdditive(Func<int, int> someFunc, int x, int y);
    }
}