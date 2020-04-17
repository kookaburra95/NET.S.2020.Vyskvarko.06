using System;

namespace JaggedArrayTask
{
    public static class JaggedArray
    {
        /// <summary>
        /// Bubble sorting of jagged array.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        /// <returns>Sorted array.</returns>
        private static int[][] BubbleSort(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i <= array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    for (int k = 0; k < array[j].Length - 1; k++)
                    {
                        if (array[j][k] > array[j][k + 1])
                        {
                            Swap<int>(ref array[j][k], ref array[j][k + 1]);
                        }
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// Swaps items.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="firstItem">First item.</param>
        /// <param name="secondItem">Second item.</param>
        private static void Swap<T>(ref T firstItem, ref T secondItem)
        {
            var temp = firstItem;
            firstItem = secondItem;
            secondItem = temp;
        }

        /// <summary>
        /// Finds the sum of the elements in an array.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <returns>The sum of the elements of the array.</returns>
        private static int Sum(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            var sum = 0;
            foreach (var i in array)
            {
                try
                {
                    checked
                    {
                        sum += i;
                    }
                }
                catch
                {
                    throw new OverflowException();
                }
            }

            return sum;
        }

        /// <summary>
        /// Finds the maximal element in the array.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <returns>The maximal element in the array.</returns>
        private static int Max(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            int maxElement = Int32.MinValue;

            foreach (var i in array)
            {
                if (i > maxElement)
                {
                    maxElement = i;
                }
            }

            return maxElement;
        }

        /// <summary>
        /// Finds the minimal element in the array.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <returns>The minimal element in the array.</returns>
        private static int Min(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            int minElement = Int32.MaxValue;

            foreach (var i in array)
            {
                if (i < minElement)
                {
                    minElement = i;
                }
            }

            return minElement;
        }

        /// <summary>
        /// Sorting by the sum of the elements of the matrix rows.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="typeSort">Sort type, true - increase, false - decrease.</param>
        /// <returns></returns>
        private static int[][] BubbleSortSum(int[][] array, bool typeSort)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            var resultArray = BubbleSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (typeSort)
                    {
                        if (Sum(array[i]) > Sum(array[j]))
                        {
                            Swap(ref array[i], ref array[j]);
                        }
                    }
                    else
                    {
                        if (Sum(array[i]) < Sum(array[j]))
                        {
                            Swap(ref array[i], ref array[j]);
                        }
                    }
                }
            }

            return resultArray;
        }

        /// <summary>
        /// Sorting in increasing order of the sum of the elements of the matrix rows.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <returns>Sorted array.</returns>
        public static int[][] BubbleSortSumInc(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            return BubbleSortSum(array, true);
        }

        /// <summary>
        /// Sorting in decreasing order of the sum of the elements of the matrix rows.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <returns>Sorted array.</returns>
        public static int[][] BubbleSortSumDec(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            return BubbleSortSum(array, false);
        }

        /// <summary>
        /// Sorting by the maximal element of the matrix rows.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="typeSort">Sort type, true - increase, false - decrease.</param>
        /// <returns>Sorted array.</returns>
        private static int[][] BubbleSortMax(int[][] array, bool typeSort)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            var resultArray = BubbleSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (typeSort)
                    {
                        if (Max(array[i]) > Max(array[j]))
                        {
                            Swap(ref array[i], ref array[j]);
                        }
                    }
                    else
                    {
                        if (Max(array[i]) < Max(array[j]))
                        {
                            Swap(ref array[i], ref array[j]);
                        }
                    }
                }
            }

            return resultArray;
        }

        /// <summary>
        /// Sorting in increasing order of maximal elements of matrix rows.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <returns>Sorted array.</returns>
        public static int[][] BubbleSortMaxInc(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            return BubbleSortMax(array, true);
        }

        /// <summary>
        /// Sorting in decreasing order of the maximum elements of the matrix rows.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <returns>Sorted array.</returns>
        public static int[][] BubbleSortMaxDec(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            return BubbleSortMax(array, false);
        }

        /// <summary>
        /// Sort by the minimal element of the matrix rows.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="typeSort">Sort type, true - increase, false - decrease.</param>
        /// <returns>Sorted array.</returns>
        private static int[][] BubbleSortMin(int[][] array, bool typeSort)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            var resultArray = BubbleSort(array);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (typeSort)
                    {
                        if (Min(array[i]) > Min(array[j]))
                        {
                            Swap(ref array[i], ref array[j]);
                        }
                    }
                    else
                    {
                        if (Min(array[i]) < Min(array[j]))
                        {
                            Swap(ref array[i], ref array[j]);
                        }
                    }
                }
            }

            return resultArray;
        }

        /// <summary>
        /// Sorting in increasing order of minimal elements of matrix rows.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <returns>Sorted array.</returns>
        public static int[][] BubbleSortMinInc(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            return BubbleSortMin(array, true);
        }

        /// <summary>
        /// Sorting in decreasing order of the maximum elements of the matrix rows.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <returns>Sorted array.</returns>
        public static int[][] BubbleSortMinDec(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            return BubbleSortMin(array, false);
        }
    }
}
