namespace Helpers_v2
{
    using System;

    public static class CollectionManipulator
    {
        /// <summary>
        /// Swap function
        /// </summary>
        public static void Swap<T>(ref T firstValue, ref T secondValue)
        {
            T temp = firstValue;
            firstValue = secondValue;
            secondValue = temp;
        }

        /// <summary>
        /// Selection sort algorithm.
        /// </summary>
        public static void SelectionSort<T>(T[] arr) where T : IComparable
        {
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                int flag = i;
                T smallestElement = arr[i];
                for (int j = i; j < len; j++)
                {
                    if (smallestElement.CompareTo(arr[j]) == 1)
                    {
                        smallestElement = arr[j];
                        flag = j;
                    }
                }

                T temp = arr[i];
                arr[i] = arr[flag];
                arr[flag] = temp;
            }
        }

        /// <summary>
        /// Merge sort algorithm.
        /// </summary>
        public static void MergeSort<T>(T[] a) where T : IComparable
        {
            T[] b = new T[a.Length];
            MergeSplit(a, 0, a.Length, b);
        }

        public static void MergeSplit<T>(T[] a, int begin, int end, T[] b) 
            where T : IComparable
        {
            if (end - begin < 2)
                return;

            int middle = (begin + end) / 2;
            MergeSplit(a, 0, middle, b);
            MergeSplit(a, middle, end, b);
            Merge(a, begin,  middle, end, b);
            Array.Copy(b, begin, a, begin, end - begin);
        }

        public static void Merge<T>(T[] a, int begin, int middle, int end, T[] b) 
            where T : IComparable
        {
            int currBegin = begin;
            int currEnd = middle;
    
            // While there are elements in the left or right runs
            for (int j = begin; j < end; j++)
            {
                // If left run head exists and is <= existing right run head.
                if (currBegin < middle && (currEnd >= end || a[currBegin].CompareTo(a[currEnd]) <= 0))
                {
                    b[j] = a[currBegin];
                    currBegin++;
                } 
                else 
                {
                    b[j] = a[currEnd];
                    currEnd++;    
                }
            } 
        }

        /// <summary>
        /// Linear Search, returns the index of the element, and -1 if nothing is found.
        /// </summary>
        public static int LinearSearch<T>(T[] arr, T key) where T : IComparable
        {
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                if (key.CompareTo(arr[i]) == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
