using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int[] array;
            int N = (int)(20 + 0.6 * 21);

            //заповнення масиву випадковими числами
            array = GenerateRandomArray(N, 10, 100);
            Console.WriteLine("Початковий масив розміру {0}:", N);
            PrintArray(array);

            //сортування масиву за методом вставки
            InsertionSort(array);
            
            //виведення відсортованого масиву
            Console.WriteLine("Відсортований масив:");
            PrintArray(array);

            Console.WriteLine("Введіть ключове значення: ");
            int key = int.Parse(Console.ReadLine());

            int binary = CountOccurrences(array, key);
            Console.WriteLine("Бінарний пошук. Кількість входжень значення {0} в масиві: {1}", key, binary);

            int sequential = SequentialSearch(array, key);
            Console.WriteLine("Послідовний пошук. Кількість входжень значення {0} в масиві: {1}", key, sequential);

            Console.ReadLine();
        }

        //метод для генерації масиву з випадковими числами
        static int[] GenerateRandomArray(int size, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }
            return array;
        }
        //сортування вставками
        static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }
        //виведення масиву на екран
        static void PrintArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
        //метод бінарного пошуку з використанням циклу
        static int BinarySearch(int[] array, int searchedValue, int left, int right)
        {
            // поки не зійшлись межі робочої зони масиву
            while (left <= right)
            {
                // індекс середнього елементу
                var middle = (left + right) / 2;

                if (searchedValue == array[middle])
                {
                    return middle;
                }
                else if (searchedValue < array[middle])
                {
                    // звуження робочої зони масиву справа
                    right = middle - 1;
                }
                else
                {
                    // звуження робочої зони масиву зліва
                    left = middle + 1;
                }
            }
            // нічого не знайдено
            return -1;
        }
        // метод для підрахунку кількості входжень ключового значення в масив.
        static int CountOccurrences(int[] array, int key)
        {
            int leftIndex = BinarySearch(array, key, 0, array.Length - 1);

            if (leftIndex == -1)
            {
                return 0; // ключове значення не знайдено
            }

            int count = 1;

            // підрахунок входжень зліва від знайденого індексу
            int left = leftIndex - 1;
            while (left >= 0 && array[left] == key)
            {
                count++;
                left--;
            }

            // підрахунок входжень справа від знайденого індексу
            int right = leftIndex + 1;
            while (right < array.Length && array[right] == key)
            {
                count++;
                right++;
            }

            return count;
        }
        //метод послідовного пошуку 
        static int SequentialSearch(int[] array, int key)
        {
            int count = 0;

            foreach (int num in array)
            {
                if (num == key)
                {
                    count++;
                }
            }

            return count;
        }
    }
    
}
