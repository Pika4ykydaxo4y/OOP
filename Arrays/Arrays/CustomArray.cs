using System;

namespace Arrays
{
    public class CustomArray
    {

        private int[] _elements;

        public CustomArray(int[] elements)
        {
            if (elements == null ||  elements.Length == 0)
            {
                throw new ArgumentException("Массив не может быть пустым.");
            }
            _elements = elements;
        }

        public int[] Elements => _elements;


        public void PrintElements()
        {
            Console.WriteLine(string.Join(" ", _elements));
        }


        public static CustomArray FromConsole(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Ввод не может быть пустым.");
            }

            string[] parts = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] arr = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out arr[i]))
                {
                    throw new FormatException("Exception.");
                }
            }
            return new CustomArray(arr);
        }


        public int GetElementAt(int index)
        {
            if (index < 0 ||  index >= _elements.Length)
            {
                throw new IndexOutOfRangeException("Индекс находится вне диапазона массива.");
            }
            return _elements[index];
        }


        public int Length => _elements.Length;


        public int GetLeftmostMinimumIndex()
        {
            int minIndex = 0;
            for (int i = 1; i < _elements.Length; i++)
            {
                if (_elements[i] < _elements[minIndex])
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }


        public int GetRightmostMinimumIndex()
        {
            int minIndex = _elements.Length - 1;
            for (int i = _elements.Length - 2; i >= 0; i--)
            {
                if (_elements[i] <= _elements[minIndex])
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }


        public CustomArray GetSubarrayAfter(int index)
        {
            if (index < 0 ||  index >= _elements.Length)
            {
                throw new ArgumentException("Неверный индекс для формирования подмассива.");
            }

            int newSize = _elements.Length - index - 1;
            if (newSize <= 0)
            {
                throw new InvalidOperationException("Нет элементов после указанного индекса.");
            }

            int[] subArray = new int[newSize];
            Array.Copy(_elements, index + 1, subArray, 0, newSize);
            return new CustomArray(subArray);
        }


        public CustomArray GetSubarrayBetween(int startIndex, int endIndex)
        {
            if (startIndex < 0 ||  endIndex >= _elements.Length || startIndex >= endIndex)
            {
                throw new ArgumentException("Некорректные индексы для формирования подмассива.");
            }

            int newSize = endIndex - startIndex - 1;
            if (newSize <= 0)
            {
                throw new InvalidOperationException("Нет элементов между указанными индексами.");
            }

            int[] subArray = new int[newSize];
            Array.Copy(_elements, startIndex + 1, subArray, 0, newSize);
            return new CustomArray(subArray);
        }
    }
}