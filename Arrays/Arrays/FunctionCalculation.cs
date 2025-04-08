using System;
using System.Collections.Generic;

namespace Arrays
{
    public static class FunctionCalculator
    {
        public static int GetUniqueValue(CustomArray array, int startIndex, HashSet<int> existingValues)
        {
            int index = startIndex % array.Length;
            int attempts = 0;

            while (attempts < array.Length)
            {
                int value = array.GetElementAt(index);
                if (!existingValues.Contains(value))
                {
                    existingValues.Add(value);
                    return value;
                }
                index = (index + 1) % array.Length;
                attempts++;
            }

            throw new IndexOutOfRangeException("Unable to find a unique value.");
        }
        public static double ComputeFunctionValue(CustomArray arrayA, CustomArray arrayB, CustomArray arrayC, int variant)
        {
            HashSet<int> uniqueValues = new HashSet<int>();

            int a = GetUniqueValue(arrayA, variant, uniqueValues);
            int b = GetUniqueValue(arrayB, variant * 2, uniqueValues);
            int c = GetUniqueValue(arrayC, variant / 2, uniqueValues);

            double numerator = 2 * Math.Sin(a) + 3 * b * Math.Pow(Math.Cos(c), 3);
            double denominator = a + b;

            if (denominator == 0)
            {
                throw new DivideByZeroException("Division by zero.");
            }
            return numerator / denominator;
        }
    }
}
