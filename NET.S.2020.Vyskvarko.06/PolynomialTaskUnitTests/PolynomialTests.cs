using System;
using NUnit.Framework;
using PolynomialTask;

namespace PolynomialTaskUnitTests
{
    [TestFixture] 
    public class PolynomialTests
    {
        [Test]
        public void CtorEmptyExpectedException()
        {
            Assert.Throws<ArgumentException>(() => new Polynomial(Array.Empty<double>()));
        }
        [Test]
        public void CtorNullExpectedException()
        {
            Assert.Throws<ArgumentNullException>(() => new Polynomial(null));
        }

        [TestCase(new double[] { 2, 4, 5, 6, 8, 4, 2 },"2 + 4*x^1 + 5*x^2 + 6*x^3 + 8*x^4 + 4*x^5 + 2*x^6")]
        [TestCase(new double[] { 1, 4, 9, 5 }, "1 + 4*x^1 + 9*x^2 + 5*x^3")]
        [TestCase(new double[] { 0 }, "0")]
        public void ToStringVariousValueCheckThem(double[] coefficients, string expected)
        {
            Polynomial polynomial = new Polynomial(coefficients);
            string result = polynomial.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestCase(new double[] {1,2,3}, new double[] {1,2,3} , true)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 3, 2, 1 }, false)]
        public void GetHashCodeVariousValueCheckThem(double[] coefficientsFirst, double[] coefficientsSecond, bool expected)
        {
            Polynomial firstPolynomial = new Polynomial(coefficientsFirst);
            Polynomial secondPolynomial = new Polynomial(coefficientsSecond);

            bool result = firstPolynomial.GetHashCode() == secondPolynomial.GetHashCode();

            Assert.AreEqual(expected, result);
        }

        [TestCase(new double[] { 4, 7, 2 }, new double[] { 4, 7, 2 }, true)]
        [TestCase(new double[] { 1.8, 2, 3 }, new double[] { 3, 2.4, 1 }, false)]
        public void EqualVariousValueCheckThem(double[] coefficientsFirst, double[] coefficientsSecond, bool expected)
        {
            Polynomial firstPolynomial = new Polynomial(coefficientsFirst);
            Polynomial secondPolynomial = new Polynomial(coefficientsSecond);

            bool result = firstPolynomial.Equals(secondPolynomial);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, new double[] { 2, 4, 6 })]
        [TestCase(new double[] { -1, 5, 7, 2, 8, 9 }, new double[] { 1, 1, 1, 3 }, new double[] { 0, 6, 8, 5, 8, 9 })]
        [TestCase(new double[] { 10.9, -5.7, 6.3 }, new double[] { 1 }, new double[] { 11.9, -5.7, 6.3 })]
        public void AdditionOperationVariousValueCheckThem(double[] coefficientsFirst, double[] coefficientsSecond,
            double[] expected)
        {
            Polynomial firstPolynomial = new Polynomial(coefficientsFirst);
            Polynomial secondPolynomial = new Polynomial(coefficientsSecond);

            Polynomial thirdPolynomial = firstPolynomial + secondPolynomial;

            Assert.AreEqual(expected, thirdPolynomial.Coefficients);
        }

        [TestCase(new double[] { 3, 2, 1 }, new double[] { 1, 2, 3 }, new double[] { 2, 0, -2 })]
        [TestCase(new double[] { -1, 5, 7, 2, 8, 9 }, new double[] { 1, 1, 1, 3 }, new double[] { -2, 4, 6, -1, 8, 9 })]
        [TestCase(new double[] { 10.9, -5.7, 6.3 }, new double[] { 1 }, new double[] { 9.9, -5.7, 6.3 })]
        public void SubtractionOperationVariousValueCheckThem(double[] coefficientsFirst, double[] coefficientsSecond,
            double[] expected)
        {
            Polynomial firstPolynomial = new Polynomial(coefficientsFirst);
            Polynomial secondPolynomial = new Polynomial(coefficientsSecond);

            Polynomial thirdPolynomial = firstPolynomial - secondPolynomial;

            Assert.AreEqual(expected, thirdPolynomial.Coefficients);
        }

        [TestCase(new double[] { 3, 2, 1 }, new double[] { 1, 2, 3 }, new double[] { 3, 8, 14, 8, 3 })]
        [TestCase(new double[] { -1, 5, 7, 2, 8, 9 }, new double[] { 1, 1, 1, 3 }, new double[] { -1, 4, 11, 11, 32, 40, 23, 33, 27 })]
        public void MultiplicationOperationVariousValueCheckThem(double[] coefficientsFirst, double[] coefficientsSecond,
            double[] expected)
        {
            Polynomial firstPolynomial = new Polynomial(coefficientsFirst);
            Polynomial secondPolynomial = new Polynomial(coefficientsSecond);

            Polynomial thirdPolynomial = firstPolynomial * secondPolynomial;

            Assert.AreEqual(expected, thirdPolynomial.Coefficients);
        }

        [TestCase(new double[] {1,2,3}, new double[] {1,2,3}, true)]
        [TestCase(new double[] { 3, 2, 1 }, new double[] { 1, 2, 3 }, false)]
        public void Compare1OperationVariousValueCheckThem(double[] coefficientsFirst, double[] coefficientsSecond,
            bool expected)
        {
            Polynomial firstPolynomial = new Polynomial(coefficientsFirst);
            Polynomial secondPolynomial = new Polynomial(coefficientsSecond);

            bool result = firstPolynomial == secondPolynomial;

            Assert.AreEqual(expected, result);
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, false)]
        [TestCase(new double[] { 3, 2, 1 }, new double[] { 1, 2, 3 }, true)]
        public void Compare2OperationVariousValueCheckThem(double[] coefficientsFirst, double[] coefficientsSecond,
            bool expected)
        {
            Polynomial firstPolynomial = new Polynomial(coefficientsFirst);
            Polynomial secondPolynomial = new Polynomial(coefficientsSecond);

            bool result = firstPolynomial != secondPolynomial;

            Assert.AreEqual(expected, result);
        }
    }   
}   
