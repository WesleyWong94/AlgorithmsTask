using System;
using System.Collections.Generic;
using System.IO;



namespace Sort
{
    class InsertionSort
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>();
            StreamReader reader = new StreamReader(File.OpenRead(@"unsorted_numbers.csv"));

            while (!reader.EndOfStream)
            {
                myList.Add(Convert.ToInt32(reader.ReadLine()));
            }

            Console.WriteLine("Import Success");


            //PrintArray(myList);
            //Console.WriteLine("\nOriginal Unsorted Array Displayed");

            Console.ReadLine();

            InsertSort(myList);
            //PrintArray(myList);
            //Console.WriteLine("\nInsertion Sorted Array Displayed");

            Console.ReadLine();

            ShellSort(myList);
            //PrintArray(myList);
            // Console.WriteLine("\nShell Sorted Array Displayed");

            Console.ReadLine();
            int result;
            int[] keys = { 575154, 182339, 17132, 773788, 296934, 991395, 303270, 45231, 580, 629822 };

            //using for loop
            for (int i = 0; i < myList.Count; i++)
            {
                result = LinearSearch(myList, myList[i]);
                Console.WriteLine("\nLinear Search Results: " + result);
            }



            Console.ReadLine();

            //using advanced for loop aka foreach
            foreach (int key in keys)
            {
                result = BinarySearch(myList, key);
                Console.WriteLine("\nBinary Search Results: " + result);
            }
            //Console.WriteLine("\nBinary Search Results");


        }


        public static void InsertSort(List<int> arr)
        {
            int n = arr.Count;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }

        }

        static void PrintArray(List<int> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n; ++i)
            {
                Console.Write(arr[i] + "\t");
            }
        }
        public static void ShellSort(List<int> arr)
        {
            int n = arr.Count;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = arr[i];

                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                        arr[j] = arr[j - gap];

                    arr[j] = temp;
                }
            }
        }
        public static int LinearSearch(List<int> arr, int key)
        {
            int n = arr.Count;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] == key)
                    return key;
            }

            Console.WriteLine("\nLinear search key not found");
            return -1;
        }
        public static int BinarySearch(List<int> arr, int key)
        {
            int min = 0;
            int n = arr.Count;
            int max = n - 1;
            do
            {
                int mid = (min + max) / 2;
                if (key > arr[mid])
                    min = mid + 1;
                else
                    max = mid - 1;
                if (arr[mid] == key)
                    return key;
            } while (min <= max);

            Console.WriteLine("\nBinary search key not found");
            return -1;

        }
    }
}

