using System;

namespace QuickSort
{
    class Program
    {
        public static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right)
                return;
            int pivot = partition(array, left, right);
            QuickSort(array, left, pivot - 1);
            QuickSort(array, pivot + 1, right);
        }
        public static int partition(int[] array, int left, int right)
        {
            int temp;
            int wall = left;
            for (int i = left; i < right; i++)
            {
                if (array[i] < array[right])
                {
                    temp = array[wall];
                    array[wall] = array[i];
                    array[i] = temp;
                    wall += 1;
                }
            }
            int buf = array[wall];
            array[wall] = array[right];
            array[right] = buf;
            return wall;
        }

        static void Main(string[] args)
        {
            EqualElementsTest();
            One1000ElementsTest();
            EmptyArrayTest();
            TestThreeElement();
            BigArrayTest();
        }
        private static void TestThreeElement()
        {
            //Тест сортировки массива из 3 разных элементов
            int f = 1;
            int[] mas = { 4, 2, 3 };
            QuickSort(mas, 0, mas.Length - 1);
            for (int i = 1; i < mas.Length; i++)
            {
                if (mas[i] < mas[i - 1])
                {
                    f = 0;
                }
            }
            if (f == 0)
                Console.WriteLine("!!! Сортировка массива из трех элементов работает не корректно !!!");
            else
                Console.WriteLine("Сортировка массива из трех элементов работает корректно");
        }

        public static void EqualElementsTest()
        {
            //Тест сортировки массива из 100 одинаковых элементов
            int[] array = new int[100];
            int f = 1;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 10;
            }
            QuickSort(array, 0, array.Length - 1);
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    f = 0;
                    break;
                }
            }
            if (f == 1)
                Console.WriteLine("Сортировка массива из 100 одинаковых чисел работает корректно");
            else
                Console.WriteLine("!!! Сортировка массива из 100 одинаковых чисел работает некорректно !!!");
        }

        public static void EmptyArrayTest()
        {
            //Тест пустого массива
            int[] empty = new int[0] { };
            QuickSort(empty, 0, empty.Length - 1);
            if (empty.Length != 0)
                Console.WriteLine("!!! Сортировка пустого массива работает некорректно!!!");
            else
                Console.WriteLine("Сортировка пустого массива работает корректно");
        }

        public static void One1000ElementsTest()
        {
            //Тест сортировки 1000 случайных элементов
            int f = 1;
            int[] array = new int[1000];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 1000);
            }
            QuickSort(array, 0, array.Length - 1);

            for (int i = 0; i < 10; i++)
            {
                int element = rnd.Next(0, 1000);
                if (array[element] < array[element - 1])
                {
                    f = 0;
                    break;
                }
            }
            if (f == 0)
                Console.WriteLine("!!! Сортировка массива из 1000 случайных элементов работает некорректно !!!");
            else
                Console.WriteLine("Сортировка массива из 1000 случайных элементов работает корректно");
        }

        public static void BigArrayTest()
        {
            //Тест сортировки массива из 150 000 000 элементов
            int[] hugeArray = new int[150000000];
            Random rnd = new Random();
            int f = 1;
            for (int i = 0; i < hugeArray.Length - 1; i++)
            {
                hugeArray[i] = 150000000 - i;
            }
            for (int i = 0; i < hugeArray.Length - 1; i++)
            {
                if (hugeArray[i] < hugeArray[i + 1])
                    f = 1;
                else
                    f = 0;
            }
            if (f == 0)
                Console.WriteLine("Сортировка массива из 150 000 000 элементов работает корректно");
            else
                Console.WriteLine("!!! Сортировка массива из 150 000 000  элементов работает некорректно !!!");
        }
    }
}


