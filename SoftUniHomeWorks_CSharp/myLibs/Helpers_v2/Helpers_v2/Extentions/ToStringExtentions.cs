namespace Helpers_v2.Extentions
{
    using System.Collections.Generic;
    using System.Text;

    public static class ToStringExtentions
    {
        /// <summary>
        /// Extension for arrays.
        /// Arrays's elements ToString with format: [$1, $2, $3, $4, $5] 
        /// </summary>
        /// <param name="delimiter">Delimiter between elements. Default = ','</param>
        public static string ElementsToString<T>(this T[] arr, string delimiter = ", ")
        {
            StringBuilder elementsToString = new StringBuilder();

            elementsToString.Append("[ ");
            for (int i = 0; i < arr.Length; i++)
            {
                elementsToString.Append(arr[i]);

                if (i != arr.Length - 1)
                {
                    elementsToString.Append(delimiter);
                }
            }

            elementsToString.Append(" ]");
            return elementsToString.ToString();
        }

        public static string ElementsToString<T>(this List<T> arr, string delimiter = ", ")
        {
            StringBuilder elementsToString = new StringBuilder();

            elementsToString.Append("[ ");
            for (int i = 0; i < arr.Count; i++)
            {
                elementsToString.Append(arr[i]);

                if (i != arr.Count - 1)
                {
                    elementsToString.Append(delimiter);
                }
            }

            elementsToString.Append(" ]");
            return elementsToString.ToString();
        }

        /// <summary>
        /// Extension for matrices.
        /// Arrays's elements ToString with format: [1, $2, $3, $4, $5] 
        /// </summary>
        /// <param name="delimiter">Delimiter between elements. Default = ','</param>
        public static string ElementsToString<T>(this T[,] arr, string delimiter = ", ")
        {
            StringBuilder elementsToString = new StringBuilder();

            elementsToString.Append("[ ");
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    elementsToString.Append(arr[row, col]);

                    if (row != arr.GetLength(0) - 1 || col != arr.GetLength(1) - 1)
                    {
                        elementsToString.Append(delimiter);
                    }
                }

                if (row != arr.GetLength(0) - 1)
                {
                    elementsToString.Append("\n");
                }
            }

            elementsToString.Append(" ]");
            return elementsToString.ToString();
        }

        /// <summary>
        /// Char array to string.
        /// </summary>
        public static string CharArrToString(this char[] charArr) 
        {
            return new string(charArr);
        }
    }
}
