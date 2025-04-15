using System;

namespace Arrays
{
    public class CustomArray
    {
        private int[] _elements;

        //Приватный конструктор
        private CustomArray(int[] elements)
        {
            _elements = elements;
        }
        //Проверка что массив не пустой
        public static CustomArray CreateSafe(int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }
            return new CustomArray(elements);
        }

        //Вводим с клавиатруы и проверяем, что массив не пустой
        public static CustomArray FromConsole(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be empty.");
            }

            //Разделяем ввод на пробелы/запятые
            //Enum здесь используется чтобы пропускать пустые строки
            string[] parts = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] arr = new int[parts.Length];

            //Преобразовываем строку в int.
            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out arr[i]))
                {
                    throw new FormatException("Format error: only integers are allowed.");
                }
            }

            return CreateSafe(arr);
        }

        //Массив в строку
        public string ToFormattedString()
        {
            return string.Join(" ", _elements);
        }
        //Ввывод в консоль
        public void PrintElements()
        {
            Console.WriteLine(ToFormattedString());
        }
        
        //Доступ чтобы читать 
        public int[] Elements => _elements;

        //Проверка индекса в пределах массива
        public int GetElementAt(int index)
        {
            if (index < 0 || index >= _elements.Length)
            {
                throw new IndexOutOfRangeException("Index is out of array bounds.");
            }
            return _elements[index];
        }

        public int Length => _elements.Length;

        //Находит первый левый индекс минимального элемента
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

        //Находит первый правый индекс минимального элемента
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
        //Создание подмассива после заданного индекса
        public CustomArray GetSubarrayAfter(int index)
        {
            if (index < 0 || index >= _elements.Length)
            {
                throw new ArgumentException("Invalid index for subarray creation.");
            }

            int newSize = _elements.Length - index - 1;
            if (newSize <= 0)
            {
                throw new InvalidOperationException("No elements after the specified index.");
            }

            int[] subArray = new int[newSize];
            Array.Copy(_elements, index + 1, subArray, 0, newSize);
            return new CustomArray(subArray);
        }
        //Создание подмассива между двумя индексами
        public CustomArray GetSubarrayBetween(int startIndex, int endIndex)
        {
            if (startIndex < 0 || endIndex >= _elements.Length || startIndex >= endIndex)
            {
                throw new ArgumentException("Invalid indices for subarray creation.");
            }

            int newSize = endIndex - startIndex - 1;
            if (newSize <= 0)
            {
                throw new InvalidOperationException("No elements between the specified indices.");
            }

            int[] subArray = new int[newSize];
            Array.Copy(_elements, startIndex + 1, subArray, 0, newSize);
            return new CustomArray(subArray);
        }
    }
}
