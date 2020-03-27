namespace Helpers_v2
{
    using System;

    public static class SequenceGenerator
    {

        /// <summary>
        /// Generates numbers from 0 to N with given step and startNumber.
        /// If step = 3 --> 0, 3, 6, 9 ...
        /// IF step = -1 --> -1, -2, -3 ..
        /// </summary>
        public static int[] GenerateNumbers(int n, int step = 1, int startNumber = 1)
        {
            int[] generatedArr = new int[n];
            int len = generatedArr.Length;

            for (int i = 0; i < generatedArr.Length; i++)
            {
                generatedArr[i] = i * step + startNumber;
            }
            
            return generatedArr;
        }

        /// <summary>
        /// Generates a random arr of integers.
        /// </summary>
        public static int[] GenerateRandomNumberArr(int n, int min = Int32.MinValue, int max = Int32.MaxValue - 1)
        {
            if (n < 0)
            {
                throw new ArgumentException("N can't be negative.");
            }

            if (min < 0 && min > max && max < 0)
            {
                throw new ArgumentException("Incorrect min/max parameter.");
            }

            int[] rndArr = new int[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                rndArr[i] = rnd.Next(min, max + 1);
            }

            return rndArr;
        }

        /// <summary>
        /// Fib sequence.
        /// </summary>
        public static long[] GenerateFibonacciNumberArr(int n)
        {
            if (n <= 1)
            {
                throw new ArgumentException("N must be bigger than one.");
            }

            if (n > 93)
            {
                throw new ArgumentException("N is to big and overflows the 64 bit long variable.");
            }

            long[] fibSequence = new long[n];
            fibSequence[0] = 0;
            fibSequence[1] = 1;

            for (int i = 1; i < n - 1; i++)
            {
                long currNumber = fibSequence[i - 1] + fibSequence[i];
                fibSequence[i + 1] = currNumber;
            }

            return fibSequence;
        }
    }
}
