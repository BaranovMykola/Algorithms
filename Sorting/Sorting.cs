using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Sort
    {
        public static void bubleSort(int[] arr)
        {   // Cmin = n^2/2 + n + 1/2 = O(n^2) ?
            // Cmax = n^2*(3/2) + n + 3/2
            int q = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = 1; j < arr.Length-i; ++j)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        Sort.swap(ref arr[j], ref arr[j-1]);
                    }
                }
            }
            Console.WriteLine("{0} iterations", q);
        }
        public static void insertionSort(int[] arr)
        {
            for(int i=1;i<arr.Length;++i)
            {
                int j = 0;
                int elementToMove = arr[i];
                for (;j<i;++j)
                {
                    if(arr[i] < arr[j])
                    {
                        break;
                    }
                }
                for(int k = i;k>j;--k)
                {
                    arr[k] = arr[k - 1];
                }
                arr[j] = elementToMove;
            }
        }
        public static void swap(ref int left, ref int right)
        {
            int swapMemory = left;
            left = right;
            right = swapMemory;
        }
        public static int[] getRandomArr(int lenght)
        {
            int[] arr = new int[lenght];
            Random rnd = new Random();
            for(int i =0;i<lenght;++i)
            {
                arr[i] = rnd.Next()%20;
            }
            return arr;
        }
    }
    class Programm
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 3, 2, 1 };
            //int[] arr = Sort.getRandomArr(1000);
            Sort.insertionSort(arr);
            foreach (int i in arr)
            {
                Console.Write("{0} ", i);
            }
            Console.ReadKey();
        }
    }
}