using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sorting
{
    class Tree
    {
        public Tree leftChild { get; set; } = null;
        public Tree rightChild { get; set; } = null;
        public int data { get; set; }
        public void push(int _data)
        {
            if(data <= _data)
            {
                if(rightChild == null)
                {
                    rightChild = new Tree(_data);
                }
                else
                {
                    rightChild.push(_data);
                }
            }
            else
            {
                if (leftChild == null)
                {
                    leftChild = new Tree(_data);
                }
                else
                {
                    leftChild.push(_data);
                }
            }
        }
        public Tree(int _data)
        {
            data = _data;
        }
        public void printNode()
        {
            //Console.Write("{0} ", data);
        }
        public void printTree(int[] arr, ref int index)
        {
            if(leftChild != null)
            {
                leftChild.printTree(arr, ref index);
            }
            printNode();
            arr[index++] = data;
            if(rightChild != null)
            {
                rightChild.printTree(arr, ref index);
            }
        }
    }
    class Sort
    {
        public static void printArr(int[] arr)
        {
            foreach(var i in arr)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
        public static void bubleSort(int[] arr)
        {   // Cmin = n^2/2 + n + 1/2 = O(n^2)      =>      Tmin(n) = n+1
            // Cmax = n^2*(3/2) + n + 3/2       =>      Tmax(n) = n^2/2+ n/2 + 1/2
            // C(n) = n^2 + n + 2 = O(n^2)      =>      ...
            bool wasSwapped = true;
            for (int i = 1; i < arr.Length && wasSwapped; ++i)
            {
                wasSwapped = false;
                for (int j = 0; j < arr.Length - i; ++j)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Sort.swap(ref arr[j], ref arr[j + 1]);
                        wasSwapped = true;
                    }
                }
            }
        }
        public static void insertionSort(int[] arr)
        {   // Cmin(n) = n^/2 + n + 1/2 = O(n^2)
            // Cmax(n) = n^2 + n/2 + 1/2 = O(n^2)
            // C(n) = (3/4)n^2 + (3/4)n + 1/2 = O(n^2)
            for (int i = 1; i < arr.Length; ++i)
            {
                int j = 0;
                int elementToMove = arr[i];
                for (; j < i; ++j)
                {
                    if (arr[i] < arr[j])
                    {
                        break;
                    }
                }
                for (; i > j; --i) // 0 or (n-1)*n/2
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
            for (int i = 0; i < arr.Length; ++i)
            {   // n
                int minElementIndex = i;
                for (int j = i; j < arr.Length; ++j)
                {   // n^2/2
                    if (arr[j] < arr[minElementIndex])
                    {
                        minElementIndex = j; //n
                    }
                }
                Sort.swap(ref arr[i], ref arr[minElementIndex]);
            }
        }
        public static void mergeSort(ref int[] arr)
        {
            arr = splitAndMerge(arr);
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
            for (int i = 0; i < lenght; ++i)
            {
                arr[i] = rnd.Next() % 20;
            }
            return arr;
        }
        private static void splitArray(int[] arr, out int[] first, out int[] second)
        {
            int fSize = arr.Length / 2;
            int sSize = arr.Length - (arr.Length / 2);
            first = new int[fSize];
            second = new int[sSize];
            for (int i = 0; i < fSize; ++i)
            {
                first[i] = arr[i];
            }
            for (int i = 0; i < sSize; ++i)
            {
                second[i] = arr[i + fSize];
            }
        }
        private static int[] mergeArray(int[] first, int[] second)
        {
            int[] result = new int[first.Length + second.Length];
            int fIndex = 0;
            int sIndex = 0;
            for (int i = 0; i < result.Length; ++i)
            {
                if (fIndex >= first.Length)
                {
                    result[i] = second[sIndex++];
                }
                else if (sIndex >= second.Length)
                {
                    result[i] = first[fIndex++];
                }
                else
                {
                    if (first[fIndex] < second[sIndex])
                    {
                        result[i] = first[fIndex++];
                    }
                    else
                    {
                        result[i] = second[sIndex++];
                    }
                }
            }
            return result;
        }
        private static int[] splitAndMerge(int[] arr)
        {
            int[] f;
            int[] s;
            splitArray(arr, out f, out s);
            if (f.Length > 1)
            {
                f = splitAndMerge(f);
            }
            if (s.Length > 1)
            {
                s = splitAndMerge(s);
            }
            return mergeArray(f, s);
        }
        public static void quickSort(ref int[] arr, int from, int to)
        {
            int left = from;
            int right = to - 1;
            int indexPivot = (from + to) / 2;
            int pivot = arr[indexPivot];
            while (left < right)
            {
                while (arr[left] <= pivot && left < indexPivot)
                {
                    ++left;
                }
                while (pivot <= arr[right] && indexPivot < right)
                {
                    --right;
                }
                if (left < right)
                {
                    if (left == indexPivot)
                    {
                        swap(ref arr[indexPivot], ref arr[indexPivot + 1]);
                        ++indexPivot;
                    }
                    else if (right == indexPivot)
                    {
                        swap(ref arr[indexPivot], ref arr[indexPivot - 1]);
                        --indexPivot;
                    }
                    if (left != indexPivot && right != indexPivot)
                    {
                        swap(ref arr[left], ref arr[right]);
                    }
                }
            }
            if (indexPivot - from > 1)
            {
                quickSort(ref arr, from, indexPivot);
            }
            if (to - indexPivot > 1)
            {
                quickSort(ref arr, indexPivot, to);
            }
        }
        public static void treeSort(int[] arr)
        {
            Tree sortTree = new Tree(arr[0]);
            for (int i = 1; i < arr.Length; ++i)
            {
                sortTree.push(arr[i]);
            }
            int index = 0;
            sortTree.printTree(arr, ref index);
        }
        public static void countingSort(int[] arr)
        {
            int[] counting = new int[getScatter(arr)+1];
            int offset = minElement(arr);
            foreach(var i in arr)
            {
                ++counting[i-offset];
            }
            Sort.printArr(counting);
            for (int i = 0; i < counting.Length-1;++i)
            {
                counting[i + 1] += counting[i];
            }
            int element = offset;
            int ind = 0;
            int quantity;
            do
            {
                quantity = counting[element-offset];
                int lastQuantity = 0;
                if(element > offset)
                {
                    lastQuantity = counting[element - 1 - offset];
                }
                for(int j=0;j<quantity-lastQuantity;++j)
                {
                    arr[ind++] = element;
                }
                ++element;
            }
            while (element-offset < counting.Length);

            //Sort.printArr(counting);
        }
        private static int maxElement(int[] arr)
        {
            int max = Int32.MinValue;
            foreach(var i in arr)
            {
                if(max < i)
                {
                    max = i;
                }
            }
            return max;
        }
        private static int minElement(int[] arr)
        {
            int min = Int32.MaxValue;
            foreach (var i in arr)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;
        }
        private static int getScatter(int[] arr)
        {
            return maxElement(arr) - minElement(arr);
        }
        public static bool testSortedArr(int[] arr)
        {
            for(int i=0;i<arr.Length-1; ++i)
            {
                if(arr[i+1] < arr[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static int discharge(int number, int i)
        {
            for(int j=0;j<i;++j)
            {
                number /= 10;
            }
            return number % 10;
        }
        public static void _radixSort(ref int[] arr, int maxDigitsCount, int digit = 0)
        {
            if (digit <= maxDigitsCount)
            {
                int[] radixCounting = new int[20]; //for each digit
                foreach (var i in arr)
                {
                    ++radixCounting[discharge(i, digit)+9];
                }
                for (int i = 0; i < radixCounting.Length - 1; ++i)
                {
                    radixCounting[i + 1] += radixCounting[i];
                }
                int[] tempArr = new int[arr.Length];
                for (int i = arr.Length - 1; i >= 0; --i)
                {
                    tempArr[--radixCounting[Sort.discharge(arr[i], digit)+9]] = arr[i];
                }
                arr = tempArr;
                _radixSort(ref arr, maxDigitsCount, digit + 1);
            }
        }
        public static void radixSort(ref int[] arr)
        {
            _radixSort(ref arr, Sort.getMaxDigits(arr));
        }
        private static int getMaxDigits(int[] arr)
        {
            int max = 1;
            foreach(int i in arr)
            {
                int currentCount = Sort.getDigitsCount(i);
                if(max < currentCount)
                {
                    max = currentCount;
                }
            }
            return max;
        }
        private static int getDigitsCount(int element)
        {
            int count = 0;
            do
            {
                element /= 10;
                ++count;
            }
            while (element != 0);
            return count;
        }
        public static void bucketSort(int[] arr)
        {
            int max = maxElement(arr);
            int[][] buckets = new int[arr.Length][];
            int[] deepBuckets = new int[arr.Length];
            foreach(int i in arr)
            {
                int a = i * arr.Length / (max + 1);
                if (deepBuckets[a] == 0)
                {
                    buckets[a] = new int[arr.Length];
                }
                buckets[a][deepBuckets[a]++] = i;
            }
            int index = 0;
            for(int i=0;i<arr.Length;++i)
            {
                if (deepBuckets[i] > 1)
                {
                    Array.Resize<int>(ref buckets[i], deepBuckets[i]);
                    radixSort(ref buckets[i]);
                }
                for (int j=0;j<deepBuckets[i]; ++j)
                {
                    arr[index++] = buckets[i][j];
                }
            }
        }
    }
    class Programm
    {
        static void Main(string[] args)
        {
            //int[] arr = { 6, 4, 3, 9 };
            int[] arr = Sort.getRandomArr(1000);
            Sort.bucketSort(arr);
            //Sort.printArr(arr);
            foreach (int i in arr)
            {
                Console.Write("{0} ", i);
            }
            Console.Write("\nTest passed: {0}", Sort.testSortedArr(arr));
            Console.ReadKey();
        }
    }
}