using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                CustomArray arrayA = CustomArray.FromConsole("Введите элементы массива A (через пробел):");
                CustomArray arrayB = CustomArray.FromConsole("Введите элементы массива B (через пробел):");


                int leftMinIndexB = arrayB.GetLeftmostMinimumIndex();
                CustomArray subArrayB = arrayB.GetSubarrayAfter(leftMinIndexB);

                Console.WriteLine("Введите индекс элемента массива A для формирования подмассива (индекс должен быть больше правого минимума):");
                string indexInput = Console.ReadLine();
                if (!int.TryParse(indexInput, out int givenIndex))
                {
                    throw new FormatException("Неверный формат числа для индекса.");
                }

                int rightMinIndexA = arrayA.GetRightmostMinimumIndex();
                if (givenIndex <= rightMinIndexA)
                {
                    throw new ArgumentException("Заданный индекс должен быть больше индекса правого минимального элемента массива A.");
                }

                CustomArray subArrayA = arrayA.GetSubarrayBetween(rightMinIndexA, givenIndex);


                int[] combinedElements = new int[subArrayB.Length + subArrayA.Length];
                Array.Copy(subArrayB.Elements, 0, combinedElements, 0, subArrayB.Length);
                Array.Copy(subArrayA.Elements, 0, combinedElements, subArrayB.Length, subArrayA.Length);
                CustomArray arrayC = new CustomArray(combinedElements);


                Console.WriteLine("Massiv A:");
                arrayA.PrintElements();

                Console.WriteLine("Massiv B:");
                arrayB.PrintElements();

                Console.WriteLine("Ready massiv C:");
                arrayC.PrintElements();


                int variant = 9;
                double result = FunctionCalculator.ComputeFunctionValue(arrayA, arrayB, arrayC, variant);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}