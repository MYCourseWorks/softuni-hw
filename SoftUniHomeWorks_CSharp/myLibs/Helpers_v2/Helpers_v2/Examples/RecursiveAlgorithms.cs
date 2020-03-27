namespace Helpers_v2.Examples
{
    public static class RecursiveAlgorithms
    {
        /// <summary>
        /// Much slower than the iterative one.
        /// Used just for example.
        /// </summary>
        public static void RecursiveReverse<T>(T[] arr, int i) 
        {
            if (i / 2 <= 0)
            {
                return;
            }

            CollectionManipulator.Swap(ref arr[i], ref arr[arr.Length - i - 1]);
            RecursiveReverse(arr, i - 1);
        }

        /// <summary>
        /// Much slower than the iterative one.
        /// Used just for example.
        /// </summary>
        public static int Fib_R(int n)
        {
            if (n < 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }

            return Fib_R(n - 1) + Fib_R(n - 2);
        }

        /// <summary>
        /// Much slower than the iterative one.
        /// Used just for example.
        /// </summary>
        public static int Sum(int[] arr, int start = 0, int end = 0)
        {
            if (end - 1 - start < 0 || start < 0 || end - 1 > arr.Length)
            {
                return 0;
            }
            else if (end - 1 - start == 0)
            {
                return arr[start]; // When we have odd length add the middle variable.
            }
            
            return Sum(arr, start + 1, end - 1) + arr[start] + arr[end - 1];
        }

        /// <summary>
        /// Much slower than the iterative one.
        /// Used just for example.
        /// </summary>
        public static int LinearRecursiveSearch<T>(T[] arr, T key, int i = 0) 
        {
            if (i >= arr.Length)
            {
                return -1;
            }

            if (arr[i].Equals(key))
            {
                return i;
            }

            return LinearRecursiveSearch(arr, key, i + 1);
        }

        /// <summary>
        /// Much slower than the iterative one.
        /// Used just for example.
        /// </summary>
        public static void RecursiveSelectionSort(int[] arr, int j = 0, int i = 0)
        {
            if (j >= arr.Length)
            {
                i++;
                j = i;

                if (i >= arr.Length)
                {
                    return;
                }
            }
            else if (j != i)
            {
                if (arr[i] > arr[j])
                {
                    int temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
            }

            RecursiveSelectionSort(arr, j + 1, i);
        }
    }
}
