using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using JaggedArrayTask;

namespace JaggedArrayTaskUnitTests
{
    [TestFixture]
    class JaggedArrayTests
    {
        [Test]
        public void BubbleSortSumIncExpectedOverflowException()
        {
            int[][] jaggedArray = new int[][]
            {
                new []{1,2,3},
                new int[]{3,2,1},
                new int[]{Int32.MaxValue, int.MaxValue} 
            };

            Assert.Throws<OverflowException>(() => JaggedArray.BubbleSortSumInc(jaggedArray));
        }

        [Test]
        public void BubbleSortSumDecExpectedOverflowException()
        {
            int[][] jaggedArray = new int[][]
            {
                new []{1,2,3},
                new int[]{3,2,1},
                new int[]{Int32.MaxValue, int.MaxValue}
            };

            Assert.Throws<OverflowException>(() => JaggedArray.BubbleSortSumDec(jaggedArray));
        }

        [Test]
        public void BubbleSortSumIncExpectedSortedArray()
        {
            int[][] jaggedArray = new int[][]
            {
                new []{3,2,1},
                new []{4,3,2,1},
                new []{2,1}
            };

            int[][] result = new int[][]
            {
                new []{1,2,3,4},
                new []{1,2,3},
                new []{1,2}
            };

            JaggedArray.BubbleSortSumInc(jaggedArray);

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    Assert.AreEqual(result[i][j], jaggedArray[i][j]);
                }
            }
        }

        [Test]
        public void BubbleSortSumDecExpectedSortedArray()
        {
            int[][] jaggedArray = new int[][]
            {
                new []{3,2,1},
                new []{4,3,2,1},
                new []{2,1}
            };

            int[][] result = new int[][]
            {
                new []{1,2},
                new []{1,2,3},
                new []{1,2,3,4}
            };

            JaggedArray.BubbleSortSumDec(jaggedArray);

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    Assert.AreEqual(result[i][j], jaggedArray[i][j]);
                }
            }
        }

        [Test]
        public void BubbleSortMaxIncExpectedSortedArray()
        {
            int[][] jaggedArray = new int[][]
            {
                new []{5,2,3},
                new []{8,2,3,4},
                new []{20,2}
            };

            int[][] result = new int[][]
            {
                new []{2,20},
                new []{2,3,4,8},
                new []{2,3,5}
            };

            JaggedArray.BubbleSortMaxInc(jaggedArray);

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    Assert.AreEqual(result[i][j], jaggedArray[i][j]);
                }
            }
        }

        [Test]
        public void BubbleSortMaxDecExpectedSortedArray()
        {
            int[][] jaggedArray = new int[][]
            {
                new []{5,2,3},
                new []{8,2,3,4},
                new []{20,2}
            };

            int[][] result = new int[][]
            {
                new []{2,3,5},
                new []{2,3,4,8},
                new []{2,20}
            };

            JaggedArray.BubbleSortMaxDec(jaggedArray);

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    Assert.AreEqual(result[i][j], jaggedArray[i][j]);
                }
            }
        }

        [Test]
        public void BubbleSortMinIncExpectedSortedArray()
        {
            int[][] jaggedArray = new int[][]
            {
                new []{5,1,3},
                new []{8,2,3,4},
                new []{20,6}
            };

            int[][] result = new int[][]
            {
                new []{6,20},
                new []{2,3,4,8},
                new []{1,3,5}
            };

            JaggedArray.BubbleSortMinInc(jaggedArray);

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    Assert.AreEqual(result[i][j], jaggedArray[i][j]);
                }
            }
        }

        [Test]
        public void BubbleSortMinDecExpectedSortedArray()
        {
            int[][] jaggedArray = new int[][]
            {
                new []{5,1,3},
                new []{8,2,3,4},
                new []{20,6}
            };

            int[][] result = new int[][]
            {
                new []{1,3,5},
                new []{2,3,4,8},
                new []{6,20}
            };

            JaggedArray.BubbleSortMinDec(jaggedArray);

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    Assert.AreEqual(result[i][j], jaggedArray[i][j]);
                }
            }
        }

        [Test]
        public void BubbleSortSumIncNullExpectedException()
        {
            int[][] jaggedArray = null;
            Assert.Throws<ArgumentNullException>(() => JaggedArray.BubbleSortSumInc(jaggedArray));
        }

        [Test]
        public void BubbleSortSumDecNullExpectedException()
        {
            int[][] jaggedArray = null;
            Assert.Throws<ArgumentNullException>(() => JaggedArray.BubbleSortSumDec(jaggedArray));
        }

        [Test]
        public void BubbleSortMaxIncNullExpectedException()
        {
            int[][] jaggedArray = null;
            Assert.Throws<ArgumentNullException>(() => JaggedArray.BubbleSortMaxInc(jaggedArray));
        }

        [Test]
        public void BubbleSortMaxDecNullExpectedException()
        {
            int[][] jaggedArray = null;
            Assert.Throws<ArgumentNullException>(() => JaggedArray.BubbleSortMaxDec(jaggedArray));
        }

        [Test]
        public void BubbleSortMinIncNullExpectedException()
        {
            int[][] jaggedArray = null;
            Assert.Throws<ArgumentNullException>(() => JaggedArray.BubbleSortMinInc(jaggedArray));
        }

        [Test]
        public void BubbleSortMinDecNullExpectedException()
        {
            int[][] jaggedArray = null;
            Assert.Throws<ArgumentNullException>(() => JaggedArray.BubbleSortMinDec(jaggedArray));
        }
    }
}
