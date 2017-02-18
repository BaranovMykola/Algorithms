﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Sort
    {
        public static void bubleSort(int[] arr)
        {   // Cmin = n^2/2 + n + 1/2 = O(n^2)
            // Cmax = n^2*(3/2) + n + 3/2
            // C(n) = n^2 + n + 2 = O(n^2)
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
        }
        public static void insertionSort(int[] arr)
        {   // Cmin(n) = n^/2 + n + 1/2 = O(n^2)
            // Cmax(n) = n^2 + n/2 + 1/2 = O(n^2)
            // C(n) = (3/4)n^2 + (3/4)n + 1/2 = O(n^2)
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
                for(;i>j;--i) // 0 or (n-1)*n/2
                {
                    arr[i] = arr[i - 1];
                }
                arr[j] = elementToMove;
            }
        }
        public static void selectionSort(int[] arr)
        {   //Cmin(n) = n^2/2 + n = O(n^2)
            //Cmax(n) = (3/2)n^2 + n = O(n^2)
            //C(n) = 2n^2 + n
            for(int i=0;i<arr.Length;++i)
            {   // n
                int minElementIndex = i;
                for(int j = i;j<arr.Length;++j)
                {   // n^2/2
                    if(arr[j] < arr[minElementIndex])
                    {
                        minElementIndex = j; //n
                    }
                }
                Sort.swap(ref arr[i], ref arr[minElementIndex]);
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
            int[] arr = { 1, 4, 3, 2 };
            int[] arr = Sort.getRandomArr(1000);
            Sort.selectionSort(arr);
            foreach (int i in arr)
            {
                Console.Write("{0} ", i);
            }
            Console.ReadKey();
        }
    }
}