using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CustomArray arrayA = CustomArray.FromConsole("Enter elements for array A (space-separated):");
                CustomArray arrayB = CustomArray.FromConsole("Enter elements for array B (space-separated):");

                int leftMinIndexB = arrayB.GetLeftmostMinimumIndex();
                CustomArray subArrayB = arrayB.GetSubarrayAfter(leftMinIndexB);

                Console.WriteLine("Enter an index in array A to extract elements after rightmost minimum:");
                string indexInput = Console.ReadLine();

                if (!int.TryParse(indexInput, out int givenIndex))
                {
                    throw new FormatException("Invalid index format.");
                }

                int rightMinIndexA = arrayA.GetRightmostMinimumIndex();

                if (givenIndex <= rightMinIndexA)
                {
                    throw new ArgumentException("Index must be greater than the rightmost minimum index in array A.");
                }

                CustomArray subArrayA = arrayA.GetSubarrayBetween(rightMinIndexA, givenIndex);

                int[] combinedElements = new int[subArrayB.Length + subArrayA.Length];
                Array.Copy(subArrayB.Elements, 0, combinedElements, 0, subArrayB.Length);
                Array.Copy(subArrayA.Elements, 0, combinedElements, subArrayB.Length, subArrayA.Length);
                CustomArray arrayC = CustomArray.CreateSafe(combinedElements);

                Console.WriteLine("\nArray A:");
                Console.WriteLine(arrayA.ToFormattedString());

                Console.WriteLine("Array B:");
                Console.WriteLine(arrayB.ToFormattedString());

                Console.WriteLine("Combined Array C:");
                Console.WriteLine(arrayC.ToFormattedString());

                int variant = 9;
                double result = FunctionCalculator.ComputeFunctionValue(arrayA, arrayB, arrayC, variant);
                Console.WriteLine($"\nFunction result: {result:F4}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
